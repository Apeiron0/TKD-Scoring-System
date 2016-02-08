using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFederacion
{
    public class Marcacion
    {
        /// <summary>
        /// parte provisional
        /// </summary>
        private int[] puntoProvisional;
        public Marcacion(int joysticks)
        {
            puntoProvisional = new int[joysticks];
        }
        public void marcarpunto(int idJoystick, int punto)
        {
            puntoProvisional[idJoystick] = punto;
        }
        public bool puntoMarcado(int indiceDispositivo)
        {
            return (puntoProvisional[indiceDispositivo]!=0);
        }
        public int confirmarMarcaje()
        {
            int pPunto = 0;
            for (int i = 0; i < puntoProvisional.Length; i++)
            {
                for (int j = i + 1; j < puntoProvisional.Length; j++)
                {
                    if (puntoProvisional[i] == puntoProvisional[j])
                    {
                        pPunto = puntoProvisional[i];
                        break;
                    }
                }
                if (pPunto != 0)
                    break;
            }
            return pPunto;
        }
        /// <summary>
        /// Marca el punto correspondiente al joystick y retorna una confirmación de que todos los joystics han marcado.
        /// </summary>
        /// <param name="idJoystick"></param>
        /// <param name="punto"></param>
        /// <returns>True: si todos los joystics ya marcaron, false si no.</returns>
        public bool marcar(int idJoystick, int punto)
        {
            int cont = 0;

            puntoProvisional[idJoystick] = punto;

            for (int i = 0; i < puntoProvisional.Length; i++)
            {
                if (puntoProvisional[i] != 0)
                    cont++;
            }

            return (cont == puntoProvisional.Length);
        }

        public void reset()
        {
            for (int i = 0; i < puntoProvisional.Length; i++)
            {
                puntoProvisional[i] = 0;
            }
        }
    }
}
