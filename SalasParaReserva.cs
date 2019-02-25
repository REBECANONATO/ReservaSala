using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Program
{
    class SalasParaReserva
    {
        List<Sala> salas = new List<Sala>();

        public SalasParaReserva()
        {
            Sala s0 = new Sala { Codigo = 1, Lugares = 10, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s1 = new Sala { Codigo = 2, Lugares = 10, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s2 = new Sala { Codigo = 3, Lugares = 10, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s3 = new Sala { Codigo = 4, Lugares = 10, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s4 = new Sala { Codigo = 5, Lugares = 10, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s5 = new Sala { Codigo = 6, Lugares = 10, Internet = true, Computador = false, Tv = false, Webcam = false };
            Sala s6 = new Sala { Codigo = 7, Lugares = 10, Internet = true, Computador = false, Tv = false, Webcam = false };
            Sala s7 = new Sala { Codigo = 8, Lugares = 3, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s8 = new Sala { Codigo = 9, Lugares = 3, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s9 = new Sala { Codigo = 10, Lugares = 3, Internet = true, Computador = true, Tv = true, Webcam = true };
            Sala s10 = new Sala { Codigo = 11, Lugares = 20, Internet = false, Computador = false, Tv = false, Webcam = false };
            Sala s11 = new Sala { Codigo = 12, Lugares = 20, Internet = false, Computador = false, Tv = false, Webcam = false };

            salas.Add(s0);
            salas.Add(s1);
            salas.Add(s2);
            salas.Add(s3);
            salas.Add(s4);
            salas.Add(s5);
            salas.Add(s6);
            salas.Add(s7);
            salas.Add(s8);
            salas.Add(s9);
            salas.Add(s10);
            salas.Add(s11);
        }

        public int[] Reservar(int axlugares, bool axInternet, bool axComputador, bool axTv, bool axWebcam)
        {
            int[] axCodigo = new int[12];
            int x = 0;
            bool axControle = false;
            bool axControleI = false;
            bool axControleC = false;
            bool axControleT = false;
            bool axControleW = false;

            for (int i = 0; i < 12; i++)
            {
                axControle = false;
                axControleI = false;
                axControleC = false;
                axControleT = false;
                axControleW = false;

                if (!axInternet && !axComputador && !axTv && !axWebcam)
                    axControle = true;

                if (salas[i].Internet && axInternet)
                    axControleI = true;

                if (salas[i].Computador && axComputador)
                    axControleC = true;

                if (salas[i].Tv && axTv)
                    axControleT = true;

                if (salas[i].Webcam && axWebcam)
                    axControleW = true;

                if (axControle || axControleI && axControleC && axControleT && axControleW)
                {
                    if (salas[i].Lugares >= axlugares)
                    {
                        axCodigo[x] = salas[i].Codigo;
                        x = x + 1;
                    }
                }

            }
            return axCodigo;
        }
    }
}