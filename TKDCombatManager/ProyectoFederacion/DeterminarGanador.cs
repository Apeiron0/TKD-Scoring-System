using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFederacion
{
    public partial class DeterminarGanador : Form
    {
        public DeterminarGanador()
        {
            InitializeComponent();
            helpProvider1.HelpNamespace = Principal.direccionAyda();
        }

        public int ganador
        {
            get;
            set;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ganador = Punteo.ROJO;
            this.Close();
        }

        private void btnAzul_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ganador = Punteo.AZUL;
            this.Close();
        }

        private void DeterminarGanador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
                ganador = 0;
                this.Close();
            }
        }

        private void DeterminarGanador_Load(object sender, EventArgs e)
        {

        }
    }
}
