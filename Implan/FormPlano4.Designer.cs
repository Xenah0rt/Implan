namespace Implan
{
    partial class FormPlano4
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.ckbCompleto = new System.Windows.Forms.CheckBox();
            this.mtxtTempo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtAcao = new System.Windows.Forms.RichTextBox();
            this.dgvItemConf = new System.Windows.Forms.DataGridView();
            this.colItemConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtxtNotas = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dgvPlanoInst = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemConf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoInst)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Location = new System.Drawing.Point(831, 453);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 35;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.ckbCompleto);
            this.panel1.Controls.Add(this.mtxtTempo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mtxtDataInicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rtxtAcao);
            this.panel1.Controls.Add(this.dgvItemConf);
            this.panel1.Controls.Add(this.rtxtNotas);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(663, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 408);
            this.panel1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigo.Location = new System.Drawing.Point(6, 385);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(66, 20);
            this.txtCodigo.TabIndex = 39;
            // 
            // ckbCompleto
            // 
            this.ckbCompleto.AutoSize = true;
            this.ckbCompleto.Location = new System.Drawing.Point(160, 381);
            this.ckbCompleto.Name = "ckbCompleto";
            this.ckbCompleto.Size = new System.Drawing.Size(70, 17);
            this.ckbCompleto.TabIndex = 37;
            this.ckbCompleto.Text = "Completo";
            this.ckbCompleto.UseVisualStyleBackColor = true;
            this.ckbCompleto.CheckedChanged += new System.EventHandler(this.ckbCompleto_CheckedChanged);
            this.ckbCompleto.Click += new System.EventHandler(this.ckbCompleto_Click);
            // 
            // mtxtTempo
            // 
            this.mtxtTempo.BackColor = System.Drawing.Color.Honeydew;
            this.mtxtTempo.Location = new System.Drawing.Point(140, 152);
            this.mtxtTempo.Mask = "00:00:00";
            this.mtxtTempo.Name = "mtxtTempo";
            this.mtxtTempo.ReadOnly = true;
            this.mtxtTempo.Size = new System.Drawing.Size(100, 20);
            this.mtxtTempo.TabIndex = 36;
            this.mtxtTempo.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Tempo Estimado";
            // 
            // mtxtDataInicio
            // 
            this.mtxtDataInicio.BackColor = System.Drawing.Color.Honeydew;
            this.mtxtDataInicio.Location = new System.Drawing.Point(6, 152);
            this.mtxtDataInicio.Mask = "00/00/0000 90:00";
            this.mtxtDataInicio.Name = "mtxtDataInicio";
            this.mtxtDataInicio.ReadOnly = true;
            this.mtxtDataInicio.Size = new System.Drawing.Size(100, 20);
            this.mtxtDataInicio.TabIndex = 33;
            this.mtxtDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Data Início";
            // 
            // rtxtAcao
            // 
            this.rtxtAcao.BackColor = System.Drawing.Color.Honeydew;
            this.rtxtAcao.Location = new System.Drawing.Point(6, 189);
            this.rtxtAcao.Name = "rtxtAcao";
            this.rtxtAcao.ReadOnly = true;
            this.rtxtAcao.Size = new System.Drawing.Size(234, 67);
            this.rtxtAcao.TabIndex = 32;
            this.rtxtAcao.Text = "";
            // 
            // dgvItemConf
            // 
            this.dgvItemConf.AllowUserToAddRows = false;
            this.dgvItemConf.AllowUserToDeleteRows = false;
            this.dgvItemConf.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvItemConf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemConf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemConf});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemConf.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemConf.Location = new System.Drawing.Point(6, 3);
            this.dgvItemConf.Name = "dgvItemConf";
            this.dgvItemConf.ReadOnly = true;
            this.dgvItemConf.RowHeadersVisible = false;
            this.dgvItemConf.Size = new System.Drawing.Size(234, 123);
            this.dgvItemConf.TabIndex = 31;
            // 
            // colItemConf
            // 
            this.colItemConf.HeaderText = "Item de Configuração";
            this.colItemConf.Name = "colItemConf";
            this.colItemConf.ReadOnly = true;
            this.colItemConf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colItemConf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colItemConf.Width = 231;
            // 
            // rtxtNotas
            // 
            this.rtxtNotas.BackColor = System.Drawing.Color.Honeydew;
            this.rtxtNotas.Location = new System.Drawing.Point(6, 275);
            this.rtxtNotas.Name = "rtxtNotas";
            this.rtxtNotas.ReadOnly = true;
            this.rtxtNotas.Size = new System.Drawing.Size(234, 90);
            this.rtxtNotas.TabIndex = 30;
            this.rtxtNotas.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Notas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Ação";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BackColor = System.Drawing.Color.Honeydew;
            this.txtPesquisar.Location = new System.Drawing.Point(12, 13);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(645, 20);
            this.txtPesquisar.TabIndex = 28;
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
            this.colCategoria,
            this.colStatus,
            this.colTempo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlanoInst.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlanoInst.Location = new System.Drawing.Point(12, 39);
            this.dgvPlanoInst.Name = "dgvPlanoInst";
            this.dgvPlanoInst.RowHeadersVisible = false;
            this.dgvPlanoInst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanoInst.Size = new System.Drawing.Size(645, 408);
            this.dgvPlanoInst.TabIndex = 27;
            this.dgvPlanoInst.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanoInst_CellClick);
            this.dgvPlanoInst.SelectionChanged += new System.EventHandler(this.dgvPlanoInst_SelectionChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Número";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 50;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "Descrição";
            this.colDesc.Name = "colDesc";
            this.colDesc.Width = 310;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Width = 142;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 70;
            // 
            // colTempo
            // 
            this.colTempo.HeaderText = "Tempo Estimado";
            this.colTempo.Name = "colTempo";
            this.colTempo.Width = 70;
            // 
            // FormPlano4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(918, 488);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.dgvPlanoInst);
            this.Name = "FormPlano4";
            this.Text = "FormPlano4";
            this.Load += new System.EventHandler(this.FormPlano4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemConf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoInst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtxtNotas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView dgvPlanoInst;
        private System.Windows.Forms.DataGridView dgvItemConf;
        private System.Windows.Forms.RichTextBox rtxtAcao;
        private System.Windows.Forms.MaskedTextBox mtxtDataInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbCompleto;
        private System.Windows.Forms.MaskedTextBox mtxtTempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemConf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
    }
}