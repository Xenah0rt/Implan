namespace Implan
{
    partial class FormPlano2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodAtividade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAmbiente = new System.Windows.Forms.ComboBox();
            this.mtxtDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGreen;
            this.panel1.Controls.Add(this.btnContinuar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCodAtividade);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbAmbiente);
            this.panel1.Controls.Add(this.mtxtDataFinal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.mtxtDataInicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 298);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Location = new System.Drawing.Point(249, 268);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 8;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(11, 268);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Código da Atividade";
            // 
            // txtCodAtividade
            // 
            this.txtCodAtividade.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodAtividade.Location = new System.Drawing.Point(175, 116);
            this.txtCodAtividade.MaxLength = 10;
            this.txtCodAtividade.Name = "txtCodAtividade";
            this.txtCodAtividade.Size = new System.Drawing.Size(149, 20);
            this.txtCodAtividade.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ambiente";
            // 
            // cmbAmbiente
            // 
            this.cmbAmbiente.BackColor = System.Drawing.Color.Honeydew;
            this.cmbAmbiente.FormattingEnabled = true;
            this.cmbAmbiente.Location = new System.Drawing.Point(11, 115);
            this.cmbAmbiente.Name = "cmbAmbiente";
            this.cmbAmbiente.Size = new System.Drawing.Size(158, 21);
            this.cmbAmbiente.TabIndex = 3;
            // 
            // mtxtDataFinal
            // 
            this.mtxtDataFinal.BackColor = System.Drawing.Color.Honeydew;
            this.mtxtDataFinal.Location = new System.Drawing.Point(117, 209);
            this.mtxtDataFinal.Mask = "00/00/0000 90:00";
            this.mtxtDataFinal.Name = "mtxtDataFinal";
            this.mtxtDataFinal.Size = new System.Drawing.Size(100, 20);
            this.mtxtDataFinal.TabIndex = 6;
            this.mtxtDataFinal.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data Final";
            // 
            // mtxtDataInicio
            // 
            this.mtxtDataInicio.BackColor = System.Drawing.Color.Honeydew;
            this.mtxtDataInicio.Location = new System.Drawing.Point(11, 209);
            this.mtxtDataInicio.Mask = "00/00/0000 90:00";
            this.mtxtDataInicio.Name = "mtxtDataInicio";
            this.mtxtDataInicio.Size = new System.Drawing.Size(100, 20);
            this.mtxtDataInicio.TabIndex = 5;
            this.mtxtDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.Honeydew;
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(117, 32);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(207, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigo.Location = new System.Drawing.Point(11, 32);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // FormPlano2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(357, 320);
            this.Controls.Add(this.panel1);
            this.Name = "FormPlano2";
            this.Text = "Detalhes do Plano";
            this.Load += new System.EventHandler(this.FormPlano2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxtDataFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtDataInicio;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodAtividade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbAmbiente;
    }
}