using CapaEntidad;
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
        private decimal targetMontoTotal, targetTransferencia, targetEfectivo, targetDebito;
        private decimal currentMontoTotal, currentTransferencia, currentEfectivo, currentDebito;
        private Timer timerContadores = new Timer();

        private readonly Usuario _usuarioLogueado;
        public frmReporteVendedor(Usuario objusuarios)
        {
            this._usuarioLogueado = objusuarios;
            InitializeComponent();


            // Configuración Timer
            timerContadores.Interval = 20; // Velocidad de animación en ms
            timerContadores.Tick += TimerContadores_Tick;

            // Configurar ComboBox de periodos
            cmbPeriodo.Items.AddRange(new string[] { "Hoy", "Esta Semana", "Este Mes", "Este Año", "Personalizado" });
            cmbPeriodo.SelectedIndex = 0; // Por defecto "Hoy"
            ActualizarFechasPorPeriodo(cmbPeriodo.SelectedItem.ToString());

            CargarTop5Clientes();
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

        }


        // --- Cargar datos desde SP y preparar animación ---

        private void CargarReporte()
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1); // Incluye todo el día

            // Reiniciar contadores
            targetMontoTotal = targetTransferencia = targetEfectivo = targetDebito = 0;

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
            }

            // Reiniciar contadores actuales
            currentMontoTotal = currentTransferencia = currentEfectivo = currentDebito = 0;

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

            // Mostrar valores actualizados
            lblMontoTotal.Text = currentMontoTotal.ToString("C2");
            lblTransferencia.Text = currentTransferencia.ToString("C2");
            lblEfectivo.Text = currentEfectivo.ToString("C2");
            lblDebito.Text = currentDebito.ToString("C2");

            // Si todos están suficientemente cerca del objetivo, fijar valores exactos y detener timer
            if (Math.Abs(targetMontoTotal - currentMontoTotal) < 1 &&
                Math.Abs(targetTransferencia - currentTransferencia) < 1 &&
                Math.Abs(targetEfectivo - currentEfectivo) < 1 &&
                Math.Abs(targetDebito - currentDebito) < 1)
            {
                lblMontoTotal.Text = targetMontoTotal.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                lblTransferencia.Text = targetTransferencia.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                lblEfectivo.Text = targetEfectivo.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                lblDebito.Text = targetDebito.ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
                timerContadores.Stop();
            }
        }

        private void CargarTop5Clientes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Top5ClientesFrecuentes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Mostrar en DataGridView 
                dgvTopClientes.DataSource = dt;
            }


        }

    }
}