namespace CapaPresentacion
{
    partial class frmReporteAdmin
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUltimoBackup = new System.Windows.Forms.Label();
            this.lblTotalBackups = new System.Windows.Forms.Label();
            this.lblAlertaBackup = new System.Windows.Forms.Label();
            this.chartUsuariosActivos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUsuariosPorRol = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMontoTotal = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalLibros = new System.Windows.Forms.Label();
            this.dgvBajoStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosPorRol)).BeginInit();
            this.pnlMontoTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBajoStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(202, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(570, 142);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUltimoBackup
            // 
            this.lblUltimoBackup.AutoSize = true;
            this.lblUltimoBackup.BackColor = System.Drawing.SystemColors.Control;
            this.lblUltimoBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoBackup.ForeColor = System.Drawing.Color.Black;
            this.lblUltimoBackup.Location = new System.Drawing.Point(223, 70);
            this.lblUltimoBackup.Name = "lblUltimoBackup";
            this.lblUltimoBackup.Size = new System.Drawing.Size(14, 16);
            this.lblUltimoBackup.TabIndex = 1;
            this.lblUltimoBackup.Text = "1";
            // 
            // lblTotalBackups
            // 
            this.lblTotalBackups.AutoSize = true;
            this.lblTotalBackups.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBackups.ForeColor = System.Drawing.Color.Black;
            this.lblTotalBackups.Location = new System.Drawing.Point(223, 100);
            this.lblTotalBackups.Name = "lblTotalBackups";
            this.lblTotalBackups.Size = new System.Drawing.Size(14, 16);
            this.lblTotalBackups.TabIndex = 2;
            this.lblTotalBackups.Text = "2";
            // 
            // lblAlertaBackup
            // 
            this.lblAlertaBackup.AutoSize = true;
            this.lblAlertaBackup.BackColor = System.Drawing.SystemColors.Control;
            this.lblAlertaBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertaBackup.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAlertaBackup.Location = new System.Drawing.Point(223, 130);
            this.lblAlertaBackup.Name = "lblAlertaBackup";
            this.lblAlertaBackup.Size = new System.Drawing.Size(15, 16);
            this.lblAlertaBackup.TabIndex = 3;
            this.lblAlertaBackup.Text = "3";
            // 
            // chartUsuariosActivos
            // 
            this.chartUsuariosActivos.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea5.Name = "ChartArea1";
            this.chartUsuariosActivos.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartUsuariosActivos.Legends.Add(legend5);
            this.chartUsuariosActivos.Location = new System.Drawing.Point(202, 154);
            this.chartUsuariosActivos.Name = "chartUsuariosActivos";
            this.chartUsuariosActivos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartUsuariosActivos.Series.Add(series5);
            this.chartUsuariosActivos.Size = new System.Drawing.Size(402, 243);
            this.chartUsuariosActivos.TabIndex = 4;
            this.chartUsuariosActivos.Text = "chart1";
            // 
            // chartUsuariosPorRol
            // 
            this.chartUsuariosPorRol.BackColor = System.Drawing.SystemColors.Control;
            chartArea6.Name = "ChartArea1";
            this.chartUsuariosPorRol.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartUsuariosPorRol.Legends.Add(legend6);
            this.chartUsuariosPorRol.Location = new System.Drawing.Point(610, 154);
            this.chartUsuariosPorRol.Name = "chartUsuariosPorRol";
            this.chartUsuariosPorRol.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartUsuariosPorRol.Series.Add(series6);
            this.chartUsuariosPorRol.Size = new System.Drawing.Size(426, 243);
            this.chartUsuariosPorRol.TabIndex = 5;
            this.chartUsuariosPorRol.Text = "chart1";
            // 
            // pnlMontoTotal
            // 
            this.pnlMontoTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMontoTotal.Controls.Add(this.iconButton1);
            this.pnlMontoTotal.Controls.Add(this.label3);
            this.pnlMontoTotal.Controls.Add(this.lblTotalLibros);
            this.pnlMontoTotal.Location = new System.Drawing.Point(778, 9);
            this.pnlMontoTotal.Name = "pnlMontoTotal";
            this.pnlMontoTotal.Size = new System.Drawing.Size(258, 142);
            this.pnlMontoTotal.TabIndex = 90;
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.iconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.iconButton1.IconColor = System.Drawing.Color.RoyalBlue;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(3, 35);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(69, 65);
            this.iconButton1.TabIndex = 3;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 53);
            this.label3.TabIndex = 1;
            this.label3.Text = "TOTAL    LIBROS     REGISTRADOS :";
            // 
            // lblTotalLibros
            // 
            this.lblTotalLibros.AutoSize = true;
            this.lblTotalLibros.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLibros.Location = new System.Drawing.Point(132, 79);
            this.lblTotalLibros.Name = "lblTotalLibros";
            this.lblTotalLibros.Size = new System.Drawing.Size(24, 28);
            this.lblTotalLibros.TabIndex = 0;
            this.lblTotalLibros.Text = "0";
            // 
            // dgvBajoStock
            // 
            this.dgvBajoStock.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBajoStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBajoStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBajoStock.Location = new System.Drawing.Point(202, 404);
            this.dgvBajoStock.Name = "dgvBajoStock";
            this.dgvBajoStock.Size = new System.Drawing.Size(834, 163);
            this.dgvBajoStock.TabIndex = 91;
            // 
            // frmReporteAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1264, 606);
            this.Controls.Add(this.dgvBajoStock);
            this.Controls.Add(this.pnlMontoTotal);
            this.Controls.Add(this.chartUsuariosPorRol);
            this.Controls.Add(this.chartUsuariosActivos);
            this.Controls.Add(this.lblAlertaBackup);
            this.Controls.Add(this.lblTotalBackups);
            this.Controls.Add(this.lblUltimoBackup);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmReporteAdmin";
            this.Text = "frmReporteAdmin";
            this.Load += new System.EventHandler(this.frmReporteAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosActivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosPorRol)).EndInit();
            this.pnlMontoTotal.ResumeLayout(false);
            this.pnlMontoTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBajoStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUltimoBackup;
        private System.Windows.Forms.Label lblTotalBackups;
        private System.Windows.Forms.Label lblAlertaBackup;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsuariosActivos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsuariosPorRol;
        private System.Windows.Forms.Panel pnlMontoTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalLibros;
        private System.Windows.Forms.DataGridView dgvBajoStock;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}