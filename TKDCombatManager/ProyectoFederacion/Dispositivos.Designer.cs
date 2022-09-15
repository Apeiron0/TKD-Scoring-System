namespace ProyectoFederacion
{
    partial class Dispositivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dispositivos));
            this.timerPrincipal = new System.Windows.Forms.Timer(this.components);
            this.tabIdentificar = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNombre = new System.Windows.Forms.Label();
            this.muestraDesactivado = new System.Windows.Forms.PictureBox();
            this.muestraActivado = new System.Windows.Forms.PictureBox();
            this.botonSalir = new System.Windows.Forms.Button();
            this.botonSiguiente = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boton5 = new System.Windows.Forms.PictureBox();
            this.boton9 = new System.Windows.Forms.PictureBox();
            this.boton7 = new System.Windows.Forms.PictureBox();
            this.boton1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boton3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boton2 = new System.Windows.Forms.PictureBox();
            this.boton0 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.boton4 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.boton6 = new System.Windows.Forms.PictureBox();
            this.boton11 = new System.Windows.Forms.PictureBox();
            this.boton13 = new System.Windows.Forms.PictureBox();
            this.boton10 = new System.Windows.Forms.PictureBox();
            this.boton12 = new System.Windows.Forms.PictureBox();
            this.boton8 = new System.Windows.Forms.PictureBox();
            this.btnConfiguracionAvanzada = new System.Windows.Forms.Button();
            this.btnConfiguracionTipica = new System.Windows.Forms.Button();
            this.btnProbar = new System.Windows.Forms.Button();
            this.btnDetectar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabIdentificar.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.muestraDesactivado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muestraActivado)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton0)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton8)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPrincipal
            // 
            this.timerPrincipal.Interval = 20;
            this.timerPrincipal.Tick += new System.EventHandler(this.timerPrincipal_Tick);
            // 
            // tabIdentificar
            // 
            this.tabIdentificar.Controls.Add(this.tabPage1);
            this.tabIdentificar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIdentificar.Location = new System.Drawing.Point(0, 0);
            this.tabIdentificar.Name = "tabIdentificar";
            this.tabIdentificar.SelectedIndex = 0;
            this.tabIdentificar.Size = new System.Drawing.Size(1060, 612);
            this.tabIdentificar.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNombre);
            this.tabPage1.Controls.Add(this.muestraDesactivado);
            this.tabPage1.Controls.Add(this.muestraActivado);
            this.tabPage1.Controls.Add(this.botonSalir);
            this.tabPage1.Controls.Add(this.botonSiguiente);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btnConfiguracionAvanzada);
            this.tabPage1.Controls.Add(this.btnConfiguracionTipica);
            this.tabPage1.Controls.Add(this.btnProbar);
            this.tabPage1.Controls.Add(this.btnDetectar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1052, 586);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dispositivos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(147, 550);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(41, 13);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "label13";
            this.lblNombre.Visible = false;
            // 
            // muestraDesactivado
            // 
            this.muestraDesactivado.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.muestraDesactivado.Location = new System.Drawing.Point(18, 411);
            this.muestraDesactivado.Name = "muestraDesactivado";
            this.muestraDesactivado.Size = new System.Drawing.Size(100, 50);
            this.muestraDesactivado.TabIndex = 9;
            this.muestraDesactivado.TabStop = false;
            this.muestraDesactivado.Visible = false;
            // 
            // muestraActivado
            // 
            this.muestraActivado.Image = global::ProyectoFederacion.Properties.Resources.amonestacionmarcada1;
            this.muestraActivado.Location = new System.Drawing.Point(18, 355);
            this.muestraActivado.Name = "muestraActivado";
            this.muestraActivado.Size = new System.Drawing.Size(100, 50);
            this.muestraActivado.TabIndex = 8;
            this.muestraActivado.TabStop = false;
            this.muestraActivado.Visible = false;
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(967, 550);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(75, 23);
            this.botonSalir.TabIndex = 6;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // botonSiguiente
            // 
            this.botonSiguiente.Location = new System.Drawing.Point(886, 550);
            this.botonSiguiente.Name = "botonSiguiente";
            this.botonSiguiente.Size = new System.Drawing.Size(75, 23);
            this.botonSiguiente.TabIndex = 5;
            this.botonSiguiente.Text = "Siguiente";
            this.botonSiguiente.UseVisualStyleBackColor = true;
            this.botonSiguiente.Visible = false;
            this.botonSiguiente.Click += new System.EventHandler(this.botonSiguiente_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackgroundImage = global::ProyectoFederacion.Properties.Resources.ladoazul;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.boton5);
            this.panel2.Controls.Add(this.boton9);
            this.panel2.Controls.Add(this.boton7);
            this.panel2.Controls.Add(this.boton1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.boton3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.boton2);
            this.panel2.Controls.Add(this.boton0);
            this.panel2.Location = new System.Drawing.Point(596, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 538);
            this.panel2.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.DarkGreen;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(227, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 22);
            this.label12.TabIndex = 21;
            this.label12.Text = "3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkGreen;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(227, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 22);
            this.label11.TabIndex = 16;
            this.label11.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkGreen;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(281, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 22);
            this.label10.TabIndex = 15;
            this.label10.Text = "2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DarkGreen;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(172, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 22);
            this.label9.TabIndex = 14;
            this.label9.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(240, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "+3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(240, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "+4";
            // 
            // boton5
            // 
            this.boton5.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton5.Location = new System.Drawing.Point(209, 101);
            this.boton5.Name = "boton5";
            this.boton5.Size = new System.Drawing.Size(25, 25);
            this.boton5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton5.TabIndex = 11;
            this.boton5.TabStop = false;
            // 
            // boton9
            // 
            this.boton9.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton9.Location = new System.Drawing.Point(19, 243);
            this.boton9.Name = "boton9";
            this.boton9.Size = new System.Drawing.Size(50, 50);
            this.boton9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton9.TabIndex = 5;
            this.boton9.TabStop = false;
            // 
            // boton7
            // 
            this.boton7.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton7.Location = new System.Drawing.Point(209, 71);
            this.boton7.Name = "boton7";
            this.boton7.Size = new System.Drawing.Size(25, 25);
            this.boton7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton7.TabIndex = 10;
            this.boton7.TabStop = false;
            // 
            // boton1
            // 
            this.boton1.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton1.Location = new System.Drawing.Point(249, 223);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(50, 50);
            this.boton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton1.TabIndex = 7;
            this.boton1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(305, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "+2";
            // 
            // boton3
            // 
            this.boton3.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton3.Location = new System.Drawing.Point(141, 223);
            this.boton3.Name = "boton3";
            this.boton3.Size = new System.Drawing.Size(50, 50);
            this.boton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton3.TabIndex = 6;
            this.boton3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(99, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "+1";
            // 
            // boton2
            // 
            this.boton2.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton2.Location = new System.Drawing.Point(195, 276);
            this.boton2.Name = "boton2";
            this.boton2.Size = new System.Drawing.Size(50, 50);
            this.boton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton2.TabIndex = 4;
            this.boton2.TabStop = false;
            // 
            // boton0
            // 
            this.boton0.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton0.Location = new System.Drawing.Point(195, 169);
            this.boton0.Name = "boton0";
            this.boton0.Size = new System.Drawing.Size(50, 50);
            this.boton0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton0.TabIndex = 5;
            this.boton0.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = global::ProyectoFederacion.Properties.Resources.ladorojo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.boton4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.boton6);
            this.panel1.Controls.Add(this.boton11);
            this.panel1.Controls.Add(this.boton13);
            this.panel1.Controls.Add(this.boton10);
            this.panel1.Controls.Add(this.boton12);
            this.panel1.Controls.Add(this.boton8);
            this.panel1.Location = new System.Drawing.Point(150, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 538);
            this.panel1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(170, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "+3";
            // 
            // boton4
            // 
            this.boton4.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton4.Location = new System.Drawing.Point(211, 101);
            this.boton4.Name = "boton4";
            this.boton4.Size = new System.Drawing.Size(25, 25);
            this.boton4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton4.TabIndex = 9;
            this.boton4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(313, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "+1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(108, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "+2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(170, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "+4";
            // 
            // boton6
            // 
            this.boton6.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton6.Location = new System.Drawing.Point(211, 71);
            this.boton6.Name = "boton6";
            this.boton6.Size = new System.Drawing.Size(25, 25);
            this.boton6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton6.TabIndex = 8;
            this.boton6.TabStop = false;
            // 
            // boton11
            // 
            this.boton11.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton11.Location = new System.Drawing.Point(257, 223);
            this.boton11.Name = "boton11";
            this.boton11.Size = new System.Drawing.Size(50, 50);
            this.boton11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton11.TabIndex = 3;
            this.boton11.TabStop = false;
            // 
            // boton13
            // 
            this.boton13.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton13.Location = new System.Drawing.Point(145, 223);
            this.boton13.Name = "boton13";
            this.boton13.Size = new System.Drawing.Size(50, 50);
            this.boton13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton13.TabIndex = 2;
            this.boton13.TabStop = false;
            // 
            // boton10
            // 
            this.boton10.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton10.Location = new System.Drawing.Point(201, 169);
            this.boton10.Name = "boton10";
            this.boton10.Size = new System.Drawing.Size(50, 50);
            this.boton10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton10.TabIndex = 1;
            this.boton10.TabStop = false;
            // 
            // boton12
            // 
            this.boton12.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton12.Location = new System.Drawing.Point(201, 276);
            this.boton12.Name = "boton12";
            this.boton12.Size = new System.Drawing.Size(50, 50);
            this.boton12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton12.TabIndex = 0;
            this.boton12.TabStop = false;
            // 
            // boton8
            // 
            this.boton8.Image = global::ProyectoFederacion.Properties.Resources.desactivado;
            this.boton8.Location = new System.Drawing.Point(375, 244);
            this.boton8.Name = "boton8";
            this.boton8.Size = new System.Drawing.Size(50, 50);
            this.boton8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boton8.TabIndex = 4;
            this.boton8.TabStop = false;
            // 
            // btnConfiguracionAvanzada
            // 
            this.btnConfiguracionAvanzada.Location = new System.Drawing.Point(3, 96);
            this.btnConfiguracionAvanzada.Name = "btnConfiguracionAvanzada";
            this.btnConfiguracionAvanzada.Size = new System.Drawing.Size(141, 23);
            this.btnConfiguracionAvanzada.TabIndex = 4;
            this.btnConfiguracionAvanzada.Text = "Configuración avanzada";
            this.btnConfiguracionAvanzada.UseVisualStyleBackColor = true;
            this.btnConfiguracionAvanzada.Visible = false;
            this.btnConfiguracionAvanzada.Click += new System.EventHandler(this.btnConfiguracionAvanzada_Click);
            // 
            // btnConfiguracionTipica
            // 
            this.btnConfiguracionTipica.Location = new System.Drawing.Point(3, 66);
            this.btnConfiguracionTipica.Name = "btnConfiguracionTipica";
            this.btnConfiguracionTipica.Size = new System.Drawing.Size(141, 23);
            this.btnConfiguracionTipica.TabIndex = 3;
            this.btnConfiguracionTipica.Text = "Ver configuración";
            this.btnConfiguracionTipica.UseVisualStyleBackColor = true;
            this.btnConfiguracionTipica.Visible = false;
            this.btnConfiguracionTipica.Click += new System.EventHandler(this.btnConfiguracionTipica_Click);
            // 
            // btnProbar
            // 
            this.btnProbar.Location = new System.Drawing.Point(3, 36);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(141, 23);
            this.btnProbar.TabIndex = 2;
            this.btnProbar.Text = "Probar dispositivos";
            this.btnProbar.UseVisualStyleBackColor = true;
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
            // 
            // btnDetectar
            // 
            this.btnDetectar.Location = new System.Drawing.Point(3, 6);
            this.btnDetectar.Name = "btnDetectar";
            this.btnDetectar.Size = new System.Drawing.Size(141, 23);
            this.btnDetectar.TabIndex = 1;
            this.btnDetectar.Text = "Detectar dispositivos";
            this.btnDetectar.UseVisualStyleBackColor = true;
            this.btnDetectar.Click += new System.EventHandler(this.btnDetectar_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "";
            // 
            // Dispositivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1060, 612);
            this.Controls.Add(this.tabIdentificar);
            this.ForeColor = System.Drawing.Color.Black;
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "F1");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dispositivos";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar dispositivos";
            this.Load += new System.EventHandler(this.Dispositivos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dispositivos_KeyDown);
            this.tabIdentificar.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.muestraDesactivado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muestraActivado)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton0)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPrincipal;
        private System.Windows.Forms.TabControl tabIdentificar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox muestraDesactivado;
        private System.Windows.Forms.PictureBox muestraActivado;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Button botonSiguiente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox boton5;
        private System.Windows.Forms.PictureBox boton9;
        private System.Windows.Forms.PictureBox boton7;
        private System.Windows.Forms.PictureBox boton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox boton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox boton2;
        private System.Windows.Forms.PictureBox boton0;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox boton4;
        private System.Windows.Forms.PictureBox boton6;
        private System.Windows.Forms.PictureBox boton8;
        private System.Windows.Forms.PictureBox boton11;
        private System.Windows.Forms.PictureBox boton13;
        private System.Windows.Forms.PictureBox boton10;
        private System.Windows.Forms.PictureBox boton12;
        private System.Windows.Forms.Button btnConfiguracionAvanzada;
        private System.Windows.Forms.Button btnConfiguracionTipica;
        private System.Windows.Forms.Button btnProbar;
        private System.Windows.Forms.Button btnDetectar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.HelpProvider helpProvider1;

    }
}