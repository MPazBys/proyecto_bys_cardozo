using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDetalleVenta : Form
    {
        private int idVentaBuscada = 0;

        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // 2. BOTÓN DE BÚSQUEDA
        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            int idVenta;
            if (!int.TryParse(txtNroIdVenta.Text, out idVenta))
            {
                MessageBox.Show("Por favor, ingrese un número de venta válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Llamada a la Lógica de Negocio ---
            CN_Venta cn_venta = new CN_Venta();
            DataSet dsVenta = cn_venta.ObtenerVentaCompleta(idVenta);

            if (dsVenta == null || dsVenta.Tables.Count < 3 || dsVenta.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ninguna venta con ese número.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarFormulario(); // Resetea el formulario
                return;
            }

            // --- Si encontramos la venta, llenamos los campos ---

            // Tabla 0: Info de Venta
            DataRow drVenta = dsVenta.Tables[0].Rows[0];
            txtFecha.Text = ((DateTime)drVenta["fecha"]).ToString("dd/MM/yyyy");
            txtTipoDoc.Text = drVenta["tipo_doc"].ToString();
            txtUsuario.Text = drVenta["NombreVendedor"].ToString();
            txtCUITCliente.Text = drVenta["CuitCliente"].ToString();
            txtRazonSocial.Text = drVenta["NombreCliente"].ToString();

            // Tabla 1: Detalle de Productos
            dgvDetalleVenta.DataSource = dsVenta.Tables[1];

            // Llenamos los totales
            decimal total = Convert.ToDecimal(drVenta["total"]);

            txtMontoTotal.Text = total.ToString("C2", new CultureInfo("es-AR")); // $

            decimal montoPagado = 0;
            foreach (DataRow drPago in dsVenta.Tables[2].Rows)
            {
                montoPagado += Convert.ToDecimal(drPago["monto"]);
            }
            txtMontoPago.Text = montoPagado.ToString("C2", new CultureInfo("es-AR")); // $

            // Calculamos el cambio (vuelto)
            decimal cambio = montoPagado - total;
            txtMontoCambio.Text = cambio.ToString("C2", new CultureInfo("es-AR")); // $

            // --- GESTIÓN DE ESTADO (Tu código está perfecto) ---
            idVentaBuscada = idVenta;
            bool ventaActiva = (bool)drVenta["estado"];

            if (ventaActiva)
            {
                btnAnularVenta.Enabled = true;
                btnDescargarFactura.Enabled = true;
            }
            else
            {
                btnAnularVenta.Enabled = false;
                MessageBox.Show("Esta venta se encuentra ANULADA.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Bloqueamos los controles de búsqueda
            txtNroIdVenta.Enabled = false;
            btnBuscar.Enabled = false;
            btnLimpiar.Enabled = true;
        }

        // 3. BOTÓN LIMPIAR
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // 4. FUNCIÓN AYUDANTE (HELPER)
        private void LimpiarFormulario()
        {
            // Limpia todos los campos
            txtNroIdVenta.Text = "";
            txtFecha.Text = "";
            // (Limpia también Tipo Documento, Usuario, CUIT, Razón Social)
            txtTipoDoc.Text = "";
            txtUsuario.Text = "";
            txtCUITCliente.Text = "";
            txtRazonSocial.Text = "";

            // Limpia la grilla
            dgvDetalleVenta.DataSource = null;

            // Limpia los totales
            txtMontoTotal.Text = "0.00";
            txtMontoPago.Text = "0.00";
            txtMontoCambio.Text = "0.00";

            // Resetea el estado
            idVentaBuscada = 0;
            btnAnularVenta.Enabled = false;
            btnLimpiar.Enabled = false;

            // Habilita la búsqueda
            txtNroIdVenta.Enabled = true;
            btnBuscar.Enabled = true;

            // Pone el foco listo para buscar
            txtNroIdVenta.Focus();
        }

        private void btnAnularVenta_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya una venta cargada
            if (idVentaBuscada == 0)
            {
                MessageBox.Show("Primero debe buscar una venta válida.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedimos confirmación (¡Acción destructiva!)
            DialogResult dr = MessageBox.Show(
                $"¿Está seguro de que desea ANULAR la venta Nro: {idVentaBuscada}?\n\n" +
                "Esta acción devolverá el stock de los productos al inventario.",
                "Confirmar Anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // 3. Llamamos a la Capa de Negocio (que ya tienes hecha)
                string mensaje = string.Empty;
                // Asumo que tu CN se llama CN_Venta
                CN_Venta cn_venta = new CN_Venta();

                bool exito = cn_venta.AnularVenta(idVentaBuscada, out mensaje);

                // 4. Mostramos el resultado (ya sea de éxito o error)
                MessageBox.Show(mensaje, "Resultado de Anulación",
                    MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                // 5. Si salió bien, limpiamos el formulario
                if (exito)
                {
                    LimpiarFormulario(); // (Llamamos a tu función de limpiar)
                }
            }
        }

        private void btnDescargarFactura_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya una venta cargada
            if (idVentaBuscada == 0)
            {
                MessageBox.Show("Primero debe buscar una venta válida.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Confirmación de descarga de factura
            CN_Venta cn_venta = new CN_Venta();
            DataSet dsVenta = cn_venta.ObtenerVentaCompleta(idVentaBuscada);
            Venta venta = ConvertirDataSetAVenta(dsVenta, idVentaBuscada);

            DialogResult resultado = MessageBox.Show($"¿Desea descargar la factura de la venta N° {idVentaBuscada}?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                CN_FacturaPDF oPDF = new CN_FacturaPDF();
                string ruta = oPDF.GenerarFacturaPDF(venta, idVentaBuscada);

                if (ruta != "CANCELADO" && !ruta.StartsWith("ERROR"))
                {
                    MessageBox.Show($"Factura guardada en:\n{ruta}", "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
            }
        }

        public Venta ConvertirDataSetAVenta(DataSet ds, int idVenta)
        {
            Venta venta = new Venta();

            // ================= TABLA 0 → ENCABEZADO =================
            DataRow v = ds.Tables[0].Rows[0];

            venta.id_venta = idVenta;
            venta.fecha = v["fecha"].ToString();
            venta.subtotal = Convert.ToDecimal(v["subtotal"]);
            venta.descuento_total = Convert.ToDecimal(v["descuento_total"]);
            venta.total = Convert.ToDecimal(v["total"]);
            venta.estado = Convert.ToBoolean(v["estado"]);
            venta.tipo_doc = v["tipo_doc"].ToString(); // si agregaste la propiedad

            // ----- Cliente -----
            venta.oCliente = new Cliente()
            {
                nombre = v["NombreCliente"].ToString(),
                apellido = "", // no viene en el SP, si lo querés traer: agregarlo
                dni = Convert.ToInt64(v["CuitCliente"])
            };

            // ----- Usuario (Vendedor) -----
            venta.oUsuario = new Usuario()
            {
                nombre = v["NombreVendedor"].ToString(),
                apellido = ""
            };

            // ================= TABLA 1 → DETALLE =================
            venta.oDetalleVenta = new List<Detalle_venta>();

            foreach (DataRow d in ds.Tables[1].Rows)
            {
                venta.oDetalleVenta.Add(new Detalle_venta()
                {
                    oLibro = new Libros()
                    {
                        titulo = d["Libro"].ToString()
                    },
                    precio_unitario = Convert.ToDecimal(d["Precio Unitario"]),
                    cantidad = Convert.ToInt32(d["Cantidad"]),
                    descuento_aplicado = Convert.ToDecimal(d["Desc. Ítem"]),
                    subtotal_linea = Convert.ToDecimal(d["Sub Total"]) // (precio_unitario * cantidad)
                });
            }

            // ================= TABLA 2 → PAGOS =================
            venta.oPagos = new List<Pagos>();

            foreach (DataRow p in ds.Tables[2].Rows)
            {
                venta.oPagos.Add(new Pagos()
                {
                    oMedio_De_Pago = new Medio_de_pago()
                    {
                        descripcion = p["MedioDePago"].ToString()
                    },
                    monto = Convert.ToDecimal(p["monto"]),
                    fecha_pago = Convert.ToDateTime(p["fecha_pago"]).ToString("dd/MM/yyyy")
                });
            }

            // --- 4) PROMOCIONES (LA NUEVA PARTE) ---
            if (ds.Tables.Count > 3)
            {
                DataTable dtPromos = ds.Tables[3];
                venta.oPromocionesAplicadas = new List<VentaPromocion>();

                foreach (DataRow row in dtPromos.Rows)
                {
                    venta.oPromocionesAplicadas.Add(new VentaPromocion
                    {
                        IdVenta = Convert.ToInt32(row["id_venta"]),
                        IdPromocion = Convert.ToInt32(row["id_promocion"]),
                        NombrePromocion = row["NombrePromocion"].ToString(),
                        TipoPromocion = row["TipoPromocion"].ToString(),
                        MontoDescuento = Convert.ToDecimal(row["MontoDescuento"])
                    });
                }
            }

            return venta;
        }
    }
}
