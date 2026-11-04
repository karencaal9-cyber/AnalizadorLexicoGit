namespace AnalizadorLexicoGit
{
    partial class FormAFDyAFND
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAutomata = new System.Windows.Forms.Label();
            this.lblCantidadEstados = new System.Windows.Forms.Label();
            this.lblVariables = new System.Windows.Forms.Label();
            this.lblInicial = new System.Windows.Forms.Label();
            this.lblAceptacion = new System.Windows.Forms.Label();
            this.cmbTipoAutomata = new System.Windows.Forms.ComboBox();
            this.cmbInicial = new System.Windows.Forms.ComboBox();
            this.txtCantEstados = new System.Windows.Forms.TextBox();
            this.txtVariables = new System.Windows.Forms.TextBox();
            this.chcAceptacion = new System.Windows.Forms.CheckedListBox();
            this.dgvTransiciones = new System.Windows.Forms.DataGridView();
            this.btnTabla = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCadenaPrueba = new System.Windows.Forms.Label();
            this.txtCadenaPrueba = new System.Windows.Forms.TextBox();
            this.btnProbarCadena = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransiciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAutomata
            // 
            this.lblAutomata.AutoSize = true;
            this.lblAutomata.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutomata.Location = new System.Drawing.Point(210, 14);
            this.lblAutomata.Name = "lblAutomata";
            this.lblAutomata.Size = new System.Drawing.Size(212, 23);
            this.lblAutomata.TabIndex = 0;
            this.lblAutomata.Text = "Elegir el tipo de autómata:";
            // 
            // lblCantidadEstados
            // 
            this.lblCantidadEstados.AutoSize = true;
            this.lblCantidadEstados.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadEstados.Location = new System.Drawing.Point(3, 17);
            this.lblCantidadEstados.Name = "lblCantidadEstados";
            this.lblCantidadEstados.Size = new System.Drawing.Size(239, 23);
            this.lblCantidadEstados.TabIndex = 1;
            this.lblCantidadEstados.Text = "Defina la cantidad de estados:";
            // 
            // lblVariables
            // 
            this.lblVariables.AutoSize = true;
            this.lblVariables.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariables.Location = new System.Drawing.Point(3, 73);
            this.lblVariables.Name = "lblVariables";
            this.lblVariables.Size = new System.Drawing.Size(247, 23);
            this.lblVariables.TabIndex = 2;
            this.lblVariables.Text = "Defina las variables de entrada:";
            // 
            // lblInicial
            // 
            this.lblInicial.AutoSize = true;
            this.lblInicial.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicial.Location = new System.Drawing.Point(3, 122);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(194, 23);
            this.lblInicial.TabIndex = 3;
            this.lblInicial.Text = "Indique el estado inicial:";
            // 
            // lblAceptacion
            // 
            this.lblAceptacion.AutoSize = true;
            this.lblAceptacion.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAceptacion.Location = new System.Drawing.Point(575, 13);
            this.lblAceptacion.Name = "lblAceptacion";
            this.lblAceptacion.Size = new System.Drawing.Size(273, 23);
            this.lblAceptacion.TabIndex = 4;
            this.lblAceptacion.Text = "Indique los estados de aceptación:";
            // 
            // cmbTipoAutomata
            // 
            this.cmbTipoAutomata.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoAutomata.FormattingEnabled = true;
            this.cmbTipoAutomata.Items.AddRange(new object[] {
            "AFD",
            "AFND"});
            this.cmbTipoAutomata.Location = new System.Drawing.Point(437, 11);
            this.cmbTipoAutomata.Name = "cmbTipoAutomata";
            this.cmbTipoAutomata.Size = new System.Drawing.Size(204, 31);
            this.cmbTipoAutomata.TabIndex = 5;
            // 
            // cmbInicial
            // 
            this.cmbInicial.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInicial.FormattingEnabled = true;
            this.cmbInicial.Location = new System.Drawing.Point(264, 122);
            this.cmbInicial.Name = "cmbInicial";
            this.cmbInicial.Size = new System.Drawing.Size(141, 31);
            this.cmbInicial.TabIndex = 6;
            // 
            // txtCantEstados
            // 
            this.txtCantEstados.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantEstados.Location = new System.Drawing.Point(264, 17);
            this.txtCantEstados.Name = "txtCantEstados";
            this.txtCantEstados.Size = new System.Drawing.Size(141, 30);
            this.txtCantEstados.TabIndex = 7;
            this.txtCantEstados.TextChanged += new System.EventHandler(this.txtCantEstados_TextChanged);
            // 
            // txtVariables
            // 
            this.txtVariables.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVariables.Location = new System.Drawing.Point(264, 71);
            this.txtVariables.Name = "txtVariables";
            this.txtVariables.Size = new System.Drawing.Size(141, 30);
            this.txtVariables.TabIndex = 8;
            // 
            // chcAceptacion
            // 
            this.chcAceptacion.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcAceptacion.FormattingEnabled = true;
            this.chcAceptacion.Location = new System.Drawing.Point(610, 53);
            this.chcAceptacion.Name = "chcAceptacion";
            this.chcAceptacion.Size = new System.Drawing.Size(199, 79);
            this.chcAceptacion.TabIndex = 9;
            // 
            // dgvTransiciones
            // 
            this.dgvTransiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransiciones.Location = new System.Drawing.Point(188, 317);
            this.dgvTransiciones.Name = "dgvTransiciones";
            this.dgvTransiciones.RowHeadersWidth = 53;
            this.dgvTransiciones.RowTemplate.Height = 24;
            this.dgvTransiciones.Size = new System.Drawing.Size(511, 150);
            this.dgvTransiciones.TabIndex = 10;
            // 
            // btnTabla
            // 
            this.btnTabla.Font = new System.Drawing.Font("Segoe UI Semibold", 9.792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabla.Location = new System.Drawing.Point(202, 261);
            this.btnTabla.Name = "btnTabla";
            this.btnTabla.Size = new System.Drawing.Size(215, 38);
            this.btnTabla.TabIndex = 11;
            this.btnTabla.Text = "Generar Tabla";
            this.btnTabla.UseVisualStyleBackColor = true;
            this.btnTabla.Click += new System.EventHandler(this.btnTabla_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCantidadEstados);
            this.panel1.Controls.Add(this.lblVariables);
            this.panel1.Controls.Add(this.lblInicial);
            this.panel1.Controls.Add(this.chcAceptacion);
            this.panel1.Controls.Add(this.lblAceptacion);
            this.panel1.Controls.Add(this.txtCantEstados);
            this.panel1.Controls.Add(this.cmbInicial);
            this.panel1.Controls.Add(this.txtVariables);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 185);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnProbarCadena);
            this.panel2.Controls.Add(this.lblCadenaPrueba);
            this.panel2.Controls.Add(this.txtCadenaPrueba);
            this.panel2.Location = new System.Drawing.Point(298, 491);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 188);
            this.panel2.TabIndex = 13;
            // 
            // lblCadenaPrueba
            // 
            this.lblCadenaPrueba.AutoSize = true;
            this.lblCadenaPrueba.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadenaPrueba.Location = new System.Drawing.Point(23, 17);
            this.lblCadenaPrueba.Name = "lblCadenaPrueba";
            this.lblCadenaPrueba.Size = new System.Drawing.Size(247, 23);
            this.lblCadenaPrueba.TabIndex = 1;
            this.lblCadenaPrueba.Text = "Ingrese una cadena de prueba:";
            // 
            // txtCadenaPrueba
            // 
            this.txtCadenaPrueba.Font = new System.Drawing.Font("Segoe UI", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadenaPrueba.Location = new System.Drawing.Point(58, 55);
            this.txtCadenaPrueba.Name = "txtCadenaPrueba";
            this.txtCadenaPrueba.Size = new System.Drawing.Size(183, 30);
            this.txtCadenaPrueba.TabIndex = 7;
            // 
            // btnProbarCadena
            // 
            this.btnProbarCadena.Font = new System.Drawing.Font("Segoe UI Semibold", 9.792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProbarCadena.Location = new System.Drawing.Point(42, 135);
            this.btnProbarCadena.Name = "btnProbarCadena";
            this.btnProbarCadena.Size = new System.Drawing.Size(215, 38);
            this.btnProbarCadena.TabIndex = 12;
            this.btnProbarCadena.Text = "Probar Cadena";
            this.btnProbarCadena.UseVisualStyleBackColor = true;
            this.btnProbarCadena.Click += new System.EventHandler(this.btnProbarCadena_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(475, 261);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(215, 38);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FormAFDyAFND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 682);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTabla);
            this.Controls.Add(this.dgvTransiciones);
            this.Controls.Add(this.cmbTipoAutomata);
            this.Controls.Add(this.lblAutomata);
            this.Name = "FormAFDyAFND";
            this.Text = "AFD y AFND";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransiciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAutomata;
        private System.Windows.Forms.Label lblCantidadEstados;
        private System.Windows.Forms.Label lblVariables;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.Label lblAceptacion;
        private System.Windows.Forms.ComboBox cmbTipoAutomata;
        private System.Windows.Forms.ComboBox cmbInicial;
        private System.Windows.Forms.TextBox txtCantEstados;
        private System.Windows.Forms.TextBox txtVariables;
        private System.Windows.Forms.CheckedListBox chcAceptacion;
        private System.Windows.Forms.DataGridView dgvTransiciones;
        private System.Windows.Forms.Button btnTabla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProbarCadena;
        private System.Windows.Forms.Label lblCadenaPrueba;
        private System.Windows.Forms.TextBox txtCadenaPrueba;
        private System.Windows.Forms.Button btnLimpiar;
    }
}