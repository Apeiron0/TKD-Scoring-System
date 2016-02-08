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
    public partial class ConfiguracionAvanzada : Form
    {
        private int[] botones;
        private int[] colores;
        private int index;
        private int paso = 0;
        private List<int> botonesUsados;
        private List<int> pasosAnulados;

        public ConfiguracionAvanzada()
        {
            InitializeComponent();
            botonesUsados = new List<int>();
            pasosAnulados = new List<int>();
            botones = new int[14];
            colores = new int[14];
            index = 0;
        }

        private void ConfiguracionAvanzada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ConfiguracionAvanzada_Load(object sender, EventArgs e)
        {
            Instrucciones inst = new Instrucciones(1);
            inst.ShowDialog();
        }

        private void botonIniciar_Click(object sender, EventArgs e)
        {
            labelBoton.Text = "Detección de dispositivo: Presione cualquier botón del \njoystick que desee utilizar para la configuración";
        }

        private void timerConfiguracion_Tick(object sender, EventArgs e)
        {
            
            if (paso == 0)
            {
                int cantidadDispositivos = Hardware.cantidadDispositivos;
                for (int i = 0; i < cantidadDispositivos; i++)
                {
                    procesar(i, Hardware.estadoDispositivo(i));
                }
            }
            else
            {
                procesarPasosPosteriores(index, Hardware.estadoDispositivo(index));
            }
        }

        private void procesar(int idJoystick, JoystickState estado)
        {
            try
            {
                bool[] botones = estado.GetButtons();
                if (botones.Length >= 10)
                {
                    if (botones[0] == true)
                    {
                        procesarBoton(idJoystick, 0);
                        index = idJoystick;
                        return;
                    }
                    if (botones[1] == true)
                    {
                        procesarBoton(idJoystick, 1);
                        index = idJoystick;
                        return;
                    }
                    if (botones[2] == true)
                    {
                        procesarBoton(idJoystick, 2);
                        index = idJoystick;
                        return;
                    }
                    if (botones[3] == true)
                    {
                        procesarBoton(idJoystick, 3);
                        index = idJoystick;
                        return;
                    }
                    if (botones[4] == true)
                    {
                        procesarBoton(idJoystick, 4);
                        index = idJoystick;
                        return;
                    }
                    if (botones[5] == true)
                    {
                        procesarBoton(idJoystick, 5);
                        index = idJoystick;
                        return;
                    }
                    if (botones[6] == true)
                    {
                        procesarBoton(idJoystick, 6);
                        index = idJoystick;
                        return;
                    }
                    if (botones[7] == true)
                    {
                        procesarBoton(idJoystick, 7);
                        index = idJoystick;
                        return;
                    }
                    if (botones[8] == true)
                    {
                        procesarBoton(idJoystick, 8);
                        index = idJoystick;
                        return;
                    }
                    if (botones[9] == true)
                    {
                        procesarBoton(idJoystick, 9);
                        index = idJoystick;
                        return;
                    }
                    int sx = estado.X;
                    int sy = estado.Y;
                    if (sx == -1000)
                    {
                        procesarBoton(idJoystick, 13);
                        index = idJoystick;
                        return;
                    }
                    else if (sx == 1000)
                    {
                        procesarBoton(idJoystick, 11);
                        index = idJoystick;
                        return;
                    }
                    if (sy == -1000)
                    {
                        procesarBoton(idJoystick, 10);
                        index = idJoystick;
                        return;
                    }
                    else if (sy == 1000)
                    {
                        procesarBoton(idJoystick, 12);
                        index = idJoystick;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void procesarPasosPosteriores(int indice, JoystickState estado)
        {
            if (paso == 1)
            {
                //+1 rojo
            }
            if (paso == 2)
            {
                //+2 rojo
            }
            if (paso == 3)
            {
                //+3 rojo
            }
            if (paso == 4)
            {
                //+4 rojo
            }
            if (paso == 5)
            {
                //+1 azul
            }
            if (paso == 6)
            {
                //+2 azul
            }
            if (paso == 7)
            {
                //+3 azul
            }
            if (paso == 8)
            {
                //+4 azul
            }
        }

        private void procesarBoton(int idJoystick, int boton)
        {
            if (boton == 0)
            {
                boton0.Image = muestraActivado.Image;
            }
            if (boton == 1)
            {
                boton1.Image = muestraActivado.Image;
            }
            if (boton == 2)
            {
                boton2.Image = muestraActivado.Image;
            }
            if (boton == 3)
            {
                boton3.Image = muestraActivado.Image;
            }
            if (boton == 4)
            {
                boton4.Image = muestraActivado.Image;
            }
            if (boton == 5)
            {
                boton5.Image = muestraActivado.Image;
            }
            if (boton == 6)
            {
                boton6.Image = muestraActivado.Image;
            }
            if (boton == 7)
            {
                boton7.Image = muestraActivado.Image;
            }
            if (boton == 8)
            {
                boton8.Image = muestraActivado.Image;
            }
            if (boton == 9)
            {
                boton9.Image = muestraActivado.Image;
            }
            if (boton == 10)
            {
                boton10.Image = muestraActivado.Image;
            }
            if (boton == 11)
            {
                boton11.Image = muestraActivado.Image;
            }
            if (boton == 12)
            {
                boton12.Image = muestraActivado.Image;
            }
            if (boton == 13)
            {
                boton13.Image = muestraActivado.Image;
            }
                       
        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            paso++;
        }
    }
}
