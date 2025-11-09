using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            CargarResumenInventario();
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
                lblAlertaBackup.Text = " Los backups se están realizando con normalidad.";
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
                // 1. Obtener los datos (esto ya lo tienes)
                DataTable dt = reportes.ObtenerUsuariosPorRol();

                // 2. Llamar a la función de estilo.
                // Esta función LIMPIA el gráfico, lo formatea
                // y devuelve la serie que debemos llenar.
                Series seriePrincipal = EstilizarChartRoles(chartUsuariosPorRol);

                // 3. Llenar la serie con los datos
                // (Todo el código de estilo anterior se elimina)
                foreach (DataRow fila in dt.Rows)
                {
                    string rol = fila["Rol"].ToString();
                    int cantidad = Convert.ToInt32(fila["Cantidad"]);

                    // Añadimos los puntos a la 'seriePrincipal' que creó el estilizador
                    seriePrincipal.Points.AddXY(rol, cantidad);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico de usuarios por rol: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarResumenInventario()
        {
            // Consulta 1: contador total
            string queryTotal = "SELECT COUNT(*) AS TotalLibros FROM libro;";

            // Consulta 2: libros con bajo stock
            // (Esto va dentro de tu método CargarResumenInventario)

            string queryBajoStock = @"
            SELECT 
                L.id_libro, 
                L.titulo AS Titulo, 
                A.nombre_autor AS Autor, 
                C.nombre_categoria AS Categoria, 
                L.stock_libro AS Stock
            FROM libro L
            LEFT JOIN autor A ON L.id_autor = A.id_autor
            LEFT JOIN categoria C ON L.id_categoria = C.id_categoria
            WHERE L.stock_libro < 5 
            ORDER BY L.stock_libro ASC;
";
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //1️ Obtener total de libros
                SqlCommand cmdTotal = new SqlCommand(queryTotal, conn);
                int totalLibros = Convert.ToInt32(cmdTotal.ExecuteScalar());
                lblTotalLibros.Text = $" {totalLibros}";

                // 2️ Obtener listado de libros con bajo stock
                SqlDataAdapter da = new SqlDataAdapter(queryBajoStock, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBajoStock.DataSource = dt;
            }

            EstilizarGridBajoStock();
        }

        private void EstilizarGridBajoStock()
        {
            // --- 1. APARIENCIA GENERAL (Minimalista) ---
            dgvBajoStock.BorderStyle = BorderStyle.None;
            dgvBajoStock.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBajoStock.GridColor = Color.FromArgb(235, 235, 235); // Línea suave
            dgvBajoStock.AllowUserToAddRows = false;
            dgvBajoStock.AllowUserToDeleteRows = false;
            dgvBajoStock.ReadOnly = true;
            dgvBajoStock.RowHeadersVisible = false;
            dgvBajoStock.BackgroundColor = Color.White;
            dgvBajoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBajoStock.RowTemplate.Height = 30; // Filas más altas

            // --- 2. ESTILO DE ENCABEZADOS ---
            dgvBajoStock.EnableHeadersVisualStyles = false;
            dgvBajoStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBajoStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); // Fondo gris claro
            dgvBajoStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBajoStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60); // Texto gris oscuro
            dgvBajoStock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBajoStock.ColumnHeadersHeight = 35;

            // --- 3. ESTILO DE FILAS ---
            dgvBajoStock.RowsDefaultCellStyle.BackColor = Color.White;
            dgvBajoStock.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvBajoStock.RowsDefaultCellStyle.ForeColor = Color.DimGray;
            dgvBajoStock.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 250); // Azul pálido
            dgvBajoStock.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // --- 4. AJUSTE DE COLUMNAS (Usando los nuevos alias del SQL) ---
            if (dgvBajoStock.Columns["id_libro"] != null)
            {
                dgvBajoStock.Columns["id_libro"].Visible = false; // Ocultamos el ID
            }
            if (dgvBajoStock.Columns["Titulo"] != null)
            {
                dgvBajoStock.Columns["Titulo"].FillWeight = 50; // 50% del espacio
            }
            if (dgvBajoStock.Columns["Autor"] != null)
            {
                dgvBajoStock.Columns["Autor"].FillWeight = 20; // 20%
            }
            if (dgvBajoStock.Columns["Categoria"] != null)
            {
                dgvBajoStock.Columns["Categoria"].FillWeight = 20; // 20%
            }
            if (dgvBajoStock.Columns["Stock"] != null)
            {
                dgvBajoStock.Columns["Stock"].HeaderText = "Stock";
                dgvBajoStock.Columns["Stock"].FillWeight = 10; // 10%
                dgvBajoStock.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBajoStock.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // --- 5. CONECTAR EVENTO DE FORMATO (Para resaltar el stock) ---
            dgvBajoStock.CellFormatting -= dgvBajoStock_CellFormatting; // Evita duplicar el evento
            dgvBajoStock.CellFormatting += dgvBajoStock_CellFormatting;
        }

        private void dgvBajoStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Solo nos interesa la columna "Stock"
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvBajoStock.Columns[e.ColumnIndex].Name != "Stock")
            {
                return;
            }

            if (e.Value != null && int.TryParse(e.Value.ToString(), out int stock))
            {
                // Umbral Crítico (ej: 3 o menos)
                if (stock <= 3)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 235); // Fondo rosa pálido
                    e.CellStyle.ForeColor = Color.FromArgb(192, 0, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                // Umbral de Advertencia (ej: 4 o 5)
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 248, 225); // Fondo amarillo/crema
                    e.CellStyle.ForeColor = Color.FromArgb(156, 101, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private Series EstilizarChartRoles(Chart chart)
        {
            // 1. Limpieza total
            chart.Series.Clear();
            chart.Titles.Clear();
            chart.Legends.Clear();
            chart.ChartAreas.Clear();
            chart.BackColor = Color.White;

            // 2. Título (Sin cambios)
            chart.Titles.Add("Usuarios por tipo de rol");
            chart.Titles[0].Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chart.Titles[0].Alignment = ContentAlignment.MiddleLeft;

            // 3. Área del Gráfico (¡EJES INTERCAMBIADOS!)
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.White;

            // --- ¡CAMBIO! Eje X (Abajo) ahora es "Cantidad" ---
            chartArea.AxisX.Title = "Cantidad";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 9F);
            chartArea.AxisX.MajorGrid.LineColor = Color.Gainsboro; // Líneas de cuadrícula suaves
            chartArea.AxisX.MajorTickMark.Enabled = false;
            chartArea.AxisX.Interval = 1; // Forzamos el conteo a 1, 2, 3
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);

            // --- ¡CAMBIO! Eje Y (Izquierda) ahora es "Rol de Usuario" ---
            chartArea.AxisY.Title = "Rol de Usuario";
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 9F);
            chartArea.AxisY.MajorGrid.Enabled = false; // Sin líneas de cuadrícula
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisY.Interval = 1; // Una etiqueta por cada rol
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            // Ya no se necesita la rotación de -45 grados

            chart.ChartAreas.Add(chartArea);

            // 4. Crear y Estilizar la Serie de datos
            Series series = new Series("UsuariosPorRol")
            {
                // --- ¡EL CAMBIO MÁS IMPORTANTE! ---
                ChartType = SeriesChartType.Bar, // De "Column" (vertical) a "Bar" (horizontal)

                IsValueShownAsLabel = true,
                Label = "#VAL",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                LabelForeColor = Color.DimGray,
                Color = Color.FromArgb(70, 130, 180),
                ["PointWidth"] = "0.7"
            };

            // Posicionamos la etiqueta (el número) al final de la barra
            series["BarLabelStyle"] = "Outside";

            // 5. Añadimos la serie (aún vacía) y la devolvemos
            chart.Series.Add(series);
            return series;
        }


    }

}