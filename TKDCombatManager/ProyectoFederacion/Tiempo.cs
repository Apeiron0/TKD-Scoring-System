using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFederacion
{
    public class Tiempo
    {
        //variables que el usuario define: la duracion del tiempo medico, la duracion del round y la cantidad de rounds
        private double duracionRound;
        private double tiempoPausa;
        private double tiempoEntreRounds;
        private int cantidadDeRounds = 3;

        //variables de control: son las que se actualizan cada segundo: llevan la cuenta del tiempo transcurrido y el round actual
        private int numeroRoundActual = 0;
        private double tiempoActual;
        private double tiempoActualTiempoMedico;
        private double tiempoActualEntreRounds;
        
        //banderas de estado del reloj.
        private bool roundDesempate = false;
        private bool pausado = false;
        private bool estadoDetenido = false;
        private bool estadoTerminado = false;
        private bool banderaTiempoMedicoDetenido = false;
        private bool estadoEntreRounds = false;

        public Tiempo()
        { }

        public Tiempo(double round, double pausa, int cantidadRounds, double entreRounds)
        {
            this.duracionRound = round;
            this.tiempoPausa = pausa;
            this.cantidadDeRounds = cantidadRounds;
            this.tiempoActual = round;
            this.tiempoActualTiempoMedico = 0;
            this.tiempoActualEntreRounds = 0;
            this.tiempoEntreRounds = entreRounds;
        }

        public void reset()
        {
            numeroRoundActual = 0;
            this.tiempoActual = duracionRound;
            this.tiempoActualTiempoMedico = 0;
            this.tiempoActualEntreRounds = tiempoEntreRounds;
            roundDesempate = false;
            pausado = false;
            estadoDetenido = false;
            estadoTerminado = false;
            estadoEntreRounds = false;
        }
        public double actual
        {
            get { return this.tiempoActual; }
        }
        public double tiempoRound
        {
            get { return this.duracionRound; }
            set { this.duracionRound = value; }
        }
        public double tiempoMedico
        {
            get { return this.tiempoPausa; }
            set { this.tiempoPausa = value; }
        }
        public int cantidadRounds
        {
            get { return cantidadDeRounds; }
            set { cantidadDeRounds = value; }
        }
        public int roundActual
        {
            get { return numeroRoundActual; }
        }
        public bool muerteSubita
        {
            get { return roundDesempate; }
            set { this.roundDesempate = value; }
        }
        public bool combateTerminado
        {
            get { return estadoTerminado; }
        }
        public bool roundTerminado
        {
            get { return (tiempoActual == 0); }
        }
       
        public bool enPausa
        {
            get { return pausado; }
        }
        public bool detenido
        {
            get { return estadoDetenido; }
        }

        public bool enDescanso
        {
            get { return estadoEntreRounds; }
        }

        public bool reiniciarDeTiempoMedico()
        {
            pausado = false;
            banderaTiempoMedicoDetenido = false;
            return true;
        }
        
        public void detenerTiempoMedico()
        {
            banderaTiempoMedicoDetenido = true;
        }

        public void iniciarDescanso()
        {
            estadoEntreRounds = true;
        }

        public void finalizarDescanso()
        {
            estadoEntreRounds = false;
        }
        
        public void detener()
        {
            estadoDetenido = true;
        }
        
        public bool reiniciar()
        {
            estadoDetenido = false;
            return true;
        }
        
        public void terminarCombate()
        {
            //pausado = false; //si estaba en pausa, terminar la pausa e indicar el fin del combate
            estadoTerminado = true;
        }
        
        public void pausar()
        {
            banderaTiempoMedicoDetenido = false;
            pausado = true;
            tiempoActualTiempoMedico = 0;
        }

        /// <summary>
        /// Suma tiempo al tiempo actual de round o de pausa entre rounds. Si es tiempo medico, se quita el tiempo.
        /// </summary>
        public void sumarTiempo()
        {
            if (pausado == true)
            {
                if (tiempoActualTiempoMedico > 0)
                    tiempoActualTiempoMedico--;
            }
            else  //si el reloj no está en tiempo médico, adelantar el reloj para el descanso entre rounds o el tiempo del round
            {
                if (estadoEntreRounds == true)
                {
                    if (tiempoActualEntreRounds < tiempoEntreRounds)
                        tiempoActualEntreRounds++;
                }
                else
                {
                    if (tiempoActual < duracionRound)
                        tiempoActual++;
                }
                
            }
        }

        /// <summary>
        /// Se resta tiempo a cualquiera de los estados: si es round o pausa entre rounds, se adelanta el reloj. Si es tiempo médico, se atrasa el reloj
        /// </summary>
        public void quitarTiempo()
        {
            if (pausado == true)
            {
                if (tiempoActualTiempoMedico < tiempoPausa)
                    tiempoActualTiempoMedico++;
            }
            else
            {
                if (estadoEntreRounds == true)
                {
                    if (tiempoActualEntreRounds > 0)
                        tiempoActualEntreRounds--;
                }
                else
                {
                    if (tiempoActual > 0)
                        tiempoActual--;
                }
            }
        }
        
        public bool iniciar()
        {
            bool bandera = true;
            pausado = false;
            estadoTerminado = false;
            estadoDetenido = false;
            estadoEntreRounds = false;
            tiempoActual = duracionRound;
            tiempoActualEntreRounds = tiempoEntreRounds;
            if (numeroRoundActual < cantidadDeRounds)
            {
                numeroRoundActual++;
            }
            else //si ya se cumplieron todos los rounds, se retorna false
            {
                estadoTerminado = true;
                bandera = false;
            }
            return bandera;
        }
        
        public void iniciarMuerteSubita()
        {
            pausado = false;
            estadoTerminado = false;
            estadoDetenido = false;
            roundDesempate = true;
            estadoEntreRounds = false;
            tiempoActual = duracionRound;
            tiempoActualEntreRounds = tiempoEntreRounds;
        }
        
        /// <summary>
        /// Corriendo el reloj
        /// </summary>
        /// <returns>True: si todavia queda tiempo. False si el cronómetro llegó a 0</returns>
        public bool reloj()
        {
            bool bandera = true;
            if (estadoTerminado)
                bandera = false;
            else
            {
                if (estadoDetenido)
                    bandera = false;
                else
                {
                    if ((roundDesempate == false) && (pausado == false))
                    {
                        if (estadoEntreRounds == true)
                        {
                            //si es tiempo de descanso entre rounds.
                            if (tiempoActualEntreRounds > 0)
                            {
                                tiempoActualEntreRounds--;
                            }
                            else
                            {
                                //terminó el tiempo de descanso entre rounds.
                                bandera = false;
                            }
                        }
                        else
                        {
                            //si es tiempo normal
                            if (tiempoActual > 0)
                            {
                                tiempoActual--;
                            }
                            else
                            {
                                if (cantidadDeRounds == numeroRoundActual) //verificar si ya se cumplieron todos los rounds
                                    estadoTerminado = true;
                                bandera = false;
                            }
                        }
                    }
                    else if (pausado == true)
                    {
                        //si es tiempo médico
                        if ((tiempoActualTiempoMedico < tiempoPausa)&&(banderaTiempoMedicoDetenido==false))
                            tiempoActualTiempoMedico++;
                        else
                            bandera = false;
                    }
                    else if ((roundDesempate == true) && (pausado == false))
                    {
                        //si es muerte subita: por ahora en cuenta regresiva
                        if (tiempoActual > 0)
                            tiempoActual--;
                        else
                        {
                            estadoTerminado = true;
                            bandera = false;
                        }
                    }
                }
            }
            return bandera;
        }
        
        public string round
        {
            get {
                string ret = "";
                if (pausado == true)
                {
                    ret = "Tiempo médico";
                }
                else if ((roundDesempate == true)&&(pausado==false))
                {
                    ret = "Muerte súbita";
                }
                else if ((roundDesempate == false)&&(pausado==false))
                {
                    if (estadoEntreRounds == true)
                    {
                        ret = "Descanso";
                    }
                    else
                    {
                        ret = "Round " + Convert.ToString(numeroRoundActual);
                    }
                }
                return ret;
            }
        }
        
        /// <summary>
        /// Solo es mostrado
        /// </summary>
        /// <returns>string: el texto del cronómetro que se va mostrar en pantalla</returns>
        public string tiempo
        {
            get
            {
                string actual = "";
                string cadenaMinutos;
                string cadenaSegundos;
                int minutos = 0;
                int segundos = 0;
                if (pausado == true)
                {
                    minutos = (int)tiempoActualTiempoMedico / 60;
                    segundos = (int)tiempoActualTiempoMedico % 60;
                }
                else
                {
                    if (estadoEntreRounds == true)
                    {
                        minutos = (int)tiempoActualEntreRounds / 60;
                        segundos = (int)tiempoActualEntreRounds % 60;
                    }
                    else
                    {
                        minutos = (int)tiempoActual / 60;
                        segundos = (int)tiempoActual % 60;
                    }
                }
                
                cadenaMinutos = Convert.ToString(minutos);
                cadenaSegundos = Convert.ToString(segundos);
                if (minutos < 10)
                    cadenaMinutos = "0" + cadenaMinutos;
                if (segundos < 10)
                    cadenaSegundos = "0" + cadenaSegundos;
                actual = actual + cadenaMinutos + ":" + cadenaSegundos;
                return actual;
            }
        }


        public void roundAnterior()
        {
            if (roundDesempate == false)
            {
                if (numeroRoundActual > 1)
                {
                    numeroRoundActual--;
                }
            }
        }

        public void roundSiguiente()
        {
            if (roundDesempate == false)
            {
                if (numeroRoundActual < cantidadDeRounds)
                {
                    numeroRoundActual++;
                }
            }
        }
    }
}
