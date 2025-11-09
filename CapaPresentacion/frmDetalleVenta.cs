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

       
    }
}
