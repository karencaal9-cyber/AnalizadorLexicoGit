using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoGit.Lexer
{
    public class LectorArchivos
    {
        public HashSet<string> CargarPalabrasReservadas(string rutaArchivo)
        {
            HashSet<string> palabras = new HashSet<string>();

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string palabraLimpia = linea.Trim();
                    if (!string.IsNullOrEmpty(palabraLimpia))
                    {
                        palabras.Add(palabraLimpia);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"No se encontró el archivo de palabras reservadas en: {rutaArchivo}");
            }

            return palabras;
        }

        public List<string> CargarTiposTokens(string rutaArchivo)
        {
            List<string> tipos = new List<string>();

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string tipoLimpio = linea.Trim();
                    if (!string.IsNullOrEmpty(tipoLimpio))
                    {
                        tipos.Add(tipoLimpio);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"No se encontró el archivo de tipos de token en: {rutaArchivo}");
            }

            return tipos;
        }
    }
}
