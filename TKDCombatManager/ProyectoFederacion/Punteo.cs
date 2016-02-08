using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFederacion
{
    public class Punteo
    {
        public static int AZUL = 1;
        public static int ROJO = 2;

        private int puntosParaGanar;
        private int amonestacionesMaximas;
        private double tiempoMarcacion;

        private int puntosMarcadosRojo = 0;
        private int puntosMarcadosAzul = 0;
        private int amonestacionesMarcadasRojo = 0;
        private int amonestacionesMarcadasAzul = 0;
        private int colorGanador = 0;

        public Punteo()
        { }

        public Punteo(int diferenciaPuntos, int amonestaciones, double tiempoMarcacion)
        {
            this.puntosParaGanar = diferenciaPuntos;
            this.amonestaciones = amonestaciones;
            this.tiempoMarcacion = tiempoMarcacion;
        }

        public int diferenciaParaGanar
        {
            get { return puntosParaGanar; }
            set { this.puntosParaGanar = value; }
        }
        public int amonestaciones
        {
            get { return amonestacionesMaximas; }
            set { this.amonestacionesMaximas = value; }
        }
        public double tiempoMarcaje
        {
            get { return tiempoMarcacion; }
            set { this.tiempoMarcacion = value; }
        }
        public string puntosRojo
        {
            get { return Convert.ToString(puntosMarcadosRojo); }
        }
        public int numeroPuntosRojo
        {
            get { return puntosMarcadosRojo; }
        }
        public string puntosAzul
        {
            get { return Convert.ToString(puntosMarcadosAzul); }
        }
        public int numeroPuntosAzul
        {
            get { return puntosMarcadosAzul; }
        }
        public int numeroAmonestacionesRojo
        {
            get { return amonestacionesMarcadasRojo; }
        }
        public int numeroAmonestacionesAzul
        {
            get { return amonestacionesMarcadasAzul; }
        }
        public string amonestacionesRojo
        {
            get { return Convert.ToString(amonestacionesMarcadasRojo); }
        }
        public string amonestacionesAzul
        {
            get { return Convert.ToString(amonestacionesMarcadasAzul); }
        }
        public int ganador
        {
            get { return colorGanador; }
            set { this.colorGanador = value; }
        }
        public bool empate
        {
            get { return (puntosMarcadosAzul == puntosMarcadosRojo); }
        }

        /// <summary>
        /// Función para marcar un punto a favor del competidor rojo.
        /// </summary>
        /// <returns>True si la diferencia de puntos a favor del competidor rojo es mayor o igual a la diferencia máxima, por lo tanto el competidor rojo es ganador, de lo contrario retorna false.</returns>
        public bool marcarPuntoRojo(int puntos)
        {
            puntosMarcadosRojo+=puntos;
            int puntosNetos = puntosMarcadosRojo - puntosMarcadosAzul;
            if (puntosNetos >= puntosParaGanar) //if ((puntosMarcadosRojo - puntosMarcadosAzul) >= puntosParaGanar)
                return true;
            else
                return false;
        }
        public bool marcarPuntoAzul(int puntos)
        {
            puntosMarcadosAzul+=puntos;
            int puntosNetos = puntosMarcadosAzul - puntosMarcadosRojo;
            if (puntosNetos >= puntosParaGanar) //if ((puntosMarcadosAzul - puntosMarcadosRojo) >= puntosParaGanar)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Función para marcar una amonestación para el competidor rojo
        /// </summary>
        /// <returns>Si el número de amonestaciones es igual al número máximo de amonestaciones retorna true entonces el competidor perdió, de lo contrario retorna false</returns>
        public bool marcarAmonestacionRojo()
        {
            amonestacionesMarcadasRojo++;
            if ((amonestacionesMarcadasRojo % 2) == 0)
            {
                marcarPuntoAzul(1);
                quitarPuntoRojo();
            }
            if (amonestacionesMarcadasRojo >= amonestacionesMaximas)
                return true;
            else
                return false;
        }
        public bool marcarAmonestacionAzul()
        {
            amonestacionesMarcadasAzul++;
            if ((amonestacionesMarcadasAzul % 2) == 0)
            {
                marcarPuntoRojo(1);
                quitarPuntoAzul();
            }
            if (amonestacionesMarcadasAzul >= amonestacionesMaximas)
                return true;
            else
                return false;
        }
        public void quitarPuntoRojo()
        {
            puntosMarcadosRojo--;
        }
        public void quitarPuntoAzul()
        {
            puntosMarcadosAzul--;
        }
        public void quitarAmonestacionRojo()
        {
            if (amonestacionesMarcadasRojo > 0)
                amonestacionesMarcadasRojo--;
        }
        public void quitarAmonestacionAzul()
        {
            if (amonestacionesMarcadasAzul > 0)
                amonestacionesMarcadasAzul--;
        }
        public void iniciarMuerteSubita()
        {
            reset();
        }
        /// <summary>
        /// ATENCIÓN CON ESTA FUNCIÓN
        /// </summary>
        public void determinarGanador()
        {
            //QUE PASA SI EL QUE TIENE MÁS AMONESTACIONES TAMBIÉN TIENE MÁS PUNTOS??
            //gana rojo si tiene mas puntos que azul o si 
            if (amonestacionesMarcadasAzul >= amonestacionesMaximas)
            {
                this.colorGanador = Punteo.ROJO;
                return;
            }
            else if (amonestacionesMarcadasRojo >= amonestacionesMaximas)
            {
                this.colorGanador = Punteo.AZUL;
                return;
            }
            else if ((puntosMarcadosRojo - puntosMarcadosAzul) >= puntosParaGanar)
            {
                this.colorGanador = Punteo.ROJO;
                return;
            }
            else if ((puntosMarcadosAzul - puntosMarcadosRojo) >= puntosParaGanar)
            {
                this.colorGanador = Punteo.AZUL;
                return;
            }
            else if (puntosMarcadosRojo < puntosMarcadosAzul)
            {
                this.colorGanador = Punteo.AZUL;
                return;
            }
            else if (puntosMarcadosAzul < puntosMarcadosRojo)
            {
                this.colorGanador = Punteo.ROJO;
                return;
            }
        }

        public void reset()
        {
            puntosMarcadosRojo = 0;
            puntosMarcadosAzul = 0;
            amonestacionesMarcadasRojo = 0;
            amonestacionesMarcadasAzul = 0;
            colorGanador = 0;
        }
    }
}
