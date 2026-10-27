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
        TK_PALABRA_RESERVADA,
        TK_NUM_ENTERO,
        TK_NUM_DECIMAL,
        TK_CADENA,
        TK_CARACTER,
        TK_OP_SUMA,
        TK_OP_RESTA,
        TK_OP_MULTI,
        TK_OP_DIVI,
        TK_OP_RESIDUO,
        TK_OP_INCREMENTO,
        TK_OP_DECREMENTO,
        TK_IGUALDAD,
        TK_DIFERENTE,
        TK_MENOR,
        TK_MAYOR, 
        TK_MENOR_IGUAL, 
        TK_MAYOR_IGUAL, 
        TK_AND, 
        TK_OR, 
        TK_NOT, 
        TK_ASIGNACION, 
        TK_SUMA_ASIGNACION,
        TK_RESTA_ASIGNACION,
        TK_MULT_ASIGNACION,
        TK_DIV_ASIGNACION,
        TK_PAR_IZQ,
        TK_PAR_DER,
        TK_LLAVE_IZQ,
        TK_LLAVE_DER,
        TK_CORCHETE_IZQ,
        TK_CORCHETE_DER,
        TK_PUNTO_COMA,
        TK_COMA,
        TK_PUNTO,
        TK_COMENTARIO_LINEA,
        TK_COMENTARIO_BLOQUE
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