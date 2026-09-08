using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoGit.Lexer
{

    internal class ErrorLexico
    {

            public string LexemaError { get; set; }
            public string Descripcion { get; set; }
            public int Fila { get; set; }
            public int Columna { get; set; }

            public ErrorLexico(string lexemaError, string descripcion, int fila, int columna)
            {
                LexemaError = lexemaError;
                Descripcion = descripcion;
                Fila = fila;
                Columna = columna;
            }
        }
    }

