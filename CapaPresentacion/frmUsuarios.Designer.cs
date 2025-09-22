namespace CapaPresentacion
{
    partial class frmUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblnombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblcuit = new System.Windows.Forms.Label();
            this.lblcontrasena = new System.Windows.Forms.Label();
            this.lblconfcontrasena = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.lblrol = new System.Windows.Forms.Label();
            this.lblsexo = new System.Windows.Forms.Label();
            this.lblfechanac = new System.Windows.Forms.Label();
            this.txtconfcont = new System.Windows.Forms.TextBox();
            this.txtcontrasena = new System.Windows.Forms.TextBox();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.rbmujer = new System.Windows.Forms.RadioButton();
            this.rbhombre = new System.Windows.Forms.RadioButton();
            this.cborol = new System.Windows.Forms.ComboBox();
            this.lbldetalleusuario = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contrasena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbllista = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.lblapellido = new System.Windows.Forms.Label();
            this.lblbusca = new System.Windows.Forms.Label();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.btnactivar = new FontAwesome.Sharp.IconButton();
            this.btndesactivar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnguardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.White;
            this.lblnombre.Location = new System.Drawing.Point(31, 93);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(47, 13);
            this.lblnombre.TabIndex = 2;
            this.lblnombre.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 568);
            this.label2.TabIndex = 1;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(34, 109);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(213, 20);
            this.txtnombre.TabIndex = 3;
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            this.txtnombre.Leave += new System.EventHandler(this.txtnombre_Leave);
            // 
            // lblcuit
            // 
            this.lblcuit.AutoSize = true;
            this.lblcuit.BackColor = System.Drawing.Color.White;
            this.lblcuit.Location = new System.Drawing.Point(31, 51);
            this.lblcuit.Name = "lblcuit";
            this.lblcuit.Size = new System.Drawing.Size(88, 13);
            this.lblcuit.TabIndex = 4;
            this.lblcuit.Text = "Nro. Documento:";
            // 
            // lblcontrasena
            // 
            this.lblcontrasena.AutoSize = true;
            this.lblcontrasena.BackColor = System.Drawing.Color.White;
            this.lblcontrasena.Location = new System.Drawing.Point(31, 265);
            this.lblcontrasena.Name = "lblcontrasena";
            this.lblcontrasena.Size = new System.Drawing.Size(64, 13);
            this.lblcontrasena.TabIndex = 6;
            this.lblcontrasena.Text = "Contraseña:";
            // 
            // lblconfcontrasena
            // 
            this.lblconfcontrasena.AutoSize = true;
            this.lblconfcontrasena.BackColor = System.Drawing.Color.White;
            this.lblconfcontrasena.Location = new System.Drawing.Point(31, 308);
            this.lblconfcontrasena.Name = "lblconfcontrasena";
            this.lblconfcontrasena.Size = new System.Drawing.Size(110, 13);
            this.lblconfcontrasena.TabIndex = 7;
            this.lblconfcontrasena.Text = "Confirmar contraseña:";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.BackColor = System.Drawing.Color.White;
            this.lblemail.Location = new System.Drawing.Point(31, 179);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(35, 13);
            this.lblemail.TabIndex = 8;
            this.lblemail.Text = "Email:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(31, 222);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(46, 13);
            this.lblusuario.TabIndex = 9;
            this.lblusuario.Text = "Usuario:";
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.BackColor = System.Drawing.Color.White;
            this.lblrol.Location = new System.Drawing.Point(31, 407);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(26, 13);
            this.lblrol.TabIndex = 10;
            this.lblrol.Text = "Rol:";
            // 
            // lblsexo
            // 
            this.lblsexo.AutoSize = true;
            this.lblsexo.BackColor = System.Drawing.Color.White;
            this.lblsexo.Location = new System.Drawing.Point(31, 380);
            this.lblsexo.Name = "lblsexo";
            this.lblsexo.Size = new System.Drawing.Size(37, 13);
            this.lblsexo.TabIndex = 11;
            this.lblsexo.Text = "Sexo: ";
            // 
            // lblfechanac
            // 
            this.lblfechanac.AutoSize = true;
            this.lblfechanac.BackColor = System.Drawing.Color.White;
            this.lblfechanac.Location = new System.Drawing.Point(31, 354);
            this.lblfechanac.Name = "lblfechanac";
            this.lblfechanac.Size = new System.Drawing.Size(96, 13);
            this.lblfechanac.TabIndex = 12;
            this.lblfechanac.Text = "Fecha Nacimiento:";
            // 
            // txtconfcont
            // 
            this.txtconfcont.Location = new System.Drawing.Point(34, 324);
            this.txtconfcont.Name = "txtconfcont";
            this.txtconfcont.PasswordChar = '*';
            this.txtconfcont.Size = new System.Drawing.Size(213, 20);
            this.txtconfcont.TabIndex = 14;
            // 
            // txtcontrasena
            // 
            this.txtcontrasena.Location = new System.Drawing.Point(34, 281);
            this.txtcontrasena.Name = "txtcontrasena";
            this.txtcontrasena.PasswordChar = '*';
            this.txtcontrasena.Size = new System.Drawing.Size(213, 20);
            this.txtcontrasena.TabIndex = 15;
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(34, 238);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(213, 20);
            this.txtusuario.TabIndex = 16;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(34, 195);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(213, 20);
            this.txtemail.TabIndex = 17;
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(34, 66);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(213, 20);
            this.txtdni.TabIndex = 19;
            this.txtdni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdni_KeyPress);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(133, 350);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(114, 20);
            this.dtpFecha.TabIndex = 20;
            // 
            // rbmujer
            // 
            this.rbmujer.AutoSize = true;
            this.rbmujer.BackColor = System.Drawing.Color.White;
            this.rbmujer.ForeColor = System.Drawing.Color.Black;
            this.rbmujer.Location = new System.Drawing.Point(128, 376);
            this.rbmujer.Name = "rbmujer";
            this.rbmujer.Size = new System.Drawing.Size(51, 17);
            this.rbmujer.TabIndex = 21;
            this.rbmujer.TabStop = true;
            this.rbmujer.Text = "Mujer";
            this.rbmujer.UseVisualStyleBackColor = false;
            // 
            // rbhombre
            // 
            this.rbhombre.AutoSize = true;
            this.rbhombre.BackColor = System.Drawing.Color.White;
            this.rbhombre.ForeColor = System.Drawing.Color.Black;
            this.rbhombre.Location = new System.Drawing.Point(185, 376);
            this.rbhombre.Name = "rbhombre";
            this.rbhombre.Size = new System.Drawing.Size(62, 17);
            this.rbhombre.TabIndex = 22;
            this.rbhombre.TabStop = true;
            this.rbhombre.Text = "Hombre";
            this.rbhombre.UseVisualStyleBackColor = false;
            // 
            // cborol
            // 
            this.cborol.FormattingEnabled = true;
            this.cborol.Location = new System.Drawing.Point(80, 399);
            this.cborol.Name = "cborol";
            this.cborol.Size = new System.Drawing.Size(167, 21);
            this.cborol.TabIndex = 23;
            // 
            // lbldetalleusuario
            // 
            this.lbldetalleusuario.AutoSize = true;
            this.lbldetalleusuario.BackColor = System.Drawing.Color.White;
            this.lbldetalleusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbldetalleusuario.Location = new System.Drawing.Point(75, 17);
            this.lbldetalleusuario.Name = "lbldetalleusuario";
            this.lbldetalleusuario.Size = new System.Drawing.Size(144, 25);
            this.lbldetalleusuario.TabIndex = 28;
            this.lbldetalleusuario.Text = "Detalle Usuario";
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
            this.btnseleccionar,
            this.Id,
            this.Documento,
            this.Nombre,
            this.Apellido,
            this.Correo,
            this.Usuario,
            this.Contrasena,
            this.IdRol,
            this.Rol,
            this.EstadoValor,
            this.Estado,
            this.Sexo,
            this.FechaNacimiento});
            this.dgvdata.Location = new System.Drawing.Point(317, 152);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(677, 367);
            this.dgvdata.TabIndex = 29;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tgvdata_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "IDUsuario";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Nro. Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Contrasena
            // 
            this.Contrasena.HeaderText = "Contraseña";
            this.Contrasena.Name = "Contrasena";
            this.Contrasena.ReadOnly = true;
            this.Contrasena.Visible = false;
            // 
            // IdRol
            // 
            this.IdRol.HeaderText = "IdRol";
            this.IdRol.Name = "IdRol";
            this.IdRol.ReadOnly = true;
            this.IdRol.Visible = false;
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
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
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Name = "Sexo";
            this.Sexo.ReadOnly = true;
            this.Sexo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sexo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FechaNacimiento
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaNacimiento.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaNacimiento.HeaderText = "Fecha Nacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.ReadOnly = true;
            this.FechaNacimiento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FechaNacimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lbllista
            // 
            this.lbllista.BackColor = System.Drawing.Color.White;
            this.lbllista.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbllista.Location = new System.Drawing.Point(317, 35);
            this.lbllista.Name = "lbllista";
            this.lbllista.Size = new System.Drawing.Size(677, 51);
            this.lbllista.TabIndex = 30;
            this.lbllista.Text = "Lista de Usuarios:";
            this.lbllista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(249, 44);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(29, 20);
            this.txtid.TabIndex = 31;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(411, 109);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(204, 21);
            this.cbobusqueda.TabIndex = 63;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(34, 152);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(213, 20);
            this.txtapellido.TabIndex = 18;
            this.txtapellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtapellido_KeyPress);
            this.txtapellido.Leave += new System.EventHandler(this.txtapellido_Leave);
            // 
            // lblapellido
            // 
            this.lblapellido.AutoSize = true;
            this.lblapellido.BackColor = System.Drawing.Color.White;
            this.lblapellido.Location = new System.Drawing.Point(31, 136);
            this.lblapellido.Name = "lblapellido";
            this.lblapellido.Size = new System.Drawing.Size(47, 13);
            this.lblapellido.TabIndex = 5;
            this.lblapellido.Text = "Apellido:";
            // 
            // lblbusca
            // 
            this.lblbusca.BackColor = System.Drawing.Color.White;
            this.lblbusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbusca.Location = new System.Drawing.Point(317, 93);
            this.lblbusca.Name = "lblbusca";
            this.lblbusca.Size = new System.Drawing.Size(677, 51);
            this.lblbusca.TabIndex = 65;
            this.lblbusca.Text = " Buscar por:";
            this.lblbusca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Location = new System.Drawing.Point(630, 110);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(204, 20);
            this.txtbusqueda.TabIndex = 66;
            // 
            // txtindice
            // 
            this.txtindice.Location = new System.Drawing.Point(214, 44);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(29, 20);
            this.txtindice.TabIndex = 69;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
            // 
            // btnactivar
            // 
            this.btnactivar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnactivar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactivar.ForeColor = System.Drawing.Color.White;
            this.btnactivar.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnactivar.IconColor = System.Drawing.Color.White;
            this.btnactivar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnactivar.IconSize = 16;
            this.btnactivar.Location = new System.Drawing.Point(142, 496);
            this.btnactivar.Name = "btnactivar";
            this.btnactivar.Size = new System.Drawing.Size(105, 23);
            this.btnactivar.TabIndex = 72;
            this.btnactivar.Text = "Activar";
            this.btnactivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnactivar.UseVisualStyleBackColor = false;
            this.btnactivar.Click += new System.EventHandler(this.btnactivar_Click);
            // 
            // btndesactivar
            // 
            this.btndesactivar.BackColor = System.Drawing.Color.Firebrick;
            this.btndesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndesactivar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btndesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndesactivar.ForeColor = System.Drawing.Color.White;
            this.btndesactivar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btndesactivar.IconColor = System.Drawing.Color.White;
            this.btndesactivar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndesactivar.IconSize = 16;
            this.btndesactivar.Location = new System.Drawing.Point(34, 496);
            this.btndesactivar.Name = "btndesactivar";
            this.btndesactivar.Size = new System.Drawing.Size(105, 23);
            this.btndesactivar.TabIndex = 71;
            this.btndesactivar.Text = "Desactivar";
            this.btndesactivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndesactivar.UseVisualStyleBackColor = false;
            this.btndesactivar.Click += new System.EventHandler(this.btndesactivar_Click);
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbuscador.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.ForeColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 16;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(943, 106);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(34, 24);
            this.btnlimpiarbuscador.TabIndex = 68;
            this.btnlimpiarbuscador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarbuscador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.Color.White;
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(900, 106);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(37, 24);
            this.btnbuscar.TabIndex = 67;
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.ForeColor = System.Drawing.Color.White;
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.White;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 16;
            this.btnlimpiar.Location = new System.Drawing.Point(34, 467);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(213, 23);
            this.btnlimpiar.TabIndex = 26;
            this.btnlimpiar.Text = "Limpiar / Cancelar";
            this.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnguardar.IconColor = System.Drawing.Color.White;
            this.btnguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnguardar.IconSize = 16;
            this.btnguardar.Location = new System.Drawing.Point(34, 438);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(213, 23);
            this.btnguardar.TabIndex = 25;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1019, 568);
            this.Controls.Add(this.btnactivar);
            this.Controls.Add(this.btndesactivar);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.btnlimpiarbuscador);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbobusqueda);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lbllista);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.lbldetalleusuario);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.cborol);
            this.Controls.Add(this.rbhombre);
            this.Controls.Add(this.rbmujer);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.txtapellido);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.txtcontrasena);
            this.Controls.Add(this.txtconfcont);
            this.Controls.Add(this.lblfechanac);
            this.Controls.Add(this.lblsexo);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.lblconfcontrasena);
            this.Controls.Add(this.lblcontrasena);
            this.Controls.Add(this.lblapellido);
            this.Controls.Add(this.lblcuit);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblbusca);
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lblcuit;
        private System.Windows.Forms.Label lblcontrasena;
        private System.Windows.Forms.Label lblconfcontrasena;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.Label lblsexo;
        private System.Windows.Forms.Label lblfechanac;
        private System.Windows.Forms.TextBox txtconfcont;
        private System.Windows.Forms.TextBox txtcontrasena;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.RadioButton rbmujer;
        private System.Windows.Forms.RadioButton rbhombre;
        private System.Windows.Forms.ComboBox cborol;
        private FontAwesome.Sharp.IconButton btnguardar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private System.Windows.Forms.Label lbldetalleusuario;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Label lbllista;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Label lblapellido;
        private System.Windows.Forms.Label lblbusca;
        private System.Windows.Forms.TextBox txtbusqueda;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contrasena;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.TextBox txtindice;
        private FontAwesome.Sharp.IconButton btndesactivar;
        private FontAwesome.Sharp.IconButton btnactivar;
    }
}