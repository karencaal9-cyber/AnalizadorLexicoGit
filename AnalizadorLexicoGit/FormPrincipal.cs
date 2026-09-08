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
        private ControladorGit _gitControlador;
        public Form1()
        {
            InitializeComponent();
            _gitControlador = new ControladorGit(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            dgvTokens.Rows.Clear();
            txtConsola.Clear();

            string codigo = txtEditorCodigo.Text;

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Por favor ingrese o cargue código fuente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Muestra de inserción manual en la tabla
            dgvTokens.Rows.Add("TK_INT", "int", "int", 1, 1);
            dgvTokens.Rows.Add("TK_ID", "edad", "[a-zA-Z_][a-zA-Z0-9_]*", 1, 5);
            dgvTokens.Rows.Add("TK_ASIGNACION", "=", "=", 1, 10);
            dgvTokens.Rows.Add("TK_NUM_ENTERO", "20", "[0-9]+", 1, 12);

            txtConsola.AppendText("[CONSOLA]: Análisis léxico finalizado exitosamente.\r\n");
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            string mensaje = txtMensajeCommit.Text;
            if (string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("Ingrese un mensaje de commit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string resultado = _gitControlador.HacerCommit(mensaje);
            txtConsola.AppendText($"[GIT COMMIT]: {resultado}\r\n");
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            string resultado = _gitControlador.HacerPush();
            txtConsola.AppendText($"[GIT PUSH]: {resultado}\r\n");
        }
    }
}
