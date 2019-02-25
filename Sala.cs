using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{

    class Sala
    {
        private int codigo;
        private int lugares;
        private bool internet;
        private bool computador;
        private bool tv;
        private bool webcam;

        public int Codigo { get => codigo; set => codigo = value; }
        public int Lugares { get => lugares; set => lugares = value; }
        public bool Internet { get => internet; set => internet = value; }
        public bool Tv { get => tv; set => tv = value; }
        public bool Webcam { get => webcam; set => webcam = value; }
        public bool Computador { get => computador; set => computador = value; }
    }
}