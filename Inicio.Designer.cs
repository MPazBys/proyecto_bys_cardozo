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
            this.usuarios = new FontAwesome.Sharp.IconMenuItem();
            this.backup = new FontAwesome.Sharp.IconMenuItem();
            this.reportes = new FontAwesome.Sharp.IconMenuItem();
            this.salir = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.LTitulo = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Lavender;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarios,
            this.backup,
            this.reportes,
            this.salir});
            this.menu.Location = new System.Drawing.Point(0, 48);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // usuarios
            // 
            this.usuarios.AutoSize = false;
            this.usuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.usuarios.IconColor = System.Drawing.Color.Black;
            this.usuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.usuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(80, 69);
            this.usuarios.Text = "Usuarios";
            this.usuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // backup
            // 
            this.backup.AutoSize = false;
            this.backup.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.backup.IconColor = System.Drawing.Color.Black;
            this.backup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.backup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.backup.Name = "backup";
            this.backup.Size = new System.Drawing.Size(80, 69);
            this.backup.Text = "Back Up";
            this.backup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // reportes
            // 
            this.reportes.AutoSize = false;
            this.reportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.reportes.IconColor = System.Drawing.Color.Black;
            this.reportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportes.Name = "reportes";
            this.reportes.Size = new System.Drawing.Size(80, 69);
            this.reportes.Text = "Reportes";
            this.reportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // salir
            // 
            this.salir.AutoSize = false;
            this.salir.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.salir.IconColor = System.Drawing.Color.Black;
            this.salir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(80, 69);
            this.salir.Text = "Salir";
            this.salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private FontAwesome.Sharp.IconMenuItem salir;
        private FontAwesome.Sharp.IconMenuItem usuarios;
        private FontAwesome.Sharp.IconMenuItem backup;
        private FontAwesome.Sharp.IconMenuItem reportes;
        private System.Windows.Forms.Panel contenedor;
    }
}

