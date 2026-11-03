using AnalizadorLexicoGit.GitService;
using AnalizadorLexicoGit.Lexer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace AnalizadorLexicoGit
{
    public partial class Form1 : Form
    {
        private AnalizadorLexico analizador;
        private HashSet<string> palabrasReservadas;
        private LectorArchivos lectorArchivos;
        private string rutaPalabras;
        private List<string> tiposTokens;
        private List<string> erroresConfig;

        private ControladorGit _gitControlador;
        public Form1()
        {
            InitializeComponent();
            ConfigurarTablaSimbolos();
            _gitControlador = new ControladorGit(AppDomain.CurrentDomain.BaseDirectory);

            btnAgregarPalabra.Click += btnAgregarPalabra_Click;
            btnModificarPalabra.Click += btnModificarPalabra_Click;
            btnEliminarPalabra.Click += btnEliminarPalabra_Click;
            dgvPalabras.CellClick += dgvPalabras_CellClick;
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                lectorArchivos = new LectorArchivos();

                rutaPalabras = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "palabras_reservadas.txt"
                );

                string rutaTipos = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "tipo_token.txt"
                );

                palabrasReservadas =
                    lectorArchivos.CargarPalabrasReservadas(rutaPalabras);

                tiposTokens =
                    lectorArchivos.CargarTiposTokens(rutaTipos);

                ConfigurarTablaDiccionario();
                CargarDiccionario();

                MessageBox.Show(
                    "Diccionario y archivos de configuración cargados correctamente.",
                    "Éxito"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los archivos: " + ex.Message,
                    "Error crítico"
                );
            }
        }


        private void CargarDiccionario()
        {
            dgvPalabras.Rows.Clear();

            foreach (string palabra in palabrasReservadas.OrderBy(p => p))
            {
                dgvPalabras.Rows.Add(palabra);
            }
        }


        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de texto (*.txt)|*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtEditorCodigo.Text = File.ReadAllText(dialog.FileName);
            }
        }
        private void ConfigurarTablaDiccionario()
        {
            dgvPalabras.Columns.Clear();

            dgvPalabras.AllowUserToAddRows = false;
            dgvPalabras.ReadOnly = true;
            dgvPalabras.MultiSelect = false;
            dgvPalabras.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPalabras.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPalabras.RowHeadersVisible = false;

            dgvPalabras.Columns.Add(
                "Palabra",
                "Palabra reservada"
            );
        }

        private void ConfigurarTablaSimbolos()
        {
            dgvSimbolos.Columns.Clear();

            dgvSimbolos.AllowUserToAddRows = false;
            dgvSimbolos.ReadOnly = true;

            dgvSimbolos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvSimbolos.Columns.Add("Nombre", "Identificador");
            dgvSimbolos.Columns.Add("Tipo", "Tipo");
            dgvSimbolos.Columns.Add("Fila", "Primera fila");
            dgvSimbolos.Columns.Add("Columna", "Primera columna");
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            dgvTokens.Rows.Clear();
            dgvSimbolos.Rows.Clear();
            txtConsola.Clear();

            string codigo = txtEditorCodigo.Text;

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Por favor ingrese o cargue código fuente.", "Advertencia");
                return;
            }

            analizador = new AnalizadorLexico(codigo, palabrasReservadas);

            analizador.Analizar();


            foreach (Token token in analizador.Tokens)
            {
                dgvTokens.Rows.Add(
                    token.Tipo.ToString(),
                    token.Lexema,
                    token.PatronRegex,
                    token.Fila,
                    token.Columna
                );
            }

            foreach (Simbolo simbolo in
         analizador.TablaSimbolos.ObtenerSimbolos())
            {
                dgvSimbolos.Rows.Add(
                    simbolo.Nombre,
                    simbolo.Tipo,
                    simbolo.Fila,
                    simbolo.Columna
                );
            }

            if (analizador.Error.Count > 0)
            {
                txtConsola.AppendText(
                    "[CONSOLA]: Se encontraron " +
                    analizador.Error.Count +
                    " error(es) léxico(s).\r\n"
                );

                foreach (ErrorLexico error in analizador.Error)
                {
                    txtConsola.AppendText(
                        "Línea " + error.Fila +
                        ", Columna " + error.Columna +
                        ": " + error.Descripcion +
                        " Lexema: " + error.LexemaError +
                        "\r\n"
                    );
                }
            }
            else
            {
                txtConsola.AppendText(
                    "[CONSOLA]: Análisis léxico finalizado exitosamente.\r\n"
                );
            }


            MostrarPanelEstadisticas(analizador);
           
        }

        private void MostrarPanelEstadisticas(AnalizadorLexico analizador)
        {
            if (analizador == null) return;

            int totalTokensP = analizador.Tokens.Count;
            int totalErroresP = analizador.Error.Count;
            int totalLineasP = txtEditorCodigo.Lines.Length; // O la forma en que calcules las líneas

            lblTotalTokensP.Text = $"Tokens Válidos: {totalTokensP}";
            lblTotalLineasP.Text = $"Líneas Totales: {totalLineasP}";
            lblTotalErroresP.Text = $"Errores Léxicos: {totalErroresP}";
            lblTiempoP.Text = $"Tiempo de Análisis: {analizador.TiempoAnalisisMs} ms";
        }


        private void txtMensajeCommit_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTokens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtConsola_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEditorCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvTokens.Rows.Count == 0)
            {
                MessageBox.Show("No hay tokens para exportar.", "Advertencia");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Reporte de tokens con estilo";
            saveFileDialog.FileName = "ReporteTokens.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Tokens");

                        for (int i = 0; i < dgvTokens.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvTokens.Columns[i].HeaderText;
                        }

                        var headerRow = worksheet.Row(1);
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

                        int rowIndex = 2;
                        foreach (DataGridViewRow row in dgvTokens.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int j = 0; j < dgvTokens.Columns.Count; j++)
                            {
                                worksheet.Cell(rowIndex, j + 1).Value = row.Cells[j].Value?.ToString() ?? "";
                            }
                            rowIndex++;
                        }

                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("¡Archivo de Excel exportado y con formato ajustado con éxito!", "Información");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Error");
                }
            }
        }

        private void btnAgregarPalabra_Click(object sender, EventArgs e)
        {
            string palabra = txtPalabra.Text.Trim();

            // Validar campo vacío
            if (string.IsNullOrWhiteSpace(palabra))
            {
                MessageBox.Show("Ingresa una palabra reservada.");
                txtPalabra.Focus();
                return;
            }

            // Validar formato de palabra
            if (!analizadorTemporalValido(palabra))
            {
                MessageBox.Show("La palabra ingresada no es válida.");
                return;
            }

            // Verificar si ya existe
            if (palabrasReservadas.Contains(palabra))
            {
                MessageBox.Show("Esta palabra ya existe en el diccionario.");
                return;
            }

            // Agregar palabra
            palabrasReservadas.Add(palabra);

            try
            {
                // Guardar en archivo TXT
                lectorArchivos.GuardarPalabrasReservadas(
                    rutaPalabras,
                    palabrasReservadas
                );

                // Actualizar tabla
                CargarDiccionario();

                // Limpiar campo
                txtPalabra.Clear();
                txtPalabra.Focus();

                MessageBox.Show(
                    "Palabra agregada correctamente.",
                    "Diccionario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                palabrasReservadas.Remove(palabra);

                MessageBox.Show(
                    "Error al guardar la palabra: " + ex.Message,
                    "Error"
                );
            }
        }

        private void btnModificarPalabra_Click(object sender, EventArgs e)
        {
            if (dgvPalabras.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una palabra de la tabla.");
                return;
            }

            string anterior = dgvPalabras.SelectedRows[0]
                .Cells[0].Value.ToString();

            string nueva = txtPalabra.Text.Trim();

            if (!analizadorTemporalValido(nueva))
            {
                MessageBox.Show("Ingresa una palabra válida.");
                return;
            }

            if (anterior.Equals(nueva, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No has realizado ningún cambio.");
                return;
            }

            if (palabrasReservadas.Contains(nueva))
            {
                MessageBox.Show("La nueva palabra ya existe.");
                return;
            }

            palabrasReservadas.Remove(anterior);
            palabrasReservadas.Add(nueva);

            try
            {
                lectorArchivos.GuardarPalabrasReservadas(
                    rutaPalabras, palabrasReservadas);

                CargarDiccionario();
                txtPalabra.Clear();

                MessageBox.Show("Palabra modificada correctamente.");
            }
            catch (Exception ex)
            {
                palabrasReservadas.Remove(nueva);
                palabrasReservadas.Add(anterior);

                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEliminarPalabra_Click(object sender, EventArgs e)
        {
            if (dgvPalabras.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una palabra para eliminar.");
                return;
            }

            string palabra = dgvPalabras.SelectedRows[0]
                .Cells[0].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Deseas eliminar la palabra '" + palabra + "'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            palabrasReservadas.Remove(palabra);

            try
            {
                lectorArchivos.GuardarPalabrasReservadas(
                    rutaPalabras, palabrasReservadas);

                CargarDiccionario();
                txtPalabra.Clear();

                MessageBox.Show("Palabra eliminada correctamente.");
            }
            catch (Exception ex)
            {
                palabrasReservadas.Add(palabra);

                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }
        private void dgvPalabras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtPalabra.Text =
                    dgvPalabras.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
        private bool analizadorTemporalValido(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
                return false;

            palabra = palabra.Trim();

            if (!(char.IsLetter(palabra[0]) || palabra[0] == '_'))
                return false;

            return palabra.All(c =>
                char.IsLetterOrDigit(c) || c == '_');
        }
        private void grpDiccionario_Enter(object sender, EventArgs e)
        {

        }

        private void dgvSimbolos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
