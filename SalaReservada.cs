using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class SalaReservada
    {
        private int codigo;
        private DateTime dtEntrada;
        private DateTime dtSaida;
        private int tempoPerm;

        public int Codigo { get => codigo; set => codigo = value; }
        public DateTime DtEntrada { get => dtEntrada; set => dtEntrada = value; }
        public DateTime DtSaida { get => dtSaida; set => dtSaida = value; }
        public int TempoPerm { get => tempoPerm; set => tempoPerm = value; }

        public SalaReservada[] salasReservadas = new SalaReservada[10];

        public bool VerificaReservaSala(int[] codSala, DateTime dataIniReuni, DateTime dataFimReuni, int tempoReuniao)
        {
            bool[] veriNaReserva = new bool[10];
            bool erroNaReserva = false;
            int horaFinalJaMarcada = 0;
            int horaInicialSerAgendada = 0;
            int j = 0;
            int i = 0;
            int x = 0;

            while (codSala[j] != 0)
            {
                while (salasReservadas[i] != null)
                {
                    if (codSala[j] == salasReservadas[i].codigo
                            && dataIniReuni.ToShortDateString() == salasReservadas[i].dtEntrada.ToShortDateString())
                    {
                        horaFinalJaMarcada = Convert.ToDateTime(salasReservadas[i].dtSaida.ToShortTimeString()).Hour;
                        horaInicialSerAgendada = Convert.ToDateTime(dataIniReuni.ToShortTimeString()).Hour;

                        if (horaInicialSerAgendada <= horaFinalJaMarcada)
                        {
                            veriNaReserva[i] = true;
                            break;
                        }
                    }
                    i = i + 1;
                }
                Console.WriteLine(" \n\n\t ******* Reserva ate o momento :" + erroNaReserva);

                j = j + 1;
            }

            for (x = 0; x < i; x++)
            {
                if (veriNaReserva[x])
                {
                    erroNaReserva = true;
                    break;
                }
            }
            if (!erroNaReserva)
                salasReservadas[x] = new SalaReservada { Codigo = codSala[j], DtEntrada = dataIniReuni, DtSaida = dataFimReuni, TempoPerm = tempoReuniao };

            return erroNaReserva;
        }

    }
}