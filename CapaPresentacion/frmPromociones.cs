using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPromociones : Form
    {
        private CN_Promocion cnPromocion = new CN_Promocion();
        private Promocion promocionSeleccionada = null; // Para guardar la fila seleccionada

        public frmPromociones()
        {
            InitializeComponent();
        }

        private void frmPromociones_Load(object sender, EventArgs e)
        {
            // ======================================
            // 1. Configuración de ComboBox de Tipo
            // ======================================
            // USANDO CapaPresentacion.Utilidades.OpcionCombo
            cboTipoDescuento.Items.Add(new OpcionCombo() { Valor = "general", Texto = "General (a toda venta)" });
            cboTipoDescuento.Items.Add(new OpcionCombo() { Valor = "libro", Texto = "Por Libro" });
            cboTipoDescuento.Items.Add(new OpcionCombo() { Valor = "categoria", Texto = "Por Categoría" });
            cboTipoDescuento.Items.Add(new OpcionCombo() { Valor = "autor", Texto = "Por Autor" });
            cboTipoDescuento.Items.Add(new OpcionCombo() { Valor = "medio_pago", Texto = "Por Medio de Pago" });

            cboTipoDescuento.DisplayMember = "Texto";
            cboTipoDescuento.ValueMember = "Valor";
            cboTipoDescuento.SelectedIndex = 0; // Seleccionar 'General' por defecto

            // ======================================
            // 2. Configuración de ComboBox de Búsqueda
            // ======================================
            cboBusqueda.Items.Add(new OpcionCombo() { Valor = "Nombre", Texto = "Nombre" });
            cboBusqueda.Items.Add(new OpcionCombo() { Valor = "TipoDescuento", Texto = "Tipo de Descuento" });

            // AÑADIR NUEVA OPCIÓN DE BÚSQUEDA:
            cboBusqueda.Items.Add(new OpcionCombo() { Valor = "ItemAsociado", Texto = "Item Asociado" });

            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            // ======================================
            // 3. Cargar la lista inicial de promociones
            // ======================================
            CargarPromociones();

            
        }


        // =================================================================
        // MÉTODOS DE LÓGICA DE NEGOCIO Y UI
        // =================================================================

        private void CargarPromociones()
        {
            dgvdata.Rows.Clear();
            List<Promocion> lista = cnPromocion.Listar();

            foreach (Promocion p in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    "", // Índice 0: Botón
                    p.IdPromocion, // Índice 1: IdPromocion
                    p.Nombre, // Índice 2
                    p.Tipo, // Índice 3
                    p.DescripcionItemAsociado, //Índice 4
                    p.ValorDescuento, // Índice 5
                    p.FechaInicio.ToString("d"), // Índice 6
                    p.FechaFin.ToString("d"), // Índice 7
                    p.Estado, // Índice 8: EstadoValor
                    p.Estado ? "Activado" : "Desactivado", // Índice 9: Estado
                    p.IdItemAsociado // Índice 10: IdItemAsociado 
                });
            }
        }

        // Método para limpiar los campos del formulario
        private void Limpiar()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtValor.Text = "";
            dtpInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            cboTipoDescuento.SelectedIndex = 0;
            promocionSeleccionada = null;
            btnEliminar.Enabled = false;
            btnCambiarEstado.Enabled = false;

            // Limpiar y ocultar campos de item asociado
            lblItemAsociado.Visible = false;
            cboItemAsociado.Visible = false;
            cboItemAsociado.DataSource = null;
            txtId.Text = "0";
            cboTipoDescuento.Focus();

            // Aseguramos que el estado del botón se actualice a un estado neutro
            btnCambiarEstado.Text = "Cambiar Estado";
            btnCambiarEstado.BackColor = Color.DarkGray;
            btnCambiarEstado.IconChar = IconChar.ToggleOff;
        }

        // =================================================================
        // MANEJO DEL ITEM ASOCIADO (Libro, Categoría, etc.)
        // =================================================================
        private void cboTipoDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ocultar/limpiar inicialmente
            lblItemAsociado.Visible = false;
            cboItemAsociado.Visible = false;
            cboItemAsociado.DataSource = null;
            txtIdItemAsociado.Text = "0";

            OpcionCombo opc = (OpcionCombo)cboTipoDescuento.SelectedItem;

            if (opc != null && opc.Valor.ToString() != "general")
            {
                lblItemAsociado.Visible = true;
                cboItemAsociado.Visible = true;

                string tipo = opc.Valor.ToString();

                // Cargar Items Asociados desde la Capa de Negocio
                List<ItemDescuento> listaItems = cnPromocion.ObtenerItemsAsociados(tipo);

                // Configurar ComboBox
                cboItemAsociado.DataSource = listaItems;
                cboItemAsociado.DisplayMember = "Descripcion";
                cboItemAsociado.ValueMember = "Id";

                // Habilitar autocompletado para facilitar la búsqueda
                cboItemAsociado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboItemAsociado.AutoCompleteSource = AutoCompleteSource.ListItems;

                // Actualizar etiqueta
                lblItemAsociado.Text = $"Item de {opc.Texto.Replace("Por ", "")}:";

                // Desuscribir y volver a suscribir para evitar múltiples llamadas
                cboItemAsociado.SelectedIndexChanged -= cboItemAsociado_SelectedIndexChanged;
                cboItemAsociado.SelectedIndexChanged += cboItemAsociado_SelectedIndexChanged;
            }
        }

        private void cboItemAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Guarda el ID del item seleccionado en el TextBox oculto
            if (cboItemAsociado.SelectedItem is ItemDescuento item)
            {
                txtIdItemAsociado.Text = item.Id.ToString(); 
            }
            else
            {
                txtIdItemAsociado.Text = "0"; 
            }
        }

        // =================================================================
        // EVENTOS DE BOTONES
        // =================================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // ======================================
            // 1. VALIDACIONES (Asegúrate que la validación del ítem use txtIdItemAsociado)
            // ======================================
            string mensaje = "";
            OpcionCombo tipoPromo = (OpcionCombo)cboTipoDescuento.SelectedItem;
            decimal valorDescuento = 0;

            // a. Campos no vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mensaje += "Debe ingresar un Nombre para la promoción.\n";
            }

            if (!decimal.TryParse(txtValor.Text, out valorDescuento) || valorDescuento <= 0)
            {
                mensaje += "Debe ingresar un Valor de Descuento válido (número positivo).\n";
            }

            // b. Fechas
            if (dtpInicio.Value.Date > dtpFechaFin.Value.Date)
            {
                mensaje += "La Fecha de Inicio no puede ser posterior a la Fecha Fin.\n";
            }

            // c. Item Asociado para tipos específicos
            // CRÍTICO: Usar txtIdItemAsociado para la validación del item
            if (tipoPromo.Valor.ToString() != "general" && (cboItemAsociado.SelectedItem == null || Convert.ToInt32(txtIdItemAsociado.Text) == 0))
            {
                mensaje += $"Debe seleccionar un {lblItemAsociado.Text.Replace(":", "")}.\n";
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ======================================
            // 2. CREAR OBJETO PROMOCIÓN (Lógica de estado simplificada)
            // ======================================

            // Si estamos editando (IdPromocion != 0), mantenemos el estado de 'promocionSeleccionada'.
            // Si estamos insertando (IdPromocion == 0), el estado inicial es True.
            bool estadoParaGuardar = (Convert.ToInt32(txtId.Text) != 0) ? (promocionSeleccionada?.Estado ?? true) : true;

            Promocion p = new Promocion()
            {
                IdPromocion = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Tipo = tipoPromo.Valor.ToString(),
                ValorDescuento = valorDescuento, 
                FechaInicio = dtpInicio.Value.Date,
                FechaFin = dtpFechaFin.Value.Date,
                Estado = estadoParaGuardar, // Usamos la lógica simplificada
                IdItemAsociado = Convert.ToInt32(txtIdItemAsociado.Text) 
            };

            // ======================================
            // 3. LLAMAR A LA CAPA DE NEGOCIO
            // ======================================
            bool resultado = cnPromocion.Guardar(p);

            if (resultado)
            {
                string accion = (p.IdPromocion == 0) ? "registrada" : "modificada";
                MessageBox.Show($"Promoción {accion} exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarPromociones();
            }
            else
            {
                MessageBox.Show("Error al guardar la promoción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar una promoción para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta promoción? Esta acción es irreversible.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnPromocion.Eliminar(Convert.ToInt32(txtId.Text)))
                {
                    MessageBox.Show("Promoción eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    CargarPromociones();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la promoción. Verifique que no esté siendo utilizada en ventas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (promocionSeleccionada == null || Convert.ToInt32(txtId.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar una promoción para cambiar su estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtId.Text);
            bool estadoActual = promocionSeleccionada.Estado;
            bool nuevoEstado = !estadoActual;
            string textoNuevoEstado = nuevoEstado ? "Activar" : "Desactivar";

            if (MessageBox.Show($"¿Desea {textoNuevoEstado} la promoción seleccionada?", "Confirmar Cambio de Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnPromocion.CambiarEstado(id, nuevoEstado))
                {
                    MessageBox.Show($"Promoción {textoNuevoEstado.ToLower()}da exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    CargarPromociones();
                }
                else
                {
                    MessageBox.Show("Error al cambiar el estado de la promoción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =================================================================
        // MANEJO DEL DATAGRIDVIEW
        // =================================================================
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pintar el botón de selección
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h)); 
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejar click en la columna del botón (Índice 0)
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar" && e.RowIndex >= 0)
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    // 1. Limpiar el formulario y cargar datos básicos
                    Limpiar();

                    // Cargar datos básicos
                    txtId.Text = dgvdata.Rows[indice].Cells["IdPromocion"].Value.ToString();
                    txtNombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtValor.Text = dgvdata.Rows[indice].Cells["ValorDescuento"].Value.ToString();
                    dtpInicio.Value = Convert.ToDateTime(dgvdata.Rows[indice].Cells["FechaInicio"].Value);
                    dtpFechaFin.Value = Convert.ToDateTime(dgvdata.Rows[indice].Cells["FechaFin"].Value);

                    // 2. Seleccionar el Tipo de Descuento
                    // *** ESTA ES LA LÍNEA CRÍTICA PARA EL ERROR 'TIPO' ***
                    string tipoSeleccionado = dgvdata.Rows[indice].Cells["TipoDescuento"].Value.ToString(); 

                    foreach (OpcionCombo oc in cboTipoDescuento.Items)
                    {
                        if (oc.Valor.ToString() == tipoSeleccionado)
                        {
                            cboTipoDescuento.SelectedItem = oc; // Esto dispara cboTipoDescuento_SelectedIndexChanged
                            break;
                        }
                    }

                    // 3. Cargar Ítem Asociado (Necesario para la Edición)
                    int idItemAsociado = Convert.ToInt32(dgvdata.Rows[indice].Cells["IdItemAsociado"].Value);

                    if (tipoSeleccionado != "general" && idItemAsociado != 0)
                    {
                        // Guarda el ID para que el botón Guardar lo envíe
                        txtIdItemAsociado.Text = idItemAsociado.ToString();

                        // Buscamos y seleccionamos el ítem por su ID
                        if (cboItemAsociado.DataSource is List<ItemDescuento> listaItems)
                        {
                            ItemDescuento itemASeleccionar = listaItems.FirstOrDefault(item => item.Id == idItemAsociado);
                            if (itemASeleccionar != null)
                            {
                                cboItemAsociado.SelectedItem = itemASeleccionar;
                            }
                        }
                    }

                    // 4. Crear el objeto Promoción Seleccionada para el botón de estado
                    promocionSeleccionada = new Promocion()
                    {
                        IdPromocion = Convert.ToInt32(txtId.Text),
                        Estado = Convert.ToBoolean(dgvdata.Rows[indice].Cells["EstadoValor"].Value)
                    };

                    // 5. Habilitar botones
                    btnEliminar.Enabled = true;
                    btnCambiarEstado.Enabled = true;
                    ActualizarBotonCambiarEstado();
                }
            }
        }

        // =================================================================
        // FILTRADO Y BÚSQUEDA
        // =================================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.SelectedItem == null || string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                MessageBox.Show("Seleccione un criterio y escriba un valor para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // El 'Valor' será "Nombre", "TipoDescuento", o "ItemAsociado"
            string columnaBusqueda = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            string valor = txtBusqueda.Text.Trim().ToUpper();

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                // 1. Obtener el valor de la columna seleccionada
                object celda = row.Cells[columnaBusqueda]?.Value;
                string valorFila = celda?.ToString().Trim().ToUpper() ?? string.Empty;

                // 2. Aplicar el filtro de coincidencia
                if (valorFila.Contains(valor))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            cboBusqueda.SelectedIndex = 0;
            // Mostrar todas las filas
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnActivado_Click(object sender, EventArgs e)
        {
            // Filtrar por estado: Activado (true) - Usando el filtro en memoria (más rápido para listas pequeñas)
            FiltrarPorEstado(true);
        }

        private void btnDesactivado_Click(object sender, EventArgs e)
        {
            // Filtrar por estado: Desactivado (false)
            FiltrarPorEstado(false);
        }

        private void FiltrarPorEstado(bool estado)
        {
            // 1. Limpiar el campo de texto de búsqueda si no está vacío
            if (!string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                txtBusqueda.Text = "";
                // Opcional: Reestablecer el ComboBox de búsqueda si lo tienes
                cboBusqueda.SelectedIndex = 0; 
            }

            // 2. Iterar sobre las filas y aplicar el filtro de estado
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                // El row.Cells["EstadoValor"] debe ser el que contiene el valor booleano (true/false)
                if (row.Cells["EstadoValor"] != null && row.Cells["EstadoValor"].Value != null)
                {
                    // Convert.ToBoolean es seguro si el valor es bool o string "True"/"False"
                    bool estadoFila = Convert.ToBoolean(row.Cells["EstadoValor"].Value);

                    // 3. Aplicar la visibilidad basándose ÚNICAMENTE en el estado
                    if (estadoFila == estado)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                else
                {
                    // Ocultar filas que no tienen valor de estado (ej: la fila de encabezado vacía)
                    row.Visible = false;
                }
            }
        }

        private void ActualizarBotonCambiarEstado()
        {
            if (promocionSeleccionada != null)
            {
                if (promocionSeleccionada.Estado)
                {
                    btnCambiarEstado.Text = "Desactivar";
                    btnCambiarEstado.BackColor = Color.Firebrick;
                    btnCambiarEstado.IconChar = IconChar.Ban;
                }
                else
                {
                    btnCambiarEstado.Text = "Activar";
                    btnCambiarEstado.BackColor = Color.DarkGreen;
                    btnCambiarEstado.IconChar = IconChar.Check;
                }
            }
        }
    }
}