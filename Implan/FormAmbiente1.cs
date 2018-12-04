using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Implan
{
    public partial class FormAmbiente1 : Form
    {
        BD banco = new BD();

        public FormAmbiente1()
        {
            InitializeComponent();
        }

        //Função para limpar os campos preenchíveis
        private void limpar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }

        //Função para preencher o grid
        private void grid()
        {

            dgvAmbiente.Rows.Clear();

            NpgsqlConnection conn;
            conn = banco.ini;
            conn.Open();

            string query_ambiente = "select * from ambiente";
            string query_ambiente_aux = "";

            int codigo = 0;
            if (!Int32.TryParse(txtPesquisar.Text, out codigo))
            {
                codigo = -1;
            }

            if (txtPesquisar.Text == "")
            {
                query_ambiente = query_ambiente + " order by codigo_ambiente";
            }
            else
            {
                query_ambiente_aux = " where nome_ambiente LIKE '%" + txtPesquisar.Text + "%' or codigo_ambiente =" + codigo;
                query_ambiente = query_ambiente + query_ambiente_aux + " order by codigo_ambiente";
            }

            NpgsqlCommand query = new NpgsqlCommand(query_ambiente, conn);
            NpgsqlCommand query2 = new NpgsqlCommand("select count (codigo_ambiente) from ambiente"+query_ambiente_aux+"", conn);
            NpgsqlDataReader ambiente, count;

            ambiente = query.ExecuteReader();

            while (ambiente.HasRows)
            {
                ambiente.Read();
                dgvAmbiente.Rows.Add(ambiente["codigo_ambiente"].ToString(), ambiente["nome_ambiente"].ToString());
            }
            ambiente.Close();
            query.Dispose();

            count = query2.ExecuteReader();
            count.Read();
            if (count["count"].ToString() != "1")
            {
                lblcont.Text = count["count"].ToString() +" ambientes cadastrados";
            }
            else
            {
                lblcont.Text = count["count"].ToString() + " ambiente cadastrado";
            }
            count.Close();
            query2.Dispose();

            
            conn.Close();
            conn.Dispose();
        }

        //Checa itens de configuração filhos e exclui junto com o ambiente
        private void checkreq_ic()
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn = banco.ini;

            try
            {
                DialogResult decisao = MessageBox.Show("Isso também irá excluir todos os itens de configuração e planos ligados ao ambiente selecionado. Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decisao == DialogResult.Yes)
                {
                    conn.Open();
                    NpgsqlCommand query = new NpgsqlCommand("delete from item_conf where codigo_ambiente = " + txtCodigo.Text, conn);
                    NpgsqlCommand query2 = new NpgsqlCommand("delete from ambiente where codigo_ambiente = " + txtCodigo.Text, conn);
                    NpgsqlCommand query_inst = new NpgsqlCommand("delete from plano_inst where codigo_plano in (select codigo_plano from plano where codigo_ambiente = " + txtCodigo.Text + ")", conn);
                    NpgsqlCommand query_plano = new NpgsqlCommand("delete from plano where codigo_ambiente = " + txtCodigo.Text, conn);
                    NpgsqlDataReader excluir, excluir2, excluir_inst, excluir_plano;
            
                    try
                    {
                        excluir_inst = query_inst.ExecuteReader();
                        excluir_plano = query_plano.ExecuteReader();
                        excluir = query.ExecuteReader();
                        excluir2 = query2.ExecuteReader();
                        panel1.Enabled = false;
                        limpar();
                        grid();
                        dgvAmbiente.Enabled = true;
                        conn.Close();
                        conn.Dispose();
                        excluir.Close();
                        excluir2.Close();
                        excluir_plano.Close();
                        excluir_inst.Close();
                        query.Dispose();
                        query2.Dispose();
                        query_inst.Dispose();
                        query_plano.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível excluir os itens de configuração! " + ex);
                        conn.Close();
                        conn.Dispose();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir: " + ex);
            }
        }

        //Determina o modo de seleção do grid
        private void dgvAmbiente_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
            dgvAmbiente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Seleciona a linha do grid ao clicar em uma célula
        private void dgvAmbiente_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvAmbiente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Chama a função grid a cada vez que o txtPesquisa é atualizado
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            grid();
        }

        //Salva os valores preenchidos no panel1
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Insira o nome do Ambiente!");
                return;          
            }

            string query_string;
            NpgsqlConnection conn = banco.ini;
            conn.Open();

            if (txtCodigo.Text.Trim() == "")
            {
                query_string = "insert into ambiente values (DEFAULT, '" + txtNome.Text.ToUpper().Trim() + "')";
            }
            else
            {
                query_string = "update ambiente set nome_ambiente = '" + txtNome.Text.ToUpper().Trim() + "' where codigo_ambiente = "+ txtCodigo.Text;
            }
            NpgsqlCommand query = new NpgsqlCommand(query_string, conn);
            NpgsqlDataReader salvar;

            try
            {
                salvar = query.ExecuteReader();
                panel1.Enabled = false;
                limpar();
                grid();
                dgvAmbiente.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o ambiente!");
            }
            conn.Close();
            conn.Dispose();
        }

        //Fecha o form atual e retorna ao form inicial
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Funções executadas ao carregar o form
        private void FormAmbiente1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            panel1.Enabled = false;
            grid();
            dgvAmbiente.ClearSelection();
            limpar();
        }

        //constructor não utilizado
        private void dgvAmbiente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Função roda ao mudar a linha selecionada do grid e preencher os campos do painel
        private void dgvAmbiente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAmbiente.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvAmbiente.SelectedRows[0];
                NpgsqlConnection conn;
                conn = banco.ini;
                conn.Open();

                string selectaux = Convert.ToString(select.Cells["colCodigo"].Value);

                NpgsqlDataReader preenc;
                NpgsqlCommand cmdSelecGrid = new NpgsqlCommand("select * from ambiente where codigo_ambiente = " + selectaux + ";", conn); //+ Convert.ToInt32(selectaux) + ";", conn);

                preenc = cmdSelecGrid.ExecuteReader();

                if (preenc.HasRows == true)
                {
                    preenc.Read();
                    txtCodigo.Text = preenc["codigo_ambiente"].ToString();
                    txtNome.Text = preenc["nome_ambiente"].ToString();
                    preenc.Close();
                    cmdSelecGrid.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }
        }

        //Habilita os campos do painel para inserção de um novo ambiente
        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
            dgvAmbiente.Enabled = false;
            panel1.Enabled = true;
            txtCodigo.Enabled = false;
            label1.Enabled = false;
            dgvAmbiente.ClearSelection();
            txtNome.Focus();
        }

        //Cancela a operação em andamento
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            dgvAmbiente.Enabled = true;
            txtPesquisar.Focus();
        }

        //Exclui o ambiente selecionado no grid
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult decisao;
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhum ambiente selecionado para exclusão");
                return;
            }
            else
            {
                decisao = MessageBox.Show("Deseja mesmo excluir o ambiente selecionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decisao == DialogResult.Yes)
                {
                    checkreq_ic();
                }
                else
                {
                    return;
                }
            }
        }

        //Habilita o ambiente selecionado para alteração
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhum ambiente selecionado para alteração");
                return;
            }
            panel1.Enabled = true;
            txtCodigo.Enabled = false;
        }

        //constructor grid
        private void dgvAmbiente_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvAmbiente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //constructor grid
        private void dgvAmbiente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAmbiente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
