using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Data.SqlClient;

namespace ALBERGUE_HUELLITAS_FELICES
{
    public partial class ReporteVacunas : Form
    {
        private ReportViewer reportViewer1; // Declaramos el visor por código de forma limpia
        private DateTimePicker dtDesde = new() { ShowCheckBox = true, Checked = false };
        private DateTimePicker dtHasta = new() { ShowCheckBox = true, Checked = false };
        private TextBox txtVacuna = new();
        private Label lblResumen = new();

        public ReporteVacunas()
        {
            InitializeComponent();

            // Inicializamos el ReportViewer y lo acoplamos para que ocupe todo el formulario
            this.reportViewer1 = new ReportViewer();
            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);

            var filtros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 72,
                Padding = new Padding(8),
                WrapContents = true,
                BackColor = Color.WhiteSmoke
            };

            dtDesde.Format = DateTimePickerFormat.Short;
            dtHasta.Format = DateTimePickerFormat.Short;
            txtVacuna.Width = 150;
            txtVacuna.PlaceholderText = "Tipo de vacuna";
            lblResumen.AutoSize = true;
            lblResumen.Margin = new Padding(15, 8, 8, 8);

            var consultar = new Button { Text = "Consultar", AutoSize = true };
            consultar.Click += (_, _) => CargarReporte();
            var limpiar = new Button { Text = "Limpiar", AutoSize = true };
            limpiar.Click += (_, _) =>
            {
                dtDesde.Checked = false;
                dtHasta.Checked = false;
                txtVacuna.Clear();
                CargarReporte();
            };

            filtros.Controls.Add(new Label { Text = "Desde:", AutoSize = true, Margin = new Padding(8, 8, 3, 8) });
            filtros.Controls.Add(dtDesde);
            filtros.Controls.Add(new Label { Text = "Hasta:", AutoSize = true, Margin = new Padding(8, 8, 3, 8) });
            filtros.Controls.Add(dtHasta);
            filtros.Controls.Add(new Label { Text = "Vacuna:", AutoSize = true, Margin = new Padding(8, 8, 3, 8) });
            filtros.Controls.Add(txtVacuna);
            filtros.Controls.Add(consultar);
            filtros.Controls.Add(limpiar);
            filtros.Controls.Add(lblResumen);
            this.Controls.Add(filtros);
        }

        private void ReporteVacunas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de vacunas: " + ex.Message);
            }
        }

        private void CargarReporte()
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "ALBERGUE_HUELLITAS_FELICES.Vacunaciones.rdlc";
                DataTable dt = ObtenerDatosVacunaciones();
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                this.reportViewer1.RefreshReport();

                lblResumen.Text = $"Aplicaciones registradas: {dt.Rows.Count}";
                if (dt.Rows.Count == 0)
                    MessageBox.Show("No existen vacunaciones para los filtros seleccionados.", "Reporte de vacunaciones",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el reporte de vacunaciones: " + ex.Message);
            }
        }

        private DataTable ObtenerDatosVacunaciones()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT a.id_aplicacion,
                                    a.fecha_aplicacion,
                                    a.id_mascota,
                                    m.nombre AS mascota,
                                    a.id_tipo_vacuna,
                                    t.nombre_vacuna AS vacuna
                             FROM dbo.aplicaciones_vacuna a
                             INNER JOIN dbo.mascotas m ON m.id_mascota = a.id_mascota
                             INNER JOIN dbo.tipos_vacuna t ON t.id_tipo_vacuna = a.id_tipo_vacuna
                             WHERE (@desde IS NULL OR a.fecha_aplicacion >= @desde)
                               AND (@hasta IS NULL OR a.fecha_aplicacion < DATEADD(day, 1, @hasta))
                               AND (@vacuna = '' OR t.nombre_vacuna LIKE '%' + @vacuna + '%')
                             ORDER BY a.fecha_aplicacion DESC";

            using (SqlConnection cn = Conexion.Obtener())
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime2).Value =
                        dtDesde.Checked ? dtDesde.Value.Date : DBNull.Value;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime2).Value =
                        dtHasta.Checked ? dtHasta.Value.Date : DBNull.Value;
                    cmd.Parameters.AddWithValue("@vacuna", txtVacuna.Text.Trim());
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}