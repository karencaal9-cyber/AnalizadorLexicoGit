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
            this.txtEditorCodigo = new System.Windows.Forms.RichTextBox();
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConsola = new System.Windows.Forms.TextBox();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTiempoP = new System.Windows.Forms.Label();
            this.lblTotalErroresP = new System.Windows.Forms.Label();
            this.lblTotalLineasP = new System.Windows.Forms.Label();
            this.lblTotalTokensP = new System.Windows.Forms.Label();
            this.grpDiccionario = new System.Windows.Forms.GroupBox();
            this.btnEliminarPalabra = new System.Windows.Forms.Button();
            this.btnModificarPalabra = new System.Windows.Forms.Button();
            this.btnAgregarPalabra = new System.Windows.Forms.Button();
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.dgvPalabras = new System.Windows.Forms.DataGridView();
            this.btnForm2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpDiccionario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(364, 12);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(67, 39);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(473, 58);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(85, 39);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "📂 ABRIR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "▶ EJECUTAR ANALIZADOR";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtEditorCodigo
            // 
            this.txtEditorCodigo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtEditorCodigo.Location = new System.Drawing.Point(0, 0);
            this.txtEditorCodigo.Name = "txtEditorCodigo";
            this.txtEditorCodigo.Size = new System.Drawing.Size(181, 845);
            this.txtEditorCodigo.TabIndex = 8;
            this.txtEditorCodigo.Text = "";
            this.txtEditorCodigo.TextChanged += new System.EventHandler(this.txtEditorCodigo_TextChanged);
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
            this.dgvTokens.Location = new System.Drawing.Point(187, 128);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.RowHeadersWidth = 51;
            this.dgvTokens.RowTemplate.Height = 24;
            this.dgvTokens.Size = new System.Drawing.Size(681, 247);
            this.dgvTokens.TabIndex = 9;
            this.dgvTokens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTokens_CellContentClick);
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
            this.txtConsola.Location = new System.Drawing.Point(187, 390);
            this.txtConsola.Multiline = true;
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(681, 65);
            this.txtConsola.TabIndex = 10;
            this.txtConsola.TextChanged += new System.EventHandler(this.txtConsola_TextChanged);
            // 
            // dgvSimbolos
            // 
            this.dgvSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimbolos.Location = new System.Drawing.Point(187, 477);
            this.dgvSimbolos.Name = "dgvSimbolos";
            this.dgvSimbolos.RowHeadersWidth = 51;
            this.dgvSimbolos.RowTemplate.Height = 24;
            this.dgvSimbolos.Size = new System.Drawing.Size(681, 340);
            this.dgvSimbolos.TabIndex = 11;
            this.dgvSimbolos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSimbolos_CellContentClick);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(640, 58);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(125, 39);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Text = "Exportar informe";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTiempoP);
            this.groupBox1.Controls.Add(this.lblTotalErroresP);
            this.groupBox1.Controls.Add(this.lblTotalLineasP);
            this.groupBox1.Controls.Add(this.lblTotalTokensP);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(907, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 203);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Panel Estadistico";
            // 
            // lblTiempoP
            // 
            this.lblTiempoP.AutoSize = true;
            this.lblTiempoP.Font = new System.Drawing.Font("Microsoft Tai Le", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoP.Location = new System.Drawing.Point(48, 166);
            this.lblTiempoP.Name = "lblTiempoP";
            this.lblTiempoP.Size = new System.Drawing.Size(172, 23);
            this.lblTiempoP.TabIndex = 3;
            this.lblTiempoP.Text = "Tiempo de Analisis:";
            // 
            // lblTotalErroresP
            // 
            this.lblTotalErroresP.AutoSize = true;
            this.lblTotalErroresP.Font = new System.Drawing.Font("Microsoft Tai Le", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalErroresP.Location = new System.Drawing.Point(48, 126);
            this.lblTotalErroresP.Name = "lblTotalErroresP";
            this.lblTotalErroresP.Size = new System.Drawing.Size(147, 23);
            this.lblTotalErroresP.TabIndex = 2;
            this.lblTotalErroresP.Text = "Total de errores:";
            // 
            // lblTotalLineasP
            // 
            this.lblTotalLineasP.AutoSize = true;
            this.lblTotalLineasP.Font = new System.Drawing.Font("Microsoft Tai Le", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLineasP.Location = new System.Drawing.Point(48, 84);
            this.lblTotalLineasP.Name = "lblTotalLineasP";
            this.lblTotalLineasP.Size = new System.Drawing.Size(140, 23);
            this.lblTotalLineasP.TabIndex = 1;
            this.lblTotalLineasP.Text = "Total de Lineas:";
            // 
            // lblTotalTokensP
            // 
            this.lblTotalTokensP.AutoSize = true;
            this.lblTotalTokensP.Font = new System.Drawing.Font("Microsoft Tai Le", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTokensP.Location = new System.Drawing.Point(48, 49);
            this.lblTotalTokensP.Name = "lblTotalTokensP";
            this.lblTotalTokensP.Size = new System.Drawing.Size(146, 23);
            this.lblTotalTokensP.TabIndex = 0;
            this.lblTotalTokensP.Text = "Total de Tokens:";
            // 
            // grpDiccionario
            // 
            this.grpDiccionario.Controls.Add(this.btnEliminarPalabra);
            this.grpDiccionario.Controls.Add(this.btnModificarPalabra);
            this.grpDiccionario.Controls.Add(this.btnAgregarPalabra);
            this.grpDiccionario.Controls.Add(this.txtPalabra);
            this.grpDiccionario.Controls.Add(this.dgvPalabras);
            this.grpDiccionario.Location = new System.Drawing.Point(907, 344);
            this.grpDiccionario.Name = "grpDiccionario";
            this.grpDiccionario.Size = new System.Drawing.Size(489, 473);
            this.grpDiccionario.TabIndex = 17;
            this.grpDiccionario.TabStop = false;
            this.grpDiccionario.Text = "Diccionario de palabras reservadas";
            this.grpDiccionario.Enter += new System.EventHandler(this.grpDiccionario_Enter);
            // 
            // btnEliminarPalabra
            // 
            this.btnEliminarPalabra.Location = new System.Drawing.Point(298, 411);
            this.btnEliminarPalabra.Name = "btnEliminarPalabra";
            this.btnEliminarPalabra.Size = new System.Drawing.Size(113, 39);
            this.btnEliminarPalabra.TabIndex = 4;
            this.btnEliminarPalabra.Text = "ELIMINAR{";
            this.btnEliminarPalabra.UseVisualStyleBackColor = true;
            this.btnEliminarPalabra.Click += new System.EventHandler(this.btnEliminarPalabra_Click);
            // 
            // btnModificarPalabra
            // 
            this.btnModificarPalabra.Location = new System.Drawing.Point(169, 411);
            this.btnModificarPalabra.Name = "btnModificarPalabra";
            this.btnModificarPalabra.Size = new System.Drawing.Size(113, 39);
            this.btnModificarPalabra.TabIndex = 3;
            this.btnModificarPalabra.Text = "MODIFICAR";
            this.btnModificarPalabra.UseVisualStyleBackColor = true;
            this.btnModificarPalabra.Click += new System.EventHandler(this.btnModificarPalabra_Click);
            // 
            // btnAgregarPalabra
            // 
            this.btnAgregarPalabra.Location = new System.Drawing.Point(32, 411);
            this.btnAgregarPalabra.Name = "btnAgregarPalabra";
            this.btnAgregarPalabra.Size = new System.Drawing.Size(113, 39);
            this.btnAgregarPalabra.TabIndex = 2;
            this.btnAgregarPalabra.Text = "AGREGAR";
            this.btnAgregarPalabra.UseVisualStyleBackColor = true;
            this.btnAgregarPalabra.Click += new System.EventHandler(this.btnAgregarPalabra_Click);
            // 
            // txtPalabra
            // 
            this.txtPalabra.Location = new System.Drawing.Point(21, 23);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(299, 22);
            this.txtPalabra.TabIndex = 1;
            // 
            // dgvPalabras
            // 
            this.dgvPalabras.AllowUserToAddRows = false;
            this.dgvPalabras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalabras.Location = new System.Drawing.Point(6, 51);
            this.dgvPalabras.MultiSelect = false;
            this.dgvPalabras.Name = "dgvPalabras";
            this.dgvPalabras.ReadOnly = true;
            this.dgvPalabras.RowHeadersWidth = 51;
            this.dgvPalabras.RowTemplate.Height = 24;
            this.dgvPalabras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dgvPalabras.Size = new System.Drawing.Size(461, 338);
            this.dgvPalabras.TabIndex = 0;
            // 
            // btnForm2
            // 
            this.btnForm2.Font = new System.Drawing.Font("Segoe UI", 9.216F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForm2.Location = new System.Drawing.Point(1178, 18);
            this.btnForm2.Name = "btnForm2";
            this.btnForm2.Size = new System.Drawing.Size(186, 54);
            this.btnForm2.TabIndex = 18;
            this.btnForm2.Text = "IR A AFD O AFND";
            this.btnForm2.UseVisualStyleBackColor = true;
            this.btnForm2.Click += new System.EventHandler(this.btnForm2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 845);
            this.Controls.Add(this.btnForm2);
            this.Controls.Add(this.grpDiccionario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvSimbolos);
            this.Controls.Add(this.txtConsola);
            this.Controls.Add(this.dgvTokens);
            this.Controls.Add(this.txtEditorCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.btnAbrir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpDiccionario.ResumeLayout(false);
            this.grpDiccionario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtEditorCodigo;
        private System.Windows.Forms.DataGridView dgvTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patron;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna;
        private System.Windows.Forms.TextBox txtConsola;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTiempoP;
        private System.Windows.Forms.Label lblTotalErroresP;
        private System.Windows.Forms.Label lblTotalLineasP;
        private System.Windows.Forms.Label lblTotalTokensP;
        private System.Windows.Forms.GroupBox grpDiccionario;
        private System.Windows.Forms.TextBox txtPalabra;
        private System.Windows.Forms.DataGridView dgvPalabras;
        private System.Windows.Forms.Button btnAgregarPalabra;
        private System.Windows.Forms.Button btnEliminarPalabra;
        private System.Windows.Forms.Button btnModificarPalabra;
        private System.Windows.Forms.Button btnForm2;
    }
}

