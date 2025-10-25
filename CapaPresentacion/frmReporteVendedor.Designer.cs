﻿namespace CapaPresentacion
{
    partial class chartResumen
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMontoTotal = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.pnlTransferencia = new System.Windows.Forms.Panel();
            this.lblTransferencia = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlEfectivo = new System.Windows.Forms.Panel();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlDebito = new System.Windows.Forms.Panel();
            this.lblDebito = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.dgvTopClientes = new System.Windows.Forms.DataGridView();
            this.chartResumenVenta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.pnlMontoTotal.SuspendLayout();
            this.pnlTransferencia.SuspendLayout();
            this.pnlEfectivo.SuspendLayout();
            this.pnlDebito.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResumenVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(575, 170);
            this.label4.TabIndex = 10;
            this.label4.Text = "Reportes Ventas:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.cmbPeriodo);
            this.groupBox1.Controls.Add(this.btnAplicarFiltro);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 133);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Periodo:";
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(254, 31);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(151, 24);
            this.cmbPeriodo.TabIndex = 63;
            this.cmbPeriodo.Text = "Seleccionar período:";
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.BackColor = System.Drawing.Color.LightBlue;
            this.btnAplicarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltro.ForeColor = System.Drawing.Color.Black;
            this.btnAplicarFiltro.Location = new System.Drawing.Point(415, 98);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(99, 29);
            this.btnAplicarFiltro.TabIndex = 58;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = false;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(108, 72);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(132, 21);
            this.dtpFechaFin.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Fecha Fin";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(108, 33);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(132, 21);
            this.dtpFechaInicio.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio";
            // 
            // pnlMontoTotal
            // 
            this.pnlMontoTotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMontoTotal.Controls.Add(this.label3);
            this.pnlMontoTotal.Controls.Add(this.lblMontoTotal);
            this.pnlMontoTotal.Location = new System.Drawing.Point(18, 12);
            this.pnlMontoTotal.Name = "pnlMontoTotal";
            this.pnlMontoTotal.Size = new System.Drawing.Size(194, 100);
            this.pnlMontoTotal.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 41);
            this.label3.TabIndex = 1;
            this.label3.Text = "MONTO   TOTAL         VENTAS:";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(41, 60);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(71, 29);
            this.lblMontoTotal.TabIndex = 0;
            this.lblMontoTotal.Text = "$0,00";
            // 
            // pnlTransferencia
            // 
            this.pnlTransferencia.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnlTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTransferencia.Controls.Add(this.lblTransferencia);
            this.pnlTransferencia.Controls.Add(this.label5);
            this.pnlTransferencia.Location = new System.Drawing.Point(238, 12);
            this.pnlTransferencia.Name = "pnlTransferencia";
            this.pnlTransferencia.Size = new System.Drawing.Size(190, 100);
            this.pnlTransferencia.TabIndex = 90;
            // 
            // lblTransferencia
            // 
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferencia.Location = new System.Drawing.Point(40, 60);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(71, 29);
            this.lblTransferencia.TabIndex = 3;
            this.lblTransferencia.Text = "$0,00";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 53);
            this.label5.TabIndex = 2;
            this.label5.Text = "MONTO     TOTAL      TRANSFERENCIAS:";
            // 
            // pnlEfectivo
            // 
            this.pnlEfectivo.BackColor = System.Drawing.Color.LightBlue;
            this.pnlEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlEfectivo.Controls.Add(this.lblEfectivo);
            this.pnlEfectivo.Controls.Add(this.label7);
            this.pnlEfectivo.Location = new System.Drawing.Point(18, 132);
            this.pnlEfectivo.Name = "pnlEfectivo";
            this.pnlEfectivo.Size = new System.Drawing.Size(194, 100);
            this.pnlEfectivo.TabIndex = 91;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.Location = new System.Drawing.Point(45, 60);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(71, 29);
            this.lblEfectivo.TabIndex = 4;
            this.lblEfectivo.Text = "$0,00";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 52);
            this.label7.TabIndex = 2;
            this.label7.Text = "MONTO  TOTAL            EFECTIVO:";
            // 
            // pnlDebito
            // 
            this.pnlDebito.BackColor = System.Drawing.Color.RosyBrown;
            this.pnlDebito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDebito.Controls.Add(this.lblDebito);
            this.pnlDebito.Controls.Add(this.label8);
            this.pnlDebito.Location = new System.Drawing.Point(234, 132);
            this.pnlDebito.Name = "pnlDebito";
            this.pnlDebito.Size = new System.Drawing.Size(194, 100);
            this.pnlDebito.TabIndex = 92;
            // 
            // lblDebito
            // 
            this.lblDebito.AutoSize = true;
            this.lblDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebito.Location = new System.Drawing.Point(45, 60);
            this.lblDebito.Name = "lblDebito";
            this.lblDebito.Size = new System.Drawing.Size(71, 29);
            this.lblDebito.TabIndex = 4;
            this.lblDebito.Text = "$0,00";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 52);
            this.label8.TabIndex = 3;
            this.label8.Text = "MONTO  TOTAL           T. DEBITO:";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumen.Controls.Add(this.pnlDebito);
            this.pnlResumen.Controls.Add(this.pnlMontoTotal);
            this.pnlResumen.Controls.Add(this.pnlEfectivo);
            this.pnlResumen.Controls.Add(this.pnlTransferencia);
            this.pnlResumen.Location = new System.Drawing.Point(12, 185);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(455, 244);
            this.pnlResumen.TabIndex = 93;
            // 
            // dgvTopClientes
            // 
            this.dgvTopClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopClientes.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvTopClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopClientes.Location = new System.Drawing.Point(593, 9);
            this.dgvTopClientes.Name = "dgvTopClientes";
            this.dgvTopClientes.Size = new System.Drawing.Size(437, 170);
            this.dgvTopClientes.TabIndex = 94;
            // 
            // chartResumenVenta
            // 
            chartArea3.Name = "ChartArea1";
            this.chartResumenVenta.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartResumenVenta.Legends.Add(legend3);
            this.chartResumenVenta.Location = new System.Drawing.Point(473, 185);
            this.chartResumenVenta.Name = "chartResumenVenta";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartResumenVenta.Series.Add(series3);
            this.chartResumenVenta.Size = new System.Drawing.Size(557, 244);
            this.chartResumenVenta.TabIndex = 96;
            this.chartResumenVenta.Text = "chart1";
            // 
            // chartResumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1059, 463);
            this.Controls.Add(this.chartResumenVenta);
            this.Controls.Add(this.dgvTopClientes);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Name = "chartResumen";
            this.Text = "frmReportes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMontoTotal.ResumeLayout(false);
            this.pnlMontoTotal.PerformLayout();
            this.pnlTransferencia.ResumeLayout(false);
            this.pnlTransferencia.PerformLayout();
            this.pnlEfectivo.ResumeLayout(false);
            this.pnlEfectivo.PerformLayout();
            this.pnlDebito.ResumeLayout(false);
            this.pnlDebito.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResumenVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.Panel pnlMontoTotal;
        private System.Windows.Forms.Panel pnlTransferencia;
        private System.Windows.Forms.Panel pnlEfectivo;
        private System.Windows.Forms.Panel pnlDebito;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTransferencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblDebito;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvTopClientes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResumenVenta;
    }
}