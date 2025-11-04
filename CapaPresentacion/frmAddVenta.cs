using CapaEntidad;
using CapaNegocio;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class frmAddVenta : Form
    {
        private Usuario usuarioLogueado; 
        private CN_Cliente oCNCliente = new CN_Cliente(); 

        private Venta ventaActual;
        private CN_Venta oCNVenta = new CN_Venta();
        private CN_Promocion oCNPromocion = new CN_Promocion();
        private CN_Libros oCNLibro = new CN_Libros(); 

        

        public frmAddVenta(Usuario objusuarios)
        {
            this.usuarioLogueado = objusuarios;
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            CultureInfo cultura = new CultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;

            // Inicializar objeto Venta
            ventaActual = new Venta
            {
                oCliente = null,
                oUsuario = usuarioLogueado,
                oDetalleVenta = new List<Detalle_venta>(),
                oPagos = new List<Pagos>(),
                oPromocionesAplicadas = new List<VentaPromocion>(),
                fecha = DateTime.Now.ToString("yyyyMMdd")
            };


            var controlsToRemove = fpnlPagos.Controls.OfType<System.Windows.Forms.Control>()
                                     .Where(c => c.Tag?.ToString() == "PAGO_DINAMICO")
                                     .ToList();

            foreach (var control in controlsToRemove)
            {
                fpnlPagos.Controls.Remove(control);
            }

            dtpVenta.Value = DateTime.Now;
            txtMontoPago.Text = "0";
            txtBuscarLibro.Text = string.Empty;

            CargarMediosPago();
            CargarTipoDocumento();
            ActualizarGrilla();
            ActualizarResumen();
            // Asociar eventos (si no están asociados desde designer)
            btnAgregar.Click += BtnAgregar_Click;
            btnAgregarPago.Click += BtnAgregarPago_Click;
            BGuardar.Click += BGuardar_Click;
            BEliminar.Click += BEliminar_Click;
            btnBuscarCliente.Click += BtnBuscarCliente_Click;
            btnBuscarLibro.Click += BtnBuscarLibro_Click;

        }

        private void CargarTipoDocumento()
        {
            // Valores por defecto para tipo doc (podés adaptar)
            cboTipoDoc.Items.Clear();
            cboTipoDoc.Items.Add("Factura A");
            cboTipoDoc.Items.Add("Factura B");
            cboTipoDoc.Items.Add("Factura C");
            cboTipoDoc.SelectedIndex = 0;
        }

        private void CargarMediosPago()
        {
            try
            {
                var items = oCNPromocion.ObtenerItemsAsociados("medio_pago");
                cboMedioPago.DisplayMember = "Descripcion";
                cboMedioPago.ValueMember = "Id";
                cboMedioPago.DataSource = items;
            }
            catch
            {
                // Si no existe DB o método, cargar manualmente ejemplos
                cboMedioPago.Items.Clear();
                cboMedioPago.Items.Add(new ItemDescuento { Id = 1, Descripcion = "Efectivo" });
                cboMedioPago.Items.Add(new ItemDescuento { Id = 2, Descripcion = "Tarjeta Débito" });
                cboMedioPago.Items.Add(new ItemDescuento { Id = 3, Descripcion = "Tarjeta Crédito" });
                cboMedioPago.DisplayMember = "Descripcion";
                cboMedioPago.ValueMember = "Id";
            }
        }

        // --- EVENTOS UI ---

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Usamos txtCuit como campo de entrada
            if (string.IsNullOrWhiteSpace(txtCuit.Text) || !long.TryParse(txtCuit.Text, out long dni))
            {
                MessageBox.Show("Ingrese un CUIT válido para buscar al cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CN_Cliente oCNCliente = new CN_Cliente();
            Cliente c = oCNCliente.ObtenerClientePorDNI(dni);

            if (c != null)
            {
                // Si existe → cargar en la venta
                ventaActual.oCliente = c;
                txtNombreCliente.Text = c.nombre + " " + c.apellido;
            }
            else
            {
                // No existe
                MessageBox.Show("El cliente no está registrado. Proceda a registrarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBuscarLibro_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscarLibro.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                MessageBox.Show("Ingrese parte del título del libro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultados = oCNLibro.BuscarPorNombre(textoBusqueda);

            if (resultados.Count == 0)
            {
                MessageBox.Show("No se encontró ningún libro con ese nombre.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Si solo hay un resultado, cargar directo
            if (resultados.Count == 1)
            {
                CargarLibroEnFormulario(resultados.First());
                return;
            }

            // Si hay varios → mostrar ventana simple para elegir
            Form selector = new Form();
            selector.Text = "Seleccionar Libro";
            selector.StartPosition = FormStartPosition.CenterParent;
            selector.Width = 400;
            selector.Height = 300;

            ListBox list = new ListBox();
            list.Dock = DockStyle.Fill;
            list.DataSource = resultados;
            list.DisplayMember = "titulo";

            Button btnSeleccionar = new Button();
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.Dock = DockStyle.Bottom;
            btnSeleccionar.Height = 35;

            btnSeleccionar.Click += (s2, e2) =>
            {
                if (list.SelectedItem != null)
                {
                    CargarLibroEnFormulario((Libros)list.SelectedItem);
                    selector.Close();
                }
            };

            selector.Controls.Add(list);
            selector.Controls.Add(btnSeleccionar);

            selector.ShowDialog();
        }


        private void CargarLibroEnFormulario(Libros l)
        {
            txtIdProducto.Text = l.id_libro.ToString();
            txtNombreLibro.Text = l.titulo;
            txtPrecio.Text = l.precio_libro.ToString("0.00", CultureInfo.InvariantCulture);
            txtStock.Text = l.stock_libro.ToString();
            nudCantidad.Value = 1;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Agregar libro a la venta (tomando los campos de la UI)
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
            {
                MessageBox.Show("Seleccioná un libro antes de agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtIdProducto.Text, out int idLibro))
            {
                MessageBox.Show("ID de libro inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(nudCantidad.Value.ToString(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingresá una cantidad válida (mayor a 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Stock inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad > stock)
            {
                MessageBox.Show($"Stock insuficiente. Stock actual: {stock}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal precio))
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto detalle
            var libro = new Libros
            {
                id_libro = idLibro,
                titulo = txtNombreLibro.Text,
                precio_libro = precio,
                stock_libro = stock
            };

            // Si ya existe el libro en la lista, incrementar cantidad
            var existente = ventaActual.oDetalleVenta.FirstOrDefault(d => d.oLibro.id_libro == idLibro);
            if (existente != null)
            {
                if (existente.cantidad + cantidad > stock)
                {
                    MessageBox.Show($"No hay stock suficiente para agregar esa cantidad. Stock: {stock}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existente.cantidad += cantidad;
            }
            else
            {
                ventaActual.oDetalleVenta.Add(new Detalle_venta
                {
                    oLibro = libro,
                    cantidad = cantidad,
                    precio_unitario = precio,
                    descuento_aplicado = 0,
                    subtotal_linea = precio * cantidad
                });
            }

            // Limpiar campos de producto (opcional)
            txtIdProducto.Text = "";
            txtNombreLibro.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            nudCantidad.Value = 1;

            ActualizarGrilla();
            ActualizarResumen();
        }


        private void BtnAgregarPago_Click(object sender, EventArgs e)
        {
            // Agregar pago a la lista
            if (cboMedioPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un medio de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMontoPago.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingresá un monto de pago válido (mayor a 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = (ItemDescuento)cboMedioPago.SelectedItem;
            var medio = new Medio_de_pago
            {
                id_medio_de_pago = item.Id,
                descripcion = item.Descripcion
            };

            // Agrego a la lista de pagos
            vendaAgregarPago(medio, monto);
            txtMontoPago.Text = "0";
            ActualizarResumen();
        }

        private void vendaAgregarPago(Medio_de_pago medio, decimal monto)
        {
            var pago = new Pagos
            {
                oMedio_De_Pago = medio,
                monto = monto,
                fecha_pago = DateTime.Now.ToString("yyyyMMdd"),
                descuento_medio_pago = 0
            };

            ventaActual.oPagos.Add(pago);

            // Mostrar en la UI (fpnlPagos) un control representando ese pago con opción de eliminar
            var pnl = new Panel
            {
                Width = fpnlPagos.Width - 25,
                Height = 30,
                Tag = "PAGO_DINAMICO"
            };

            var lbl = new Label
            {
                Text = $"{medio.descripcion}: {monto:C}",
                AutoSize = false,
                Width = pnl.Width - 60,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Left = 0
            };

            var btnQuitar = new Button
            {
                Text = "X",
                Width = 25,
                Height = 22,
                Left = pnl.Width - 30,
                Top = 3,
                Tag = pago
            };
            btnQuitar.Click += (s, e) =>
            {
                var p = (Pagos)((Button)s).Tag;
                ventaActual.oPagos.Remove(p);
                fpnlPagos.Controls.Remove(pnl);
                ActualizarResumen();
            };

            pnl.Controls.Add(lbl);
            pnl.Controls.Add(btnQuitar);
            fpnlPagos.Controls.Add(pnl);

            
            
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (ventaActual.oCliente == null || ventaActual.oCliente.id_cliente == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ventaActual.oDetalleVenta == null || ventaActual.oDetalleVenta.Count == 0)
            {
                MessageBox.Show("La venta no tiene ítems.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Asegurarse de recalcular promociones y totales localmente antes de enviar
            AplicarPromocionesLocal(ventaActual);

            decimal sumaPagos = ventaActual.oPagos.Sum(p => p.monto);
            if (sumaPagos < ventaActual.total)
            {
                MessageBox.Show($"El monto total de pagos ({sumaPagos:C}) es menor al total a pagar ({ventaActual.total:C}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pasar valores adicionales al objeto venta
            ventaActual.oUsuario = usuarioLogueado;
            ventaActual.fecha = dtpVenta.Value.ToString("yyyyMMdd");

            string mensaje;
            int idVenta = oCNVenta.RegistrarVenta(ventaActual, out mensaje);
            if (idVenta > 0)
            {
                MessageBox.Show($"Venta registrada correctamente. N° {idVenta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult resultado = MessageBox.Show($"¿Desea descargar la factura de la venta N° {idVenta}?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    CN_FacturaPDF oPDF = new CN_FacturaPDF();
                    string ruta = oPDF.GenerarFacturaPDF(ventaActual, idVenta);

                    if (ruta != "CANCELADO" && !ruta.StartsWith("ERROR"))
                    {
                        MessageBox.Show($"Factura guardada en:\n{ruta}", "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Resetear formulario para nueva venta
                Inicializar();
            }
            else
            {
                MessageBox.Show($"No se pudo registrar la venta. {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            Inicializar();
        }

        // --- UTILIDADES UI ---

        private void ActualizarGrilla()
        {
            dgvLibros.Rows.Clear();
            foreach (var d in ventaActual.oDetalleVenta)
            {
                // calcular subtotal de linea y mostrar descuento por item (si ya calculado)
                decimal subtotalLinea = d.precio_unitario * d.cantidad;
                decimal descuentoItem = d.descuento_aplicado;
                decimal netoLinea = subtotalLinea - descuentoItem;

                dgvLibros.Rows.Add(
                    d.oLibro.id_libro,
                    d.oLibro.titulo,
                    d.precio_unitario.ToString("0.00", CultureInfo.InvariantCulture),
                    d.cantidad,
                    subtotalLinea.ToString("0.00", CultureInfo.InvariantCulture),
                    descuentoItem.ToString("0.00", CultureInfo.InvariantCulture),
                    netoLinea.ToString("0.00", CultureInfo.InvariantCulture)
                );
            }
        }

        private void ActualizarResumen()
        {
            // Recalcular promociones localmente para mostrar al usuario
            AplicarPromocionesLocal(ventaActual);

            // Mostrar totales en la UI (podés agregar labels para mostrar subtotal, descuentos, total)
            decimal subtotal = ventaActual.subtotal;
            decimal descuentos = ventaActual.descuento_total;
            decimal total = ventaActual.total;
            decimal totalPagado = ventaActual.oPagos.Sum(p => p.monto);
            decimal vuelto = totalPagado - ventaActual.total;

            lblSubtotal.Text = $"Subtotal: {subtotal:C}";
            lblDescuentos.Text = $"Descuentos: {descuentos:C}";
            lblTotal.Text = $"Total: {total:C}";

            if (vuelto < 0)
            {
                lblVuelto.Text = "Vuelto: $0.00";
            }
            else {
                lblVuelto.Text = $"Vuelto: {vuelto:C}";
            }

        }

        // --- Lógica local para aplicar promociones (mismo comportamiento que CN_Venta.AplicarPromocionesYCalcularTotales) ---
        private void AplicarPromocionesLocal(Venta oVenta)
        {
            // Obtener promociones activas y vigentes
            List<Promocion> promosActivas = oCNPromocion.Listar()
                .Where(p => p.Estado && p.FechaInicio.Date <= DateTime.Now.Date && p.FechaFin.Date >= DateTime.Now.Date).ToList();

            // Separar promociones por tipo
            var promosItem = promosActivas.Where(p => p.Tipo == "libro" || p.Tipo == "categoria" || p.Tipo == "autor").ToList();
            var promosMedioPago = promosActivas.Where(p => p.Tipo == "medio_pago").ToList();

            oVenta.subtotal = 0;
            oVenta.descuento_total = 0;
            oVenta.oPromocionesAplicadas = new List<VentaPromocion>();

            // 1. Descuentos por ítem
            foreach (var detalle in oVenta.oDetalleVenta)
            {
                detalle.precio_unitario = detalle.oLibro.precio_libro;
                detalle.subtotal_linea = detalle.precio_unitario * detalle.cantidad;
                detalle.descuento_aplicado = 0;

                Promocion mejorPromoItem = null;

                var promoLibro = promosItem.FirstOrDefault(p => p.Tipo == "libro" && p.IdItemAsociado == detalle.oLibro.id_libro);
                var promoCategoria = (detalle.oLibro.oCategoria != null) ? promosItem.FirstOrDefault(p => p.Tipo == "categoria" && detalle.oLibro.oCategoria.id_categoria == p.IdItemAsociado) : null;
                var promoAutor = (detalle.oLibro.oAutor != null) ? promosItem.FirstOrDefault(p => p.Tipo == "autor" && detalle.oLibro.oAutor.id_autor == p.IdItemAsociado) : null;

                if (promoLibro != null) mejorPromoItem = promoLibro;
                else if (promoCategoria != null) mejorPromoItem = promoCategoria;
                else if (promoAutor != null) mejorPromoItem = promoAutor;

                if (mejorPromoItem != null)
                {
                    decimal descuentoMonto = detalle.subtotal_linea * mejorPromoItem.ValorDescuento / 100M;
                    detalle.descuento_aplicado = descuentoMonto;
                    oVenta.descuento_total += descuentoMonto;

                    if (oVenta.oPromocionesAplicadas.All(p => p.IdPromocion != mejorPromoItem.IdPromocion))
                    {
                        oVenta.oPromocionesAplicadas.Add(new VentaPromocion
                        {
                            IdPromocion = mejorPromoItem.IdPromocion,
                            MontoDescuento = descuentoMonto,
                            NombrePromocion = mejorPromoItem.Nombre,
                            TipoPromocion = mejorPromoItem.Tipo
                        });
                    }
                    else
                    {
                        oVenta.oPromocionesAplicadas.First(p => p.IdPromocion == mejorPromoItem.IdPromocion).MontoDescuento += descuentoMonto;
                    }
                }

                oVenta.subtotal += detalle.subtotal_linea;
            }

            // 2. Descuentos por medio de pago
            decimal descuentoMedioPagoTotal = 0;
            foreach (var pago in oVenta.oPagos)
            {
                Promocion promoMedioPago = promosMedioPago.FirstOrDefault(p => p.Tipo == "medio_pago" && p.IdItemAsociado == pago.oMedio_De_Pago.id_medio_de_pago);
                if (promoMedioPago != null)
                {
                    decimal descuentoMonto = pago.monto * promoMedioPago.ValorDescuento / 100M;
                    pago.descuento_medio_pago = descuentoMonto;
                    descuentoMedioPagoTotal += descuentoMonto;

                    if (oVenta.oPromocionesAplicadas.All(p => p.IdPromocion != promoMedioPago.IdPromocion))
                    {
                        oVenta.oPromocionesAplicadas.Add(new VentaPromocion
                        {
                            IdPromocion = promoMedioPago.IdPromocion,
                            MontoDescuento = descuentoMonto,
                            NombrePromocion = promoMedioPago.Nombre,
                            TipoPromocion = promoMedioPago.Tipo
                        });
                    }
                    else
                    {
                        oVenta.oPromocionesAplicadas.First(p => p.IdPromocion == promoMedioPago.IdPromocion).MontoDescuento += descuentoMonto;
                    }
                }
            }

            oVenta.descuento_total += descuentoMedioPagoTotal;
            oVenta.total = oVenta.subtotal - oVenta.descuento_total;

            // Actualizar grilla (mostrar descuentos por item)
            ActualizarGrilla();
        }

        private void dgvLibros_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 7)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.trash.Width;
                var h = Properties.Resources.trash.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.trash, new Rectangle(x, y, w, h));
                e.Handled = true;

            }
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLibros.Columns[e.ColumnIndex].Name == "btnEliminar" && e.RowIndex >= 0)
            {
                int idLibro = Convert.ToInt32(dgvLibros.Rows[e.RowIndex].Cells["ID_Libro"].Value);

                var item = ventaActual.oDetalleVenta.FirstOrDefault(d => d.oLibro.id_libro == idLibro);

                if(item != null) {
                    ventaActual.oDetalleVenta.Remove(item);
                }

                ActualizarGrilla();
                ActualizarResumen();
            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMontoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}


