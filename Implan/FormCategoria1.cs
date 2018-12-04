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
    public partial class FormCategoria1 : Form
    {
        BD banco = new BD();

        public FormCategoria1()
        {
            InitializeComponent();
        }

        //Limpa os campos do painel
        private void limpar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }

        //Preenche o grid de acordo com o banco de dados ou o filtro do txtPesquisa
        private void grid()
        {

            dgvCategoria.Rows.Clear();
            dgvCategoria.BackgroundColor = Color.White;
            NpgsqlConnection conn;
            conn = banco.ini;
            conn.Open();

            string query_categoria = "select * from categoria";
            string query_categoria_aux = "";

            int codigo = 0;
            if (!Int32.TryParse(txtPesquisar.Text, out codigo))
            {
                codigo = -1;
            }

            if (txtPesquisar.Text == "")
            {
                query_categoria = query_categoria + " order by codigo_categoria ";
            }
            else
            {
                query_categoria_aux = " where nome_categoria LIKE '%" + txtPesquisar.Text + "%' or codigo_categoria =" + codigo;
                query_categoria = query_categoria + query_categoria_aux + " order by codigo_categoria";
            }

            NpgsqlCommand query = new NpgsqlCommand(query_categoria, conn);
            NpgsqlCommand query2 = new NpgsqlCommand("select count (codigo_categoria) from categoria" + query_categoria_aux + "", conn);
            NpgsqlDataReader categoria, count;

            categoria = query.ExecuteReader();

            while (categoria.HasRows)
            {
                categoria.Read();
                dgvCategoria.Rows.Add(categoria["codigo_categoria"].ToString(), categoria["nome_categoria"].ToString());
            }
            categoria.Close();
            query.Dispose();

            count = query2.ExecuteReader();
            count.Read();
            if (count["count"].ToString() != "1")
            {
                lblcont.Text = count["count"].ToString() + " categorias cadastrados";
            }
            else
            {
                lblcont.Text = count["count"].ToString() + " categoria cadastrado";
            }
            count.Close();
            query2.Dispose();


            conn.Close();
            conn.Dispose();
        }

        //Checa e exclui itens de configuração filhos da categoria
        private void checkreq_ic()
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn = banco.ini;

            try
            {
                DialogResult decisao = MessageBox.Show("Isso também irá excluir todos os itens de configuração relacionados à categoria selecionada. Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decisao == DialogResult.Yes)
                {
                    conn.Open();
                    NpgsqlCommand query = new NpgsqlCommand("delete from item_conf where codigo_categoria = " + txtCodigo.Text, conn);
                    NpgsqlCommand query2 = new NpgsqlCommand("delete from categoria where codigo_categoria = " + txtCodigo.Text, conn);
                    NpgsqlCommand query_inst = new NpgsqlCommand("update plano_inst set codigo_categoria = null where codigo_categoria = " + txtCodigo.Text, conn);
                    NpgsqlDataReader excluir, excluir2, excluir_inst;

                    try
                    {
                        excluir = query.ExecuteReader();
                        excluir_inst = query_inst.ExecuteReader();
                        excluir2 = query2.ExecuteReader();
                        panel1.Enabled = false;
                        limpar();
                        grid();
                        dgvCategoria.Enabled = true;
                        conn.Close();
                        conn.Dispose();
                        excluir.Close();
                        excluir2.Close();
                        excluir_inst.Close();
                        query.Dispose();
                        query2.Dispose();
                        query_inst.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível excluir os registros! " + ex);
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
                MessageBox.Show("Erro: " + ex);
            }
        }

        //Salva os dados inseridos no banco de dados
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Insira o nome da Categoria!");
                return;
            }

            string query_string;
            NpgsqlConnection conn = banco.ini;
            conn.Open();

            if (txtCodigo.Text.Trim() == "")
            {
                query_string = "insert into categoria values (DEFAULT, '" + txtNome.Text.ToUpper().Trim() + "')";
            }
            else
            {
                query_string = "update categoria set nome_categoria = '" + txtNome.Text.ToUpper().Trim() + "' where codigo_categoria = " + txtCodigo.Text;
            }
            NpgsqlCommand query = new NpgsqlCommand(query_string, conn);
            NpgsqlDataReader salvar;

            try
            {
                salvar = query.ExecuteReader();
                panel1.Enabled = false;
                limpar();
                grid();
                dgvCategoria.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar a categoria! " + ex);
            }

            conn.Close();
            conn.Dispose();
        }

        //Cancela a operação em andamento
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            dgvCategoria.Enabled = true;
        }

        //Fecha o form atual e retorna ao form inicial
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Ações realizadas ao carregar o form
        private void FormCategoria1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            panel1.Enabled = false;
            grid();
            dgvCategoria.ClearSelection();
            limpar();
        }

        //Preenche os campos do painel de acordo com a linha selecionada do grid
        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvCategoria.SelectedRows[0];
                NpgsqlConnection conn;
                conn = banco.ini;
                conn.Open();

                string selectaux = "0";
                if (Convert.ToString(select.Cells["colCodigo"].Value) != "")
                {
                    selectaux = Convert.ToString(select.Cells["colCodigo"].Value);
                }
                NpgsqlDataReader preenc;
                NpgsqlCommand cmdSelecGrid = new NpgsqlCommand("select * from Categoria where codigo_Categoria = " + selectaux , conn); //+ Convert.ToInt32(selectaux) + ";", conn);

                preenc = cmdSelecGrid.ExecuteReader();

                if (preenc.HasRows == true)
                {
                    preenc.Read();
                    txtCodigo.Text = preenc["codigo_Categoria"].ToString();
                    txtNome.Text = preenc["nome_Categoria"].ToString();
                    preenc.Close();
                    cmdSelecGrid.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }
        }

        //NA
        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //NA
        private void dgvCategoria_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        //Habilita os campos do painel para inserir nova categoria
        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
            dgvCategoria.Enabled = false;
            panel1.Enabled = true;
            txtCodigo.Enabled = false;
            label1.Enabled = false;
            dgvCategoria.ClearSelection();
        }

        //Habilita a categoria selecionada para alteração
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhuma categoria selecionada para alteração");
                return;
            }
            panel1.Enabled = true;
            txtCodigo.Enabled = false;
        }

        //Exclui a categoria selecionada e registros filhos
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult decisao;
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhuma categoria selecionada para exclusão");
                return;
            }
            else
            {
                string codigo = txtCodigo.Text;
                decisao = MessageBox.Show("Deseja mesmo excluir a categoria selecionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        //Preenche o grid de acordo com o texto inserido na barra de pesquisa
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            grid();
        }
    }
}
