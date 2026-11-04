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
            string estadoActual = cmbInicial.SelectedItem?.ToString();

            estadoActual = estadoActual.Replace("->", "").Trim();

            foreach (char simbolo in cadena)
            {
                string simboloStr = simbolo.ToString();
                bool transicionEncontrada = false;

                foreach (DataGridViewRow row in dgvTransiciones.Rows)
                {
                    if (row.IsNewRow) continue;

                    string estadoFila = row.Cells["Estado"].Value.ToString().Replace("->", "").Replace("*", "").Trim();

                    if (estadoFila == estadoActual)
                    {
                        if (dgvTransiciones.Columns.Contains(simboloStr))
                        {
                            string siguienteEstado = row.Cells[simboloStr].Value?.ToString();

                            if (!string.IsNullOrEmpty(siguienteEstado))
                            {
                                estadoActual = siguienteEstado.Trim();
                                transicionEncontrada = true;
                                break; 
                            }
                        }
                    }
                }

                if (!transicionEncontrada)
                {
                    MessageBox.Show($"Cadena RECHAZADA ❌. El símbolo '{simboloStr}' no tiene transición válida desde el estado {estadoActual}.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            bool esAceptado = false;
            foreach (var itemChecked in chcAceptacion.CheckedItems)
            {
                string estadoFinalConfigurado = itemChecked.ToString().Replace("*", "").Trim();
                if (estadoFinalConfigurado == estadoActual)
                {
                    esAceptado = true;
                    break;
                }
            }

            if (esAceptado)
            {
                MessageBox.Show($"¡Cadena ACEPTADA! El recorrido finalizó en el estado de aceptación [{estadoActual}].", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Cadena RECHAZADA. El recorrido finalizó en [{estadoActual}], el cual no es un estado final.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
