using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoGit.Lexer
{
    public class TablaSimbolos
    {
        public List<Simbolo> Simbolos { get; private set; }

        public TablaSimbolos()
        {
            Simbolos = new List<Simbolo>();
        }

        public void Agregar(string nombre, int fila)
        {
            foreach (Simbolo simbolo in Simbolos)
            {
                if (simbolo.Nombre == nombre)
                {
                    return;
                }
            }

            Simbolos.Add(new Simbolo(nombre, fila));
        }

        public List<Simbolo> ObtenerSimbolos()
        {
            return Simbolos;
        }
    }
}
