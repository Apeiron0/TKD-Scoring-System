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
    public partial class Tablero : Form
    {
        private int direccion = 0;
        private Tiempo subsistemaTiempo;
        private Punteo subsistemaPuntos;
        private bool blanco = false;
        private PictureBox[] gamRojo;
        private PictureBox[] gamAzul;
        private double contadorTimerRojo = 0;
        private double contadorTimerAzul = 0;
        private double contador2PuntosTimerRojo = 0;
        private double contador2PuntosTimerAzul = 0;
        private double contador3PuntosTimerRojo = 0;
        private double contador3PuntosTimerAzul = 0;
        private double contador4PuntosTimerRojo = 0;
        private double contador4PuntosTimerAzul = 0;
        private Size tamanioStandar;

        public Tablero(Tiempo motorTiempo, Punteo motorPunteo)
        {
            InitializeComponent();

            helpProvider1.HelpNamespace = Principal.direccionAyda();

            this.KeyPreview = true;
            //asignar los subsitemas que se reciben de la ventana de configuracion
            subsistemaPuntos = motorPunteo;
            subsistemaTiempo = motorTiempo;
            //crear el arreglo de picturebox
            nuevoCombate();

            for (int i = 0; i < subsistemaPuntos.amonestaciones; i++)
            {
                tamanioStandar = gamRojo[i].Size;
                break;
            }
            
            picUnPuntoA.Visible = false;
            picUnPuntoR.Visible = false;
            picDosPuntosA.Visible = false;
            picDosPuntosR.Visible = false;
            picTresPuntosA.Visible = false;
            picTresPuntosR.Visible = false;
            pic4PuntosA.Visible = false;
            pic4PuntosR.Visible = false;
            
            int size = Hardware.cantidadDispositivos;
            if (size > 0)
            {
            }
        }

        private void btnGamSumaRojo_Click(object sender, EventArgs e)
        {
            sumaGRojo();
        }

        private void btnGamSumaAzul_Click(object sender, EventArgs e)
        {
            sumaGAzul();
        }

        private void timerPrincipal_Tick(object sender, EventArgs e)
        {
            //encender el reloj de control y de mostrado
            timerPrincipal.Enabled = subsistemaTiempo.reloj();
            //actualizar los mensajes mostrados
            lblTiempo.Text = subsistemaTiempo.tiempo;
            lblRound.Text = subsistemaTiempo.round;
            //si el timer no se activó determinar si terminó el combate o se terminó el round o se terminó el tiempo médico
            if (timerPrincipal.Enabled == false)
            {
                if (subsistemaTiempo.detenido == false) //si el tiempo no se ha puesto en pausa general, de lo contrario no se hace nada
                {
                    //si el tiempo médico estaba activado
                    if (subsistemaTiempo.enPausa == true)
                    {
                        detenerClicSostenido(); //detener clic sostenido por si se llegó a cero
                        botonPlay.Enabled = false;
                        
                        //se reinicia el timer y el subsistema de tiempo
                        timerPrincipal.Enabled = subsistemaTiempo.reiniciarDeTiempoMedico();
                        //actualizar las etiquetas
                        lblTiempo.Text = subsistemaTiempo.tiempo;
                        lblRound.Text = subsistemaTiempo.round;
                    }
                    else if (subsistemaTiempo.roundTerminado == true) //si el round terminó
                    {
                        if ((subsistemaTiempo.combateTerminado == true) && (subsistemaTiempo.muerteSubita == false)) //si el combate ya terminó y no está en muerte súbita
                        {
                            if (subsistemaPuntos.empate == true) //si hay un empate
                            {
                                //preguntar si se desea un round de desempate
                                if (MessageBox.Show("¿Iniciar round de desempate?", "Empate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    
                                    //en los subsistemas de puntos y tiempo se inicia la muerte súbita
                                    subsistemaPuntos.iniciarMuerteSubita();
                                    subsistemaTiempo.iniciarMuerteSubita();
                                    //se actualiza toda la información mostrada
                                    lblTiempo.Text = subsistemaTiempo.tiempo;
                                    lblRound.Text = subsistemaTiempo.round;
                                    lblAzul.Text = subsistemaPuntos.puntosAzul;
                                    lblRojo.Text = subsistemaPuntos.puntosRojo;

                                    for (int i = 0; i < subsistemaPuntos.amonestaciones; i++)
                                    {
                                        gamAzul[i].BackgroundImage = picNoMarcada.BackgroundImage;
                                        gamAzul[i].BackgroundImageLayout = picMuestra.BackgroundImageLayout;
                                        gamAzul[i].Size = tamanioStandar;
                                        gamAzul[i].Visible = true;

                                        gamRojo[i].BackgroundImage = picNoMarcada.BackgroundImage;
                                        gamRojo[i].BackgroundImageLayout = picMuestra.BackgroundImageLayout;
                                        gamRojo[i].Size = tamanioStandar;
                                        gamRojo[i].Visible = true;
                                    }

                                    MessageBox.Show("Iniciar muerte súbita", "Iniciar round", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    timerPrincipal.Enabled = true;
                                }
                                else //si el usuario respondió que no quiere determinar automáticamente al ganador, mostrar el formulario para determinar manualmente al ganador
                                {
                                    DeterminarGanador ganador = new DeterminarGanador();
                                    if (ganador.ShowDialog() == DialogResult.OK)
                                    {
                                        int win = ganador.ganador;
                                        if (win == Punteo.AZUL)
                                            ganadorAzul();
                                        else if (win == Punteo.ROJO)
                                            ganadorRojo();
                                    }
                                    else
                                        groupGanador.Enabled = true;
                                }

                            }
                            else //si no hay empate, se determina al ganador automáticamente
                            {
                                detenerCombate(true);
                            }
                        }
                        else if ((subsistemaTiempo.combateTerminado == true) && (subsistemaTiempo.muerteSubita == true)) //si el combate terminó y estaba en muerte subita
                        {
                            //preguntar por quién va ganar
                            detenerCombate(true);
                        }
                        else //si el combate no ha terminado, pero sí el round
                        {
                            detenerClicSostenido(); //detener el timer del clic sostenido porque cuando se llega a cero, el evento mouseUp no funciona.
                            //esperar la confirmación del usuario para iniciar el siguiente round
                            MessageBox.Show("Iniciar siguiente round", "Iniciar round", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            timerPrincipal.Enabled = subsistemaTiempo.iniciar();
                            lblTiempo.Text = subsistemaTiempo.tiempo;
                            lblRound.Text = subsistemaTiempo.round;
                        }
                    }
                }
            }
        }
                
        private void timerBlink_Tick(object sender, EventArgs e)
        {
            //parpadeo cuando ya se determinó a un ganador
            //si el ganador es el competidor azul
            if (subsistemaPuntos.ganador == Punteo.AZUL)
            {
                lblRojo.BackColor = Color.Red;
                lblRojo.ForeColor = Color.White;
                //lblTiempo.ForeColor = Color.Blue;
                if (blanco == true)
                {
                    lblAzul.BackColor = Color.Blue;
                    lblAzul.ForeColor = Color.White;
                    blanco = false;
                }
                else
                {
                    lblAzul.BackColor = Color.White;
                    lblAzul.ForeColor = Color.Blue;
                    blanco = true;
                }
            }
            else //si el ganador es el competidor rojo
            {
                lblAzul.BackColor = Color.Blue;
                lblAzul.ForeColor = Color.White;
                //lblTiempo.ForeColor = Color.Red;
                if (blanco == true)
                {
                    lblRojo.BackColor = Color.Red;
                    lblRojo.ForeColor = Color.White;
                    blanco = false;
                }
                else
                {
                    lblRojo.BackColor = Color.White;
                    lblRojo.ForeColor = Color.Red;
                    blanco = true;
                }
            }
        }

        private void determinarGanador()
        {
            //se determina al ganador del combate en base a los puntos y amonestaciones
            subsistemaPuntos.determinarGanador();
            string color = "";
            if (subsistemaPuntos.ganador == Punteo.AZUL)
            {
                color = "Azul";
                lblNombreAzul.Text = "Ganador " + lblNombreAzul.Text;
            }
            else
            {
                color = "Rojo";
                lblNombreRojo.Text = "Ganador " + lblNombreRojo.Text;
            }
            timerBlink.Enabled = true;
            MessageBox.Show(this,"El ganador es el competidor " + color, "Combate finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //lblTiempo.Text = "Ganador " + color;
            
        }
      
        private void Tablero_KeyDown(object sender, KeyEventArgs e)
        {
            int codigo = e.KeyValue;

            if (e.KeyCode==Keys.F8)
            {
                if (((e.Shift == true) && (e.Control == false))&&(e.Alt==false))
                {
                    //F8 -> disminuir el tamaño de fuente del reloj en 10 unidades
                    float sizefont = lblTiempo.Font.Size - 1;
                    if ((sizefont <= System.Single.MaxValue) && (sizefont > 0))
                        lblTiempo.Font = new Font(lblTiempo.Font.FontFamily, sizefont, lblTiempo.Font.Style, lblTiempo.Font.Unit, lblTiempo.Font.GdiCharSet, lblTiempo.Font.GdiVerticalFont);
                }
                else if (((e.Shift == true) && (e.Control == true))&&(e.Alt==false))
                {
                    //F8 -> disminuir el tamaño de fuente del round de combate en 10 unidades
                    float sizefont = lblRound.Font.Size - 1;
                    if ((sizefont <= System.Single.MaxValue) && (sizefont > 0))
                        lblRound.Font = new Font(lblRound.Font.FontFamily, sizefont, lblRound.Font.Style, lblRound.Font.Unit, lblRound.Font.GdiCharSet, lblRound.Font.GdiVerticalFont);
                }
                else if (((e.Shift == false) && (e.Control == false))&&(e.Alt==false))
                {
                    //F8 -> disminuir el tamaño de fuente de los marcadores en 10 unidades
                    float sizefont = lblAzul.Font.Size - 5;
                    if ((sizefont <= System.Single.MaxValue) && (sizefont > 0))
                    {
                        lblAzul.Font = new Font(lblAzul.Font.FontFamily, sizefont, lblAzul.Font.Style, lblAzul.Font.Unit, lblAzul.Font.GdiCharSet, lblAzul.Font.GdiVerticalFont);
                        lblRojo.Font = new Font(lblRojo.Font.FontFamily, sizefont, lblRojo.Font.Style, lblRojo.Font.Unit, lblRojo.Font.GdiCharSet, lblRojo.Font.GdiVerticalFont);
                    }
                }
                else if (((e.Shift == false) && (e.Control == false)) && (e.Alt == true))
                {
                    //disminuir tamaño de fuente de los labels de nombres de competidores
                    float sizefontGR = lblNombreRojo.Font.Size - 1;
                    if ((sizefontGR <= System.Single.MaxValue) && (sizefontGR > 0))
                    {
                        lblNombreRojo.Font = new Font(lblNombreRojo.Font.FontFamily, sizefontGR, lblNombreRojo.Font.Style, lblNombreRojo.Font.Unit, lblNombreRojo.Font.GdiCharSet, lblNombreRojo.Font.GdiVerticalFont);
                        lblNombreAzul.Font = new Font(lblNombreAzul.Font.FontFamily, sizefontGR, lblNombreAzul.Font.Style, lblNombreAzul.Font.Unit, lblNombreAzul.Font.GdiCharSet, lblNombreAzul.Font.GdiVerticalFont);
                    }
                }
                else if (((e.Shift == false) && (e.Control == true)) && (e.Alt == true))
                {
                    if (gamRojo.Length > 0)
                    {
                        //F8 -> disminuir el tamaño de los iconos de amonestaciones en 2 unidades
                        int size = gamRojo[0].Width - 1;
                        if (size > 0)
                        {
                            for (int i = 0; i < gamRojo.Length; i++)
                            {
                                gamRojo[i].Width = size;
                                gamRojo[i].Height = size;
                                gamAzul[i].Width = size;
                                gamAzul[i].Height = size;
                            }

                            for (int i = 0; i < subsistemaPuntos.amonestaciones; i++)
                            {
                                tamanioStandar = gamRojo[i].Size;
                                break;
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                if (((e.Shift == true) && (e.Control == false)) && (e.Alt == false))
                {
                    //F9 -> aumentar el tamaño de fuente del reloj en 10 unidades
                    if (lblTiempo.Font.Size < 180)
                        lblTiempo.Font = new Font(lblTiempo.Font.FontFamily, lblTiempo.Font.Size + 1, lblTiempo.Font.Style, lblTiempo.Font.Unit, lblTiempo.Font.GdiCharSet, lblTiempo.Font.GdiVerticalFont);
                }
                else if (((e.Shift == true) && (e.Control == true)) && (e.Alt == false))
                {
                    //F9 -> aumentar el tamaño de fuente del mostrador de combate en 10 unidades
                    if (lblRound.Font.Size<39)
                        lblRound.Font = new Font(lblRound.Font.FontFamily, lblRound.Font.Size + 1, lblRound.Font.Style, lblRound.Font.Unit, lblRound.Font.GdiCharSet, lblRound.Font.GdiVerticalFont);
                }
                else if (((e.Shift == false) && (e.Control == false)) && (e.Alt == false))
                {
                    //F9 -> aumentar el tamaño de fuente de los marcadores en 10 unidades
                    lblAzul.Font = new Font(lblAzul.Font.FontFamily, lblAzul.Font.Size + 10, lblAzul.Font.Style, lblAzul.Font.Unit, lblAzul.Font.GdiCharSet, lblAzul.Font.GdiVerticalFont);
                    lblRojo.Font = new Font(lblRojo.Font.FontFamily, lblRojo.Font.Size + 10, lblRojo.Font.Style, lblRojo.Font.Unit, lblRojo.Font.GdiCharSet, lblRojo.Font.GdiVerticalFont);
                }
                else if (((e.Shift == false) && (e.Control == false)) && (e.Alt == true))
                {
                    //aumentar tamaño de fuente de los labels de nombres de competidores
                    if (lblNombreAzul.Font.Size < 38)
                    {
                        lblNombreRojo.Font = new Font(lblNombreRojo.Font.FontFamily, lblNombreRojo.Font.Size + 1, lblNombreRojo.Font.Style, lblNombreRojo.Font.Unit, lblNombreRojo.Font.GdiCharSet, lblNombreRojo.Font.GdiVerticalFont);
                        lblNombreAzul.Font = new Font(lblNombreAzul.Font.FontFamily, lblNombreAzul.Font.Size + 1, lblNombreAzul.Font.Style, lblNombreAzul.Font.Unit, lblNombreAzul.Font.GdiCharSet, lblNombreAzul.Font.GdiVerticalFont);
                    }
                }
                else if (((e.Shift == false) && (e.Control == true)) && (e.Alt == true))
                {
                    if (gamRojo.Length > 0) 
                    {
                        //F9 -> aumenta el tamaño de los iconos de amonestaciones en 2 unidades
                        if (gamRojo[0].Height < flayoutAmonestacionesRojo.Height)
                        {
                            int size = gamRojo[0].Width + 1;
                            for (int i = 0; i < gamRojo.Length; i++)
                            {
                                gamRojo[i].Width = size;
                                gamRojo[i].Height = size;
                                gamAzul[i].Width = size;
                                gamAzul[i].Height = size;
                            }

                            for (int i = 0; i < subsistemaPuntos.amonestaciones; i++)
                            {
                                tamanioStandar = gamRojo[i].Size;
                                break;
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Q)
            {
                if (botonSumaKR.Enabled)
                    sumaKRojo();
            }
            else if (e.KeyCode == Keys.W)
            {
                if (botonRestaKR.Enabled)
                    restaKRojo();
            }
            else if (e.KeyCode == Keys.E)
            {
                if (botonSumaGR.Enabled)
                    sumaGRojo();
            }
            else if (e.KeyCode == Keys.R)
            {
                if (botonSumaKA.Enabled)
                    sumaKAzul();
            }
            else if (e.KeyCode == Keys.T)
            {
                if (botonRestaKA.Enabled)
                    restaKAzul();
            }
            else if (e.KeyCode == Keys.Y)
            {
                if (botonSumaGA.Enabled)
                    sumaGAzul();
            }
            else if (e.KeyCode == Keys.H)
            {
                if (botonSumaPuntoR.Enabled)
                    sumarPuntoRojo(1);
            }
            else if (e.KeyCode == Keys.J)
            {
                if (botonRestaPuntoR.Enabled)
                    quitarPuntoRojo();
            }
            else if (e.KeyCode == Keys.K)
            {
                if (botonSumaPuntoA.Enabled)
                    sumarPuntoAzul(1);
            }
            else if (e.KeyCode == Keys.L)
            {
                if (botonRestaPuntoA.Enabled)
                    quitarPuntoAzul();
            }
            else if (e.KeyCode == Keys.A)
            {
                if (botonGanadorRojo.Enabled)
                    ganadorRojo();
            }
            else if (e.KeyCode == Keys.S)
            {
                if (botonGanadorAzul.Enabled)
                    ganadorAzul();
            }
            else if (e.KeyCode == Keys.D)
            {
                if (botonDetenerCombate.Enabled)
                    detenerCombate(true);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (botonNuevoCombate.Enabled)
                    reiniciarCombate();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Space)
            {
                /////
                if (botonPlay.Enabled)
                {
                    playUnico();
                }
                else if (botonPausa.Enabled)
                {
                    iniciarTiempoMedico();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (botonStop.Enabled)
                    pausaGeneral();
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (botonAtrasar.Enabled)
                {
                    direccion = 1; //dirección 1 indica agregar tiempo al cronómetro (atrasar)
                    timerClicSostenido.Enabled = true;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (botonAdelantar.Enabled)
                {
                    direccion = 2; //dirección 1 indica quitar tiempo al cronómetro (adelantar)
                    timerClicSostenido.Enabled = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (botonAvanzar.Enabled)
                {
                    adelantarRound();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (botonRetroceder.Enabled)
                {
                    atrasarRound();
                }
            }
        }

        private void btnKSumaRojo_Click(object sender, EventArgs e)
        {
            sumaKRojo();
        }

        private void btnKRestaRojo_Click(object sender, EventArgs e)
        {
            restaKRojo();
        }

        private void btnKSumaAzul_Click(object sender, EventArgs e)
        {
            sumaKAzul();
        }

        private void btnKRestaAzul_Click(object sender, EventArgs e)
        {
            restaKAzul();
        }
                
        private void reiniciarCombate()
        {
            int size = picMuestra.Width;
            if (gamRojo.Length > 0)
            {
                size = gamRojo[0].Width;
            }
            //botonDetenerCombate.Enabled = true;
            botonNuevoCombate.Enabled = false;
            botonPlay.Enabled = true;
            botonPausa.Enabled = false;
            botonStop.Enabled = false;
            botonAdelantar.Enabled = false;
            botonAtrasar.Enabled = false;
            groupAmonestaciones.Enabled = false;
            groupGanador.Enabled = false;
            groupPuntos.Enabled = false;

            flayoutAmonestacionesAzul.Controls.Clear();
            flayoutAmonestacionesRojo.Controls.Clear();
            timerPrincipal.Enabled = false;
            timerBlink.Enabled = false;

            lblRojo.BackColor = Color.Red;
            lblRojo.ForeColor = Color.White;

            lblAzul.BackColor = Color.Blue;
            lblAzul.ForeColor = Color.White;

            lblTiempo.ForeColor = Color.Black;

            nuevoCombate();

            lblRojo.Text = subsistemaPuntos.puntosRojo;
            lblAzul.Text = subsistemaPuntos.puntosAzul;
            lblNombreRojo.Text = "Rojo";
            lblNombreAzul.Text = "Azul";

            if (gamRojo.Length > 0)
            {
                for (int i = 0; i < gamRojo.Length; i++)
                {
                    gamRojo[i].Width = size;
                    gamRojo[i].Height = size;
                    gamAzul[i].Width = size;
                    gamAzul[i].Height = size;
                }

            }

            picUnPuntoA.Visible = false;
            picUnPuntoR.Visible = false;
            picDosPuntosA.Visible = false;
            picDosPuntosR.Visible = false;
            picTresPuntosA.Visible = false;
            picTresPuntosR.Visible = false;
            pic4PuntosA.Visible = false;
            pic4PuntosR.Visible = false;

            timerMarcajeAzul.Enabled = false;
            timerMarcajeRojo.Enabled = false;
            contadorTimerAzul = 0;
            contadorTimerRojo = 0;
            contador2PuntosTimerAzul = 0;
            contador2PuntosTimerRojo = 0;
            contador3PuntosTimerAzul = 0;
            contador3PuntosTimerRojo = 0;
            contador4PuntosTimerAzul = 0;
            contador4PuntosTimerRojo = 0;
        }

        private void sumarPuntoRojo(int cantidad)
        {
            //sumar punto y determinar si al marcar el punto ya se alcanzó la diferencia máxima
            bool ganador = subsistemaPuntos.marcarPuntoRojo(cantidad);
            lblRojo.Text = subsistemaPuntos.puntosRojo;
            //si está en muerte súbita, detener el tiempo y dar como ganador al color rojo
            if (subsistemaTiempo.muerteSubita == true)
            {
                subsistemaTiempo.terminarCombate();
                timerPrincipal.Enabled = false;
                determinarGanador();

                botonDetenerCombate.Enabled = false;
                botonNuevoCombate.Enabled = true;
                botonPlay.Enabled = false;
                botonPausa.Enabled = false;
                botonStop.Enabled = false;
                botonAdelantar.Enabled = false;
                botonAtrasar.Enabled = false;
                groupAmonestaciones.Enabled = false;
                groupGanador.Enabled = false;
                groupPuntos.Enabled = false;
            }
            else //si no está en muerte súbita
            {
                //si el competidor alcanzó la diferencia máxima, detener el combate y determinar el ganador (rojo)
                if (ganador)
                {
                    detenerCombate(false);
                    //determinarGanador();
                }
            }
        }
        private void quitarPuntoRojo()
        {
            //quitar un punto al competidor rojo
            subsistemaPuntos.quitarPuntoRojo();
            lblRojo.Text = subsistemaPuntos.puntosRojo;
        }
        private void sumarPuntoAzul(int cantidad)
        {
            //determinar si el competidor azul alcanzó la diferencia máxima de puntos
            bool ganador = subsistemaPuntos.marcarPuntoAzul(cantidad);
            lblAzul.Text = subsistemaPuntos.puntosAzul;
            //si el sistema está en muerte súbita, terminar el combate y dar como ganador al competidor Azul
            if (subsistemaTiempo.muerteSubita == true)
            {
                subsistemaTiempo.terminarCombate();
                timerPrincipal.Enabled = false;
                determinarGanador();

                botonDetenerCombate.Enabled = false;
                botonNuevoCombate.Enabled = true;
                botonPlay.Enabled = false;
                botonPausa.Enabled = false;
                botonStop.Enabled = false;
                botonAdelantar.Enabled = false;
                botonAtrasar.Enabled = false;
                groupAmonestaciones.Enabled = false;
                groupGanador.Enabled = false;
                groupPuntos.Enabled = false;
            }
            else //si no está en muerte súbita
            {
                //si el competidor ya alcanzó la diferencia máxima, dar como ganador al competidor azul
                if (ganador)
                {
                    detenerCombate(false);
                    //determinarGanador();
                }
            }
        }
        private void quitarPuntoAzul()
        {
            //quita un punto al competidor azul
            subsistemaPuntos.quitarPuntoAzul();
            lblAzul.Text = subsistemaPuntos.puntosAzul;
        }
        private void sumaKRojo()
        {
            //cambiar el color del icono de amonestacion mostrado en el tablero
            gamRojo[subsistemaPuntos.numeroAmonestacionesRojo].BackgroundImage = picMuestra.BackgroundImage;
            //determinar si el competidor alcanzó el número máximo de amonestaciones
            bool amonestacionesAlcanzadas = subsistemaPuntos.marcarAmonestacionRojo();
            lblAzul.Text = subsistemaPuntos.puntosAzul;
            lblRojo.Text = subsistemaPuntos.puntosRojo;
            if ((subsistemaTiempo.muerteSubita == true) && (subsistemaPuntos.numeroPuntosAzul > 0)) //si está en muerte súbita y el oponente suma puntos por esa amonestación, terminar el combate
            {
                subsistemaTiempo.terminarCombate();
                timerPrincipal.Enabled = false;
                determinarGanador();

                botonDetenerCombate.Enabled = false;
                botonNuevoCombate.Enabled = true;
                botonPlay.Enabled = false;
                botonPausa.Enabled = false;
                botonStop.Enabled = false;
                botonAdelantar.Enabled = false;
                botonAtrasar.Enabled = false;
                groupAmonestaciones.Enabled = false;
                groupGanador.Enabled = false;
                groupPuntos.Enabled = false;
            }
            else
            {
                if ((amonestacionesAlcanzadas) || (subsistemaPuntos.marcarPuntoAzul(0) == true)) //if (amonestacionesAlcanzadas)
                {
                    //si se llegó al máximo de amonestaciones gana el otro competidor
                    detenerCombate(false);
                    //determinarGanador();
                }
            }
        }
        private void restaKRojo()
        {
            //si el número de amonestaciones es mayor que cero
            if (subsistemaPuntos.numeroAmonestacionesRojo > 0)
            {
                //cambiar el color del icono de amonestacion mostrado en el tablero
                gamRojo[subsistemaPuntos.numeroAmonestacionesRojo - 1].BackgroundImage = picNoMarcada.BackgroundImage;
                //quitar la amonestacion
                subsistemaPuntos.quitarAmonestacionRojo();
                //si se le dio un punto al otro competidor, se le quita y se devuelve??
                lblAzul.Text = subsistemaPuntos.puntosAzul;
                lblRojo.Text = subsistemaPuntos.puntosRojo;
            }
        }
        private void sumaKAzul()
        {
            //cambiar el color del icono de amonestacion mostrado en el tablero
            gamAzul[subsistemaPuntos.numeroAmonestacionesAzul].BackgroundImage = picMuestra.BackgroundImage;
            //determinar si el competidor alcanzó el número máximo de amonestaciones
            bool amonestacionesMaximasAlcanzadas = subsistemaPuntos.marcarAmonestacionAzul();
            lblAzul.Text = subsistemaPuntos.puntosAzul;
            lblRojo.Text = subsistemaPuntos.puntosRojo;
            if ((subsistemaTiempo.muerteSubita == true) && (subsistemaPuntos.numeroPuntosRojo > 0)) //si está en muerte súbita y el oponente suma puntos por esa amonestación, terminar el combate
            {
                subsistemaTiempo.terminarCombate();
                timerPrincipal.Enabled = false;
                determinarGanador();

                botonDetenerCombate.Enabled = false;
                botonNuevoCombate.Enabled = true;
                botonPlay.Enabled = false;
                botonPausa.Enabled = false;
                botonStop.Enabled = false;
                botonAdelantar.Enabled = false;
                botonAtrasar.Enabled = false;
                groupAmonestaciones.Enabled = false;
                groupGanador.Enabled = false;
                groupPuntos.Enabled = false;

            }
            else
            {
                if ((amonestacionesMaximasAlcanzadas)||(subsistemaPuntos.marcarPuntoRojo(0)==true))
                {
                    //si se llegó al máximo de amonestaciones gana el otro competidor
                    detenerCombate(false);
                    //determinarGanador();
                }
            }
        }
        private void restaKAzul()
        {
            //si el número de amonestaciones es mayor que cero
            if (subsistemaPuntos.numeroAmonestacionesAzul > 0)
            {
                //cambiar el color del icono de amonestacion mostrado en el tablero
                gamAzul[subsistemaPuntos.numeroAmonestacionesAzul - 1].BackgroundImage = picNoMarcada.BackgroundImage;
                //quitar la amonestacion
                subsistemaPuntos.quitarAmonestacionAzul();
                //si se le dio un punto al otro competidor, se le quita y se devuelve??
                lblAzul.Text = subsistemaPuntos.puntosAzul;
                lblRojo.Text = subsistemaPuntos.puntosRojo;
            }
        }
        private void sumaGRojo()
        {
            if (subsistemaPuntos.numeroAmonestacionesRojo < gamRojo.Length)
                sumaKRojo();
            if (subsistemaPuntos.numeroAmonestacionesRojo < gamRojo.Length)
                sumaKRojo();
        }
        private void sumaGAzul()
        {
            if (subsistemaPuntos.numeroAmonestacionesAzul < gamAzul.Length)
                sumaKAzul();
            if (subsistemaPuntos.numeroAmonestacionesAzul < gamAzul.Length)
                sumaKAzul();
            
        }
        
        private void detenerCombate(bool preguntarPorGanador)
        {
            subsistemaTiempo.terminarCombate();
            if (preguntarPorGanador) //si se recibe el parametro como true, se pregunta si se desea determinar al ganador automáticamente
            {
                //preguntar si se desea establecer automáticamente al ganador.
                if (MessageBox.Show("¿Determinar ganador automáticamente?", "Combate finalizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    determinarGanador();
                }
                else
                {
                    //mostrar form de ganador manual
                    DeterminarGanador ganador = new DeterminarGanador();
                    if (ganador.ShowDialog() == DialogResult.OK)
                    {
                        int win = ganador.ganador;
                        if (win == Punteo.AZUL)
                            ganadorAzul();
                        else if (win == Punteo.ROJO)
                            ganadorRojo();
                    }
                    else
                        groupGanador.Enabled = true;
                }
            }
            else //sino, simplemente se determina automáticamente
                determinarGanador();

            botonDetenerCombate.Enabled = false;
            botonNuevoCombate.Enabled = true;
            botonPlay.Enabled = false;
            botonPausa.Enabled = false;
            botonStop.Enabled = false;
            botonAdelantar.Enabled = false;
            botonAtrasar.Enabled = false;
            groupAmonestaciones.Enabled = false;
            //groupGanador.Enabled = false;
            groupPuntos.Enabled = false;
        }
        private void pausaGeneral()
        {
            botonAdelantar.Enabled = true;
            botonAtrasar.Enabled = true;
            botonPlay.Enabled = true;
            botonStop.Enabled = false;
            botonPausa.Enabled = false;
            groupGanador.Enabled = true;
            subsistemaTiempo.detener();
            if (!subsistemaTiempo.enPausa)
            {
                botonAvanzar.Enabled = true;
                botonRetroceder.Enabled = true;
            }
        }
        private void iniciarTiempoMedico()
        {
            //iniciar la pausa o tiempo médico
            subsistemaTiempo.pausar();
            //actualizar los mensajes mostrados de tiempo y round
            lblTiempo.Text = subsistemaTiempo.tiempo;
            lblRound.Text = subsistemaTiempo.round;

            botonPlay.Enabled = true;
            botonPausa.Enabled = false;
        }
        
        /// <summary>
        /// Terminar tiempo médico.
        /// </summary>
        private void terminarTiempoMedico()
        {
            //subsistemaTiempo.reiniciarDeTiempoMedico();            
            subsistemaTiempo.detenerTiempoMedico();
        }
        private void playUnico()
        {
            botonDetenerCombate.Enabled = true;
            if (subsistemaTiempo.detenido) //si el sistema de tiempo está en pausa general:
            {                
                timerPrincipal.Enabled = subsistemaTiempo.reiniciar();
                botonAdelantar.Enabled = false;
                botonAtrasar.Enabled = false;
                botonStop.Enabled = true;
                groupGanador.Enabled = false;
                botonAvanzar.Enabled = false;
                botonRetroceder.Enabled = false;
                botonPausa.Enabled = !subsistemaTiempo.enPausa; //si el sistema de tiempo está en tiempo médico, activa el botón play para que pueda finalizarse el tiempo médico
                botonPlay.Enabled = subsistemaTiempo.enPausa;
            }
            else //si el sistema de tiempo no está en pausa general
            {
                if (((subsistemaTiempo.combateTerminado == false) && (subsistemaTiempo.enPausa==false))&&(timerPrincipal.Enabled ==false)) //si el combate no se ha iniciado (al iniciar un combate)
                {
                    //encender el timer principal
                    timerPrincipal.Enabled = subsistemaTiempo.iniciar();
                    //mostrar el tiempo actual
                    lblTiempo.Text = subsistemaTiempo.tiempo;
                    //mostrar el round actual
                    lblRound.Text = subsistemaTiempo.round;

                    //activar botones:
                    groupPuntos.Enabled = true;
                    groupAmonestaciones.Enabled = true;
                    groupGanador.Enabled = false;
                    botonPlay.Enabled = false;
                    botonStop.Enabled = true;
                    botonPausa.Enabled = true;
                    botonDetenerCombate.Enabled = true;                    
                }
                else if ((subsistemaTiempo.combateTerminado == false) && (subsistemaTiempo.enPausa)) //si el sistema está en tiempo médico
                {
                    //reiniciar el tiempo normal
                    terminarTiempoMedico();
                    botonPlay.Enabled = false;
                    botonPausa.Enabled = true;
                }
            }
        }        
        private void adelantarTiempo()
        {
            //se le quita segundos al tiempo actual
            subsistemaTiempo.quitarTiempo();
            lblTiempo.Text = subsistemaTiempo.tiempo;
        }
        private void atrasarTiempo()
        {
            //se le agregan segundos al tiempo actual
            subsistemaTiempo.sumarTiempo();
            lblTiempo.Text = subsistemaTiempo.tiempo;
        }
        
        private void nuevoCombate()
        {
            subsistemaTiempo.reset();
            subsistemaPuntos.reset();
            timerBlink.Enabled = false;
            int size = picMuestra.Width;
            int standar = (flayoutAmonestacionesRojo.Width <= flayoutAmonestacionesAzul.Width) ? flayoutAmonestacionesRojo.Width : flayoutAmonestacionesAzul.Width;

            if ((size * subsistemaPuntos.amonestaciones) >= standar)
                size = (standar / subsistemaPuntos.amonestaciones)-2;

            gamAzul = new PictureBox[subsistemaPuntos.amonestaciones];
            gamRojo = new PictureBox[subsistemaPuntos.amonestaciones];
            //inicializar cada picture box y mostrarlo
            for (int i = 0; i < subsistemaPuntos.amonestaciones; i++)
            {
                gamAzul[i] = new PictureBox();
                gamAzul[i].BackgroundImage = picNoMarcada.BackgroundImage;
                gamAzul[i].BackgroundImageLayout = picMuestra.BackgroundImageLayout;
                //gamAzul[i].Size = picMuestra.Size;
                gamAzul[i].Width = size;
                gamAzul[i].Height = size;
                gamAzul[i].Visible = true;
                flayoutAmonestacionesAzul.Controls.Add(gamAzul[i]);

                gamRojo[i] = new PictureBox();
                gamRojo[i].BackgroundImage = picNoMarcada.BackgroundImage;
                gamRojo[i].BackgroundImageLayout = picMuestra.BackgroundImageLayout;
                //gamRojo[i].Size = picMuestra.Size;
                gamRojo[i].Width = size;
                gamRojo[i].Height = size;
                gamRojo[i].Visible = true;
                flayoutAmonestacionesRojo.Controls.Add(gamRojo[i]);

                //tamanioStandar = gamRojo[i].Size;
            }
            //mostrar el tiempo y round inicial
            lblRound.Text = "Round " + Convert.ToString(subsistemaTiempo.roundActual + 1);
            lblTiempo.Text = subsistemaTiempo.tiempo;
        }
        private void ganadorRojo()
        {
            timerPrincipal.Enabled = false;
            subsistemaTiempo.terminarCombate();
            //establecer como ganador al competidor con peto rojo
            subsistemaPuntos.ganador = Punteo.ROJO;
            lblNombreRojo.Text = "Ganador Rojo";
            //encender el timer para el parpadeo
            timerBlink.Enabled = true;
            MessageBox.Show("El ganador es el competidor rojo", "Combate finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //lblTiempo.Text = "Ganador rojo";
            

            botonDetenerCombate.Enabled = false;
            botonNuevoCombate.Enabled = true;
            botonPlay.Enabled = false;
            botonPausa.Enabled = false;
            botonStop.Enabled = false;
            botonAdelantar.Enabled = false;
            botonAtrasar.Enabled = false;
            groupAmonestaciones.Enabled = false;
            groupGanador.Enabled = false;
            groupPuntos.Enabled = false;
        }
        private void ganadorAzul()
        {
            timerPrincipal.Enabled = false;
            subsistemaTiempo.terminarCombate();
            //establecer como ganador al competidor con peto rojo
            subsistemaPuntos.ganador = Punteo.AZUL;
            lblNombreAzul.Text = "Ganador Azul";
            //encender el timer para el parpadeo
            timerBlink.Enabled = true;
            MessageBox.Show("El ganador es el competidor azul", "Combate finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //lblTiempo.Text = "Ganador azul";
            

            botonDetenerCombate.Enabled = false;
            botonNuevoCombate.Enabled = true;
            botonPlay.Enabled = false;
            botonPausa.Enabled = false;
            botonStop.Enabled = false;
            botonAdelantar.Enabled = false;
            botonAtrasar.Enabled = false;
            groupAmonestaciones.Enabled = false;
            groupGanador.Enabled = false;
            groupPuntos.Enabled = false;
        }

        private void adelantarRound()
        {
            subsistemaTiempo.roundSiguiente();
            lblRound.Text = subsistemaTiempo.round;
        }
        private void atrasarRound()
        {
            subsistemaTiempo.roundAnterior();
            lblRound.Text = subsistemaTiempo.round;
        }

        public void detenerClicSostenido()
        {
            timerClicSostenido.Enabled = false;
            direccion = 0;
        }
        
        private void timerClicSostenido_Tick(object sender, EventArgs e)
        {
            if (direccion == 2)
                adelantarTiempo();
            else if (direccion == 1)
                atrasarTiempo();
        }
        
        private void botonSumaPuntoR_Click(object sender, EventArgs e)
        {
            sumarPuntoRojo(1);
        }

        private void botonRestaPuntoR_Click(object sender, EventArgs e)
        {
            quitarPuntoRojo();
        }

        private void botonSumaPuntoA_Click(object sender, EventArgs e)
        {
            sumarPuntoAzul(1);
        }

        private void botonRestaPuntoA_Click(object sender, EventArgs e)
        {
            quitarPuntoAzul();
        }

        private void botonGanadorRojo_Click(object sender, EventArgs e)
        {
            
            ganadorRojo();
        }

        private void botonGanadorAzul_Click(object sender, EventArgs e)
        {
            ganadorAzul();
        }

        private void botonPlay_Click(object sender, EventArgs e)
        {
            //play();
            playUnico();
        }

        private void botonPausa_Click(object sender, EventArgs e)
        {
            iniciarTiempoMedico();
        }

        private void botonStop_Click(object sender, EventArgs e)
        {
            //pausa general del combate
            pausaGeneral();
        }

        private void botonSumaKR_Click(object sender, EventArgs e)
        {
            sumaKRojo();
        }

        private void botonRestaKR_Click(object sender, EventArgs e)
        {
            restaKRojo();
        }

        private void botonSumaGR_Click(object sender, EventArgs e)
        {
            sumaGRojo();
        }

        private void botonSumaKA_Click(object sender, EventArgs e)
        {
            sumaKAzul();
        }

        private void botonRestaKA_Click(object sender, EventArgs e)
        {
            restaKAzul();
        }

        private void botonSumaGA_Click(object sender, EventArgs e)
        {
            sumaGAzul();
        }

        private void botonAtrasar_MouseDown(object sender, MouseEventArgs e)
        {
            direccion = 1; //dirección 1 indica agregar tiempo al cronómetro
            timerClicSostenido.Enabled = true;
        }

        private void botonAtrasar_MouseUp(object sender, MouseEventArgs e)
        {
            detenerClicSostenido();
        }

        private void botonAdelantar_MouseDown(object sender, MouseEventArgs e)
        {
            direccion = 2;
            timerClicSostenido.Enabled = true;
        }

        private void botonAdelantar_MouseUp(object sender, MouseEventArgs e)
        {
            detenerClicSostenido();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tablero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                detenerClicSostenido();
            }
            else if (e.KeyCode == Keys.Right)
            {
                detenerClicSostenido();
            }
        }

        private void botonRetroceder_Click(object sender, EventArgs e)
        {
            atrasarRound();
            
        }

        private void botonAvanzar_Click(object sender, EventArgs e)
        {
            adelantarRound();
            
        }

        private void timerJoystics_Tick(object sender, EventArgs e)
        {
            //si el sistema no está en pausa o detenido
            if (((((timerPrincipal.Enabled == true) && (subsistemaTiempo.enPausa == false)) && (subsistemaTiempo.combateTerminado == false)) && (subsistemaTiempo.detenido == false)) && (Hardware.existenDispositivos))
            {
                //si al sistema le queda más de un segundo
                if (subsistemaTiempo.actual > 1)
                {
                    int cantidadDispositivos = Hardware.cantidadDispositivos;
                    for (int i = 0; i < cantidadDispositivos; i++)
                    {
                        procesar(i, Hardware.estadoDispositivo(i));
                    }
                }
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
                        marcarPuntoJoystick(idJoystick, 0);
                    }
                    if (botones[1] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 1);
                    }
                    if (botones[2] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 2);
                    }
                    if (botones[3] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 3);
                    }
                    if (botones[4] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 4);
                    }
                    if (botones[5] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 5);
                    }
                    if (botones[6] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 6);
                    }
                    if (botones[7] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 7);
                    }
                    if (botones[8] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 8);
                    }
                    if (botones[9] == true)
                    {
                        marcarPuntoJoystick(idJoystick, 9);
                    }
                    int sx = estado.X;
                    int sy = estado.Y;
                    if (sx == -1000)
                    {
                        marcarPuntoJoystick(idJoystick, 13);
                    }
                    else if (sx == 1000)
                    {
                        marcarPuntoJoystick(idJoystick, 11);
                    }
                    if (sy == -1000)
                    {
                        marcarPuntoJoystick(idJoystick, 10);
                    }
                    else if (sy == 1000)
                    {
                        marcarPuntoJoystick(idJoystick, 12);
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }

        private void marcarPuntoJoystick(int idJoystick, int idBoton)
        {
            int valor = Hardware.valorBoton(idBoton);
            if (valor != 0) //si el botón marca punto
            {
                int color = Hardware.colorBoton(idBoton);

                if (color == Punteo.ROJO)
                {
                    if (valor == 1)
                    {
                        if (timerMarcajeRojo.Enabled == false)
                        {
                            contadorTimerRojo = 0;
                            timerMarcajeRojo.Enabled = true;
                            picUnPuntoR.Visible = true;
                        }
                        int p = Hardware.marcajeUnPuntoRojo(idJoystick);
                        if (p == 1)
                        {
                            contadorTimerRojo = subsistemaPuntos.tiempoMarcaje;
                        }
                    }
                    if (valor == 2)
                    {
                        if (timerMarcaje2PuntosR.Enabled == false)
                        {
                            contador2PuntosTimerRojo = 0;
                            timerMarcaje2PuntosR.Enabled = true;
                            picDosPuntosR.Visible = true;
                        }
                        int p = Hardware.marcajeDosPuntosRojo(idJoystick);
                        if (p == 2)
                        {
                            timerMarcaje2PuntosR.Enabled = false;
                            sumarPuntoRojo(2);
                            Hardware.resetDosPuntosRojo();
                            picDosPuntosR.Visible = false;
                        }
                    }
                    if (valor == 3)
                    {
                        if (timerMarcaje3PuntosR.Enabled == false)
                        {
                            contador3PuntosTimerRojo = 0;
                            timerMarcaje3PuntosR.Enabled = true;
                            picTresPuntosR.Visible = true;
                        }
                        int p = Hardware.marcajeTresPuntosRojo(idJoystick);
                        if (p == 3)
                        {
                            //timerMarcaje3PuntosR.Enabled = false;
                            //sumarPuntoRojo(3);
                            //Hardware.resetTresPuntosRojo();
                            //picTresPuntosR.Visible = false;
                            contador3PuntosTimerRojo = subsistemaPuntos.tiempoMarcaje;
                        }
                    }
                    if (valor == 4)
                    {
                        if (timerMarcaje4PuntosR.Enabled == false)
                        {
                            contador4PuntosTimerRojo = 0;
                            timerMarcaje4PuntosR.Enabled = true;
                            pic4PuntosR.Visible = true;
                        }
                        int p = Hardware.marcajeCuatroPuntosRojo(idJoystick);
                        if (p == 4)
                        {
                            timerMarcaje4PuntosR.Enabled = false;
                            sumarPuntoRojo(4);
                            Hardware.resetCuatroPuntosRojo();
                            pic4PuntosR.Visible = false;
                        }
                    }
                }
                else if (color == Punteo.AZUL)
                {
                    if (valor == 1)
                    {
                        if (timerMarcajeAzul.Enabled == false)
                        {
                            contadorTimerAzul = 0;
                            timerMarcajeAzul.Enabled = true;
                            picUnPuntoA.Visible = true;
                        }
                        int p = Hardware.marcajeUnPuntoAzul(idJoystick);
                        if (p == 1)
                        {
                            contadorTimerAzul = subsistemaPuntos.tiempoMarcaje;
                        }
                    }
                    if (valor == 2)
                    {
                        if (timerMarcaje2PuntosA.Enabled == false)
                        {
                            contador2PuntosTimerAzul = 0;
                            timerMarcaje2PuntosA.Enabled = true;
                            picDosPuntosA.Visible = true;
                        }
                        int p = Hardware.marcajeDosPuntosAzul(idJoystick);
                        if (p == 2)
                        {
                            timerMarcaje2PuntosA.Enabled = false;
                            sumarPuntoAzul(2);
                            Hardware.resetDosPuntosAzul();
                            picDosPuntosA.Visible = false;
                        }
                    }
                    if (valor == 3)
                    {
                        if (timerMarcaje3PuntosA.Enabled == false)
                        {
                            contador3PuntosTimerAzul = 0;
                            timerMarcaje3PuntosA.Enabled = true;
                            picTresPuntosA.Visible = true;
                        }
                        int p = Hardware.marcajeTresPuntosAzul(idJoystick);
                        if (p == 3)
                        {
                            //timerMarcaje3PuntosA.Enabled = false;
                            //sumarPuntoAzul(3);
                            //Hardware.resetTresPuntosAzul();
                            //picTresPuntosA.Visible = false;
                            contador3PuntosTimerAzul = subsistemaPuntos.tiempoMarcaje;
                        }
                    }
                    if (valor == 4)
                    {
                        if (timerMarcaje4PuntosA.Enabled == false)
                        {
                            contador4PuntosTimerAzul = 0;
                            timerMarcaje4PuntosA.Enabled = true;
                            pic4PuntosA.Visible = true;
                        }
                        int p = Hardware.marcajeCuatroPuntosAzul(idJoystick);
                        if (p == 4)
                        {
                            timerMarcaje4PuntosA.Enabled = false;
                            sumarPuntoAzul(4);
                            Hardware.resetCuatroPuntosAzul();
                            pic4PuntosA.Visible = false;
                        }
                    }
                }                
            }
        }

        private void verificarMarcajePuntoRojoPorJoystick()
        {
            timerMarcajeRojo.Enabled = false;
            int puntoMarcado = Hardware.puntoMarcadoRojo();
            if (puntoMarcado > 0)
            {
                sumarPuntoRojo(puntoMarcado);
            }
            if (Hardware.colaMarcajeRojo == true) //si todavia hay elementos de marcaje de puntos en la cola, encender de nuevo el timer de marcaje
            {
                contadorTimerRojo = 0;
                timerMarcajeRojo.Enabled = true;
            }
            else
            {
                picUnPuntoR.Visible = false;
            }
        }

        private void timerMarcajeAzul_Tick(object sender, EventArgs e)
        {
            if (contadorTimerAzul < subsistemaPuntos.tiempoMarcaje)
            {
                contadorTimerAzul += 2;
            }
            else
                verificarMarcajePuntoAzulPorJoystick();
        }

        private void verificarMarcajePuntoAzulPorJoystick()
        {
            timerMarcajeAzul.Enabled = false;
            int puntoMarcado = Hardware.puntoMarcadoAzul();
            if (puntoMarcado > 0)
            {
                sumarPuntoAzul(puntoMarcado);
            }
            if (Hardware.colaMarcajeAzul == true) //si en la cola de marcaje hay señales por confirmar, continuar el conteo
            {
                contadorTimerAzul = 0;
                timerMarcajeAzul.Enabled = true;
            }
            else
            {
                picUnPuntoA.Visible = false;
            }
        }

        private void botonDetenerCombate_Click_1(object sender, EventArgs e)
        {
            detenerCombate(true);
        }

        private void botonNuevoCombate_Click_1(object sender, EventArgs e)
        {
            reiniciarCombate();
        }

        private void timerMarcajeRojo_Tick(object sender, EventArgs e)
        {
            if (contadorTimerRojo < subsistemaPuntos.tiempoMarcaje)
            {
                contadorTimerRojo += 2;
            }
            else
                verificarMarcajePuntoRojoPorJoystick();
        }

        private void timerMarcaje2PuntosR_Tick(object sender, EventArgs e)
        {
            if (contador2PuntosTimerRojo < subsistemaPuntos.tiempoMarcaje)
                contador2PuntosTimerRojo += 2;
            else
                verificarMarcaje2PR();
        }
        private void verificarMarcaje2PR()
        {
            timerMarcaje2PuntosR.Enabled = false;
            int puntoMarcado = Hardware.verificarMarcajeDosPuntosRojo();
            if (puntoMarcado == 2)
            {
                sumarPuntoRojo(2);
            }
            Hardware.resetDosPuntosRojo();
            picDosPuntosR.Visible = false;
        }

        private void timerMarcaje2PuntosA_Tick(object sender, EventArgs e)
        {
            if (contador2PuntosTimerAzul < subsistemaPuntos.tiempoMarcaje)
                contador2PuntosTimerAzul += 2;
            else
                verificarMarcaje2PA();
        }
        private void verificarMarcaje2PA()
        {
            timerMarcaje2PuntosA.Enabled = false;
            int puntoMarcado = Hardware.verificarMarcajeDosPuntosAzul();
            if (puntoMarcado == 2)
                sumarPuntoAzul(2);
            Hardware.resetDosPuntosAzul();
            picDosPuntosA.Visible = false;
        }

        private void timerMarcaje3PuntosR_Tick(object sender, EventArgs e)
        {
            if (contador3PuntosTimerRojo < subsistemaPuntos.tiempoMarcaje)
                contador3PuntosTimerRojo += 2;
            else
                verificarMarcaje3PR();
        }
        private void verificarMarcaje3PR()
        {
            timerMarcaje3PuntosR.Enabled = false;
            int puntoMarcado = Hardware.verificarMarcajeTresPuntosRojo();
            if (puntoMarcado == 3)
                sumarPuntoRojo(3);

            if (Hardware.colaMarcaje3PuntosRojo == true)
            {
                contador3PuntosTimerRojo = 0;
                timerMarcaje3PuntosR.Enabled = true;
            }
            else
            {
                picTresPuntosR.Visible = false;
            }
        }

        private void timerMarcaje3PuntosA_Tick(object sender, EventArgs e)
        {
            if (contador3PuntosTimerAzul < subsistemaPuntos.tiempoMarcaje)
                contador3PuntosTimerAzul += 2;
            else
                verificarMarcaje3PA();
        }
        private void verificarMarcaje3PA()
        {
            timerMarcaje3PuntosA.Enabled = false;
            int puntoMarcado = Hardware.verificarMarcajeTresPuntosAzul();
            if (puntoMarcado == 3)
                sumarPuntoAzul(3);

            if (Hardware.colaMarcaje3PuntosAzul == true)
            {
                contador4PuntosTimerAzul = 0;
                timerMarcaje3PuntosA.Enabled = true;
            }
            else
                picTresPuntosA.Visible = false;       
        }

        private void timerMarcaje4PuntosR_Tick(object sender, EventArgs e)
        {
            if (contador4PuntosTimerRojo < subsistemaPuntos.tiempoMarcaje)
                contador4PuntosTimerRojo += 2;
            else
                verificarMarcaje4PR();
        }
        private void verificarMarcaje4PR()
        {
            timerMarcaje4PuntosR.Enabled = false;
            int puntoMarcado = Hardware.verificarMarcajeCuatroPuntosRojo();
            if (puntoMarcado == 4)
                sumarPuntoRojo(4);
            Hardware.resetCuatroPuntosRojo();
            pic4PuntosR.Visible = false;
        }

        private void timerMarcaje4PuntosA_Tick(object sender, EventArgs e)
        {
            if (contador4PuntosTimerAzul < subsistemaPuntos.tiempoMarcaje)
                contador4PuntosTimerAzul += 2;
            else
                verificarMarcaje4PA();
        }
        private void verificarMarcaje4PA()
        {
            timerMarcaje4PuntosA.Enabled = false;
            int puntoMarcado = Hardware.verificarMarcajeCuatroPuntosAzul();
            if (puntoMarcado == 4)
                sumarPuntoAzul(4);
            Hardware.resetCuatroPuntosAzul();
            pic4PuntosA.Visible = false;
        }

        private void lblRound_Click(object sender, EventArgs e)
        {

        }

        private void Tablero_Load(object sender, EventArgs e)
        {

        }
    }
}
