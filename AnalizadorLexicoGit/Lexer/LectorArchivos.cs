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
            if (!File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException(
                    $"No se encontró el archivo de palabras reservadas en: {rutaArchivo}");
            }

            HashSet<string> palabras = new HashSet<string>(
                StringComparer.OrdinalIgnoreCase
            );

            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                string palabra = linea.Trim();

                if (!string.IsNullOrEmpty(palabra))
                    palabras.Add(palabra);
            }

            return palabras;
        }

        public void GuardarPalabrasReservadas(
            string rutaArchivo, IEnumerable<string> palabras)
        {
            if (palabras == null)
                throw new ArgumentNullException(nameof(palabras));

            File.WriteAllLines(
                rutaArchivo,
                palabras.OrderBy(p => p),
                System.Text.Encoding.UTF8
            );
        }

        public List<string> CargarTiposTokens(string rutaArchivo)
        {
            List<string> tipos = new List<string>();

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);

                foreach (string linea in lineas)
                {
                    string tipo = linea.Trim();

                    if (!string.IsNullOrEmpty(tipo))
                        tipos.Add(tipo);
                }
            }
            else
            {
                throw new FileNotFoundException(
                    $"No se encontró el archivo de tipos de token en: {rutaArchivo}");
            }

            return tipos;
        }
    }
}
