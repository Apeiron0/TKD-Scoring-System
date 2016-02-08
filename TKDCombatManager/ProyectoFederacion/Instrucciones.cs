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
    public partial class Instrucciones : Form
    {
        public Instrucciones(int tema)
        {
            InitializeComponent();
            if (tema == 0)
            {
                label1.Text = "Instrucciones para probar los dispositivos: \n\n1. Presione cualquier botón de cualquiera de los joysticks, cuando alguno de los botones en la pantalla se coloque en amarillo con reborde negro, significa que ya \n     se puede continuar probando el dispositivo. \n2. Presione cada uno de los botones del joystick, si el dispositivo no está dañado y si se encuentra bien conectado, en la pantalla, el botón \n     se pondrá de color amarillo con reborde negro. \n3. Cuando todos los botones se coloquen en color rojo, significará que el dispositivo funciona correctamente. \n4. Cuando termine de probar el dispositivo o si decide probar otro, haga clic en siguiente y repita el proceso desde el paso 1. \n \nSi desea volver a probar los dispositivos, simplemente haga clic en el botón 'Probar dispositivos', y luego repita el proceso anterior.";
            }
            if (tema == 1)
            {
                label1.Text = "Instrucciones de configuración avanzada: \n\n1. Luego de hacer clic en 'Iniciar', se le pedirá que presione cualquier botón de cualquiera de los joysticks, el primer botón en \n    activarse, indicará que dicho dispositivo deberá utilizarse en la configuración. Luego haga clic en 'siguiente', \n2. En la parte superior de la pantalla se mostrará el punteo y el color que se está configurando. \n3. Cuando presione un botón del joystick, éste tomará el valor de puntos y el color del competidor. Dicho botón ya no podrá \n    utilizarse para otro punteo, por lo que si desea cambiar la configuración, simplemente haga clic en 'reset'. \n4. Si no desea asignar un punteo a un botón de joystick, haga clic en 'Siguiente', tome en cuenta que al no utilizar un punteo \n    para un color, el mismo punteo para el otro competidor tampoco se configurará. \n5. Al finalizar, el programa le mostrará un aviso. Puede hacer clic en 'Aceptar'. \n\nSi desea utilizar la configuración típica, haga clic en el botón 'Configuración típica' en el formulario 'Configurar dispositivos'.";
            }
        }

        private void Instrucciones_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Instrucciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
