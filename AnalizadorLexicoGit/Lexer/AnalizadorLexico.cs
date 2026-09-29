using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoGit.Lexer
{
    public class AnalizadorLexico
    {
        private readonly HashSet<string> palabrasReservadas =
        new HashSet<string>
        {
            "if",
            "else",
            "while",
            "do",
            "for",
            "continue",
            "switch",
            "case",
            "break",
            "float",
            "int",
            "double",
            "char",
            "bool",
            "string",
            "void",
            "return",
            "class",
            "static",
            "using",
            "namespace",
            "true",
            "false",
            "public",
            "private",
            "protected",
            "null"
        };

        private string _codigo;
        private int _posicion;
        private int _fila;
        private int _columna;

        public List<Token> Tokens { get; private set; }
        public List<ErrorLexico> Error { get; private set; }
        public TablaSimbolos TablaSimbolos { get; private set; }

        public AnalizadorLexico(string codigo)
        {
            _codigo = codigo;
            _posicion = 0;
            _fila = 1;
            _columna = 1;

            Tokens = new List<Token>();
            Error = new List<ErrorLexico>();
            TablaSimbolos = new TablaSimbolos();
        }

        public void Analizar()
        {
            while (_posicion < _codigo.Length)
            {
                char actual = _codigo[_posicion];

                if (char.IsWhiteSpace(actual))
                {
                    Avanzar();
                    continue;
                }
                if (char.IsLetter(actual) || actual == '_')
                {
                    ReconocerIdentificador();
                    continue;
                }
                if (char.IsDigit(actual))
                {
                    ReconocerNumero();
                    continue;
                }
                if (actual == '"')
                {
                    ReconocerCadena();
                    continue;
                }

                if (actual == '\'')
                {
                    ReconocerCaracter();
                    continue;
                }

                if (actual == '+' ||
                    actual == '-' ||
                    actual == '*' ||
                    actual == '/' ||
                    actual == '%')
                {
                    ReconocerOperadorAritmetico();
                    continue;
                }

                if (actual == '=' ||
                    actual == '!' ||
                    actual == '<' ||
                    actual == '>' ||
                    actual == '&' ||
                    actual == '|')
                {
                    ReconocerOperadorRelacionalLogico();
                    continue;
                }

                if (actual == '(' ||
                    actual == ')' ||
                    actual == '{' ||
                    actual == '}' ||
                    actual == '[' ||
                    actual == ']' ||
                    actual == ';' ||
                    actual == ',' ||
                    actual == '.')
                {
                    ReconocerDelimitador();
                    continue;
                }

                Error.Add(new ErrorLexico(
                    actual.ToString(),
                    "Carácter no reconocido.",
                    _fila,
                    _columna
                ));


                Avanzar();
            }
        }

        private void Avanzar()
        {
            if (_codigo[_posicion] == '\n')
            {
                _fila++;
                _columna = 1;
            }
            else
            {
                _columna++;
            }

            _posicion++;
        }

        private void ReconocerIdentificador()
        {
            int filaInicio = _fila;
            int columnaInicio = _columna;
            int inicio = _posicion;

            while (_posicion < _codigo.Length)
            {
                char actual = _codigo[_posicion];
                if (char.IsLetterOrDigit(actual) || actual == '_')
                {
                    Avanzar();
                }
                else
                {
                    break;
                }
            }

            string lexema = _codigo.Substring(inicio, _posicion - inicio);

            if (palabrasReservadas.Contains(lexema))
            {
                Tokens.Add(new Token(
                    TipoToken.TK_PALABRA_RESERVADA,
                    lexema,
                    "Palabra reservada",
                    filaInicio,
                    columnaInicio
                ));
            }
            else
            {
                Tokens.Add(new Token(
                    TipoToken.TK_ID,
                    lexema,
                    "Identificador",
                    filaInicio,
                    columnaInicio
                ));

                TablaSimbolos.Agregar(lexema, filaInicio);
            }
        }

        private void ReconocerNumero()
        {
            int filaInicio = _fila;
            int columnaInicio = _columna;
            int inicio = _posicion;
            bool tienePunto = false;

            while (_posicion < _codigo.Length)
            {
                char actual = _codigo[_posicion];

                if (char.IsDigit(actual))
                {
                    Avanzar();
                }
                else if (actual == '.' && !tienePunto)
                {
                    tienePunto = true;
                    Avanzar();
                }
                else
                {
                    break;
                }
            }

            string lexema = _codigo.Substring(inicio, _posicion - inicio);

            TipoToken tipo;

            if (tienePunto)
            {
                tipo = TipoToken.TK_NUM_DECIMAL;
            }
            else
            {
                tipo = TipoToken.TK_NUM_ENTERO;
            }

            Tokens.Add(new Token(
                tipo,
                lexema,
                tienePunto ? "Número decimal" : "Número entero",
                filaInicio,
                columnaInicio
            ));
        }

        private void ReconocerCadena()
        {
            int filaInicio = _fila;
            int columnaInicio = _columna;
            int inicio = _posicion;

            Avanzar();

            while (_posicion < _codigo.Length)
            {
                char actual = _codigo[_posicion];

                if (actual == '"')
                {
                    Avanzar();

                    string lexema = _codigo.Substring(
                        inicio,
                        _posicion - inicio
                    );

                    Tokens.Add(new Token(
                        TipoToken.TK_CADENA,
                        lexema,
                        "Cadena de caracteres",
                        filaInicio,
                        columnaInicio
                    ));

                    return;
                }

                if (actual == '\n')
                {
                    Error.Add(new ErrorLexico(
                        _codigo.Substring(inicio, _posicion - inicio),
                        "Cadena de caracter sin cerrar.",
                        filaInicio,
                        columnaInicio
                    ));

                    return;
                }
                Avanzar();
            }

            Error.Add(new ErrorLexico(
                _codigo.Substring(inicio, _posicion - inicio),
                "Cadena de caracteres sin cerrar.",
                filaInicio,
                columnaInicio
            ));
        }

        private void ReconocerCaracter()
        {
            int filaInicio = _fila;
            int columnaInicio = _columna;
            int inicio = _posicion;

            Avanzar();

            if (_posicion < _codigo.Length)
            {
                if (_codigo[_posicion] == '\n')
                {
                    Error.Add(new ErrorLexico(
                        _codigo.Substring(inicio, _posicion - inicio),
                        "Carácter literal sin cerrar.",
                        filaInicio,
                        columnaInicio
                    ));

                    return;
                }

                Avanzar();
            }

            if (_posicion < _codigo.Length && _codigo[_posicion] == '\'')
            {
                Avanzar();

                string lexema = _codigo.Substring(
                    inicio,
                    _posicion - inicio
                );

                Tokens.Add(new Token(
                    TipoToken.TK_CARACTER,
                    lexema,
                    "Carácter literal",
                    filaInicio,
                    columnaInicio
                ));

                return;
            }

            Error.Add(new ErrorLexico(
                _codigo.Substring(inicio, _posicion - inicio),
                "Carácter literal inválido o sin cerrar.",
                filaInicio,
                columnaInicio
            ));
        }

        private void ReconocerOperadorAritmetico()
        {
            int filaInicio = _fila;
            int columnaInicio = _columna;

            char actual = _codigo[_posicion];

            switch (actual)
            {
                case '+':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '+')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_OP_INCREMENTO,
                            "++",
                            "Incremento",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_SUMA_ASIGNACION,
                            "+=",
                            "Suma y asignación",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_OP_SUMA,
                            "+",
                            "Suma",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;

                case '-':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '-')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_OP_DECREMENTO,
                            "--",
                            "Decremento",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_RESTA_ASIGNACION,
                            "-=",
                            "Resta y asignación",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_OP_RESTA,
                            "-",
                            "Resta",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;


                case '*':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_MULT_ASIGNACION,
                            "*=",
                            "Multiplicación y asignación",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_OP_MULTI,
                            "*",
                            "Multiplicación",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;

                case '/':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '/')
                    {
                        Avanzar();

                        int inicioComentario = _posicion - 2;

                        while (_posicion < _codigo.Length && _codigo[_posicion] != '\n')
                        {
                            Avanzar();
                        }

                        string lexema = _codigo.Substring(
                            inicioComentario,
                            _posicion - inicioComentario
                        );

                        Tokens.Add(new Token(
                            TipoToken.TK_COMENTARIO_LINEA,
                            lexema,
                            "Comentario de línea",
                            filaInicio,
                            columnaInicio
                        ));
                    }

                    else if (_posicion < _codigo.Length && _codigo[_posicion] == '*')
                    {
                        Avanzar();

                        int inicioComentario = _posicion - 2;
                        bool cerrado = false;

                        while (_posicion < _codigo.Length)
                        {
                            if (_codigo[_posicion] == '*' &&
                                _posicion + 1 < _codigo.Length &&
                                _codigo[_posicion + 1] == '/')
                            {
                                Avanzar();
                                Avanzar();

                                cerrado = true;
                                break;
                            }

                            Avanzar();
                        }

                        string lexema = _codigo.Substring(
                            inicioComentario,
                            _posicion - inicioComentario
                        );

                        if (cerrado)
                        {
                            Tokens.Add(new Token(
                                TipoToken.TK_COMENTARIO_BLOQUE,
                                lexema,
                                "Comentario de bloque",
                                filaInicio,
                                columnaInicio
                            ));
                        }
                        else
                        {
                            Error.Add(new ErrorLexico(
                                lexema,
                                "Comentario de bloque sin cerrar.",
                                filaInicio,
                                columnaInicio
                            ));
                        }
                    }

                    else if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_DIV_ASIGNACION,
                            "/=",
                            "División y asignación",
                            filaInicio,
                            columnaInicio
                        ));
                    }

                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_OP_DIVI,
                            "/",
                            "División",
                            filaInicio,
                            columnaInicio
                        ));
                    }

                    break;


                case '%':
                    Avanzar();

                    Tokens.Add(new Token(
                        TipoToken.TK_OP_RESIDUO,
                        "%",
                        "Residuo",
                        filaInicio,
                        columnaInicio
                    ));
                    break;
            }
        }

        private void ReconocerOperadorRelacionalLogico()
        {
            int filaInicio = _fila;
            int columnaInicio = _columna;

            char actual = _codigo[_posicion];

            switch (actual)
            {
                case '=':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_IGUALDAD,
                            "==",
                            "Igualdad",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_ASIGNACION,
                            "=",
                            "Asignación",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;

                case '!':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_DIFERENTE,
                            "!=",
                            "Diferente",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_NOT,
                            "!",
                            "NOT",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;

                case '<':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_MENOR_IGUAL,
                            "<=",
                            "Menor o igual",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_MENOR,
                            "<",
                            "Menor que",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;

                case '>':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '=')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_MAYOR_IGUAL,
                            ">=",
                            "Mayor o igual",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Tokens.Add(new Token(
                            TipoToken.TK_MAYOR,
                            ">",
                            "Mayor que",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;

                case '&':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '&')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_AND,
                            "&&",
                            "AND",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Error.Add(new ErrorLexico(
                            "&",
                            "Operador '&' incompleto. Se esperaba '&'.",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;

                case '|':
                    Avanzar();

                    if (_posicion < _codigo.Length && _codigo[_posicion] == '|')
                    {
                        Avanzar();

                        Tokens.Add(new Token(
                            TipoToken.TK_OR,
                            "||",
                            "OR",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    else
                    {
                        Error.Add(new ErrorLexico(
                            "|",
                            "Operador '|' incompleto. Se esperaba '|'.",
                            filaInicio,
                            columnaInicio
                        ));
                    }
                    break;
            }
        }

        private void ReconocerDelimitador()
        {
            int filaInicio = _fila;
            int columnaInicio = _columna;

            char actual = _codigo[_posicion];

            TipoToken tipo;
            string lexema = actual.ToString();
            string patron;

            switch (actual)
            {
                case '(':
                    tipo = TipoToken.TK_PAR_IZQ;
                    patron = "Paréntesis izquierdo";
                    break;

                case ')':
                    tipo = TipoToken.TK_PAR_DER;
                    patron = "Paréntesis derecho";
                    break;

                case '{':
                    tipo = TipoToken.TK_LLAVE_IZQ;
                    patron = "Llave izquierda";
                    break;

                case '}':
                    tipo = TipoToken.TK_LLAVE_DER;
                    patron = "Llave derecha";
                    break;

                case '[':
                    tipo = TipoToken.TK_CORCHETE_IZQ;
                    patron = "Corchete izquierdo";
                    break;

                case ']':
                    tipo = TipoToken.TK_CORCHETE_DER;
                    patron = "Corchete derecho";
                    break;

                case ';':
                    tipo = TipoToken.TK_PUNTO_COMA;
                    patron = "Punto y coma";
                    break;

                case ',':
                    tipo = TipoToken.TK_COMA;
                    patron = "Coma";
                    break;

                case '.':
                    tipo = TipoToken.TK_PUNTO;
                    patron = "Punto";
                    break;

                default:
                    return;
            }

            Avanzar();

            Tokens.Add(new Token(
                tipo,
                lexema,
                patron,
                filaInicio,
                columnaInicio
            ));
        }


    }
}
