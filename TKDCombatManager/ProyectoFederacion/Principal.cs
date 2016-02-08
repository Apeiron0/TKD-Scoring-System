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
using System.IO;
using System.Reflection;

namespace ProyectoFederacion
{
    public partial class Principal : Form
    {
        public static Assembly _assembly = Assembly.GetExecutingAssembly();        

        public Principal()
        {
            InitializeComponent();
            this.KeyPreview = true;

            Joystick[] dispositivos = obtenerDispositivos();
            Hardware.joystics = dispositivos;

            string dir = Path.GetDirectoryName(_assembly.Location);
            helpProvider1.HelpNamespace = Principal.direccionAyda();
        }

        public static string direccionAyda()
        {
            string dir = Path.GetDirectoryName(_assembly.Location);
            return dir + Path.DirectorySeparatorChar + "help.chm";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {           
            string dir = Path.GetDirectoryName(_assembly.Location);
            Help.ShowHelp(this, dir + Path.DirectorySeparatorChar + "help.chm", System.Windows.Forms.HelpNavigator.TableOfContents);
        }

        private void btnCalibrar_Click(object sender, EventArgs e)
        {
            Dispositivos frm = new Dispositivos();
            frm.Show(this);
        }

        private void btnNuevoCombate_Click(object sender, EventArgs e)
        {
            ConfigurarCombate config = new ConfigurarCombate();
            config.Show(this);
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);

            //Joystick[] dispositivos = obtenerDispositivos();
            //Hardware.joystics = dispositivos;
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hardware.unAquire();
        }
    }
}
