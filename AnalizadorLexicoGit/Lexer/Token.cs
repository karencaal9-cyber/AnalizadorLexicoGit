using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoGit.Lexer
{
    public enum TipoToken
    {
        TK_ID,
        TK_NUM_ENTERO,
        TK_NUM_DECIMAL,
        TK_CADENA,
        TK_CARACTER,
        TK_OP_SUMA,
        TK_OP_RESTA,
        TK_OP_MULTI,
        TK_OP_DIVI,
        TK_ASIGNACION,
        TK_PUNTO_COMA,
        TK_PAR_IZQ,
        TK_PAR_DER,
        TK_LLAVE_IZQ,
        TK_LLAVE_DER
    }

    public class Token
    {
        public TipoToken Tipo { get; set; }
        public string Lexema { get; set; }
        public string PatronRegex { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }

        public Token(TipoToken tipo, string lexema, string patronRegex, int fila, int columna)
        {
            Tipo = tipo;
            Lexema = lexema;
            PatronRegex = patronRegex;
            Fila = fila;
            Columna = columna;
        }
    }
}
internal class Token
    {
}
