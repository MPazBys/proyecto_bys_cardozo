using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion
{
    public partial class frmReporteGerente : Form
    {
        private decimal targetVentas, targetIngresos , targetLibros;

        private decimal startVentas, startIngresos, startLibros;

        private int animationDuration = 800; 
        private int animationTicks, totalTicks = 0; 
        

        public frmReporteGerente()
        {
            InitializeComponent();

            // Configurar ComboBox de periodos
            cmbPeriodo.Items.AddRange(new string[] { "Hoy", "Esta Semana", "Este Mes", "Este Año", "Personalizado" });
            cmbPeriodo.SelectedIndex = 0; // Por defecto "Hoy"
            ActualizarFechasPorPeriodo(cmbPeriodo.SelectedItem.ToString());

            CargarPromocionesVigentes();

           
        }


        // --- Evento del ComboBox ---
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string periodo = cmbPeriodo.SelectedItem.ToString();

            if (periodo != "Personalizado")
            {
                ActualizarFechasPorPeriodo(periodo);
            }
        }

        // --- Método que actualiza fechas según el período ---
        private void ActualizarFechasPorPeriodo(string periodo)
        {
            DateTime hoy = DateTime.Today;

            switch (periodo)
            {
                case "Hoy":
                    dtpFechaInicio.Value = hoy;
                    dtpFechaFin.Value = hoy;
                    break;

                case "Esta Semana":
                    int diff = (7 + (hoy.DayOfWeek - DayOfWeek.Monday)) % 7;
                    DateTime inicioSemana = hoy.AddDays(-diff);
                    dtpFechaInicio.Value = inicioSemana;
                    dtpFechaFin.Value = hoy;
                    break;

                case "Este Mes":
                    dtpFechaInicio.Value = new DateTime(hoy.Year, hoy.Month, 1);
                    dtpFechaFin.Value = hoy;
                    break;

                case "Este Año":
                    dtpFechaInicio.Value = new DateTime(hoy.Year, 1, 1);
                    dtpFechaFin.Value = hoy;
                    break;

                default:
                    // "Personalizado": deja las fechas manuales
                    break;
            }
        }

        // --- Botón Aplicar Filtro ---
        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.",
                                "Error de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarResumenGeneral();
            CargarRankingLibros();
            CargarReportePromociones();
            CargarReporteVendedores();
        }

        private void CargarResumenGeneral()
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);

            targetVentas = targetIngresos = targetLibros = 0;
            startVentas = startIngresos = startLibros = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            Decimal.TryParse(lblTotalVentas.Text, out startVentas);
          
            Decimal.TryParse(lblIngresosTotales.Text, NumberStyles.Currency,
                             CultureInfo.GetCultureInfo("es-AR"), out startIngresos);
            Decimal.TryParse(lblLibrosVendidos.Text, out startLibros);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Total de ventas e ingresos totales
                string queryResumen = @"
                SELECT 
                    COUNT(*) AS TotalVentas,
                    SUM(total) AS IngresosTotales
                FROM venta V
                WHERE V.fecha BETWEEN @inicio AND @fin  
                    AND V.estado = 1 ;";

                SqlCommand cmdResumen = new SqlCommand(queryResumen, conn);
                cmdResumen.Parameters.AddWithValue("@inicio", fechaInicio);
                cmdResumen.Parameters.AddWithValue("@fin", fechaFin);

                SqlDataReader reader = cmdResumen.ExecuteReader();
                if (reader.Read())
                {
                    // --- ¡CAMBIO! Guardamos el "objetivo" (target) ---
                    targetVentas = Convert.ToDecimal(reader["TotalVentas"] == DBNull.Value ? 0 : reader["TotalVentas"]);
                    targetIngresos = Convert.ToDecimal(reader["IngresosTotales"] == DBNull.Value ? 0 : reader["IngresosTotales"]);

                }
                reader.Close();

                // Libros vendidos (sumatoria de cantidades en detalle_venta, pero tomando fecha desde venta)
                string queryLibros = @"
                SELECT SUM(DV.cantidad) AS LibrosVendidos
                FROM detalle_venta DV
                INNER JOIN venta V ON DV.id_venta = V.id_venta
                WHERE V.fecha BETWEEN @inicio AND @fin
                     AND V.estado = 1 ;";

                SqlCommand cmdLibros = new SqlCommand(queryLibros, conn);
                cmdLibros.Parameters.AddWithValue("@inicio", fechaInicio);
                cmdLibros.Parameters.AddWithValue("@fin", fechaFin);

                object resultLibros = cmdLibros.ExecuteScalar();
                targetLibros = Convert.ToDecimal(resultLibros == DBNull.Value ? 0 : resultLibros);

                //  Mejor vendedor (solo usuarios con rol = 2)
                string queryVendedor = @"
                SELECT TOP 1 U.nombre + ' ' + U.apellido AS NombreCompleto, SUM(V.total) AS Ingresos
                FROM venta V
                INNER JOIN usuario U ON V.id_usuario = U.id_usuario
                INNER JOIN rol R ON U.id_rol = R.id_rol
                WHERE R.id_rol = 2
                  AND V.fecha BETWEEN @inicio AND @fin  AND V.estado = 1 
                GROUP BY U.nombre, U.apellido
                ORDER BY Ingresos DESC;";

                SqlCommand cmdVendedor = new SqlCommand(queryVendedor, conn);
                cmdVendedor.Parameters.AddWithValue("@inicio", fechaInicio);
                cmdVendedor.Parameters.AddWithValue("@fin", fechaFin);

                SqlDataReader readerVendedor = cmdVendedor.ExecuteReader();
                if (readerVendedor.Read())
                {
                    lblMejorVendedor.Text = readerVendedor["NombreCompleto"].ToString();
                }
                else
                {
                    lblMejorVendedor.Text = "—";
                }
                readerVendedor.Close();
            }

            animationTicks = 0;

            totalTicks = animationDuration / timerContadores.Interval;

            timerContadores.Start();
        }


        private void CargarRankingLibros()
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // --- 1. Libros más vendidos ---
                SqlCommand cmdTop = new SqlCommand("sp_ReporteTop5MasVendidos", conn);

                cmdTop.CommandType = CommandType.StoredProcedure;

                cmdTop.Parameters.AddWithValue("@inicio", fechaInicio);
                cmdTop.Parameters.AddWithValue("@fin", fechaFin);

                SqlDataAdapter daTop = new SqlDataAdapter(cmdTop);

                DataTable dtTop = new DataTable();
                daTop.Fill(dtTop);

                // --- APLICAR ESTILO Y DATOS (TOP) ---
                // Color azul similar a tu panel:
                EstilizarGrafico(chartTopLibros, Color.FromArgb(74, 120, 168), "Top 5 Libros Más Vendidos");

                chartTopLibros.DataSource = dtTop;
                chartTopLibros.Series["Series1"].XValueMember = "titulo";
                chartTopLibros.Series["Series1"].YValueMembers = "VentasTotales";
                chartTopLibros.DataBind(); // Volver a enlazar los datos


                // --- 2. Libros menos vendidos ---
                string queryBottom = @"
                SELECT TOP 5 L.titulo, SUM(DV.cantidad) AS VentasTotales
                FROM detalle_venta DV
                INNER JOIN libro L ON DV.id_libro = L.id_libro
                INNER JOIN venta V ON DV.id_venta = V.id_venta
                WHERE V.fecha BETWEEN @inicio AND @fin  AND V.estado = 1 
                GROUP BY L.titulo
                ORDER BY VentasTotales ASC;
                ";

                SqlDataAdapter daBottom = new SqlDataAdapter(queryBottom, conn);
                daBottom.SelectCommand.Parameters.AddWithValue("@inicio", fechaInicio);
                daBottom.SelectCommand.Parameters.AddWithValue("@fin", fechaFin);
                DataTable dtBottom = new DataTable();
                daBottom.Fill(dtBottom);

                
                EstilizarGrafico(chartPeorLibros, Color.FromArgb(204, 85, 85), "Top 5 Libros Menos Vendidos");

                chartPeorLibros.DataSource = dtBottom;
                chartPeorLibros.Series["Series1"].XValueMember = "titulo";
                chartPeorLibros.Series["Series1"].YValueMembers = "VentasTotales";
                chartPeorLibros.DataBind(); // Volver a enlazar los datos
            }
        }


        /// <summary>
        /// Aplica un estilo moderno y limpio a un control Chart.
        /// </summary>
        /// <param name="chart">El gráfico a estilizar.</param>
        /// <param name="colorBarra">El color principal para las barras.</param>
        /// <param name="titulo">El título que se mostrará en el gráfico.</param>
        private void EstilizarGrafico(Chart chart, Color colorBarra, string titulo)
        {
            // Limpieza inicial
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();
            chart.Legends.Clear(); 

            // 1. Configurar Área del Gráfico
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // --- Estilo "Moderno" (Fondo y Bordes) ---
            chart.BackColor = Color.White;
            chartArea.BackColor = Color.White;
            chart.BorderlineWidth = 0;

            // --- Título ---
            Title titleObj = new Title(titulo, Docking.Top, new Font("Segoe UI", 12F, FontStyle.Bold), Color.Black);
            chart.Titles.Add(titleObj);

            // --- Eje X (Libros) ---
            chartArea.AxisX.MajorGrid.Enabled = false;     // Sin cuadrícula vertical
            chartArea.AxisX.MajorTickMark.Enabled = false; // Sin marcas
            chartArea.AxisX.LineColor = Color.Transparent; // Sin línea del eje
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap; // Ajusta texto largo
            chartArea.AxisX.Interval = 1; // Muestra todas las etiquetas

            // --- Eje Y (Ventas) ---
            chartArea.AxisY.MajorGrid.LineColor = Color.Gainsboro; // Cuadrícula horizontal suave
            chartArea.AxisY.MajorTickMark.Enabled = false; // Sin marcas
            chartArea.AxisY.LineColor = Color.Transparent; // Sin línea del eje
            chartArea.AxisY.LabelStyle.Enabled = false; // Ocultamos etiquetas (el valor irá en la barra)

       
            chartArea.AxisY.Interval = 1;
            chartArea.AxisY.Minimum = 0;

            Series series = new Series
            {
                Name = "Series1",
                ChartType = SeriesChartType.Column,
                Color = colorBarra,
                IsValueShownAsLabel = true
            };

            series.Font = new Font("Segoe UI", 9F, FontStyle.Bold); 
            series.LabelForeColor = Color.Black;

            chart.Series.Add(series);
        }

        private void CargarPromocionesVigentes()
        {
         
            CN_Promocion cn_promocion = new CN_Promocion();
            DataTable dtPromociones = cn_promocion.ListarPromocionesVigentes();

            // Enlazar los datos al DataGridView
            dgvPromociones.DataSource = dtPromociones;

            EstilizarGrillaPromociones();

        }

        private void EstilizarGrillaPromociones()
        {
            // --- 1. AJUSTES DE DISEÑO MINIMALISTA (Como tu imagen) ---
            dgvPromociones.BorderStyle = BorderStyle.None;
            dgvPromociones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // ¡LA CLAVE!
            dgvPromociones.GridColor = Color.FromArgb(235, 235, 235); // Color de la línea suave
            dgvPromociones.AllowUserToAddRows = false;
            dgvPromociones.AllowUserToDeleteRows = false;
            dgvPromociones.ReadOnly = true;
            dgvPromociones.RowHeadersVisible = false;
            dgvPromociones.BackgroundColor = Color.White; // Fondo de la grilla
            dgvPromociones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPromociones.RowTemplate.Height = 35; // Damos más altura a las filas

            // --- 2. ESTILO DE ENCABEZADOS (Columnas) ---
            dgvPromociones.EnableHeadersVisualStyles = false; 
            dgvPromociones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPromociones.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvPromociones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPromociones.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPromociones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // --- 3. ESTILO DE FILAS ---
            dgvPromociones.RowsDefaultCellStyle.BackColor = Color.White;
            dgvPromociones.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvPromociones.RowsDefaultCellStyle.ForeColor = Color.DimGray;
            dgvPromociones.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 250); // Un azul pálido
            dgvPromociones.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPromociones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // --- 4. OCULTAR COLUMNAS ---
            dgvPromociones.Columns["id_promocion"].Visible = false;
            dgvPromociones.Columns["IdItemAsociado"].Visible = false;
            dgvPromociones.Columns["estado"].Visible = false;
            dgvPromociones.Columns["tipo"].Visible = false;
            dgvPromociones.Columns["fecha_inicio"].Visible = false;
            // ¡NUEVO! Ocultamos esta para que sea más simple
            dgvPromociones.Columns["DescripcionItemAsociado"].Visible = false;

            // --- 5. RENOMBRAR Y AJUSTAR COLUMNAS VISIBLES ---
            dgvPromociones.Columns["nombre"].HeaderText = "Nombre";
            dgvPromociones.Columns["valor_descuento"].HeaderText = "Descuento";
            dgvPromociones.Columns["fecha_fin"].HeaderText = "Fecha";

            dgvPromociones.Columns["nombre"].FillWeight = 150;
            dgvPromociones.Columns["valor_descuento"].FillWeight = 80;
            dgvPromociones.Columns["fecha_fin"].FillWeight = 100;


            // Conectar el evento de formato
            // (Añadimos -= primero para evitar que el evento se suscriba múltiples veces)
            dgvPromociones.CellFormatting -= dgvPromociones_CellFormatting;
            dgvPromociones.CellFormatting += dgvPromociones_CellFormatting;
        }

        private void dgvPromociones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Si la columna es "Fecha"
            if (dgvPromociones.Columns[e.ColumnIndex].Name == "fecha_fin")
            {
                if (e.Value != null)
                {
                    DateTime fecha = (DateTime)e.Value;
                    e.Value = fecha.ToString("dd-MM-yyyy"); 
                    e.FormattingApplied = true;
                }
            }

            // --- ¡ACTUALIZADO! Si la columna es "Descuento" ---
            if (dgvPromociones.Columns[e.ColumnIndex].Name == "valor_descuento")
            {
                if (e.Value != null)
                {
                    // Asumimos que el valor es un porcentaje (ej: 10.00 en la BD es 10%)
                    decimal descuento = (decimal)e.Value;

                    // Convertimos a string sin decimales y añadimos "%"
                    e.Value = descuento.ToString("0") + "%";

                    e.FormattingApplied = true;
                }
            }
        }

        //CARGAR LAS PROMOCIONES MAS UTILIZADAS 
        private void CargarReportePromociones()
        {
            // Obtenemos las fechas de tus controles
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;

            // 1. Obtenemos los datos (esto ya funciona)
            CN_Promocion cn_promocion = new CN_Promocion();
            DataTable dt = cn_promocion.ReportePromocionesMasUsadas(fechaInicio, fechaFin);

            // --- 2. APLICAR ESTILO AL GRÁFICO PRIMERO ---
            // Esto prepara el gráfico, borra series antiguas y crea la nueva
            EstilizarChartPromociones();

            // --- 3. ASIGNAR LOS DATOS AL GRÁFICO ---
            chartPromociones.DataSource = dt;

            // --- 4. CONFIGURAR MIEMBROS DE LA SERIE ---
            // (Nos aseguramos de que la serie "Series1" creada en el estilizador exista)
            if (chartPromociones.Series.Count > 0 && chartPromociones.Series["Series1"] != null)
            {
                chartPromociones.Series["Series1"].XValueMember = "nombre";
                chartPromociones.Series["Series1"].YValueMembers = "MontoTotalDescontado";
            }

            // --- 5. ¡LA LÍNEA CLAVE! ---
            // Forzamos al gráfico a dibujarse con los nuevos datos
            chartPromociones.DataBind();

            // --- 6. Cargar la Grilla (esto ya funcionaba) ---
            dgvPromocionesUsadas.DataSource = dt;
            EstilizarGridPromocionesUsadas();
        }

        private void EstilizarChartPromociones()
        {
            // --- LIMPIEZA INICIAL ---
            chartPromociones.Series.Clear();
            chartPromociones.ChartAreas.Clear();
            chartPromociones.Legends.Clear();

            // --- ÁREA ---
            ChartArea chartArea = new ChartArea();
            chartArea.BackColor = Color.Transparent;
            chartPromociones.ChartAreas.Add(chartArea);
            chartPromociones.BackColor = Color.Transparent;

            // --- SERIES (LA TORTA) ---
            Series series = new Series
            {
                Name = "Series1",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = false, // 🔹 Desactiva texto dentro del gráfico
               
            };

            series["PieLabelStyle"] = "Disabled"; // ← ESTA LÍNEA ES CLAVE
            series.LabelForeColor = Color.Transparent; // Por seguridad, también lo forzamos invisible
            chartPromociones.Series.Add(series);

            // --- LEYENDA  ---
            Legend legend = new Legend
            {
                Name = "Legend1",
                Docking = Docking.Right,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9F),
                LegendStyle = LegendStyle.Table, 
                IsDockedInsideChartArea = false, 
                MaximumAutoSize = 50
            };
            chartPromociones.Legends.Add(legend);

            // --- COLORES (Paleta de azules) ---
            chartPromociones.Palette = ChartColorPalette.SeaGreen;
            // O una paleta personalizada de azules:
            chartPromociones.PaletteCustomColors = new Color[] {
            Color.FromArgb(50, 88, 133),
            Color.FromArgb(88, 140, 195),
            Color.FromArgb(141, 182, 222),
            Color.FromArgb(193, 218, 240)
             };
            chartPromociones.Palette = ChartColorPalette.None;
        }

        private void EstilizarGridPromocionesUsadas()
        {
            // --- 1. APARIENCIA GENERAL ---
            dgvPromocionesUsadas.BorderStyle = BorderStyle.None;
            dgvPromocionesUsadas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPromocionesUsadas.GridColor = Color.FromArgb(235, 235, 235); 
            dgvPromocionesUsadas.AllowUserToAddRows = false;
            dgvPromocionesUsadas.AllowUserToDeleteRows = false;
            dgvPromocionesUsadas.ReadOnly = true;
            dgvPromocionesUsadas.RowHeadersVisible = false;
            dgvPromocionesUsadas.BackgroundColor = Color.White;
            dgvPromocionesUsadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPromocionesUsadas.RowTemplate.Height = 30;
            dgvPromocionesUsadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // --- 2. OCULTAR ENCABEZADOS ---
            dgvPromocionesUsadas.EnableHeadersVisualStyles = true;
            dgvPromocionesUsadas.ColumnHeadersVisible = true;

            dgvPromocionesUsadas.EnableHeadersVisualStyles = false;


            dgvPromocionesUsadas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            // --- 3. ESTILO DE FILAS ---

            // Un fondo suave para el header, o usa Color.White
            dgvPromocionesUsadas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvPromocionesUsadas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvPromocionesUsadas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPromocionesUsadas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPromocionesUsadas.ColumnHeadersHeight = 35;

            dgvPromocionesUsadas.RowsDefaultCellStyle.BackColor = Color.White;
            dgvPromocionesUsadas.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvPromocionesUsadas.RowsDefaultCellStyle.ForeColor = Color.DimGray;
            dgvPromocionesUsadas.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            dgvPromocionesUsadas.RowsDefaultCellStyle.SelectionForeColor = Color.DimGray;

            // --- 4. AJUSTE DE COLUMNAS ---
            if (dgvPromocionesUsadas.Columns["nombre"] != null)
            {
                dgvPromocionesUsadas.Columns["nombre"].HeaderText = "Promoción";
                dgvPromocionesUsadas.Columns["nombre"].FillWeight = 70;
            }

            // Columna "VecesUtilizada"
            if (dgvPromocionesUsadas.Columns["VecesUtilizada"] != null)
            {
                dgvPromocionesUsadas.Columns["VecesUtilizada"].HeaderText = "Usos";
                dgvPromocionesUsadas.Columns["VecesUtilizada"].FillWeight = 20; 
                                                                                
                dgvPromocionesUsadas.Columns["VecesUtilizada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Verificamos si la columna "MontoTotalDescontado" existe
            if (dgvPromocionesUsadas.Columns["MontoTotalDescontado"] != null)
            {
                dgvPromocionesUsadas.Columns["MontoTotalDescontado"].HeaderText = "Total Desc.";
                dgvPromocionesUsadas.Columns["MontoTotalDescontado"].FillWeight = 30;
                dgvPromocionesUsadas.Columns["MontoTotalDescontado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvPromocionesUsadas.CellFormatting -= dgvPromocionesUsadas_CellFormatting;
            dgvPromocionesUsadas.CellFormatting += dgvPromocionesUsadas_CellFormatting;
        }

        private void dgvPromocionesUsadas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Si la columna es "MontoTotalDescontado"
            if (dgvPromocionesUsadas.Columns[e.ColumnIndex].Name == "MontoTotalDescontado")
            {
                if (e.Value != null)
                {
                    // Formateamos el valor como moneda
                    decimal monto = (decimal)e.Value;

                    // Usamos la cultura "es-AR" (Peso Argentino) para forzar el "$"
                    e.Value = monto.ToString("C0", new CultureInfo("es-AR"));
                    e.FormattingApplied = true;
                }
            }
        }

        // 1. MÉTODO DE CARGA
        private void CargarReporteVendedores()
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;

            // (Asumo que la clase de negocio se llama CN_Usuario)
            CN_Usuario cn_usuario = new CN_Usuario();
            DataTable dt = cn_usuario.ReporteVendedores(fechaInicio, fechaFin);

            dgvVendedores.DataSource = dt;
            EstilizarGridVendedores();
        }

        // 2. MÉTODO DE ESTILO (¡COPIA EL DISEÑO DE TU IMAGEN!)
        private void EstilizarGridVendedores()
        {
            // --- 1. APARIENCIA GENERAL (Minimalista) ---
            dgvVendedores.BorderStyle = BorderStyle.None;
            dgvVendedores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVendedores.GridColor = Color.FromArgb(235, 235, 235); // Línea suave
            dgvVendedores.AllowUserToAddRows = false;
            dgvVendedores.AllowUserToDeleteRows = false;
            dgvVendedores.ReadOnly = true;
            dgvVendedores.RowHeadersVisible = false;
            dgvVendedores.BackgroundColor = Color.White;
            dgvVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendedores.RowTemplate.Height = 35;

            // --- 2. ESTILO DE ENCABEZADOS (Fondo azul pálido) ---
            dgvVendedores.EnableHeadersVisualStyles = false;
            dgvVendedores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVendedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 243, 250); // Azul pálido
            dgvVendedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvVendedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dgvVendedores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvVendedores.ColumnHeadersHeight = 35;

            // --- 3. ESTILO DE FILAS ---
            dgvVendedores.RowsDefaultCellStyle.BackColor = Color.White;
            dgvVendedores.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvVendedores.RowsDefaultCellStyle.ForeColor = Color.DimGray;
            dgvVendedores.RowsDefaultCellStyle.SelectionBackColor = Color.White; // Sin cambio al seleccionar
            dgvVendedores.RowsDefaultCellStyle.SelectionForeColor = Color.DimGray;

            // --- 4. AJUSTE DE COLUMNAS ---
            if (dgvVendedores.Columns["NombreVendedor"] != null)
            {
                dgvVendedores.Columns["NombreVendedor"].HeaderText = "Nombre";
                dgvVendedores.Columns["NombreVendedor"].FillWeight = 40;
            }
            if (dgvVendedores.Columns["TotalVentas"] != null)
            {
                dgvVendedores.Columns["TotalVentas"].HeaderText = "Total Ventas";
                dgvVendedores.Columns["TotalVentas"].FillWeight = 25;
                dgvVendedores.Columns["TotalVentas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVendedores.Columns["TotalVentas"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvVendedores.Columns["TotalAnuladas"] != null)
            {
                dgvVendedores.Columns["TotalAnuladas"].HeaderText = "Total Anuladas";
                dgvVendedores.Columns["TotalAnuladas"].FillWeight = 25;
                dgvVendedores.Columns["TotalAnuladas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVendedores.Columns["TotalAnuladas"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvVendedores.Columns["TotalAnuladas"].DefaultCellStyle.ForeColor = Color.Red;
            }
            if (dgvVendedores.Columns["TotalIngresos"] != null)
            {
                dgvVendedores.Columns["TotalIngresos"].HeaderText = "Total Ingresos";
                dgvVendedores.Columns["TotalIngresos"].FillWeight = 25;
                dgvVendedores.Columns["TotalIngresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvVendedores.Columns["TotalIngresos"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // --- 5. CONECTAR EVENTO DE FORMATO (Para el "$") ---
            dgvVendedores.CellFormatting -= dgvVendedores_CellFormatting;
            dgvVendedores.CellFormatting += dgvVendedores_CellFormatting;
        }

        // 3. MÉTODO DE FORMATO DE CELDAS
        private void dgvVendedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Si la columna es "TotalIngresos"
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvVendedores.Columns[e.ColumnIndex] == null) return;

            string colName = dgvVendedores.Columns[e.ColumnIndex].Name;

            if (colName == "TotalIngresos")
            {
                if (e.Value != null)
                {
                    decimal monto = (decimal)e.Value;
                    // "C0" = Formato Moneda, 0 decimales (como en tu imagen)
                    e.Value = monto.ToString("C0", new CultureInfo("es-AR"));
                    e.FormattingApplied = true;
                }
            }
        }

      
        private void timerContadores_Tick(object sender, EventArgs e)
        {
            animationTicks++;
            decimal progreso = (decimal)animationTicks / totalTicks;

            // 2. Aplicamos un "Easing" (desaceleración suave) para que no sea lineal
            // Esto hace que la animación sea rápida al inicio y suave al final
            decimal easeProgreso = 1 - (1 - progreso) * (1 - progreso); // Ease-Out

            if (animationTicks >= totalTicks)
            {
                timerContadores.Stop();
                lblTotalVentas.Text = targetVentas.ToString();
                lblIngresosTotales.Text = targetIngresos.ToString("C2", CultureInfo.GetCultureInfo("es-AR"));
                lblLibrosVendidos.Text = targetLibros.ToString();
            }
            else
            {
                // --- 3. Durante la Animación: Calcular valores intermedios ---
                decimal currentVentas = startVentas + (targetVentas - startVentas) * easeProgreso;
                decimal currentIngresos = startIngresos + (targetIngresos - startIngresos) * easeProgreso;
                decimal currentLibros = startLibros + (targetLibros - startLibros) * easeProgreso;

                // Actualizar los labels
                lblTotalVentas.Text = Math.Round(currentVentas).ToString();
                lblIngresosTotales.Text = currentIngresos.ToString("C2", CultureInfo.GetCultureInfo("es-AR"));
                lblLibrosVendidos.Text = Math.Round(currentLibros).ToString();
            }
        }
    }
}
