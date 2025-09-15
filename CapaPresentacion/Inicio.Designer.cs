namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuusuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menubackup = new FontAwesome.Sharp.IconMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.menuproductos = new FontAwesome.Sharp.IconMenuItem();
            this.menucategoria = new FontAwesome.Sharp.IconMenuItem();
            this.menulibros = new FontAwesome.Sharp.IconMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menusalir = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.LTitulo = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.lbluser = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.menuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.menuverdetalle = new FontAwesome.Sharp.IconMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Lavender;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuarios,
            this.menubackup,
            this.menuventas,
            this.menuproductos,
            this.menuclientes,
            this.menureportes,
            this.menusalir});
            this.menu.Location = new System.Drawing.Point(0, 48);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuusuarios
            // 
            this.menuusuarios.AutoSize = false;
            this.menuusuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuusuarios.IconColor = System.Drawing.Color.Black;
            this.menuusuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuarios.Name = "menuusuarios";
            this.menuusuarios.Size = new System.Drawing.Size(80, 69);
            this.menuusuarios.Text = "Usuarios";
            this.menuusuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuarios.Click += new System.EventHandler(this.menuusuarios_Click);
            // 
            // menubackup
            // 
            this.menubackup.AutoSize = false;
            this.menubackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.menubackup.IconColor = System.Drawing.Color.Black;
            this.menubackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menubackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menubackup.Name = "menubackup";
            this.menubackup.Size = new System.Drawing.Size(80, 69);
            this.menubackup.Text = "Back Up";
            this.menubackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuregistrarventa,
            this.menuverdetalle});
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Size = new System.Drawing.Size(80, 69);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuproductos
            // 
            this.menuproductos.AutoSize = false;
            this.menuproductos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menucategoria,
            this.menulibros});
            this.menuproductos.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuproductos.IconColor = System.Drawing.Color.Black;
            this.menuproductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproductos.Name = "menuproductos";
            this.menuproductos.Size = new System.Drawing.Size(80, 69);
            this.menuproductos.Text = "Productos";
            this.menuproductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menucategoria
            // 
            this.menucategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menucategoria.IconColor = System.Drawing.Color.Black;
            this.menucategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucategoria.Name = "menucategoria";
            this.menucategoria.Size = new System.Drawing.Size(180, 22);
            this.menucategoria.Text = "Categorias";
            this.menucategoria.Click += new System.EventHandler(this.menucategoria_Click);
            // 
            // menulibros
            // 
            this.menulibros.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menulibros.IconColor = System.Drawing.Color.Black;
            this.menulibros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menulibros.Name = "menulibros";
            this.menulibros.Size = new System.Drawing.Size(180, 22);
            this.menulibros.Text = "Libros";
            this.menulibros.Click += new System.EventHandler(this.menulibros_Click);
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(80, 69);
            this.menuclientes.Text = "Clientes";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuclientes.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(80, 69);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menureportes.Click += new System.EventHandler(this.menureportes_Click);
            // 
            // menusalir
            // 
            this.menusalir.AutoSize = false;
            this.menusalir.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.menusalir.IconColor = System.Drawing.Color.Black;
            this.menusalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menusalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menusalir.Name = "menusalir";
            this.menusalir.Size = new System.Drawing.Size(80, 69);
            this.menusalir.Text = "Salir";
            this.menusalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.MidnightBlue;
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(800, 48);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.BackColor = System.Drawing.Color.MidnightBlue;
            this.LTitulo.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.Color.White;
            this.LTitulo.Location = new System.Drawing.Point(12, 9);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(198, 31);
            this.LTitulo.TabIndex = 2;
            this.LTitulo.Text = "Libreria MyP";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 121);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(800, 329);
            this.contenedor.TabIndex = 3;
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.BackColor = System.Drawing.Color.MidnightBlue;
            this.lbluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser.ForeColor = System.Drawing.Color.White;
            this.lbluser.Location = new System.Drawing.Point(580, 19);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(67, 16);
            this.lbluser.TabIndex = 4;
            this.lbluser.Text = "Usuario:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(653, 19);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(75, 16);
            this.lblusuario.TabIndex = 5;
            this.lblusuario.Text = "lblusuario";
            // 
            // menuregistrarventa
            // 
            this.menuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuregistrarventa.IconColor = System.Drawing.Color.Black;
            this.menuregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuregistrarventa.Name = "menuregistrarventa";
            this.menuregistrarventa.Size = new System.Drawing.Size(180, 22);
            this.menuregistrarventa.Text = "Registrar";
            this.menuregistrarventa.Click += new System.EventHandler(this.menuregistrarventa_Click);
            // 
            // menuverdetalle
            // 
            this.menuverdetalle.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuverdetalle.IconColor = System.Drawing.Color.Black;
            this.menuverdetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuverdetalle.Name = "menuverdetalle";
            this.menuverdetalle.Size = new System.Drawing.Size(180, 22);
            this.menuverdetalle.Text = "Ver detalle";
            this.menuverdetalle.Click += new System.EventHandler(this.menuverdetalle_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.LTitulo);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label LTitulo;
        private FontAwesome.Sharp.IconMenuItem menusalir;
        private FontAwesome.Sharp.IconMenuItem menuusuarios;
        private FontAwesome.Sharp.IconMenuItem menubackup;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menuproductos;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Label lblusuario;
        private FontAwesome.Sharp.IconMenuItem menucategoria;
        private FontAwesome.Sharp.IconMenuItem menulibros;
        private FontAwesome.Sharp.IconMenuItem menuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem menuverdetalle;
    }
}

