using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX;
using SlimDX.DirectInput;

namespace ProyectoFederacion
{
    public partial class Dispositivos : Form
    {
        Joystick[] dispositivos;
        bool prueba = false;
        int index = 0;
        public Dispositivos()
        {
            InitializeComponent();
            helpProvider1.HelpNamespace = Principal.direccionAyda();
        }

        private void Dispositivos_Load(object sender, EventArgs e)
        {
            detectar();
        }
        private Joystick[] obtenerDispositivos()
        {
            var sticks = new List<SlimDX.DirectInput.Joystick>();
            DirectInput dinput = new DirectInput();
            foreach (DeviceInstance device in dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                // crear los dispositivos
                try
                {
                    var stick = new SlimDX.DirectInput.Joystick(dinput, device.InstanceGuid);
                    stick.Acquire();

                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-1000, 1000);
                    }

                    sticks.Add(stick);
                }
                catch (DirectInputException)
                {
                }
            }
            return sticks.ToArray();
        }

        private void btnDetectar_Click(object sender, EventArgs e)
        {
            detectar();
        }

        private void detectar()
        {
            dispositivos = obtenerDispositivos();
            Hardware.joystics = dispositivos;
            if (dispositivos.Length==0)
                MessageBox.Show("No Se detectaron dispositivos conectados, intente de nuevo utilizando el botón 'Detectar dispositivos'", "Dispositivos",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                MessageBox.Show("Se detectaron " + Convert.ToString(dispositivos.Length) + " dispositivos", "Dispositivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            if (dispositivos.Length == 0)
                MessageBox.Show("No hay dispositivos para probar", "Dispositivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                botonSiguiente.Visible = true;
                boton0.Image = muestraDesactivado.Image;
                boton1.Image = muestraDesactivado.Image;
                boton2.Image = muestraDesactivado.Image;
                boton3.Image = muestraDesactivado.Image;
                boton4.Image = muestraDesactivado.Image;
                boton5.Image = muestraDesactivado.Image;
                boton6.Image = muestraDesactivado.Image;
                boton7.Image = muestraDesactivado.Image;
                boton8.Image = muestraDesactivado.Image;
                boton9.Image = muestraDesactivado.Image;
                boton10.Image = muestraDesactivado.Image;
                boton11.Image = muestraDesactivado.Image;
                boton12.Image = muestraDesactivado.Image;
                boton13.Image = muestraDesactivado.Image;
                index = 0;
                prueba = true;
                //Instrucciones instruc = new Instrucciones(0);
                //instruc.ShowDialog();
                timerPrincipal.Enabled = true;
                lblNombre.Visible = true;
                
            }
        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            if (prueba==true)
            {
                if (index < (dispositivos.Length-1))
                {
                    boton0.Image = muestraDesactivado.Image;
                    boton1.Image = muestraDesactivado.Image;
                    boton2.Image = muestraDesactivado.Image;
                    boton3.Image = muestraDesactivado.Image;
                    boton4.Image = muestraDesactivado.Image;
                    boton5.Image = muestraDesactivado.Image;
                    boton6.Image = muestraDesactivado.Image;
                    boton7.Image = muestraDesactivado.Image;
                    boton8.Image = muestraDesactivado.Image;
                    boton9.Image = muestraDesactivado.Image;
                    boton10.Image = muestraDesactivado.Image;
                    boton11.Image = muestraDesactivado.Image;
                    boton12.Image = muestraDesactivado.Image;
                    boton13.Image = muestraDesactivado.Image;
                    index++;
                }
                else
                {
                    index = 0;
                    prueba = false;
                    timerPrincipal.Enabled = false;
                    botonSiguiente.Visible = false;
                    lblNombre.Visible = false;
                    MessageBox.Show("Todos los dispositivos han sido probados.", "Prueba finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void timerPrincipal_Tick(object sender, EventArgs e)
        {
            if (prueba == true)
            {
                if (index<dispositivos.Length)
                    procesar(dispositivos[index]);
            }
        }
        private void procesar(Joystick stick)
        {
            try
            {
                JoystickState state = new JoystickState();
                state = stick.GetCurrentState();

                string nombre = stick.Information.InstanceName; //instance name
                lblNombre.Text = nombre;

                bool[] botones = state.GetButtons();
                if (botones.Length >= 10)
                {
                    if (botones[0] == true)
                    {
                        boton0.Image = muestraActivado.Image;
                    }
                    if (botones[1] == true)
                    {
                        boton1.Image = muestraActivado.Image;
                    }
                    if (botones[2] == true)
                    {
                        boton2.Image = muestraActivado.Image;
                    }
                    if (botones[3] == true)
                    {
                        boton3.Image = muestraActivado.Image;
                    }
                    if (botones[4] == true)
                    {
                        boton4.Image = muestraActivado.Image;
                    }
                    if (botones[5] == true)
                    {
                        boton5.Image = muestraActivado.Image;
                    }
                    if (botones[6] == true)
                    {
                        boton6.Image = muestraActivado.Image;
                    }
                    if (botones[7] == true)
                    {
                        boton7.Image = muestraActivado.Image;
                    }
                    if (botones[8] == true)
                    {
                        boton8.Image = muestraActivado.Image;
                    }
                    if (botones[9] == true)
                    {
                        boton9.Image = muestraActivado.Image;
                    }
                    int sx = state.X;
                    int sy = state.Y;
                    if (sx == -1000)
                    {
                        boton13.Image = muestraActivado.Image;
                    }
                    else if (sx == 1000)
                    {
                        boton11.Image = muestraActivado.Image;
                    }
                    if (sy == -1000)
                    {
                        boton10.Image = muestraActivado.Image;
                    }
                    else if (sy == 1000)
                    {
                        boton12.Image = muestraActivado.Image;
                    }
                }
                else
                {
                    MessageBox.Show("El dispositivo no es del tipo adecuado o está dañado.", "Dispositivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            { 
            }
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfiguracionTipica_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            Hardware.configuracionTipica();
            //MessageBox.Show("Si no desea utilizar la configuración de puntos y botones mostrada, puede personalizar el comportamiento de los dispositivos haciendo clic en 'Configuración avanzada'", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Se mostrará la configuración de botones para la marcación de puntos.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConfiguracionAvanzada_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            ConfiguracionAvanzada config = new ConfiguracionAvanzada();
            config.Show();
        }

        private void Dispositivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
