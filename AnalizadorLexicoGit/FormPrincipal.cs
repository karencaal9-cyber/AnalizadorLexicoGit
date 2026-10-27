using AnalizadorLexicoGit.GitService;
using AnalizadorLexicoGit.Lexer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnalizadorLexicoGit
{
    public partial class Form1 : Form
    {
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

            MostrarEstadisticas(analizador);
        }

        private void MostrarEstadisticas(AnalizadorLexico analizador)
        {
            int totalTokens = analizador.Tokens.Count;
            int totalErrores = analizador.Error.Count;
            int totalSimbolos = analizador.TablaSimbolos.ObtenerSimbolos().Count;

            lblTotalTokens.Text = $"Total de Tokens: {totalTokens}";
            lblTotalErrores.Text = $"Total Errores: {totalErrores}";
            lblTotalSimbolos.Text = $"Total Símbolos: {totalSimbolos}";
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
            saveFileDialog.Filter = "Archivo CSV (*.csv)|*.csv|Archivo de texto (*.txt)|*.txt";
            saveFileDialog.Title = "Reporte de tokens";
            saveFileDialog.FileName = "ReporteTokens.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("Token,Lexema,Patron,Fila,Columna");

                    foreach (DataGridViewRow row in dgvTokens.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string tipo = row.Cells[0].Value?.ToString() ?? "";
                        string lexema = row.Cells[1].Value?.ToString() ?? "";
                        string patron = row.Cells[2].Value?.ToString() ?? "";
                        string fila = row.Cells[3].Value?.ToString() ?? "";
                        string columna = row.Cells[4].Value?.ToString() ?? "";

                        sb.AppendLine($"{tipo},{lexema},{patron},{fila},{columna}");
                    }

                    File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("¡Archivo exportado con éxito!", "Información");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Error");
                }
            }

        }
    }
}
