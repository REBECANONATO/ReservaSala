using System;
using System.Linq;
using Program;

namespace ReservaSala
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidDadosEntrada dadosRecebidos = new ValidDadosEntrada();
            SalasParaReserva verificaReserva = new SalasParaReserva();
            SalaReservada salasReservadas = new SalaReservada();
            int codValidaDadosEntrada = 0;
            string dtIniString = null;
            string dtFimString = null;
            string axSair = null;
            string axInternet = "N";
            string axTv = "N";
            string axWebcam = "N";
            string axLugares = null;
            string axComputador = "N";
            int[] codSala;
            codSala = new int[12];
            bool reservaNok = false;


            do
            {
                dtIniString = null;
                dtFimString = null;
                axSair = null;
                axInternet = "N";
                axTv = "N";
                axWebcam = "N";
                axLugares = null;
                axComputador = "N";

                Console.Title = "Reservas de Sala para Reunião";

                //______________________________________________________________________Valida Data Inicial 
                do
                {
                    codValidaDadosEntrada = 0;
                    Console.Clear();
                    Console.WriteLine("\n\n\tVAMOS EFETUAR A RESERVA DA SALA ");
                    Console.Write("\n\tDigite a Data do Inicio Reunião e a Hora (dd/mm/yyyy 00:00:00): ");
                    dtIniString = Console.ReadLine();

                    codValidaDadosEntrada = dadosRecebidos.validaInformacoesEntrada(dtIniString, dtFimString);

                    switch (codValidaDadosEntrada)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n\t ***Favor verificar se a data é Válida e seu Formato!***");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("\n\t ***As reuniões devem ser agendadas com no mínimo um dia de antecedência!***");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("\n\t ***As reuniões devem ser agendadas com no máximo 40 dia de antecedência!***");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("\n\t ***As reuniões devem ser agendadas apenas para os dias úteis!***");
                            Console.ReadLine();
                            break;
                    }
                } while (codValidaDadosEntrada != 0);

                //______________________________________________________________________Valida Data Final
                do
                {
                    codValidaDadosEntrada = 0;
                    Console.Clear();
                    Console.WriteLine("\n\n\tVAMOS EFETUAR A RESERVA DA SALA ");
                    Console.WriteLine("\n\tInicio da Reunião: " + dadosRecebidos.DataIni);
                    Console.Write("\n\tDigite a Data do Fim da Reunião e a Hora (dd/mm/yyyy 00:00:00): ");
                    dtFimString = Console.ReadLine();

                    codValidaDadosEntrada = dadosRecebidos.validaInformacoesEntrada(dtIniString, dtFimString);

                    switch (codValidaDadosEntrada)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n\t ***Favor verificar se a data é Válida e seu Formato!***");
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("\n\t ***A data/hora do Fim da Reunião deve ser maior que a do Inicio!***");
                            Console.ReadLine();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("\n\t ***Reuniões não podem durar mais que 8 horas!***");
                            Console.ReadLine();
                            break;
                    }
                } while (codValidaDadosEntrada != 0);

                //______________________________________________________________________Valida informações da sala

                do
                {
                    codValidaDadosEntrada = 0;
                    Console.Clear();
                    Console.WriteLine("\n\n\tVAMOS EFETUAR A RESERVA DA SALA ");
                    Console.WriteLine("\n\tInicio da Reunião: " + dadosRecebidos.DataIni);
                    Console.WriteLine("\n\tFim da Reunião: " + dadosRecebidos.DataFim);
                    Console.WriteLine("\n\tTempo de Reunião: " + dadosRecebidos.TempoReuniao);
                    Console.Write("\n\tPRecisa de Quantos Lugares na Sala: ");
                    axLugares = Console.ReadLine();
                    Console.Write("\n\tPRecisa de Internet (S/N): ");
                    axInternet = Console.ReadLine();
                    Console.Write("\n\tPRecisa de Computador (S/N): ");
                    axComputador = Console.ReadLine();
                    Console.Write("\n\tPRecisa de TV (S/N): ");
                    axTv = Console.ReadLine();
                    Console.Write("\n\tPRecisa de Webcam (S/N): ");
                    axWebcam = Console.ReadLine();

                    codValidaDadosEntrada = dadosRecebidos.verificaInformacoesSala(axLugares, axInternet, axComputador, axTv, axWebcam);

                    if (codValidaDadosEntrada == 7)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t ***Você digitou informações inválidas!***");
                        Console.ReadLine();
                    }

                } while (codValidaDadosEntrada != 0);

                codSala = verificaReserva.Reservar(dadosRecebidos.LugaresReserva, dadosRecebidos.InternetReserva, dadosRecebidos.ComputadorReserva, dadosRecebidos.TvReserva, dadosRecebidos.WebcamReserva);

                Console.WriteLine("\n\n Sugestão de Salas ");
                codSala.ToList().ForEach(i => Console.WriteLine(i.ToString()));
                Console.ReadLine();

                if (codSala != null)
                {
                    reservaNok = salasReservadas.VerificaReservaSala(codSala, dadosRecebidos.DataIni, dadosRecebidos.DataFim, dadosRecebidos.TempoReuniao);

                    if (reservaNok)
                        Console.WriteLine("\n\tSua Reserva Não pode ser Feita, pois não há salas Disponíveis Nesse Dia/Hora");
                    else
                        Console.WriteLine("\n\tSua Reserva Foi Realizada Com Sucesso");
                }
                else
                    Console.WriteLine("\n\tSua Reserva Não pode ser Feita, pois não há salas que atendam seus critérios.");



                Console.Write("\n\tPara sair informe 'S', ou para reservar mais 'enter': ");
                axSair = Console.ReadLine();
                Console.ReadKey();

            } while (axSair != "s");
        }//Main
    } //Program
}// ReservaSala