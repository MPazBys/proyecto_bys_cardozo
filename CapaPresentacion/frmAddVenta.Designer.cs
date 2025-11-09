namespace CapaPresentacion
{
    partial class frmAddVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpVenta = new System.Windows.Forms.DateTimePicker();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarCliente = new FontAwesome.Sharp.IconButton();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new FontAwesome.Sharp.IconButton();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.numCantidad = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtNombreLibro = new System.Windows.Forms.TextBox();
            this.btnBuscarLibro = new FontAwesome.Sharp.IconButton();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.lblLibro = new System.Windows.Forms.Label();
            this.lblBuscarLibro = new System.Windows.Forms.Label();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.lblAgregarPago = new System.Windows.Forms.Label();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.BGuardar = new FontAwesome.Sharp.IconButton();
            this.BEliminar = new FontAwesome.Sharp.IconButton();
            this.txtBuscarLibro = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.fpnlPagos = new System.Windows.Forms.FlowLayoutPanel();
            this.cboMedioPago = new System.Windows.Forms.ComboBox();
            this.btnAgregarPago = new FontAwesome.Sharp.IconButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDescuentos = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.ID_Libro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Libro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalNetoLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            this.fpnlPagos.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(153, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(149, 22);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "Registrar Venta:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(28, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(50, 18);
            this.lblFecha.TabIndex = 24;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(186, 25);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(112, 18);
            this.lblTipoDoc.TabIndex = 25;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.dtpVenta);
            this.groupBox1.Controls.Add(this.cboTipoDoc);
            this.groupBox1.Controls.Add(this.lblTipoDoc);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(93, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 72);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion Venta";
            // 
            // dtpVenta
            // 
            this.dtpVenta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVenta.Location = new System.Drawing.Point(28, 45);
            this.dtpVenta.Name = "dtpVenta";
            this.dtpVenta.Size = new System.Drawing.Size(100, 20);
            this.dtpVenta.TabIndex = 45;
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.BackColor = System.Drawing.SystemColors.Window;
            this.cboTipoDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTipoDoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboTipoDoc.Location = new System.Drawing.Point(186, 45);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(137, 21);
            this.cboTipoDoc.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnBuscarCliente);
            this.groupBox2.Controls.Add(this.txtNombreCliente);
            this.groupBox2.Controls.Add(this.txtCuit);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(511, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 72);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion Cliente";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btnBuscarCliente.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCliente.IconSize = 16;
            this.btnBuscarCliente.Location = new System.Drawing.Point(165, 43);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(25, 21);
            this.btnBuscarCliente.TabIndex = 31;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(215, 45);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(158, 20);
            this.txtNombreCliente.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(215, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "Razón Social / Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "CUIT:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.btnAgregar);
            this.groupBox3.Controls.Add(this.nudCantidad);
            this.groupBox3.Controls.Add(this.txtBuscarLibro);
            this.groupBox3.Controls.Add(this.txtStock);
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.numCantidad);
            this.groupBox3.Controls.Add(this.lblStock);
            this.groupBox3.Controls.Add(this.lblPrecio);
            this.groupBox3.Controls.Add(this.txtNombreLibro);
            this.groupBox3.Controls.Add(this.btnBuscarLibro);
            this.groupBox3.Controls.Add(this.txtIdProducto);
            this.groupBox3.Controls.Add(this.lblLibro);
            this.groupBox3.Controls.Add(this.lblBuscarLibro);
            this.groupBox3.Location = new System.Drawing.Point(93, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(818, 117);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacion Podructo";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnAgregar.IconColor = System.Drawing.Color.White;
            this.btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregar.IconSize = 16;
            this.btnAgregar.Location = new System.Drawing.Point(663, 83);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(149, 28);
            this.btnAgregar.TabIndex = 50;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(642, 47);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(75, 20);
            this.nudCantidad.TabIndex = 32;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(543, 47);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(75, 20);
            this.txtStock.TabIndex = 38;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(440, 47);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(75, 20);
            this.txtPrecio.TabIndex = 37;
            // 
            // numCantidad
            // 
            this.numCantidad.AutoSize = true;
            this.numCantidad.BackColor = System.Drawing.Color.Transparent;
            this.numCantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.numCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCantidad.Location = new System.Drawing.Point(642, 25);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(66, 18);
            this.numCantidad.TabIndex = 36;
            this.numCantidad.Text = "Cantidad:";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.BackColor = System.Drawing.Color.Transparent;
            this.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(543, 25);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(46, 18);
            this.lblStock.TabIndex = 35;
            this.lblStock.Text = "Stock:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(440, 25);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(51, 18);
            this.lblPrecio.TabIndex = 34;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtNombreLibro
            // 
            this.txtNombreLibro.Location = new System.Drawing.Point(270, 47);
            this.txtNombreLibro.Name = "txtNombreLibro";
            this.txtNombreLibro.ReadOnly = true;
            this.txtNombreLibro.Size = new System.Drawing.Size(146, 20);
            this.txtNombreLibro.TabIndex = 33;
            // 
            // btnBuscarLibro
            // 
            this.btnBuscarLibro.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBuscarLibro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarLibro.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarLibro.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarLibro.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btnBuscarLibro.IconColor = System.Drawing.Color.Black;
            this.btnBuscarLibro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarLibro.IconSize = 16;
            this.btnBuscarLibro.Location = new System.Drawing.Point(186, 46);
            this.btnBuscarLibro.Name = "btnBuscarLibro";
            this.btnBuscarLibro.Size = new System.Drawing.Size(25, 21);
            this.btnBuscarLibro.TabIndex = 32;
            this.btnBuscarLibro.UseVisualStyleBackColor = false;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(125, 19);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(29, 20);
            this.txtIdProducto.TabIndex = 30;
            this.txtIdProducto.Visible = false;
            // 
            // lblLibro
            // 
            this.lblLibro.AutoSize = true;
            this.lblLibro.BackColor = System.Drawing.Color.Transparent;
            this.lblLibro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibro.Location = new System.Drawing.Point(270, 25);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new System.Drawing.Size(42, 18);
            this.lblLibro.TabIndex = 25;
            this.lblLibro.Text = "Libro:";
            // 
            // lblBuscarLibro
            // 
            this.lblBuscarLibro.AutoSize = true;
            this.lblBuscarLibro.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscarLibro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBuscarLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarLibro.Location = new System.Drawing.Point(32, 24);
            this.lblBuscarLibro.Name = "lblBuscarLibro";
            this.lblBuscarLibro.Size = new System.Drawing.Size(87, 18);
            this.lblBuscarLibro.TabIndex = 24;
            this.lblBuscarLibro.Text = "Buscar Libro:";
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLibros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLibros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Libro,
            this.Libro,
            this.PrecioUnitario,
            this.Cantidad,
            this.SubTotalLinea,
            this.DescuentoItem,
            this.SubTotalNetoLinea,
            this.btnEliminar});
            this.dgvLibros.Location = new System.Drawing.Point(93, 245);
            this.dgvLibros.MultiSelect = false;
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLibros.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLibros.RowTemplate.Height = 30;
            this.dgvLibros.Size = new System.Drawing.Size(818, 230);
            this.dgvLibros.TabIndex = 31;
            this.dgvLibros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLibros_CellContentClick);
            this.dgvLibros.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLibros_CellPainting);
            // 
            // lblAgregarPago
            // 
            this.lblAgregarPago.AutoSize = true;
            this.lblAgregarPago.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAgregarPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAgregarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregarPago.Location = new System.Drawing.Point(3, 0);
            this.lblAgregarPago.Name = "lblAgregarPago";
            this.lblAgregarPago.Size = new System.Drawing.Size(165, 18);
            this.lblAgregarPago.TabIndex = 36;
            this.lblAgregarPago.Text = "Agregar Método de Pago:";
            this.lblAgregarPago.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Location = new System.Drawing.Point(3, 48);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(137, 20);
            this.txtMontoPago.TabIndex = 38;
            this.txtMontoPago.Text = "Ingrese Monto";
            this.txtMontoPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoPago_KeyPress);
            // 
            // BGuardar
            // 
            this.BGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.BGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar.ForeColor = System.Drawing.Color.White;
            this.BGuardar.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.BGuardar.IconColor = System.Drawing.Color.White;
            this.BGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BGuardar.IconSize = 16;
            this.BGuardar.Location = new System.Drawing.Point(945, 486);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(149, 26);
            this.BGuardar.TabIndex = 43;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BGuardar.UseVisualStyleBackColor = false;
            // 
            // BEliminar
            // 
            this.BEliminar.BackColor = System.Drawing.Color.Maroon;
            this.BEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminar.ForeColor = System.Drawing.Color.White;
            this.BEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.BEliminar.IconColor = System.Drawing.Color.White;
            this.BEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BEliminar.IconSize = 16;
            this.BEliminar.Location = new System.Drawing.Point(790, 486);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(149, 26);
            this.BEliminar.TabIndex = 44;
            this.BEliminar.Text = "Cancelar";
            this.BEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEliminar.UseVisualStyleBackColor = false;
            // 
            // txtBuscarLibro
            // 
            this.txtBuscarLibro.Location = new System.Drawing.Point(31, 47);
            this.txtBuscarLibro.Name = "txtBuscarLibro";
            this.txtBuscarLibro.Size = new System.Drawing.Size(143, 20);
            this.txtBuscarLibro.TabIndex = 48;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(27, 44);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(114, 20);
            this.txtCuit.TabIndex = 49;
            this.txtCuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuit_KeyPress);
            // 
            // fpnlPagos
            // 
            this.fpnlPagos.AutoScroll = true;
            this.fpnlPagos.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlPagos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fpnlPagos.Controls.Add(this.lblAgregarPago);
            this.fpnlPagos.Controls.Add(this.cboMedioPago);
            this.fpnlPagos.Controls.Add(this.txtMontoPago);
            this.fpnlPagos.Controls.Add(this.btnAgregarPago);
            this.fpnlPagos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlPagos.Location = new System.Drawing.Point(941, 80);
            this.fpnlPagos.Name = "fpnlPagos";
            this.fpnlPagos.Size = new System.Drawing.Size(224, 233);
            this.fpnlPagos.TabIndex = 50;
            this.fpnlPagos.WrapContents = false;
            // 
            // cboMedioPago
            // 
            this.cboMedioPago.BackColor = System.Drawing.SystemColors.Window;
            this.cboMedioPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMedioPago.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboMedioPago.FormattingEnabled = true;
            this.cboMedioPago.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboMedioPago.Location = new System.Drawing.Point(3, 21);
            this.cboMedioPago.Name = "cboMedioPago";
            this.cboMedioPago.Size = new System.Drawing.Size(137, 21);
            this.cboMedioPago.TabIndex = 46;
            // 
            // btnAgregarPago
            // 
            this.btnAgregarPago.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarPago.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAgregarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPago.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPago.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            this.btnAgregarPago.IconColor = System.Drawing.Color.White;
            this.btnAgregarPago.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarPago.IconSize = 18;
            this.btnAgregarPago.Location = new System.Drawing.Point(3, 74);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(137, 30);
            this.btnAgregarPago.TabIndex = 51;
            this.btnAgregarPago.Text = "Agregar";
            this.btnAgregarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarPago.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.lblVuelto);
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.lblDescuentos);
            this.groupBox4.Controls.Add(this.lblSubtotal);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(941, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 112);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales y subtotales";
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.BackColor = System.Drawing.Color.Transparent;
            this.lblVuelto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.Location = new System.Drawing.Point(6, 81);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(50, 18);
            this.lblVuelto.TabIndex = 27;
            this.lblVuelto.Text = "Vuelto:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(6, 62);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(43, 18);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "Total:";
            // 
            // lblDescuentos
            // 
            this.lblDescuentos.AutoSize = true;
            this.lblDescuentos.BackColor = System.Drawing.Color.Transparent;
            this.lblDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentos.Location = new System.Drawing.Point(6, 43);
            this.lblDescuentos.Name = "lblDescuentos";
            this.lblDescuentos.Size = new System.Drawing.Size(84, 18);
            this.lblDescuentos.TabIndex = 25;
            this.lblDescuentos.Text = "Descuentos:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(7, 22);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(64, 18);
            this.lblSubtotal.TabIndex = 24;
            this.lblSubtotal.Text = "Subtotal: ";
            // 
            // ID_Libro
            // 
            this.ID_Libro.HeaderText = "ID";
            this.ID_Libro.Name = "ID_Libro";
            this.ID_Libro.ReadOnly = true;
            this.ID_Libro.Visible = false;
            // 
            // Libro
            // 
            this.Libro.HeaderText = "Libro";
            this.Libro.Name = "Libro";
            this.Libro.ReadOnly = true;
            this.Libro.Width = 120;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            this.PrecioUnitario.Width = 140;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // SubTotalLinea
            // 
            this.SubTotalLinea.HeaderText = "Sub Total";
            this.SubTotalLinea.Name = "SubTotalLinea";
            this.SubTotalLinea.ReadOnly = true;
            this.SubTotalLinea.Width = 120;
            // 
            // DescuentoItem
            // 
            this.DescuentoItem.HeaderText = "Desc. Ítem";
            this.DescuentoItem.Name = "DescuentoItem";
            this.DescuentoItem.ReadOnly = true;
            this.DescuentoItem.Width = 120;
            // 
            // SubTotalNetoLinea
            // 
            this.SubTotalNetoLinea.HeaderText = "Sub Total Neto";
            this.SubTotalNetoLinea.Name = "SubTotalNetoLinea";
            this.SubTotalNetoLinea.ReadOnly = true;
            this.SubTotalNetoLinea.Width = 130;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Width = 40;
            // 
            // frmAddVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1266, 572);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.fpnlPagos);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.dgvLibros);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmAddVenta";
            this.Text = "frmAddVenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            this.fpnlPagos.ResumeLayout(false);
            this.fpnlPagos.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private FontAwesome.Sharp.IconButton btnBuscarCliente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label numCantidad;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtNombreLibro;
        private FontAwesome.Sharp.IconButton btnBuscarLibro;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.Label lblBuscarLibro;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.Label lblAgregarPago;
        private System.Windows.Forms.TextBox txtMontoPago;
        private FontAwesome.Sharp.IconButton BGuardar;
        private FontAwesome.Sharp.IconButton BEliminar;
        private System.Windows.Forms.DateTimePicker dtpVenta;
        private System.Windows.Forms.TextBox txtBuscarLibro;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.FlowLayoutPanel fpnlPagos;
        private System.Windows.Forms.ComboBox cboMedioPago;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnAgregarPago;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblDescuentos;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Libro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Libro;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalNetoLinea;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
    }
}