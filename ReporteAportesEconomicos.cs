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
    public partial class ReporteAportesEconomicos : Form
    {
        private ReportViewer reportViewer1;
        private DateTimePicker dtDesde = new() { ShowCheckBox = true, Checked = false };
        private DateTimePicker dtHasta = new() { ShowCheckBox = true, Checked = false };
        private TextBox txtDonante = new();
        private Label lblResumen = new();

        public ReporteAportesEconomicos()
        {
            InitializeComponent();

            // Inicializamos el ReportViewer por código de forma limpia
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
            txtDonante.Width = 150;
            txtDonante.PlaceholderText = "Nombre del donante";
            lblResumen.AutoSize = true;
            lblResumen.Margin = new Padding(15, 8, 8, 8);

            var consultar = new Button { Text = "Consultar", AutoSize = true };
            consultar.Click += (_, _) => CargarReporte();
            var limpiar = new Button { Text = "Limpiar", AutoSize = true };
            limpiar.Click += (_, _) =>
            {
                dtDesde.Checked = false;
                dtHasta.Checked = false;
                txtDonante.Clear();
                CargarReporte();
            };

            filtros.Controls.Add(new Label { Text = "Desde:", AutoSize = true, Margin = new Padding(8, 8, 3, 8) });
            filtros.Controls.Add(dtDesde);
            filtros.Controls.Add(new Label { Text = "Hasta:", AutoSize = true, Margin = new Padding(8, 8, 3, 8) });
            filtros.Controls.Add(dtHasta);
            filtros.Controls.Add(new Label { Text = "Donante:", AutoSize = true, Margin = new Padding(8, 8, 3, 8) });
            filtros.Controls.Add(txtDonante);
            filtros.Controls.Add(consultar);
            filtros.Controls.Add(limpiar);
            filtros.Controls.Add(lblResumen);
            this.Controls.Add(filtros);
        }

        private void ReporteAportesEconomicos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de aportes económicos: " + ex.Message);
            }
        }

        // Método puente para evitar el error del diseñador
        private void ReporteAportesEconomicos_Load_1(object sender, EventArgs e)
        {
            ReporteAportesEconomicos_Load(sender, e);
        }

        private void CargarReporte()
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "ALBERGUE_HUELLITAS_FELICES.AportesEconomicos.rdlc";
                DataTable dt = ObtenerDatosAportes();
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
                this.reportViewer1.RefreshReport();

                decimal total = 0;
                foreach (DataRow fila in dt.Rows)
                    total += fila["monto"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["monto"]);
                lblResumen.Text = $"Registros: {dt.Rows.Count} | Total: {total:C2}";
                if (dt.Rows.Count == 0)
                    MessageBox.Show("No existen aportes para los filtros seleccionados.", "Reporte de aportes",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el reporte de aportes económicos: " + ex.Message);
            }
        }

        private DataTable ObtenerDatosAportes()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT ap.id_aporte, ap.monto, ap.fecha_aporte,
                                    ap.id_donante, d.nombre_completo
                             FROM dbo.aportes_economicos ap
                             INNER JOIN dbo.donantes d ON d.id_donante = ap.id_donante
                             WHERE (@desde IS NULL OR ap.fecha_aporte >= @desde)
                               AND (@hasta IS NULL OR ap.fecha_aporte < DATEADD(day, 1, @hasta))
                               AND (@donante = '' OR d.nombre_completo LIKE '%' + @donante + '%')
                             ORDER BY ap.fecha_aporte DESC";

            using (SqlConnection cn = Conexion.Obtener())
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime2).Value =
                        dtDesde.Checked ? dtDesde.Value.Date : DBNull.Value;
                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime2).Value =
                        dtHasta.Checked ? dtHasta.Value.Date : DBNull.Value;
                    cmd.Parameters.AddWithValue("@donante", txtDonante.Text.Trim());
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