using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion
{
    public partial class frmReporteAdmin : Form
    {
        private CN_ReporteAdmin reportes = new CN_ReporteAdmin();
        public frmReporteAdmin()
        {
            InitializeComponent();
        }

        private void frmReporteAdmin_Load(object sender, EventArgs e)
        {
            CargarUltimoBackup();
            CargarUsuariosActivosInactivos();
            CargarUsuariosPorRol();
            VerificarAlertaBackup();
        }

        // --- ÚLTIMO BACKUP ---
        private void CargarUltimoBackup()
        {
            DataTable dt = reportes.ObtenerUltimoBackup();
            DataTable backupsMes = reportes.ObtenerBackupsDelMes();

            if (dt.Rows.Count > 0)
            {
                DateTime fechaBackup = Convert.ToDateTime(dt.Rows[0]["fecha_backup"]);
                string usuario = dt.Rows[0]["usuario_backup"].ToString();

                lblUltimoBackup.Text = $"Último backup: {fechaBackup:dd/MM/yyyy HH:mm} (realizado por {usuario})";

                lblTotalBackups.Text = $"Total de backups en el mes: {backupsMes.Rows[0]["TotalBackups"]}";
            }
            else
            {
                lblUltimoBackup.Text = "No se registran backups aún.";
                lblTotalBackups.Text = "";
            }
        }

        // --- ALERTA SI NO HUBO BACKUPS EN 7 DÍAS ---
        private void VerificarAlertaBackup()
        {
            DataTable dt = reportes.ObtenerUltimoBackup();

            if (dt.Rows.Count == 0)
            {
                lblAlertaBackup.Text = "No se registran backups en el sistema.";
                lblAlertaBackup.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DateTime fechaUltimoBackup = Convert.ToDateTime(dt.Rows[0]["fecha_backup"]);
            TimeSpan diferencia = DateTime.Now - fechaUltimoBackup;

            if (diferencia.TotalDays > 7)
            {
                lblAlertaBackup.Text = "No se realizó ningún backup en los últimos 7 días.";
                lblAlertaBackup.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblAlertaBackup.Text = "Los backups se están realizando con normalidad.";
                lblAlertaBackup.ForeColor = System.Drawing.Color.Green;
            }
        }

        //  --- USUARIOS ACTIVOS / INACTIVOS ---
        private void CargarUsuariosActivosInactivos()
        {
            try
            {
                DataTable dt = reportes.ObtenerUsuariosActivosInactivos();

                // Limpia el gráfico antes de volver a cargar
                chartUsuariosActivos.Series.Clear();
                chartUsuariosActivos.Titles.Clear();
                chartUsuariosActivos.Legends.Clear();

                // Crea una nueva serie tipo "torta" (pie chart)
                var serie = new System.Windows.Forms.DataVisualization.Charting.Series("Usuarios")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                    IsValueShownAsLabel = true
                };

                // Carga los datos al gráfico
                foreach (DataRow fila in dt.Rows)
                {
                    string estado = fila["Estado"].ToString();
                    int cantidad = Convert.ToInt32(fila["Cantidad"]);
                    serie.Points.AddXY(estado, cantidad);
                }

                // Etiquetas personalizadas: muestra porcentaje y cantidad
                serie.Label = "#VALX: #PERCENT{P0} (#VAL)";
                serie.LegendText = "#VALX";
                
                // Agrega la serie al gráfico
                chartUsuariosActivos.Series.Add(serie);

                // Leyenda
                var leyenda = new System.Windows.Forms.DataVisualization.Charting.Legend("Leyenda");
                chartUsuariosActivos.Legends.Add(leyenda);

                // Título
                chartUsuariosActivos.Titles.Add("Usuarios activos e inactivos");

                // Paleta de colores
                chartUsuariosActivos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
                
                // Asegura un área de gráfico
                if (chartUsuariosActivos.ChartAreas.Count == 0)
                    chartUsuariosActivos.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

                // Fuente uniforme tamaño 9
                Font fuente = new Font("Segoe UI", 9, FontStyle.Regular);

                foreach (var titulo in chartUsuariosActivos.Titles)
                    titulo.Font = fuente;

                foreach (var legend in chartUsuariosActivos.Legends)
                    legend.Font = fuente;

                foreach (var s in chartUsuariosActivos.Series)
                    s.Font = fuente;

                foreach (var area in chartUsuariosActivos.ChartAreas)
                {
                    area.AxisX.LabelStyle.Font = fuente;
                    area.AxisY.LabelStyle.Font = fuente;
                    area.AxisX.TitleFont = fuente;
                    area.AxisY.TitleFont = fuente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico de usuarios activos/inactivos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- USUARIOS POR ROL ---
        private void CargarUsuariosPorRol()
        {
            try
            {
                DataTable dt = reportes.ObtenerUsuariosPorRol();

                // Limpia antes de volver a cargar
                chartUsuariosPorRol.Series.Clear();
                chartUsuariosPorRol.Titles.Clear();
                chartUsuariosPorRol.Legends.Clear();

                // Crea una serie de barras
                var serie = new System.Windows.Forms.DataVisualization.Charting.Series("Usuarios por Rol")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                // Carga los datos
                foreach (DataRow fila in dt.Rows)
                {
                    string rol = fila["Rol"].ToString();
                    int cantidad = Convert.ToInt32(fila["Cantidad"]);
                    serie.Points.AddXY(rol, cantidad);
                }

                // Etiquetas personalizadas
                serie.Label = "#VAL";

                // Agrega la serie al gráfico
                chartUsuariosPorRol.Series.Add(serie);

                // Leyenda
                var leyenda = new System.Windows.Forms.DataVisualization.Charting.Legend("Leyenda");
                chartUsuariosPorRol.Legends.Add(leyenda);

                // Título
                chartUsuariosPorRol.Titles.Add("Usuarios por tipo de rol");

                // Paleta colores
                chartUsuariosPorRol.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;

                // Asegura un área de gráfico
                if (chartUsuariosPorRol.ChartAreas.Count == 0)
                chartUsuariosPorRol.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

                // Configura el área del gráfico
                var area = chartUsuariosPorRol.ChartAreas[0];
                area.AxisX.Title = "Rol de Usuario";
                area.AxisY.Title = "Cantidad";
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Angle = -45;
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

                //Fuente uniforme tamaño 9
                Font fuente = new Font("Segoe UI", 9, FontStyle.Regular);

                foreach (var titulo in chartUsuariosPorRol.Titles)
                    titulo.Font = fuente;

                foreach (var legend in chartUsuariosPorRol.Legends)
                    legend.Font = fuente;

                foreach (var s in chartUsuariosPorRol.Series)
                    s.Font = fuente;

                foreach (var a in chartUsuariosPorRol.ChartAreas)
                {
                    a.AxisX.LabelStyle.Font = fuente;
                    a.AxisY.LabelStyle.Font = fuente;
                    a.AxisX.TitleFont = fuente;
                    a.AxisY.TitleFont = fuente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico de usuarios por rol: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}