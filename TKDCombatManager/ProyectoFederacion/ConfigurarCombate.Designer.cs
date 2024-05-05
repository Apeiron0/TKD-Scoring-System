namespace ProyectoFederacion
{
    partial class ConfigurarCombate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurarCombate));
            this.label6 = new System.Windows.Forms.Label();
            this.txtTiempoMarcaje = new System.Windows.Forms.MaskedTextBox();
            this.spinAmonestaciones = new System.Windows.Forms.NumericUpDown();
            this.spinDiferenciaMaxima = new System.Windows.Forms.NumericUpDown();
            this.txtTiempoMedico = new System.Windows.Forms.MaskedTextBox();
            this.txtTiempoCombate = new System.Windows.Forms.MaskedTextBox();
            this.groupRounds = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioDosRounds = new System.Windows.Forms.RadioButton();
            this.radioTresRounds = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tmpPausaRounds = new System.Windows.Forms.MaskedTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinAmonestaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiferenciaMaxima)).BeginInit();
            this.groupRounds.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "segundos";
            // 
            // txtTiempoMarcaje
            // 
            this.txtTiempoMarcaje.Location = new System.Drawing.Point(3, 3);
            this.txtTiempoMarcaje.Mask = "9.99";
            this.txtTiempoMarcaje.Name = "txtTiempoMarcaje";
            this.txtTiempoMarcaje.Size = new System.Drawing.Size(72, 20);
            this.txtTiempoMarcaje.TabIndex = 9;
            this.txtTiempoMarcaje.Text = "100";
            this.txtTiempoMarcaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spinAmonestaciones
            // 
            this.spinAmonestaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinAmonestaciones.Location = new System.Drawing.Point(209, 239);
            this.spinAmonestaciones.Name = "spinAmonestaciones";
            this.spinAmonestaciones.Size = new System.Drawing.Size(201, 20);
            this.spinAmonestaciones.TabIndex = 8;
            this.spinAmonestaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinAmonestaciones.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // spinDiferenciaMaxima
            // 
            this.spinDiferenciaMaxima.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinDiferenciaMaxima.Location = new System.Drawing.Point(209, 114);
            this.spinDiferenciaMaxima.Name = "spinDiferenciaMaxima";
            this.spinDiferenciaMaxima.Size = new System.Drawing.Size(201, 20);
            this.spinDiferenciaMaxima.TabIndex = 4;
            this.spinDiferenciaMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinDiferenciaMaxima.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // txtTiempoMedico
            // 
            this.txtTiempoMedico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTiempoMedico.Location = new System.Drawing.Point(209, 40);
            this.txtTiempoMedico.Mask = "00:00";
            this.txtTiempoMedico.Name = "txtTiempoMedico";
            this.txtTiempoMedico.Size = new System.Drawing.Size(201, 20);
            this.txtTiempoMedico.TabIndex = 2;
            this.txtTiempoMedico.Text = "0100";
            this.txtTiempoMedico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTiempoMedico.ValidatingType = typeof(System.DateTime);
            // 
            // txtTiempoCombate
            // 
            this.txtTiempoCombate.BeepOnError = true;
            this.txtTiempoCombate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTiempoCombate.Location = new System.Drawing.Point(209, 3);
            this.txtTiempoCombate.Mask = "00:00";
            this.txtTiempoCombate.Name = "txtTiempoCombate";
            this.txtTiempoCombate.Size = new System.Drawing.Size(201, 20);
            this.txtTiempoCombate.TabIndex = 1;
            this.txtTiempoCombate.Text = "0200";
            this.txtTiempoCombate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTiempoCombate.ValidatingType = typeof(System.DateTime);
            // 
            // groupRounds
            // 
            this.groupRounds.Controls.Add(this.flowLayoutPanel3);
            this.groupRounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRounds.Location = new System.Drawing.Point(3, 159);
            this.groupRounds.Name = "groupRounds";
            this.groupRounds.Size = new System.Drawing.Size(200, 74);
            this.groupRounds.TabIndex = 5;
            this.groupRounds.TabStop = false;
            this.groupRounds.Text = "Rounds";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.radioDosRounds);
            this.flowLayoutPanel3.Controls.Add(this.radioTresRounds);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(194, 55);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // radioDosRounds
            // 
            this.radioDosRounds.AutoSize = true;
            this.radioDosRounds.Location = new System.Drawing.Point(3, 3);
            this.radioDosRounds.Name = "radioDosRounds";
            this.radioDosRounds.Size = new System.Drawing.Size(66, 17);
            this.radioDosRounds.TabIndex = 6;
            this.radioDosRounds.Text = "2 rounds";
            this.radioDosRounds.UseVisualStyleBackColor = true;
            // 
            // radioTresRounds
            // 
            this.radioTresRounds.AutoSize = true;
            this.radioTresRounds.Checked = true;
            this.radioTresRounds.Location = new System.Drawing.Point(3, 26);
            this.radioTresRounds.Name = "radioTresRounds";
            this.radioTresRounds.Size = new System.Drawing.Size(66, 17);
            this.radioTresRounds.TabIndex = 7;
            this.radioTresRounds.TabStop = true;
            this.radioTresRounds.Text = "3 rounds";
            this.radioTresRounds.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 41);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tiempo para marcar los puntos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 37);
            this.label4.TabIndex = 20;
            this.label4.Text = "Amonestaciones para ganar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 45);
            this.label3.TabIndex = 19;
            this.label3.Text = "Punteo de diferencia para ganar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 37);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tiempo de descanso (tiempo médico)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 37);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tiempo de combate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(313, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 23);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(210, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(97, 23);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "Nuevo combate";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tmpPausaRounds, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.spinAmonestaciones, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtTiempoCombate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.groupRounds, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.spinDiferenciaMaxima, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTiempoMedico, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.35484F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(413, 314);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // tmpPausaRounds
            // 
            this.tmpPausaRounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmpPausaRounds.Location = new System.Drawing.Point(209, 77);
            this.tmpPausaRounds.Mask = "00:00";
            this.tmpPausaRounds.Name = "tmpPausaRounds";
            this.tmpPausaRounds.Size = new System.Drawing.Size(201, 20);
            this.tmpPausaRounds.TabIndex = 3;
            this.tmpPausaRounds.Text = "0100";
            this.tmpPausaRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tmpPausaRounds.ValidatingType = typeof(System.DateTime);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtTiempoMarcaje);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(209, 276);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(201, 35);
            this.flowLayoutPanel2.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 37);
            this.label7.TabIndex = 28;
            this.label7.Text = "Pausa entre rounds";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSalir);
            this.flowLayoutPanel1.Controls.Add(this.btnNuevo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 314);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(413, 29);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(209, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 74);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formato";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tradicional";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "El Mejor de 3";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // ConfigurarCombate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 343);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "F1");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ConfigurarCombate";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Combate";
            this.Load += new System.EventHandler(this.OpcionesCombate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigurarCombate_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinAmonestaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiferenciaMaxima)).EndInit();
            this.groupRounds.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtTiempoMarcaje;
        private System.Windows.Forms.NumericUpDown spinAmonestaciones;
        private System.Windows.Forms.NumericUpDown spinDiferenciaMaxima;
        private System.Windows.Forms.MaskedTextBox txtTiempoMedico;
        private System.Windows.Forms.MaskedTextBox txtTiempoCombate;
        private System.Windows.Forms.GroupBox groupRounds;
        private System.Windows.Forms.RadioButton radioTresRounds;
        private System.Windows.Forms.RadioButton radioDosRounds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.MaskedTextBox tmpPausaRounds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}