namespace Implan
{
    partial class FormPlano1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dgvPlano = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmbiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblcont = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.ckbArq = new System.Windows.Forms.CheckBox();
            this.ckbPend = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlano)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.Location = new System.Drawing.Point(180, 376);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 19;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = false;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Location = new System.Drawing.Point(93, 376);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(81, 23);
            this.btnAlterar.TabIndex = 18;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Location = new System.Drawing.Point(12, 376);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 17;
            this.btnNovo.Text = "Novo Plano";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BackColor = System.Drawing.Color.Honeydew;
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.Location = new System.Drawing.Point(12, 12);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(240, 20);
            this.txtPesquisar.TabIndex = 16;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // dgvPlano
            // 
            this.dgvPlano.AllowUserToAddRows = false;
            this.dgvPlano.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvPlano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNome,
            this.colAmbiente,
            this.colData,
            this.colStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlano.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlano.Location = new System.Drawing.Point(12, 38);
            this.dgvPlano.Name = "dgvPlano";
            this.dgvPlano.RowHeadersVisible = false;
            this.dgvPlano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlano.Size = new System.Drawing.Size(670, 320);
            this.dgvPlano.TabIndex = 15;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 45;
            // 
            // colNome
            // 
            this.colNome.HeaderText = "Plano";
            this.colNome.Name = "colNome";
            this.colNome.Width = 292;
            // 
            // colAmbiente
            // 
            this.colAmbiente.HeaderText = "Ambiente";
            this.colAmbiente.Name = "colAmbiente";
            this.colAmbiente.Width = 140;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 70;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Location = new System.Drawing.Point(261, 376);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 20;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblcont
            // 
            this.lblcont.AutoSize = true;
            this.lblcont.Location = new System.Drawing.Point(9, 360);
            this.lblcont.Name = "lblcont";
            this.lblcont.Size = new System.Drawing.Size(35, 13);
            this.lblcont.TabIndex = 21;
            this.lblcont.Text = "label6";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Location = new System.Drawing.Point(607, 376);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 22;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // ckbArq
            // 
            this.ckbArq.AutoSize = true;
            this.ckbArq.Location = new System.Drawing.Point(266, 12);
            this.ckbArq.Name = "ckbArq";
            this.ckbArq.Size = new System.Drawing.Size(79, 17);
            this.ckbArq.TabIndex = 38;
            this.ckbArq.Text = "Arquivados";
            this.ckbArq.UseVisualStyleBackColor = true;
            this.ckbArq.CheckedChanged += new System.EventHandler(this.ckbArq_CheckedChanged);
            // 
            // ckbPend
            // 
            this.ckbPend.AutoSize = true;
            this.ckbPend.Location = new System.Drawing.Point(351, 12);
            this.ckbPend.Name = "ckbPend";
            this.ckbPend.Size = new System.Drawing.Size(77, 17);
            this.ckbPend.TabIndex = 39;
            this.ckbPend.Text = "Pendentes";
            this.ckbPend.UseVisualStyleBackColor = true;
            this.ckbPend.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormPlano1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(694, 402);
            this.Controls.Add(this.ckbPend);
            this.Controls.Add(this.ckbArq);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblcont);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.dgvPlano);
            this.Name = "FormPlano1";
            this.Text = "Gerenciar Planos de Implementação";
            this.Load += new System.EventHandler(this.FormPlano1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlano)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView dgvPlano;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblcont;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmbiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.CheckBox ckbArq;
        private System.Windows.Forms.CheckBox ckbPend;
    }
}