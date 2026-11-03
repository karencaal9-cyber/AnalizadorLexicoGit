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
        private List<string> tiposTokens;
        private List<string> erroresConfig;

        private ControladorGit _gitControlador;
        public Form1()
        {
            InitializeComponent();
            ConfigurarTablaSimbolos();
            _gitControlador = new ControladorGit(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LectorArchivos lector = new LectorArchivos();

                palabrasReservadas = lector.CargarPalabrasReservadas("palabras_reservadas.txt");
                tiposTokens = lector.CargarTiposTokens("tipo_token.txt");
                
                MessageBox.Show("¡Archivos de configuración cargados con éxito en memoria!", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los archivos de configuración: " + ex.Message, "Error crítico");
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

            AnalizadorLexico analizador = new AnalizadorLexico(codigo, palabrasReservadas);

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

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            analizador.Analizar(); 
            stopwatch.Stop();
            long tiempoMs = stopwatch.ElapsedMilliseconds;

            string codigoFuente = txtEditorCodigo.Text; 
            analizador.Analizar(codigoFuente);

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
    }
}
