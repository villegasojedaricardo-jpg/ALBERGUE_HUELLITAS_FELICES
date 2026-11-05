using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient; // O usa Microsoft.Data.SqlClient si es el que manejas

namespace ALBERGUE_HUELLITAS_FELICES
{
    public partial class Form1 : Form
    {
        private ReportViewer reportViewer1;

        public Form1()
        {
            InitializeComponent();

            this.reportViewer1 = new ReportViewer();
            this.reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.reportViewer1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Cargamos el reporte incrustado
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "ALBERGUE_HUELLITAS_FELICES.Report1.rdlc";

                // 2. Obtenemos los datos con tu conexión real
                DataTable dt = ObtenerDatosDonantes();

                // 3. Enlazamos los datos con el DataSet1 del reporte
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del reporte: " + ex.Message);
            }
        }

        private DataTable ObtenerDatosDonantes()
        {
            DataTable dt = new DataTable();

            // REEMPLAZA ESTA CADENA con la misma que usas en tus otros formularios (ej. Conexion.cs)
            // Si tu servidor local es SQLEXPRESS, normalmente es: "Server=.\\SQLEXPRESS;Database=Huellitas_Felices;Trusted_Connection=True;"
            string cadenaConexion = "Server=localhost;Database=Huellitas_Felices;Trusted_Connection=True;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // Asegúrate de que el nombre de la tabla y columnas coincidan con tu base de datos
                string query = "SELECT id_donante, nombre_completo FROM Donantes";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
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