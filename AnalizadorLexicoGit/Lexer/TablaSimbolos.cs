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

        // Agregar identificador
        public void Agregar(string nombre, int fila)
        {
            Agregar(nombre, "No especificado", fila, 1);
        }

        // Agregar símbolo
        public void Agregar(string nombre, string tipo, int fila, int columna)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return;

            if (Buscar(nombre) != null)
                return;

            Simbolos.Add(new Simbolo(nombre, tipo, fila, columna));
        }

        // Consultar todos los símbolos
        public List<Simbolo> ObtenerSimbolos()
        {
            return Simbolos;
        }

        // Buscar símbolo por nombre
        public Simbolo Buscar(string nombre)
        {
            return Simbolos.FirstOrDefault(
                s => s.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
            );
        }

        public bool Modificar(string nombreAnterior, string nuevoNombre, string nuevoTipo)
        {
            Simbolo simbolo = Buscar(nombreAnterior);

            if (simbolo == null || string.IsNullOrWhiteSpace(nuevoNombre))
                return false;

            Simbolo existente = Buscar(nuevoNombre);

            if (existente != null && existente != simbolo)
                return false;

            simbolo.Nombre = nuevoNombre;
            simbolo.Tipo = nuevoTipo;

            return true;
        }

        public bool Eliminar(string nombre)
        {
            Simbolo simbolo = Buscar(nombre);

            if (simbolo == null)
                return false;

            Simbolos.Remove(simbolo);
            return true;
        }

        public void Limpiar()
        {
            Simbolos.Clear();
        }
    }
}
