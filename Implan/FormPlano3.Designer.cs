namespace Implan
{
    partial class FormPlano3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.rtxtAcao = new System.Windows.Forms.RichTextBox();
            this.rtxtNotas = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxtTempo = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.dgvPlanoInst = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoInst)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Location = new System.Drawing.Point(613, 372);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(613, 340);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(448, 340);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Location = new System.Drawing.Point(178, 372);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Location = new System.Drawing.Point(91, 372);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(81, 23);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Location = new System.Drawing.Point(10, 372);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.rtxtAcao);
            this.panel1.Controls.Add(this.rtxtNotas);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.mtxtTempo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbCategoria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDesc);
            this.panel1.Location = new System.Drawing.Point(448, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 354);
            this.panel1.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Codigo*";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigo.Location = new System.Drawing.Point(6, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(66, 20);
            this.txtCodigo.TabIndex = 6;
            // 
            // rtxtAcao
            // 
            this.rtxtAcao.BackColor = System.Drawing.Color.Honeydew;
            this.rtxtAcao.Location = new System.Drawing.Point(6, 133);
            this.rtxtAcao.Name = "rtxtAcao";
            this.rtxtAcao.Size = new System.Drawing.Size(234, 60);
            this.rtxtAcao.TabIndex = 10;
            this.rtxtAcao.Text = "";
            // 
            // rtxtNotas
            // 
            this.rtxtNotas.BackColor = System.Drawing.Color.Honeydew;
            this.rtxtNotas.Location = new System.Drawing.Point(6, 213);
            this.rtxtNotas.Name = "rtxtNotas";
            this.rtxtNotas.Size = new System.Drawing.Size(234, 106);
            this.rtxtNotas.TabIndex = 11;
            this.rtxtNotas.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Notas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ação*";
            // 
            // mtxtTempo
            // 
            this.mtxtTempo.BackColor = System.Drawing.Color.Honeydew;
            this.mtxtTempo.Location = new System.Drawing.Point(133, 95);
            this.mtxtTempo.Mask = "00:00:00";
            this.mtxtTempo.Name = "mtxtTempo";
            this.mtxtTempo.Size = new System.Drawing.Size(100, 20);
            this.mtxtTempo.TabIndex = 9;
            this.mtxtTempo.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Categoria IC";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.Honeydew;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(6, 94);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoria.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descrição*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tempo Estimado*";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.Honeydew;
            this.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc.Location = new System.Drawing.Point(6, 54);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(234, 20);
            this.txtDesc.TabIndex = 7;
            // 
            // dgvPlanoInst
            // 
            this.dgvPlanoInst.AllowUserToAddRows = false;
            this.dgvPlanoInst.AllowUserToDeleteRows = false;
            this.dgvPlanoInst.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvPlanoInst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanoInst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colDesc,
            this.colIC,
            this.colTempo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlanoInst.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlanoInst.Location = new System.Drawing.Point(12, 38);
            this.dgvPlanoInst.Name = "dgvPlanoInst";
            this.dgvPlanoInst.RowHeadersVisible = false;
            this.dgvPlanoInst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanoInst.Size = new System.Drawing.Size(430, 325);
            this.dgvPlanoInst.TabIndex = 2;
            this.dgvPlanoInst.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanoInst_CellEnter);
            this.dgvPlanoInst.SelectionChanged += new System.EventHandler(this.dgvPlanoInst_SelectionChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Numero";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 50;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "Descrição";
            this.colDesc.Name = "colDesc";
            this.colDesc.Width = 200;
            // 
            // colIC
            // 
            this.colIC.HeaderText = "Item de Configuração";
            this.colIC.Name = "colIC";
            this.colIC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTempo
            // 
            this.colTempo.HeaderText = "Tempo";
            this.colTempo.Name = "colTempo";
            this.colTempo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BackColor = System.Drawing.Color.Honeydew;
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.Location = new System.Drawing.Point(13, 12);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(240, 20);
            this.txtPesquisar.TabIndex = 1;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // FormPlano3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(702, 402);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgvPlanoInst);
            this.Controls.Add(this.panel1);
            this.Name = "FormPlano3";
            this.Text = "Instruções do Plano";
            this.Load += new System.EventHandler(this.FormPlano3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoInst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.DataGridView dgvPlanoInst;
        private System.Windows.Forms.RichTextBox rtxtNotas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtTempo;
        private System.Windows.Forms.RichTextBox rtxtAcao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewComboBoxColumn colIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempo;
    }
}