using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Program
{
    class ValidDadosEntrada
    {
        private DateTime dataIni;
        private DateTime dataFim;
        private int lugaresReserva;
        private bool internetReserva;
        private bool computadorReserva;
        private bool tvReserva;
        private bool webcamReserva;
        private int tempoReuniao;

        public int LugaresReserva { get => lugaresReserva; set => lugaresReserva = value; }
        public bool InternetReserva { get => internetReserva; set => internetReserva = value; }
        public bool ComputadorReserva { get => computadorReserva; set => computadorReserva = value; }
        public bool TvReserva { get => tvReserva; set => tvReserva = value; }
        public bool WebcamReserva { get => webcamReserva; set => webcamReserva = value; }
        public DateTime DataIni { get => dataIni; set => dataIni = value; }
        public DateTime DataFim { get => dataFim; set => dataFim = value; }
        public int TempoReuniao { get => tempoReuniao; set => tempoReuniao = value; }

        public int validaInformacoesEntrada(string dtIniString, string dtFimString)
        {

            bool dataOk = false;
            bool dadosOk = false;
            int codRetorno = 0;
            string diaSemana = null;
            //Feriados_Nacionais objFeriado = new Feriados_Nacionais();

            if (dtFimString == " " || dtFimString == null)
            {

                dataOk = verificaFormatoData(dtIniString); // Valida formato de Data e Hora
                if (dataOk)
                {
                    this.DataIni = Convert.ToDateTime(dtIniString);
                    dadosOk = verificaDiaAnterior(); // Valida dados Recebidos para Efetuar a reserva

                    if (dadosOk)
                    {
                        dadosOk = verificaDiaApos(); // Valida dados Recebidos para Efetuar a reserva
                        if (dadosOk)
                        {
                            diaSemana = DataIni.DayOfWeek.ToString();
                            if (diaSemana == "Saturday" || diaSemana == "Sunday")
                            {
                                codRetorno = 4;
                            }
                        }
                        else
                            codRetorno = 3;
                    }
                    else
                        codRetorno = 2;
                }
                else
                    codRetorno = 1;
            }
            else //_______________________________________________ Valida data Fim
            {

                dataOk = verificaFormatoData(dtFimString); // Valida formato de Data e Hora
                if (dataOk)
                {
                    this.DataFim = Convert.ToDateTime(dtFimString);
                    dadosOk = verificaDataFim();
                    if (dadosOk)
                    {
                        dadosOk = verificaTempoReuniao();
                        if (!dadosOk)
                            codRetorno = 6;
                    }
                    else
                        codRetorno = 5;
                }
                else
                    codRetorno = 1;
            }
            return codRetorno;
        }


        public bool verificaDiaAnterior()
        {
            DateTime dataAtual = DateTime.Now;
            bool solicitacaoOk = false;
            int result = DateTime.Compare(this.DataIni, dataAtual);

            if (result > 0)
                solicitacaoOk = true;

            return solicitacaoOk;
        }

        public bool verificaDiaApos()
        {
            DateTime dataAtual = DateTime.Now;
            bool solicitacaoOk = false;
            TimeSpan diferenca = this.DataIni.Subtract(dataAtual);
            int diferencaDias = diferenca.Days;

            if (diferencaDias < 40)
                solicitacaoOk = true;

            return solicitacaoOk;
        }

        public bool verificaFormatoData(string dataHora)
        {
            bool dataOk = false;
            DateTime dataValida;
            Regex r = new Regex(@"(\d{2}\/\d{2}\/\d{4} \d{2}:\d{2}:\d{2})");
            dataOk = r.Match(dataHora).Success;
            if (dataOk)
            {
                if (!DateTime.TryParse(dataHora, out dataValida))
                    dataOk = false;
            }
            return dataOk;
        }

        public bool verificaDataFim()
        {
            bool tempoOk = false;
            if (this.DataFim > this.DataIni)
                tempoOk = true;

            return tempoOk;
        }

        public bool verificaTempoReuniao()
        {
            bool tempoOk = false;
            TimeSpan tempoOitoHoras = TimeSpan.Parse("08:00:00");
            TimeSpan diferenca = this.DataIni.Subtract(this.DataFim);

            int diferencaDias = diferenca.Hours;
            diferencaDias = Math.Abs(diferencaDias);
            int totalMaximoHoras = tempoOitoHoras.Hours;
            TempoReuniao = diferencaDias;

            if (diferencaDias <= totalMaximoHoras)
                tempoOk = true;

            return tempoOk;
        }

        public int verificaInformacoesSala(string axLugares, string axInternet, string axComputador, string axTv, string axWebcam)
        {
            int codigoRetorno = 0;
            axInternet = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(axInternet);
            axTv = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(axTv);
            axWebcam = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(axWebcam);
            axComputador = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(axComputador);

            try
            {
                lugaresReserva = Convert.ToInt32(axLugares);
            }
            catch (FormatException)
            {
                codigoRetorno = 7;
            }

            if (codigoRetorno == 0)
            {
                switch (axInternet)
                {
                    case "N":
                        internetReserva = false;
                        break;
                    case "S":
                        internetReserva = true;
                        break;
                    default:
                        codigoRetorno = 7;
                        break;
                }
            }

            if (codigoRetorno == 0)
            {
                switch (axComputador)
                {
                    case "N":
                        ComputadorReserva = false;
                        break;
                    case "S":
                        ComputadorReserva = true;
                        break;
                    default:
                        codigoRetorno = 7;
                        break;
                }
            }

            if (codigoRetorno == 0)
            {
                switch (axTv)
                {
                    case "N":
                        tvReserva = false;
                        break;
                    case "S":
                        tvReserva = true;
                        break;
                    default:
                        codigoRetorno = 7;
                        break;
                }
            }

            if (codigoRetorno == 0)
            {
                switch (axWebcam)
                {
                    case "N":
                        webcamReserva = false;
                        break;
                    case "S":
                        webcamReserva = true;
                        break;
                    default:
                        codigoRetorno = 7;
                        break;
                }
            }

            return codigoRetorno;
        }
    }
}