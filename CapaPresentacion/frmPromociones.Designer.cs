namespace CapaPresentacion
{
    partial class frmPromociones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.lblPromocion = new System.Windows.Forms.Label();
            this.cboTipoDescuento = new System.Windows.Forms.ComboBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.btnCambiarEstado = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarBuscador = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnActivado = new FontAwesome.Sharp.IconButton();
            this.btnDesactivado = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.cboItemAsociado = new System.Windows.Forms.ComboBox();
            this.lblItemAsociado = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdItemAsociado = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdPromocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdItemAsociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(539, 99);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(204, 20);
            this.txtBusqueda.TabIndex = 103;
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Location = new System.Drawing.Point(421, 98);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(112, 21);
            this.cboBusqueda.TabIndex = 101;
            // 
            // lblLista
            // 
            this.lblLista.BackColor = System.Drawing.Color.White;
            this.lblLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblLista.Location = new System.Drawing.Point(327, 16);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(677, 51);
            this.lblLista.TabIndex = 99;
            this.lblLista.Text = "Lista de Promociones:";
            this.lblLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.IdPromocion,
            this.Nombre,
            this.TipoDescuento,
            this.ValorDescuento,
            this.FechaInicio,
            this.FechaFin,
            this.EstadoValor,
            this.Estado,
            this.IdItemAsociado});
            this.dgvdata.Location = new System.Drawing.Point(327, 149);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(677, 316);
            this.dgvdata.TabIndex = 98;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // lblPromocion
            // 
            this.lblPromocion.AutoSize = true;
            this.lblPromocion.BackColor = System.Drawing.Color.White;
            this.lblPromocion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPromocion.Location = new System.Drawing.Point(38, 16);
            this.lblPromocion.Name = "lblPromocion";
            this.lblPromocion.Size = new System.Drawing.Size(208, 25);
            this.lblPromocion.TabIndex = 97;
            this.lblPromocion.Text = "Datos de la Promoción";
            // 
            // cboTipoDescuento
            // 
            this.cboTipoDescuento.FormattingEnabled = true;
            this.cboTipoDescuento.Location = new System.Drawing.Point(33, 140);
            this.cboTipoDescuento.Name = "cboTipoDescuento";
            this.cboTipoDescuento.Size = new System.Drawing.Size(213, 21);
            this.cboTipoDescuento.TabIndex = 94;
            this.cboTipoDescuento.SelectedIndexChanged += new System.EventHandler(this.cboTipoDescuento_SelectedIndexChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(127, 268);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(119, 20);
            this.dtpInicio.TabIndex = 91;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(33, 231);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(213, 20);
            this.txtValor.TabIndex = 88;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.BackColor = System.Drawing.Color.White;
            this.lblInicio.Location = new System.Drawing.Point(30, 271);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(68, 13);
            this.lblInicio.TabIndex = 81;
            this.lblInicio.Text = "Fecha Inicio:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.BackColor = System.Drawing.Color.White;
            this.lblValor.Location = new System.Drawing.Point(30, 214);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(106, 13);
            this.lblValor.TabIndex = 80;
            this.lblValor.Text = "Valor del Descuento:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.BackColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(30, 122);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(101, 13);
            this.lblTipo.TabIndex = 77;
            this.lblTipo.Text = "Tipo de Descuento:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(221, 46);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 76;
            this.lblId.Text = "ID:";
            this.lblId.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(33, 93);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(213, 20);
            this.txtNombre.TabIndex = 75;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(30, 77);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 74;
            this.lblNombre.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 486);
            this.label2.TabIndex = 73;
            // 
            // lblBusca
            // 
            this.lblBusca.BackColor = System.Drawing.Color.White;
            this.lblBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusca.Location = new System.Drawing.Point(327, 77);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(677, 60);
            this.lblBusca.TabIndex = 102;
            this.lblBusca.Text = " Buscar por:";
            this.lblBusca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(127, 305);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(119, 20);
            this.dtpFechaFin.TabIndex = 110;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.BackColor = System.Drawing.Color.White;
            this.lblFechaFin.Location = new System.Drawing.Point(30, 308);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 109;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstado.ForeColor = System.Drawing.Color.White;
            this.btnCambiarEstado.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.btnCambiarEstado.IconColor = System.Drawing.Color.White;
            this.btnCambiarEstado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCambiarEstado.IconSize = 16;
            this.btnCambiarEstado.Location = new System.Drawing.Point(33, 441);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(213, 23);
            this.btnCambiarEstado.TabIndex = 108;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarEstado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiarEstado.UseVisualStyleBackColor = false;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // btnLimpiarBuscador
            // 
            this.btnLimpiarBuscador.BackColor = System.Drawing.Color.White;
            this.btnLimpiarBuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBuscador.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarBuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiarBuscador.IconColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarBuscador.IconSize = 16;
            this.btnLimpiarBuscador.Location = new System.Drawing.Point(802, 96);
            this.btnLimpiarBuscador.Name = "btnLimpiarBuscador";
            this.btnLimpiarBuscador.Size = new System.Drawing.Size(34, 24);
            this.btnLimpiarBuscador.TabIndex = 105;
            this.btnLimpiarBuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarBuscador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiarBuscador.UseVisualStyleBackColor = false;
            this.btnLimpiarBuscador.Click += new System.EventHandler(this.btnLimpiarBuscador_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 16;
            this.btnBuscar.Location = new System.Drawing.Point(759, 96);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(37, 24);
            this.btnBuscar.TabIndex = 104;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.White;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 16;
            this.btnLimpiar.Location = new System.Drawing.Point(33, 383);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(213, 23);
            this.btnLimpiar.TabIndex = 96;
            this.btnLimpiar.Text = "Limpiar / Cancelar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 16;
            this.btnGuardar.Location = new System.Drawing.Point(33, 354);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(213, 23);
            this.btnGuardar.TabIndex = 95;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActivado
            // 
            this.btnActivado.BackColor = System.Drawing.Color.DarkGreen;
            this.btnActivado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnActivado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivado.ForeColor = System.Drawing.Color.White;
            this.btnActivado.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnActivado.IconColor = System.Drawing.Color.White;
            this.btnActivado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActivado.IconSize = 16;
            this.btnActivado.Location = new System.Drawing.Point(878, 83);
            this.btnActivado.Name = "btnActivado";
            this.btnActivado.Size = new System.Drawing.Size(105, 23);
            this.btnActivado.TabIndex = 112;
            this.btnActivado.Text = "Activado";
            this.btnActivado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActivado.UseVisualStyleBackColor = false;
            this.btnActivado.Click += new System.EventHandler(this.btnActivado_Click);
            // 
            // btnDesactivado
            // 
            this.btnDesactivado.BackColor = System.Drawing.Color.Firebrick;
            this.btnDesactivado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDesactivado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivado.ForeColor = System.Drawing.Color.White;
            this.btnDesactivado.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnDesactivado.IconColor = System.Drawing.Color.White;
            this.btnDesactivado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDesactivado.IconSize = 16;
            this.btnDesactivado.Location = new System.Drawing.Point(878, 109);
            this.btnDesactivado.Name = "btnDesactivado";
            this.btnDesactivado.Size = new System.Drawing.Size(105, 23);
            this.btnDesactivado.TabIndex = 111;
            this.btnDesactivado.Text = "Desactivado";
            this.btnDesactivado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesactivado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesactivado.UseVisualStyleBackColor = false;
            this.btnDesactivado.Click += new System.EventHandler(this.btnDesactivado_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkRed;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.White;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 16;
            this.btnEliminar.Location = new System.Drawing.Point(33, 412);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(213, 23);
            this.btnEliminar.TabIndex = 113;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboItemAsociado
            // 
            this.cboItemAsociado.FormattingEnabled = true;
            this.cboItemAsociado.Location = new System.Drawing.Point(33, 187);
            this.cboItemAsociado.Name = "cboItemAsociado";
            this.cboItemAsociado.Size = new System.Drawing.Size(213, 21);
            this.cboItemAsociado.TabIndex = 115;
            this.cboItemAsociado.SelectedIndexChanged += new System.EventHandler(this.cboItemAsociado_SelectedIndexChanged);
            // 
            // lblItemAsociado
            // 
            this.lblItemAsociado.AutoSize = true;
            this.lblItemAsociado.BackColor = System.Drawing.Color.White;
            this.lblItemAsociado.Location = new System.Drawing.Point(30, 169);
            this.lblItemAsociado.Name = "lblItemAsociado";
            this.lblItemAsociado.Size = new System.Drawing.Size(0, 13);
            this.lblItemAsociado.TabIndex = 114;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(248, 43);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(29, 20);
            this.txtId.TabIndex = 100;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // txtIdItemAsociado
            // 
            this.txtIdItemAsociado.Location = new System.Drawing.Point(33, 166);
            this.txtIdItemAsociado.Name = "txtIdItemAsociado";
            this.txtIdItemAsociado.Size = new System.Drawing.Size(29, 20);
            this.txtIdItemAsociado.TabIndex = 116;
            this.txtIdItemAsociado.Visible = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.HeaderText = "";
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ReadOnly = true;
            this.btnSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnSeleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnSeleccionar.Width = 30;
            // 
            // IdPromocion
            // 
            this.IdPromocion.HeaderText = "IdPromocion";
            this.IdPromocion.Name = "IdPromocion";
            this.IdPromocion.ReadOnly = true;
            this.IdPromocion.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // TipoDescuento
            // 
            this.TipoDescuento.HeaderText = "Tipo de Descuento";
            this.TipoDescuento.Name = "TipoDescuento";
            this.TipoDescuento.ReadOnly = true;
            this.TipoDescuento.Width = 125;
            // 
            // ValorDescuento
            // 
            this.ValorDescuento.HeaderText = "Valor del Descuento";
            this.ValorDescuento.Name = "ValorDescuento";
            this.ValorDescuento.ReadOnly = true;
            this.ValorDescuento.Width = 125;
            // 
            // FechaInicio
            // 
            this.FechaInicio.HeaderText = "Fecha Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 125;
            // 
            // FechaFin
            // 
            this.FechaFin.HeaderText = "Fecha Fin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 125;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Estado.Width = 125;
            // 
            // IdItemAsociado
            // 
            this.IdItemAsociado.HeaderText = "IdItemAsociado";
            this.IdItemAsociado.Name = "IdItemAsociado";
            this.IdItemAsociado.ReadOnly = true;
            this.IdItemAsociado.Visible = false;
            // 
            // frmPromociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1046, 486);
            this.Controls.Add(this.txtIdItemAsociado);
            this.Controls.Add(this.cboItemAsociado);
            this.Controls.Add(this.lblItemAsociado);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActivado);
            this.Controls.Add(this.btnDesactivado);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.btnLimpiarBuscador);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cboBusqueda);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.lblPromocion);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboTipoDescuento);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBusca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPromociones";
            this.Text = "frmPromociones";
            this.Load += new System.EventHandler(this.frmPromociones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCambiarEstado;
        private FontAwesome.Sharp.IconButton btnLimpiarBuscador;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Label lblPromocion;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.ComboBox cboTipoDescuento;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private FontAwesome.Sharp.IconButton btnActivado;
        private FontAwesome.Sharp.IconButton btnDesactivado;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.ComboBox cboItemAsociado;
        private System.Windows.Forms.Label lblItemAsociado;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtIdItemAsociado;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPromocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdItemAsociado;
    }
}