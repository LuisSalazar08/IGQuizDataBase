using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDGameQuiz
{
    internal class Pregunta
    {
        public string Enunciado { get; set; }
        public string[] Opciones { get; set; }
        public int Correcta { get; set; }
    }
}
