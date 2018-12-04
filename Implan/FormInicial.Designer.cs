namespace Implan
{
    partial class FormInicial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAmb = new System.Windows.Forms.Button();
            this.btnPlano = new System.Windows.Forms.Button();
            this.btnIC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAmb
            // 
            this.btnAmb.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmb.Location = new System.Drawing.Point(12, 60);
            this.btnAmb.Name = "btnAmb";
            this.btnAmb.Size = new System.Drawing.Size(75, 51);
            this.btnAmb.TabIndex = 0;
            this.btnAmb.Text = "Gerenciar Ambientes";
            this.btnAmb.UseVisualStyleBackColor = false;
            this.btnAmb.Click += new System.EventHandler(this.btnAmb_Click);
            // 
            // btnPlano
            // 
            this.btnPlano.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPlano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlano.Location = new System.Drawing.Point(116, 60);
            this.btnPlano.Name = "btnPlano";
            this.btnPlano.Size = new System.Drawing.Size(82, 51);
            this.btnPlano.TabIndex = 1;
            this.btnPlano.Text = "Gerenciar Planos";
            this.btnPlano.UseVisualStyleBackColor = false;
            this.btnPlano.Click += new System.EventHandler(this.btnPlano_Click);
            // 
            // btnIC
            // 
            this.btnIC.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIC.Location = new System.Drawing.Point(222, 60);
            this.btnIC.Name = "btnIC";
            this.btnIC.Size = new System.Drawing.Size(86, 51);
            this.btnIC.TabIndex = 2;
            this.btnIC.Text = "Gerenciar Itens de Configuração";
            this.btnIC.UseVisualStyleBackColor = false;
            this.btnIC.Click += new System.EventHandler(this.btnIC_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seja Bem Vindo ao Implan!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoria.Location = new System.Drawing.Point(116, 129);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(82, 51);
            this.btnCategoria.TabIndex = 4;
            this.btnCategoria.Text = "Gerenciar Categorias de IC";
            this.btnCategoria.UseVisualStyleBackColor = false;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(320, 192);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIC);
            this.Controls.Add(this.btnPlano);
            this.Controls.Add(this.btnAmb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormInicial";
            this.Text = "Gerenciador de Planos";
            this.Load += new System.EventHandler(this.FormInicial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAmb;
        private System.Windows.Forms.Button btnPlano;
        private System.Windows.Forms.Button btnIC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCategoria;
    }
}

