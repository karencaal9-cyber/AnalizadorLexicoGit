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
        public string Tipo { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }

        public Simbolo(string nombre, int fila)
        {
            Nombre = nombre;
            Tipo = "No especificado";
            Fila = fila;
            Columna = 1;
        }

        public Simbolo(string nombre, string tipo, int fila, int columna)
        {
            Nombre = nombre;
            Tipo = tipo;
            Fila = fila;
            Columna = columna;
        }
    }
}
