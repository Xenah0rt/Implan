using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Implan
{
    public partial class FormInicial : Form
    {
        public FormInicial()
        {
            InitializeComponent();
        }

        //Funções executadas ao carregar o form
        private void FormInicial_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Abre o form de gerenciamento de planos
        private void btnPlano_Click(object sender, EventArgs e)
        {
            FormPlano1 formPlano1 = new FormPlano1();
            formPlano1.ShowDialog();
        }

        //Abre o form de gerenciamento de ambientes
        private void btnAmb_Click(object sender, EventArgs e)
        {
            FormAmbiente1 formAmbiente1 = new FormAmbiente1();
            formAmbiente1.ShowDialog();   
        }

        //Abre o form de gerenciamento de Itens de Configuração
        private void btnIC_Click(object sender, EventArgs e)
        {
            FormItemConf1 formItemConf1 = new FormItemConf1();
            formItemConf1.ShowDialog();
        }

        //Abre o form de gerenciamento de Categorias de itens de configuração
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FormCategoria1 formCategoria1 = new FormCategoria1();
            formCategoria1.ShowDialog();
        }
    }
}
