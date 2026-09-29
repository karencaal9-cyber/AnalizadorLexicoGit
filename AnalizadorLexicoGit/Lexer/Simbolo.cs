using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoGit.Lexer
{
    public class Simbolo
    {
        public string Nombre { get; set; }
        public int Fila { get; set; }

        public Simbolo(string nombre, int fila)
        {
            Nombre = nombre;
            Fila = fila;
        }
    }
}
