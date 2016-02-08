using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectInput;

namespace ProyectoFederacion
{
    public static class Hardware
    {
        private static Joystick[] lstJoysticks = null;
        private static int[] mapBotonesPuntos = new int[14] { 0, 2, 0, 1, 3, 3, 4, 4, 0, 0, 0, 1, 0, 2 };
        private static int[] colorBotones = new int[14] { 0, 1, 0, 1, 2, 1, 2, 1, 0, 0, 0, 2, 0, 2 };
        private static int[] puntoProvisionalRojo;
        private static int[] puntoProvisionalAzul;

        private static Queue<Marcacion> colaPuntoRojo = new Queue<Marcacion>();
        private static Queue<Marcacion> colaPuntoAzul = new Queue<Marcacion>();
        private static Queue<Marcacion> cola3PuntosRojo = new Queue<Marcacion>();
        private static Queue<Marcacion> cola3PuntosAzul = new Queue<Marcacion>();
        private static Marcacion marcadorDosPuntosAzul;
        private static Marcacion marcadorDosPuntosRojo;
        private static Marcacion marcadorTresPuntosAzul;
        private static Marcacion marcadorTresPuntosRojo;
        private static Marcacion marcadorCuatroPuntosAzul;
        private static Marcacion marcadorCuatroPuntosRojo;

        #region manejo de hardware
        public static Joystick[] joystics
        {
            get { return Hardware.lstJoysticks; }
            set 
            {
                Hardware.lstJoysticks = value;
                Hardware.puntoProvisionalRojo = new int[Hardware.lstJoysticks.Length];
                Hardware.puntoProvisionalAzul = new int[Hardware.lstJoysticks.Length];

                marcadorCuatroPuntosAzul = new Marcacion(Hardware.lstJoysticks.Length);
                marcadorCuatroPuntosRojo = new Marcacion(Hardware.lstJoysticks.Length);
                //marcadorTresPuntosAzul = new Marcacion(Hardware.lstJoysticks.Length);
                //marcadorTresPuntosRojo = new Marcacion(Hardware.lstJoysticks.Length);
                marcadorDosPuntosAzul = new Marcacion(Hardware.lstJoysticks.Length);
                marcadorDosPuntosRojo = new Marcacion(Hardware.lstJoysticks.Length);

                for (int i = 0; i < Hardware.joystics.Length; i++)
                {
                    Hardware.puntoProvisionalRojo[i] = 0;
                    Hardware.puntoProvisionalAzul[i] = 0;
                }
            }
        }
        public static bool existenDispositivos
        {
            get 
            { 
                bool bandera = false;
                if (lstJoysticks != null)
                {
                    if (lstJoysticks.Length > 0)
                        bandera = true;
                }
                return bandera;
            }
        }
        public static int cantidadDispositivos
        {
            get
            {
                if (!Hardware.existenDispositivos)
                    return 0;
                else
                    return Hardware.lstJoysticks.Length;
            }
        }
        public static void configuracionAvanzada(int [] mapBotones, int [] mapColorCompetidor)
        {
            mapBotonesPuntos = mapBotones;
            colorBotones = mapColorCompetidor;
        }
        public static void configuracionTipica()
        {
            mapBotonesPuntos = new int[14] { 0, 2, 0, 1, 3, 3, 4, 4, 0, 0, 0, 1, 0, 2 };
            colorBotones = new int[14] { 0, 1, 0, 1, 2, 1, 2, 1, 0, 0, 0, 2, 0, 2 };
        }
        public static Joystick dispositivo(int index)
        {
            return lstJoysticks[index];
        }
        public static JoystickState estadoDispositivo(int index)
        {
            return lstJoysticks[index].GetCurrentState();
        }
        /// <summary>
        /// Función para configurar cada botón
        /// </summary>
        /// <param name="idJoystick"></param>
        /// <param name="idBoton"></param>
        /// <param name="idColor"></param>
        public static void setJoysticBotonColor(int idJoystick, int idBoton, int idColor)
        {
            if (Hardware.lstJoysticks != null)
            {
            }
        }
        public static int valorBoton(int index)
        {
            return mapBotonesPuntos[index];
        }
        public static int colorBoton(int index)
        {
            return colorBotones[index];
        }
        public static void unAquire()
        {
            if (lstJoysticks != null)
            {
                for (int i = 0; i < Hardware.lstJoysticks.Length; i++)
                {
                    lstJoysticks[i].Unacquire();
                }
            }
        }
        #endregion

        #region verificacion de colas

        public static bool colaMarcajeRojo
        {
            get { return (Hardware.colaPuntoRojo.Count > 0); }
        }
        public static bool colaMarcajeAzul
        {
            get { return (Hardware.colaPuntoAzul.Count > 0); }
        }
        public static bool colaMarcaje3PuntosAzul
        {
            get { return (Hardware.cola3PuntosAzul.Count > 0); }
        }
        public static bool colaMarcaje3PuntosRojo
        {
            get { return (Hardware.cola3PuntosRojo.Count > 0); }
        }

        #endregion

        #region marcaje 1 punto
        /// <summary>
        /// Esta funcion se ejecuta al detenerse el timer de marcaje de competidor rojo, para determinar si se marcó o no el punto.
        /// </summary>
        /// <returns></returns>
        public static int puntoMarcadoRojo()
        {
            int pPunto = 0;
            if (Hardware.colaPuntoRojo.Count>0)
            {
                Marcacion temp = Hardware.colaPuntoRojo.Dequeue();
                pPunto = temp.confirmarMarcaje();
            }
            return pPunto;
        }
        public static int puntoMarcadoAzul()
        {
            int pPunto = 0;
            if (Hardware.colaPuntoAzul.Count > 0)
            {
                Marcacion temp = Hardware.colaPuntoAzul.Dequeue();
                pPunto = temp.confirmarMarcaje();
            }
            return pPunto;
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="idJoystick"></param>
        /// <param name="punto"></param>
        /// <returns></returns>
        public static int marcajeUnPuntoRojo(int idJoystick)
        {
            //si no hay elementos en la cola, insertar una nueva señal de marcaje
            bool banderaInsercion = true;
            int confirmacion = 0;
            if (Hardware.lstJoysticks != null)
            {
                for (int i = 0; i < Hardware.colaPuntoRojo.Count; i++)
                {
                    Marcacion temp = Hardware.colaPuntoRojo.ElementAt(i);
                    if (temp.puntoMarcado(idJoystick) == false) //si en la señal de marcado, el boton no se ha marcado, se marca en esa señal y se finaliza el ciclo
                    {
                        banderaInsercion = false;
                        if (temp.marcar(idJoystick, 1))
                            confirmacion = temp.confirmarMarcaje();
                        break;
                    }
                }
                if ((banderaInsercion == true) && (Hardware.colaPuntoRojo.Count < 4)) //si despues de revisar en todos los elementos de la cola si el punto no había sido marcado en otra señal, se inserta una nueva señal de marcaje a la cola
                {
                    Marcacion temp = new Marcacion(Hardware.cantidadDispositivos);
                    temp.marcarpunto(idJoystick, 1);
                    colaPuntoRojo.Enqueue(temp);
                }
            }
            return confirmacion;
        }
        public static int marcajeUnPuntoAzul(int idJoystick)
        {
            //si no hay elementos en la cola, insertar una nueva señal de marcaje
            bool banderaInsercion = true;
            int confirmacion = 0;
            if (Hardware.lstJoysticks != null)
            {
                for (int i = 0; i < Hardware.colaPuntoAzul.Count; i++)
                {
                    Marcacion temp = Hardware.colaPuntoAzul.ElementAt(i);
                    if (temp.puntoMarcado(idJoystick) == false) //si en la señal de marcado, el boton no se ha marcado, se marca en esa señal y se finaliza el ciclo
                    {
                        banderaInsercion = false;
                        if (temp.marcar(idJoystick, 1))
                            confirmacion = temp.confirmarMarcaje();
                        break;
                    }
                }
                if ((banderaInsercion == true) && (Hardware.colaPuntoAzul.Count < 4)) //si despues de revisar en todos los elementos de la cola si el punto no había sido marcado en otra señal, se inserta una nueva señal de marcaje a la cola
                {
                    Marcacion temp = new Marcacion(Hardware.cantidadDispositivos);
                    temp.marcarpunto(idJoystick, 1);
                    colaPuntoAzul.Enqueue(temp);
                }
            }
            return confirmacion;
        }

        #endregion

        #region marcaje 2 puntos
        public static int marcajeDosPuntosRojo(int idJoystick)
        {
            if (Hardware.marcadorDosPuntosRojo.marcar(idJoystick, 2))
                return Hardware.marcadorDosPuntosRojo.confirmarMarcaje();
            else
                return 0;
        }
        public static void resetDosPuntosRojo()
        {
            Hardware.marcadorDosPuntosRojo.reset();
        }
        public static int verificarMarcajeDosPuntosRojo()
        {
            return Hardware.marcadorDosPuntosRojo.confirmarMarcaje();
        }

        public static int marcajeDosPuntosAzul(int idJoystick)
        {
            if (Hardware.marcadorDosPuntosAzul.marcar(idJoystick, 2))
                return Hardware.marcadorDosPuntosAzul.confirmarMarcaje();
            else
                return 0;
        }
        public static void resetDosPuntosAzul()
        {
            Hardware.marcadorDosPuntosAzul.reset();
        }
        public static int verificarMarcajeDosPuntosAzul()
        {
            return Hardware.marcadorDosPuntosAzul.confirmarMarcaje();
        }

        #endregion

        #region marcaje 3 puntos

        public static int marcajeTresPuntosRojo(int idJoystick)
        {
            bool banderaInsercion = true;
            int confirmacion = 0;
            if (Hardware.lstJoysticks != null)
            {
                for (int i = 0; i < Hardware.cola3PuntosRojo.Count; i++)
                {
                    Marcacion temp = Hardware.cola3PuntosRojo.ElementAt(i);
                    if (temp.puntoMarcado(idJoystick) == false)
                    {
                        banderaInsercion = false;
                        if (temp.marcar(idJoystick,3))
                            confirmacion = temp.confirmarMarcaje();
                        break;
                    }
                }
                if ((banderaInsercion == true) && (Hardware.cola3PuntosRojo.Count < 4))
                {
                    Marcacion temp = new Marcacion(Hardware.cantidadDispositivos);
                    temp.marcarpunto(idJoystick,3);
                    cola3PuntosRojo.Enqueue(temp);
                }
            }
            return confirmacion;
        }        
        public static int verificarMarcajeTresPuntosRojo()
        {
            int pPunto = 0;
            if (Hardware.cola3PuntosRojo.Count > 0)
            {
                Marcacion temp = Hardware.cola3PuntosRojo.Dequeue();
                pPunto = temp.confirmarMarcaje();
            }
            return pPunto;
        }

        public static int marcajeTresPuntosAzul(int idJoystick)
        {
            bool banderaInsercion = true;
            int confirmacion = 0;
            if (Hardware.lstJoysticks != null)
            {
                for (int i = 0; i < Hardware.cola3PuntosAzul.Count; i++)
                {
                    Marcacion temp = Hardware.cola3PuntosAzul.ElementAt(i);
                    if (temp.puntoMarcado(idJoystick) == false)
                    {
                        banderaInsercion = false;
                        if (temp.marcar(idJoystick, 3))
                            confirmacion = temp.confirmarMarcaje();
                        break;
                    }
                }
                if ((banderaInsercion == true) && (Hardware.cola3PuntosAzul.Count < 4))
                {
                    Marcacion temp = new Marcacion(Hardware.cantidadDispositivos);
                    temp.marcarpunto(idJoystick, 3);
                    cola3PuntosAzul.Enqueue(temp);
                }
            }
            return confirmacion;
        }
        public static int verificarMarcajeTresPuntosAzul()
        {
            int pPunto = 0;
            if (Hardware.cola3PuntosAzul.Count > 0)
            {
                Marcacion temp = Hardware.cola3PuntosAzul.Dequeue();
                pPunto = temp.confirmarMarcaje();
            }
            return pPunto;
        }

        #endregion

        #region marcaje 4 puntos
        public static int marcajeCuatroPuntosRojo(int idJoystick)
        {
            if (Hardware.marcadorCuatroPuntosRojo.marcar(idJoystick, 4))
                return Hardware.marcadorCuatroPuntosRojo.confirmarMarcaje();
            else
                return 0;
        }
        public static void resetCuatroPuntosRojo()
        {
            Hardware.marcadorCuatroPuntosRojo.reset();
        }
        public static int verificarMarcajeCuatroPuntosRojo()
        {
            return Hardware.marcadorCuatroPuntosRojo.confirmarMarcaje();
        }

        public static int marcajeCuatroPuntosAzul(int idJoystick)
        {
            if (Hardware.marcadorCuatroPuntosAzul.marcar(idJoystick, 4))
                return Hardware.marcadorCuatroPuntosAzul.confirmarMarcaje();
            else
                return 0;
        }
        public static void resetCuatroPuntosAzul()
        {
            Hardware.marcadorCuatroPuntosAzul.reset();
        }
        public static int verificarMarcajeCuatroPuntosAzul()
        {
            return Hardware.marcadorCuatroPuntosAzul.confirmarMarcaje();
        }

        #endregion

    }
}
