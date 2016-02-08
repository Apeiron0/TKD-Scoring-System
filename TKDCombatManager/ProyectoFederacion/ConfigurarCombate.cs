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
    public partial class ConfigurarCombate : Form
    {
        public ConfigurarCombate()
        {
            InitializeComponent();
            helpProvider1.HelpNamespace = Principal.direccionAyda();
        }

        private void OpcionesCombate_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            double tiempoMedico = 0;
            double tiempoNormal = 0;
            double tiempoMarcaje = 0;
            int rounds = 3;
            int diferenciaPuntos = (int)spinDiferenciaMaxima.Value;
            int amonestaciones = (int)spinAmonestaciones.Value;

            string tMedico = txtTiempoMedico.Text;
            tMedico = tMedico.Replace(" ", "");
            string[] lstTiempoMedico = tMedico.Split(':');
            double tMedicoMinutos = (lstTiempoMedico[0].Equals("")) ? 0 : Convert.ToDouble(lstTiempoMedico[0]);
            double tMedicoSegundos = (lstTiempoMedico[1].Equals("")) ? 0 : Convert.ToDouble(lstTiempoMedico[1]);
            tiempoMedico = tMedicoMinutos * 60 + tMedicoSegundos;

            string tNormal = txtTiempoCombate.Text;
            tNormal = tNormal.Replace(" ", "");
            string[] lstTiempoNormal = tNormal.Split(':');
            double tNormalMinutos = (lstTiempoNormal[0].Equals("")) ? 0 : Convert.ToDouble(lstTiempoNormal[0]);
            double tNormalSegundos = (lstTiempoNormal[1].Equals("")) ? 0 : Convert.ToDouble(lstTiempoNormal[1]);
            tiempoNormal = tNormalMinutos * 60 + tNormalSegundos;

            string tMarcaje = txtTiempoMarcaje.Text;
            tMarcaje = tMarcaje.Replace(" ", "0");
            string separador = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            string[] lstTiempoMarcaje = tMarcaje.Split(separador[0]);
            double tMarcajeMinutos = (lstTiempoMarcaje[0].Equals("")) ? 0 : Convert.ToDouble(lstTiempoMarcaje[0]);
            double tMarcajeSegundos = (lstTiempoMarcaje[1].Equals("")) ? 0 : Convert.ToDouble(lstTiempoMarcaje[1]);
            tiempoMarcaje = (tMarcajeMinutos + (tMarcajeSegundos / 100))*100;

            if (radioDosRounds.Checked == true)
                rounds = 2;

            Tiempo motorTiempo = new Tiempo(tiempoNormal, tiempoMedico, rounds);
            Punteo motorPuntos = new Punteo(diferenciaPuntos, amonestaciones, tiempoMarcaje);

            Tablero t = new Tablero(motorTiempo, motorPuntos);
            t.Show(this);
        }

        private bool validar()
        {
            if (txtTiempoCombate.Text == "")
            {
                MessageBox.Show("Debe indicar un tiempo de combate correcto.", "Sin tiempo de combate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTiempoCombate.Focus();
                return false;
            }

            return true;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarCombate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
