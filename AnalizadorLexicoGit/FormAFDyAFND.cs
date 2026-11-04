using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexicoGit
{
    public partial class FormAFDyAFND : Form
    {
        public FormAFDyAFND()
        {
            InitializeComponent();
        }

        private void btnTabla_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCantEstados.Text, out int nEstados) || nEstados <= 0)
                {
                    MessageBox.Show("Ingresa una cantidad de estados válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] alfabeto = txtVariables.Text.Split(',');
                string tipoAutomata = cmbTipoAutomata.SelectedItem?.ToString() ?? "";
                bool esAfnd = tipoAutomata.ToUpper().Contains("AFND");

                dgvTransiciones.Columns.Clear();
                dgvTransiciones.Rows.Clear();

                dgvTransiciones.Columns.Add("Estado", "Estado");

                foreach (var simbolo in alfabeto)
                {
                    string simboloLimpio = simbolo.Trim();
                    if (!string.IsNullOrEmpty(simboloLimpio))
                    {
                        dgvTransiciones.Columns.Add(simboloLimpio, simboloLimpio);
                    }
                }

                if (esAfnd && !dgvTransiciones.Columns.Contains("ε"))
                {
                    dgvTransiciones.Columns.Add("ε", "ε");
                }

                string estadoInicial = cmbInicial.SelectedItem?.ToString() ?? "";

                for (int i = 0; i < nEstados; i++)
                {
                    string nombreEstadoBase = $"q{i}";
                    string etiquetaEstado = nombreEstadoBase;

                    if (nombreEstadoBase == estadoInicial)
                    {
                        etiquetaEstado = "-> " + etiquetaEstado;
                    }

                    bool esFinal = false;
                    foreach (var itemChecked in chcAceptacion.CheckedItems)
                    {
                        if (itemChecked.ToString() == nombreEstadoBase)
                        {
                            esFinal = true;
                            break;
                        }
                    }

                    if (esFinal)
                    {
                        etiquetaEstado = "* " + etiquetaEstado;
                    }

                    dgvTransiciones.Rows.Add(etiquetaEstado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantEstados_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantEstados.Text, out int nEstados) && nEstados > 0)
            {
                cmbInicial.Items.Clear();
                chcAceptacion.Items.Clear();

                for (int i = 0; i < nEstados; i++)
                {
                    string nombreEstado = $"q{i}";
                    cmbInicial.Items.Add(nombreEstado);
                    chcAceptacion.Items.Add(nombreEstado);
                }

                if (cmbInicial.Items.Count > 0)
                    cmbInicial.SelectedIndex = 0;
            }
        }

        private void btnProbarCadena_Click(object sender, EventArgs e)
        {
            string cadena = txtCadenaPrueba.Text.Trim();
            string tipoAutomata = cmbTipoAutomata.SelectedItem?.ToString() ?? "";
            bool esAfnd = tipoAutomata.ToUpper().Contains("AFND");

            string estadoInicialStr = cmbInicial.SelectedItem?.ToString().Replace("->", "").Trim() ?? "";

            if (string.IsNullOrEmpty(estadoInicialStr))
            {
                MessageBox.Show("Por favor selecciona un estado inicial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HashSet<string> estadosActuales = new HashSet<string> { estadoInicialStr };

            if (esAfnd)
            {
                estadosActuales = ObtenerEpsilonClosure(estadosActuales);
            }

            foreach (char simbolo in cadena)
            {
                string simboloStr = simbolo.ToString();
                HashSet<string> siguientesEstados = new HashSet<string>();

                foreach (string estadoActual in estadosActuales)
                {
                    foreach (DataGridViewRow row in dgvTransiciones.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string estadoFila = row.Cells["Estado"].Value.ToString().Replace("->", "").Replace("*", "").Trim();

                        if (estadoFila == estadoActual)
                        {
                            if (dgvTransiciones.Columns.Contains(simboloStr))
                            {
                                string valorCelda = row.Cells[simboloStr].Value?.ToString();
                                if (!string.IsNullOrEmpty(valorCelda))
                                {
                                    string[] destinos = valorCelda.Split(',');
                                    foreach (string destino in destinos)
                                    {
                                        string destLimpio = destino.Trim();
                                        if (!string.IsNullOrEmpty(destLimpio))
                                        {
                                            siguientesEstados.Add(destLimpio);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                estadosActuales = siguientesEstados;

                if (esAfnd && estadosActuales.Count > 0)
                {
                    estadosActuales = ObtenerEpsilonClosure(estadosActuales);
                }

                if (estadosActuales.Count == 0)
                {
                    break; 
                }
            }
            bool esAceptado = false;
            foreach (string estado in estadosActuales)
            {
                foreach (var itemChecked in chcAceptacion.CheckedItems)
                {
                    string estadoFinalConfigurado = itemChecked.ToString().Replace("*", "").Trim();
                    if (estadoFinalConfigurado == estado)
                    {
                        esAceptado = true;
                        break;
                    }
                }
                if (esAceptado) break;
            }

            string estadosFinalesStr = string.Join(", ", estadosActuales);

            if (esAceptado)
            {
                MessageBox.Show($"¡Cadena ACEPTADA! 🚀\nEl recorrido finalizó en los estados: [{estadosFinalesStr}], incluyendo al menos un estado de aceptación.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Cadena RECHAZADA ❌.\nEl recorrido finalizó en los estados: [{estadosFinalesStr}], ninguno es estado final o no hay transiciones válidas.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private HashSet<string> ObtenerEpsilonClosure(HashSet<string> estados)
        {
            if (!dgvTransiciones.Columns.Contains("ε")) return estados;

            HashSet<string> closure = new HashSet<string>(estados);
            Stack<string> pila = new Stack<string>(estados);

            while (pila.Count > 0)
            {
                string estadoActual = pila.Pop();

                foreach (DataGridViewRow row in dgvTransiciones.Rows)
                {
                    if (row.IsNewRow) continue;
                    string estadoFila = row.Cells["Estado"].Value.ToString().Replace("->", "").Replace("*", "").Trim();

                    if (estadoFila == estadoActual)
                    {
                        string valorCelda = row.Cells["ε"].Value?.ToString();
                        if (!string.IsNullOrEmpty(valorCelda))
                        {
                            string[] destinos = valorCelda.Split(',');
                            foreach (string destino in destinos)
                            {
                                string destLimpio = destino.Trim();
                                if (!string.IsNullOrEmpty(destLimpio) && !closure.Contains(destLimpio))
                                {
                                    closure.Add(destLimpio);
                                    pila.Push(destLimpio);
                                }
                            }
                        }
                    }
                }
            }

            return closure;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantEstados.Clear();
            txtVariables.Clear();

            cmbTipoAutomata.SelectedIndex = -1; 
            cmbInicial.Items.Clear();           

            chcAceptacion.Items.Clear();

            dgvTransiciones.Columns.Clear();
            dgvTransiciones.Rows.Clear();

            txtCadenaPrueba.Clear();
            txtCantEstados.Focus();
        }
    }
}
