using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AnalizadorLexicoGit.Lexer;
using AnalizadorLexicoGit.GitService;

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
    }
}
