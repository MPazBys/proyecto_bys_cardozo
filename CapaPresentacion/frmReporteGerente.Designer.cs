namespace CapaPresentacion
{
    partial class frmReporteGerente
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.pnlDebito = new System.Windows.Forms.Panel();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMejorVendedor = new System.Windows.Forms.Label();
            this.pnlMontoTotal = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.pnlEfectivo = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLibrosVendidos = new System.Windows.Forms.Label();
            this.pnlTransferencia = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.lblIngresosTotales = new System.Windows.Forms.Label();
            this.chartTopLibros = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPeorLibros = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvPromociones = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chartPromociones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPromocionesUsadas = new System.Windows.Forms.DataGridView();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.timerContadores = new System.Windows.Forms.Timer(this.components);
            this.pnlResumen.SuspendLayout();
            this.pnlDebito.SuspendLayout();
            this.pnlMontoTotal.SuspendLayout();
            this.pnlEfectivo.SuspendLayout();
            this.pnlTransferencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeorLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromociones)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromocionesUsadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(623, 48);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(112, 21);
            this.dtpFechaFin.TabIndex = 75;
            this.dtpFechaFin.Value = new System.DateTime(2025, 9, 22, 15, 52, 23, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(540, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 74;
            this.label1.Text = "Fecha Fin:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(268, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 18);
            this.label5.TabIndex = 73;
            this.label5.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(365, 48);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(112, 21);
            this.dtpFechaInicio.TabIndex = 72;
            this.dtpFechaInicio.Value = new System.DateTime(2025, 9, 22, 15, 52, 16, 0);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(189, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(965, 78);
            this.label4.TabIndex = 71;
            this.label4.Text = "                                         Panel Gerencial - Resumen de Ventas y Pr" +
    "omociones";
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(801, 46);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(151, 23);
            this.cmbPeriodo.TabIndex = 95;
            this.cmbPeriodo.Text = "Seleccionar período:";
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltro.ForeColor = System.Drawing.Color.Azure;
            this.btnAplicarFiltro.Location = new System.Drawing.Point(1031, 26);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(113, 38);
            this.btnAplicarFiltro.TabIndex = 96;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = false;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlResumen.Controls.Add(this.pnlDebito);
            this.pnlResumen.Controls.Add(this.pnlMontoTotal);
            this.pnlResumen.Controls.Add(this.pnlEfectivo);
            this.pnlResumen.Controls.Add(this.pnlTransferencia);
            this.pnlResumen.Location = new System.Drawing.Point(131, 70);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(1041, 122);
            this.pnlResumen.TabIndex = 97;
            // 
            // pnlDebito
            // 
            this.pnlDebito.BackColor = System.Drawing.Color.RosyBrown;
            this.pnlDebito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDebito.Controls.Add(this.iconButton4);
            this.pnlDebito.Controls.Add(this.label7);
            this.pnlDebito.Controls.Add(this.lblMejorVendedor);
            this.pnlDebito.Location = new System.Drawing.Point(793, 12);
            this.pnlDebito.Name = "pnlDebito";
            this.pnlDebito.Size = new System.Drawing.Size(245, 100);
            this.pnlDebito.TabIndex = 92;
            // 
            // iconButton4
            // 
            this.iconButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton4.BackColor = System.Drawing.Color.RosyBrown;
            this.iconButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButton4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.ForeColor = System.Drawing.Color.Tan;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.iconButton4.IconColor = System.Drawing.Color.White;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.Location = new System.Drawing.Point(3, 24);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(37, 44);
            this.iconButton4.TabIndex = 100;
            this.iconButton4.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(46, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 25);
            this.label7.TabIndex = 99;
            this.label7.Text = "MEJOR VENDEDOR:";
            // 
            // lblMejorVendedor
            // 
            this.lblMejorVendedor.AutoSize = true;
            this.lblMejorVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMejorVendedor.ForeColor = System.Drawing.Color.White;
            this.lblMejorVendedor.Location = new System.Drawing.Point(62, 48);
            this.lblMejorVendedor.Name = "lblMejorVendedor";
            this.lblMejorVendedor.Size = new System.Drawing.Size(127, 24);
            this.lblMejorVendedor.TabIndex = 4;
            this.lblMejorVendedor.Text = "JUAN PERES";
            // 
            // pnlMontoTotal
            // 
            this.pnlMontoTotal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlMontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMontoTotal.Controls.Add(this.iconButton1);
            this.pnlMontoTotal.Controls.Add(this.label3);
            this.pnlMontoTotal.Controls.Add(this.lblTotalVentas);
            this.pnlMontoTotal.Location = new System.Drawing.Point(14, 12);
            this.pnlMontoTotal.Name = "pnlMontoTotal";
            this.pnlMontoTotal.Size = new System.Drawing.Size(245, 100);
            this.pnlMontoTotal.TabIndex = 89;
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.iconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(-2, 18);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(52, 54);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "TOTAL VENTAS:";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.ForeColor = System.Drawing.Color.White;
            this.lblTotalVentas.Location = new System.Drawing.Point(98, 43);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(39, 29);
            this.lblTotalVentas.TabIndex = 0;
            this.lblTotalVentas.Text = "00";
            // 
            // pnlEfectivo
            // 
            this.pnlEfectivo.BackColor = System.Drawing.Color.Tan;
            this.pnlEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlEfectivo.Controls.Add(this.iconButton3);
            this.pnlEfectivo.Controls.Add(this.label2);
            this.pnlEfectivo.Controls.Add(this.lblLibrosVendidos);
            this.pnlEfectivo.Location = new System.Drawing.Point(534, 12);
            this.pnlEfectivo.Name = "pnlEfectivo";
            this.pnlEfectivo.Size = new System.Drawing.Size(245, 100);
            this.pnlEfectivo.TabIndex = 91;
            // 
            // iconButton3
            // 
            this.iconButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton3.BackColor = System.Drawing.Color.Tan;
            this.iconButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButton3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.ForeColor = System.Drawing.Color.Tan;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.Location = new System.Drawing.Point(3, 24);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(37, 44);
            this.iconButton3.TabIndex = 99;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 25);
            this.label2.TabIndex = 98;
            this.label2.Text = "LIBROS VENDIDOS:";
            // 
            // lblLibrosVendidos
            // 
            this.lblLibrosVendidos.AutoSize = true;
            this.lblLibrosVendidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibrosVendidos.ForeColor = System.Drawing.Color.White;
            this.lblLibrosVendidos.Location = new System.Drawing.Point(103, 43);
            this.lblLibrosVendidos.Name = "lblLibrosVendidos";
            this.lblLibrosVendidos.Size = new System.Drawing.Size(39, 29);
            this.lblLibrosVendidos.TabIndex = 4;
            this.lblLibrosVendidos.Text = "00";
            // 
            // pnlTransferencia
            // 
            this.pnlTransferencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTransferencia.BackColor = System.Drawing.Color.YellowGreen;
            this.pnlTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTransferencia.Controls.Add(this.label6);
            this.pnlTransferencia.Controls.Add(this.iconButton2);
            this.pnlTransferencia.Controls.Add(this.lblIngresosTotales);
            this.pnlTransferencia.Location = new System.Drawing.Point(274, 12);
            this.pnlTransferencia.Name = "pnlTransferencia";
            this.pnlTransferencia.Size = new System.Drawing.Size(245, 100);
            this.pnlTransferencia.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(34, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "INGRESOS  TOTALES:";
            // 
            // iconButton2
            // 
            this.iconButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton2.BackColor = System.Drawing.Color.YellowGreen;
            this.iconButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconButton2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(-2, 24);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(37, 44);
            this.iconButton2.TabIndex = 4;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // lblIngresosTotales
            // 
            this.lblIngresosTotales.AutoSize = true;
            this.lblIngresosTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosTotales.ForeColor = System.Drawing.Color.White;
            this.lblIngresosTotales.Location = new System.Drawing.Point(48, 43);
            this.lblIngresosTotales.Name = "lblIngresosTotales";
            this.lblIngresosTotales.Size = new System.Drawing.Size(71, 29);
            this.lblIngresosTotales.TabIndex = 3;
            this.lblIngresosTotales.Text = "$0,00";
            // 
            // chartTopLibros
            // 
            this.chartTopLibros.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chartTopLibros.BorderlineColor = System.Drawing.Color.LightGray;
            this.chartTopLibros.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartTopLibros.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTopLibros.Legends.Add(legend1);
            this.chartTopLibros.Location = new System.Drawing.Point(145, 199);
            this.chartTopLibros.Name = "chartTopLibros";
            this.chartTopLibros.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTopLibros.Series.Add(series1);
            this.chartTopLibros.Size = new System.Drawing.Size(332, 178);
            this.chartTopLibros.TabIndex = 98;
            this.chartTopLibros.Text = "chart1";
            // 
            // chartPeorLibros
            // 
            this.chartPeorLibros.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chartPeorLibros.BorderlineColor = System.Drawing.Color.LightGray;
            this.chartPeorLibros.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chartPeorLibros.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPeorLibros.Legends.Add(legend2);
            this.chartPeorLibros.Location = new System.Drawing.Point(496, 198);
            this.chartPeorLibros.Name = "chartPeorLibros";
            this.chartPeorLibros.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPeorLibros.Series.Add(series2);
            this.chartPeorLibros.Size = new System.Drawing.Size(348, 178);
            this.chartPeorLibros.TabIndex = 99;
            this.chartPeorLibros.Text = "chart2";
            // 
            // dgvPromociones
            // 
            this.dgvPromociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromociones.Location = new System.Drawing.Point(857, 225);
            this.dgvPromociones.Name = "dgvPromociones";
            this.dgvPromociones.Size = new System.Drawing.Size(312, 151);
            this.dgvPromociones.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(909, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 25);
            this.label8.TabIndex = 101;
            this.label8.Text = "PROMOCIONES   ACTIVAS:";
          
            // 
            // label9
            // 
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(99, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(294, 25);
            this.label9.TabIndex = 102;
            this.label9.Text = "PROMOCIONES MAS UTILIZADAS:";
         
            // 
            // chartPromociones
            // 
            this.chartPromociones.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chartPromociones.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPromociones.Legends.Add(legend3);
            this.chartPromociones.Location = new System.Drawing.Point(349, 0);
            this.chartPromociones.Name = "chartPromociones";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartPromociones.Series.Add(series3);
            this.chartPromociones.Size = new System.Drawing.Size(334, 180);
            this.chartPromociones.TabIndex = 103;
            this.chartPromociones.Text = "chart1";
           
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvPromocionesUsadas);
            this.panel2.Controls.Add(this.chartPromociones);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(145, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 190);
            this.panel2.TabIndex = 90;
            // 
            // dgvPromocionesUsadas
            // 
            this.dgvPromocionesUsadas.BackgroundColor = System.Drawing.Color.White;
            this.dgvPromocionesUsadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromocionesUsadas.Location = new System.Drawing.Point(12, 28);
            this.dgvPromocionesUsadas.Name = "dgvPromocionesUsadas";
            this.dgvPromocionesUsadas.Size = new System.Drawing.Size(318, 137);
            this.dgvPromocionesUsadas.TabIndex = 104;
            this.dgvPromocionesUsadas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPromocionesUsadas_CellFormatting);
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Location = new System.Drawing.Point(860, 385);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.Size = new System.Drawing.Size(312, 190);
            this.dgvVendedores.TabIndex = 102;
            // 
            // timerContadores
            // 
            this.timerContadores.Tick += new System.EventHandler(this.timerContadores_Tick);
            // 
            // frmReporteGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1267, 713);
            this.Controls.Add(this.dgvVendedores);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvPromociones);
            this.Controls.Add(this.chartPeorLibros);
            this.Controls.Add(this.chartTopLibros);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.btnAplicarFiltro);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label4);
            this.Name = "frmReporteGerente";
            this.Text = "frmReporteGerente";
            this.pnlResumen.ResumeLayout(false);
            this.pnlDebito.ResumeLayout(false);
            this.pnlDebito.PerformLayout();
            this.pnlMontoTotal.ResumeLayout(false);
            this.pnlMontoTotal.PerformLayout();
            this.pnlEfectivo.ResumeLayout(false);
            this.pnlEfectivo.PerformLayout();
            this.pnlTransferencia.ResumeLayout(false);
            this.pnlTransferencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeorLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPromociones)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromocionesUsadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Panel pnlDebito;
        private System.Windows.Forms.Label lblMejorVendedor;
        private System.Windows.Forms.Panel pnlMontoTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Panel pnlEfectivo;
        private System.Windows.Forms.Label lblLibrosVendidos;
        private System.Windows.Forms.Panel pnlTransferencia;
        private System.Windows.Forms.Label lblIngresosTotales;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopLibros;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeorLibros;
        private System.Windows.Forms.DataGridView dgvPromociones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPromociones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPromocionesUsadas;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.Timer timerContadores;
    }
}