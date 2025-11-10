using CapaEntidad;

using CapaNegocio;
using FontAwesome.Sharp;
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
    public partial class frmReporteVendedor : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;


        // Variables para animación
        private decimal targetMontoTotal, targetTransferencia, targetEfectivo, targetDebito, targetAnuladas;
        private decimal currentMontoTotal, currentTransferencia, currentEfectivo, currentDebito, currentAnuladas;
        private Timer timerContadores = new Timer();

        private readonly Usuario _usuarioLogueado;
        public frmReporteVendedor(Usuario objusuarios)
        {
            this._usuarioLogueado = objusuarios;
            InitializeComponent();


        }

        private void frmReporteVendedor_Load(object sender, EventArgs e)
        {

            // Configuración Timer
            timerContadores.Interval = 20; // Velocidad de animación en ms
            timerContadores.Tick += TimerContadores_Tick;

            // Configurar ComboBox de periodos
            cmbPeriodo.Items.AddRange(new string[] { "Hoy", "Esta Semana", "Este Mes", "Este Año", "Personalizado" });
            cmbPeriodo.SelectedIndex = 0; // Por defecto "Hoy"
            ActualizarFechasPorPeriodo(cmbPeriodo.SelectedItem.ToString());

         


        }

        // --- Evento cuando cambia la selección del ComboBox ---
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string periodo = cmbPeriodo.SelectedItem.ToString();

            if (periodo != "Personalizado")
            {
                ActualizarFechasPorPeriodo(periodo);
            }
        }

 
        // --- Método que actualiza los rangos de fechas según el período ---
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
                    // "Personalizado": no modifica las fechas
                    break;
            }
        }

        // --- Botón Aplicar Filtro ---
        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            // Valida fechas
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.",
                                "Error de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarReporte();
            CargarReporteTopClientes();

        }


        // --- Cargar datos desde SP y preparar animación ---

        private void CargarReporte()
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1); // Incluye todo el día

            // Reiniciar contadores
            targetMontoTotal = targetTransferencia = targetEfectivo = targetDebito = targetAnuladas = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // === PRIMER SP: Paneles ===
                using (SqlCommand cmdPaneles = new SqlCommand("sp_ReportePaneles", con))
                {
                    cmdPaneles.CommandType = CommandType.StoredProcedure;
                    cmdPaneles.Parameters.AddWithValue("@Fecha_inicio", fechaInicio);
                    cmdPaneles.Parameters.AddWithValue("@Fecha_fin", fechaFin);
                    cmdPaneles.Parameters.AddWithValue("@IdUsuario", _usuarioLogueado?.id_usuario ?? (object)DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmdPaneles);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    // Primer tabla: Monto total
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        targetMontoTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["MontoTotal"]);
                    }

                    // Segunda tabla: montos por medio de pago
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[1].Rows[0];
                        targetTransferencia = Convert.ToDecimal(row["Transferencia"]);
                        targetEfectivo = Convert.ToDecimal(row["Efectivo"]);
                        targetDebito = Convert.ToDecimal(row["Debito"]);
                    }
                }

                // === SEGUNDO SP: Gráfico de resumen ===
                using (SqlCommand cmdGrafico = new SqlCommand("sp_ReporteVentasPorPeriodo", con))
                {
                    cmdGrafico.CommandType = CommandType.StoredProcedure;
                    cmdGrafico.Parameters.AddWithValue("@Fecha_inicio", fechaInicio);
                    cmdGrafico.Parameters.AddWithValue("@Fecha_fin", fechaFin);
                    cmdGrafico.Parameters.AddWithValue("@IdUsuario", _usuarioLogueado?.id_usuario ?? (object)DBNull.Value);

                    using (SqlDataReader dr = cmdGrafico.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            decimal montoTotal = Convert.ToDecimal(dr["MontoTotalVendido"]);
                            int cantidadVentas = Convert.ToInt32(dr["CantidadVentas"]);
                            int librosVendidos = Convert.ToInt32(dr["LibrosVendidos"]);
                            decimal ticketPromedio = Convert.ToDecimal(dr["TicketPromedio"]);

                            MostrarGraficoResumen(montoTotal, cantidadVentas, librosVendidos, ticketPromedio);
                        }
                    }
                }

                // sp para las facturas dadas de bajas 
                using (SqlCommand cmdAnuladas = new SqlCommand("sp_ReporteTotalAnuladas", con))
                {
                    cmdAnuladas.CommandType = CommandType.StoredProcedure;
                    cmdAnuladas.Parameters.AddWithValue("@Fecha_inicio", fechaInicio);
                    cmdAnuladas.Parameters.AddWithValue("@Fecha_fin", fechaFin);
                    cmdAnuladas.Parameters.AddWithValue("@IdUsuario", _usuarioLogueado?.id_usuario ?? (object)DBNull.Value);

                    // Usamos ExecuteScalar porque solo devuelve un número
                    object resultado = cmdAnuladas.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        // Guardamos el objetivo
                        targetAnuladas = Convert.ToDecimal(resultado);
                    }
                }
            }

            // Reiniciar contadores actuales
            currentMontoTotal = currentTransferencia = currentEfectivo = currentDebito = currentAnuladas = 0;

            // Iniciar animación
            timerContadores.Start();
        }


        private void MostrarGraficoResumen(decimal montoTotal, int cantidadVentas, int librosVendidos, decimal ticketPromedio)
        {
            chartResumenVenta.Series.Clear();
            chartResumenVenta.Titles.Clear();
            chartResumenVenta.ChartAreas.Clear();
            chartResumenVenta.Legends.Clear(); 

            chartResumenVenta.Titles.Add($"Resumen de Ventas ({dtpFechaInicio.Value:dd/MM/yyyy} - {dtpFechaFin.Value:dd/MM/yyyy})");

           
            ChartArea areaMonetaria = new ChartArea("AreaMonetaria");
            ChartArea areaConteo = new ChartArea("AreaConteo");

         
            
            areaConteo.AlignWithChartArea = "AreaMonetaria";
            areaConteo.AlignmentOrientation = AreaAlignmentOrientations.Vertical;

          

            // Añadimos ambas áreas al control del gráfico
            chartResumenVenta.ChartAreas.Add(areaMonetaria);
            chartResumenVenta.ChartAreas.Add(areaConteo);


            
            Series serieMonetaria = new Series("Monetario");
            serieMonetaria.ChartType = SeriesChartType.Bar;
            serieMonetaria.IsValueShownAsLabel = true;
            serieMonetaria.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            serieMonetaria.LabelForeColor = Color.Black;
            serieMonetaria.ChartArea = "AreaMonetaria"; 

            Series serieConteo = new Series("Conteo");
            serieConteo.ChartType = SeriesChartType.Bar;
            serieConteo.IsValueShownAsLabel = true;
            serieConteo.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            serieConteo.LabelForeColor = Color.Black;
            serieConteo.ChartArea = "AreaConteo"; 

            

            // Puntos de la Serie Monetaria
            serieMonetaria.Points.AddXY("Monto Total", montoTotal);
            serieMonetaria.Points.AddXY("Ticket Promedio", ticketPromedio);
            serieMonetaria.Points[0].Color = Color.FromArgb(119, 158, 203); // Azul Pastel
            serieMonetaria.Points[1].Color = Color.FromArgb(179, 226, 221); // Menta Pastel

            
            serieConteo.Points.AddXY("Ventas", cantidadVentas);
            serieConteo.Points.AddXY("Libros", librosVendidos);
            serieConteo.Points[0].Color = Color.FromArgb(255, 179, 186); // Rosa Pastel
            serieConteo.Points[1].Color = Color.FromArgb(255, 223, 186); // Durazno Pastel

            
            chartResumenVenta.Series.Add(serieMonetaria);
            chartResumenVenta.Series.Add(serieConteo);


           
            foreach (ChartArea area in chartResumenVenta.ChartAreas)
            {
                area.AxisX.Title = "Indicadores";
                area.AxisY.Title = "Valores";
                area.AxisX.Interval = 1;
                area.AxisY.LabelStyle.Format = "N0"; 
                area.AxisX.MajorGrid.Enabled = false; 
                area.AxisY.MajorGrid.Enabled = true;  
                area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            }
        }



        // --- Animación de contadores ---
        private void TimerContadores_Tick(object sender, EventArgs e)
        {
            
            decimal speed = 0.2m; // velocidad de acercamiento al valor final 

            // Actualizar los valores actuales acercándolos al objetivo
            currentMontoTotal += (targetMontoTotal - currentMontoTotal) * speed;
            currentTransferencia += (targetTransferencia - currentTransferencia) * speed;
            currentEfectivo += (targetEfectivo - currentEfectivo) * speed;
            currentDebito += (targetDebito - currentDebito) * speed;
            currentAnuladas += (targetAnuladas - currentAnuladas) * speed;

            // Mostrar valores actualizados
            lblMontoTotal.Text = currentMontoTotal.ToString("C2");
            lblTransferencia.Text = currentTransferencia.ToString("C2");
            lblEfectivo.Text = currentEfectivo.ToString("C2");
            lblDebito.Text = currentDebito.ToString("C2");
            lblTotalAnuladas.Text = Math.Round(currentAnuladas).ToString("00");

            // Si todos están suficientemente cerca del objetivo, fijar valores exactos y detener timer
            if (Math.Abs(targetMontoTotal - currentMontoTotal) < 1 &&
                Math.Abs(targetTransferencia - currentTransferencia) < 1 &&
                Math.Abs(targetEfectivo - currentEfectivo) < 1 &&
                Math.Abs(targetDebito - currentDebito) < 1 &&
                Math.Abs(targetAnuladas - currentAnuladas) < 0.1m)
            {
                lblMontoTotal.Text = targetMontoTotal.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                lblTransferencia.Text = targetTransferencia.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                lblEfectivo.Text = targetEfectivo.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                lblDebito.Text = targetDebito.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                lblTotalAnuladas.Text = targetAnuladas.ToString("00");
                timerContadores.Stop();
            }
        }

        private void CargarReporteTopClientes()
        {
           
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;

            CN_ReporteAdmin cn_reportes = new CN_ReporteAdmin();
            DataTable dt = cn_reportes.ReporteTop5Clientes(fechaInicio, fechaFin);

            // 2. Asignamos los datos a la grilla
            // (Asumo que tu grilla se llama dgvTopClientes)
            dgvTopClientes.DataSource = dt;

            // 3. Llamamos al método de estilo
            EstilizarGridTopClientes();
        }

        // (Asegúrate de tener "using System.Drawing;" al inicio)

        private void EstilizarGridTopClientes()
        {
            // --- Estilo General (fondo, líneas, etc.) ---
            dgvTopClientes.BorderStyle = BorderStyle.None;
            dgvTopClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTopClientes.GridColor = Color.FromArgb(235, 235, 235);
            dgvTopClientes.AllowUserToAddRows = false;
            dgvTopClientes.AllowUserToDeleteRows = false;
            dgvTopClientes.ReadOnly = true;
            dgvTopClientes.RowHeadersVisible = false;
            dgvTopClientes.BackgroundColor = Color.White;
            dgvTopClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopClientes.RowTemplate.Height = 30;

            // --- Estilo de Encabezados (Headers) ---
            dgvTopClientes.EnableHeadersVisualStyles = false;
            dgvTopClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTopClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvTopClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvTopClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvTopClientes.ColumnHeadersHeight = 35;

            // --- Estilo de Filas ---
            dgvTopClientes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTopClientes.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvTopClientes.RowsDefaultCellStyle.ForeColor = Color.DimGray;
            dgvTopClientes.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 250);
            dgvTopClientes.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // --- Ajuste de Columnas (basado en tu SP) ---
            if (dgvTopClientes.Columns["id_cliente"] != null)
                dgvTopClientes.Columns["id_cliente"].Visible = false; // Oculto

            if (dgvTopClientes.Columns["Cliente"] != null)
                dgvTopClientes.Columns["Cliente"].FillWeight = 40; // 40%

            if (dgvTopClientes.Columns["CantidadCompras"] != null)
            {
                dgvTopClientes.Columns["CantidadCompras"].HeaderText = "Compras";
                dgvTopClientes.Columns["CantidadCompras"].FillWeight = 25;
                dgvTopClientes.Columns["CantidadCompras"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTopClientes.Columns["CantidadCompras"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvTopClientes.Columns["PromedioGasto"] != null)
            {
                dgvTopClientes.Columns["PromedioGasto"].HeaderText = "Gasto Promedio";
                dgvTopClientes.Columns["PromedioGasto"].FillWeight = 35;
                dgvTopClientes.Columns["PromedioGasto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTopClientes.Columns["PromedioGasto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // --- Conectamos el evento para formatear el dinero ---
            dgvTopClientes.CellFormatting -= dgvTopClientes_CellFormatting;
            dgvTopClientes.CellFormatting += dgvTopClientes_CellFormatting;
        }


        // MÉTODO 3: El que formatea el dinero (el "$")
        private void dgvTopClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Solo nos interesa la columna "PromedioGasto"
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvTopClientes.Columns[e.ColumnIndex].Name != "PromedioGasto")
            {
                return;
            }

            if (e.Value != null && e.Value != DBNull.Value)
            {
                decimal monto = (decimal)e.Value;

                // Formateamos como moneda (ej: $14,166.67)
                e.Value = monto.ToString("C2", CultureInfo.GetCultureInfo("es-AR"));
                e.FormattingApplied = true;
            }
        }

    }
}