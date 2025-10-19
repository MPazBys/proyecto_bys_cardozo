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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUltimoBackup = new System.Windows.Forms.Label();
            this.lblTotalBackups = new System.Windows.Forms.Label();
            this.lblAlertaBackup = new System.Windows.Forms.Label();
            this.chartUsuariosActivos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUsuariosPorRol = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosPorRol)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(25, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(835, 148);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUltimoBackup
            // 
            this.lblUltimoBackup.AutoSize = true;
            this.lblUltimoBackup.BackColor = System.Drawing.Color.White;
            this.lblUltimoBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoBackup.ForeColor = System.Drawing.Color.Black;
            this.lblUltimoBackup.Location = new System.Drawing.Point(46, 70);
            this.lblUltimoBackup.Name = "lblUltimoBackup";
            this.lblUltimoBackup.Size = new System.Drawing.Size(14, 16);
            this.lblUltimoBackup.TabIndex = 1;
            this.lblUltimoBackup.Text = "1";
            // 
            // lblTotalBackups
            // 
            this.lblTotalBackups.AutoSize = true;
            this.lblTotalBackups.BackColor = System.Drawing.Color.White;
            this.lblTotalBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBackups.ForeColor = System.Drawing.Color.Black;
            this.lblTotalBackups.Location = new System.Drawing.Point(46, 100);
            this.lblTotalBackups.Name = "lblTotalBackups";
            this.lblTotalBackups.Size = new System.Drawing.Size(14, 16);
            this.lblTotalBackups.TabIndex = 2;
            this.lblTotalBackups.Text = "2";
            // 
            // lblAlertaBackup
            // 
            this.lblAlertaBackup.AutoSize = true;
            this.lblAlertaBackup.BackColor = System.Drawing.Color.White;
            this.lblAlertaBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertaBackup.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAlertaBackup.Location = new System.Drawing.Point(46, 130);
            this.lblAlertaBackup.Name = "lblAlertaBackup";
            this.lblAlertaBackup.Size = new System.Drawing.Size(15, 16);
            this.lblAlertaBackup.TabIndex = 3;
            this.lblAlertaBackup.Text = "3";
            // 
            // chartUsuariosActivos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartUsuariosActivos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartUsuariosActivos.Legends.Add(legend1);
            this.chartUsuariosActivos.Location = new System.Drawing.Point(25, 180);
            this.chartUsuariosActivos.Name = "chartUsuariosActivos";
            this.chartUsuariosActivos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartUsuariosActivos.Series.Add(series1);
            this.chartUsuariosActivos.Size = new System.Drawing.Size(400, 300);
            this.chartUsuariosActivos.TabIndex = 4;
            this.chartUsuariosActivos.Text = "chart1";
            // 
            // chartUsuariosPorRol
            // 
            chartArea2.Name = "ChartArea1";
            this.chartUsuariosPorRol.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartUsuariosPorRol.Legends.Add(legend2);
            this.chartUsuariosPorRol.Location = new System.Drawing.Point(460, 180);
            this.chartUsuariosPorRol.Name = "chartUsuariosPorRol";
            this.chartUsuariosPorRol.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartUsuariosPorRol.Series.Add(series2);
            this.chartUsuariosPorRol.Size = new System.Drawing.Size(400, 300);
            this.chartUsuariosPorRol.TabIndex = 5;
            this.chartUsuariosPorRol.Text = "chart1";
            // 
            // frmReporteAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(991, 749);
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
    }
}