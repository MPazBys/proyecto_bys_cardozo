namespace CapaPresentacion
{
    partial class frmBackup
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
            this.btnConectar = new FontAwesome.Sharp.IconButton();
            this.cboBD = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBD = new System.Windows.Forms.Label();
            this.btnRuta = new FontAwesome.Sharp.IconButton();
            this.lblRuta = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnbackup = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.White;
            this.btnConectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConectar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.ForeColor = System.Drawing.Color.Black;
            this.btnConectar.IconChar = FontAwesome.Sharp.IconChar.Plug;
            this.btnConectar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConectar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConectar.IconSize = 16;
            this.btnConectar.Location = new System.Drawing.Point(431, 92);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(104, 24);
            this.btnConectar.TabIndex = 71;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConectar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // cboBD
            // 
            this.cboBD.FormattingEnabled = true;
            this.cboBD.Location = new System.Drawing.Point(126, 95);
            this.cboBD.Name = "cboBD";
            this.cboBD.Size = new System.Drawing.Size(279, 21);
            this.cboBD.TabIndex = 69;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitulo.Location = new System.Drawing.Point(12, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(545, 51);
            this.lblTitulo.TabIndex = 68;
            this.lblTitulo.Text = "Back Up";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBD
            // 
            this.lblBD.BackColor = System.Drawing.Color.White;
            this.lblBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBD.Location = new System.Drawing.Point(12, 78);
            this.lblBD.Name = "lblBD";
            this.lblBD.Size = new System.Drawing.Size(545, 51);
            this.lblBD.TabIndex = 70;
            this.lblBD.Text = "Base de Datos:";
            this.lblBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRuta
            // 
            this.btnRuta.BackColor = System.Drawing.Color.White;
            this.btnRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRuta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuta.ForeColor = System.Drawing.Color.Black;
            this.btnRuta.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnRuta.IconColor = System.Drawing.Color.DarkGoldenrod;
            this.btnRuta.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnRuta.IconSize = 16;
            this.btnRuta.Location = new System.Drawing.Point(431, 149);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(104, 24);
            this.btnRuta.TabIndex = 74;
            this.btnRuta.Text = "Ruta";
            this.btnRuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRuta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRuta.UseVisualStyleBackColor = false;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.BackColor = System.Drawing.Color.White;
            this.lblRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta.Location = new System.Drawing.Point(12, 135);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(545, 51);
            this.lblRuta.TabIndex = 73;
            this.lblRuta.Text = "Ruta:";
            this.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(58, 149);
            this.txtRuta.Multiline = true;
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(347, 24);
            this.txtRuta.TabIndex = 75;
            // 
            // btnbackup
            // 
            this.btnbackup.BackColor = System.Drawing.Color.SkyBlue;
            this.btnbackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbackup.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbackup.ForeColor = System.Drawing.Color.Black;
            this.btnbackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnbackup.IconColor = System.Drawing.Color.Black;
            this.btnbackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbackup.IconSize = 16;
            this.btnbackup.Location = new System.Drawing.Point(431, 209);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(124, 30);
            this.btnbackup.TabIndex = 89;
            this.btnbackup.Text = "Back Up";
            this.btnbackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbackup.UseVisualStyleBackColor = false;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(569, 263);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.cboBD);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBD);
            this.Name = "frmBackup";
            this.Text = "frmBackup";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnConectar;
        private System.Windows.Forms.ComboBox cboBD;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBD;
        private FontAwesome.Sharp.IconButton btnRuta;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.TextBox txtRuta;
        private FontAwesome.Sharp.IconButton btnbackup;
    }
}