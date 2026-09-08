namespace AnalizadorLexicoGit
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMensajeCommit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.txtEditorCodigo = new System.Windows.Forms.RichTextBox();
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConsola = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(353, 51);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(67, 39);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(353, 112);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(67, 39);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "📂 ABRIR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "▶ EJECUTAR ANALIZADOR";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtMensajeCommit
            // 
            this.txtMensajeCommit.Location = new System.Drawing.Point(620, 51);
            this.txtMensajeCommit.Name = "txtMensajeCommit";
            this.txtMensajeCommit.Size = new System.Drawing.Size(135, 22);
            this.txtMensajeCommit.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "AVANCE ANALIZADOR";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(465, 112);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(87, 39);
            this.btnCommit.TabIndex = 6;
            this.btnCommit.Text = "Git Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(616, 112);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(67, 39);
            this.btnPush.TabIndex = 7;
            this.btnPush.Text = "Git Push";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // txtEditorCodigo
            // 
            this.txtEditorCodigo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtEditorCodigo.Location = new System.Drawing.Point(0, 0);
            this.txtEditorCodigo.Name = "txtEditorCodigo";
            this.txtEditorCodigo.Size = new System.Drawing.Size(146, 562);
            this.txtEditorCodigo.TabIndex = 8;
            this.txtEditorCodigo.Text = "";
            // 
            // dgvTokens
            // 
            this.dgvTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Token,
            this.Lexema,
            this.Patron,
            this.Fila,
            this.Columna});
            this.dgvTokens.Location = new System.Drawing.Point(174, 183);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.RowHeadersWidth = 51;
            this.dgvTokens.RowTemplate.Height = 24;
            this.dgvTokens.Size = new System.Drawing.Size(684, 247);
            this.dgvTokens.TabIndex = 9;
            // 
            // Token
            // 
            this.Token.HeaderText = "Token";
            this.Token.MinimumWidth = 6;
            this.Token.Name = "Token";
            this.Token.Width = 125;
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.MinimumWidth = 6;
            this.Lexema.Name = "Lexema";
            this.Lexema.Width = 125;
            // 
            // Patron
            // 
            this.Patron.HeaderText = "Patron";
            this.Patron.MinimumWidth = 6;
            this.Patron.Name = "Patron";
            this.Patron.Width = 125;
            // 
            // Fila
            // 
            this.Fila.HeaderText = "Fila";
            this.Fila.MinimumWidth = 6;
            this.Fila.Name = "Fila";
            this.Fila.Width = 125;
            // 
            // Columna
            // 
            this.Columna.HeaderText = "Columna";
            this.Columna.MinimumWidth = 6;
            this.Columna.Name = "Columna";
            this.Columna.Width = 125;
            // 
            // txtConsola
            // 
            this.txtConsola.BackColor = System.Drawing.Color.Black;
            this.txtConsola.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtConsola.Location = new System.Drawing.Point(180, 459);
            this.txtConsola.Multiline = true;
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(137, 28);
            this.txtConsola.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 562);
            this.Controls.Add(this.txtConsola);
            this.Controls.Add(this.dgvTokens);
            this.Controls.Add(this.txtEditorCodigo);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMensajeCommit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.btnAbrir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMensajeCommit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.RichTextBox txtEditorCodigo;
        private System.Windows.Forms.DataGridView dgvTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patron;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna;
        private System.Windows.Forms.TextBox txtConsola;
    }
}

