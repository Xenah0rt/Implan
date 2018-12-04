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
    public partial class FormItemConf1 : Form
    {
        BD banco = new BD();

        //Limpa os campos do painel
        private void limpar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            cmbAmbiente.Text = "";
            cmbCategoria.Text = "";
        }

        //Preenche os comboboxes de categoria e ambiente
        private void combo()
        {
            cmbCategoria.Items.Clear();
            cmbAmbiente.Items.Clear();
            NpgsqlConnection conn;
            conn = banco.ini;

            string sql_amb = "select * from ambiente";
            string sql_amb_aux = "";

            string sql_cat = "select * from categoria";
            string sql_cat_aux = "";

            NpgsqlDataReader amb, cat;

            NpgsqlCommand query_amb = new NpgsqlCommand(sql_amb, conn);
            NpgsqlCommand query_cat = new NpgsqlCommand(sql_cat, conn);

            try
            {
                conn.Open();
                amb = query_amb.ExecuteReader();

                while (amb.HasRows)
                {
                    amb.Read();
                    cmbAmbiente.Items.Add(amb["codigo_ambiente"].ToString() + " - " + amb["nome_ambiente"].ToString());
                }
                amb.Close();

                cat = query_cat.ExecuteReader();

                while (cat.HasRows)
                {
                    cat.Read();
                    cmbCategoria.Items.Add(cat["codigo_categoria"].ToString() + " - " + cat["nome_categoria"].ToString());
                }
                cat.Close();

                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não há ambientes ou categorias cadastrados");
            }
        }

        //Preenche o grid de acordo com os registros do banco de dados e o filtro selecionado
        private void grid()
        {

            dgvItemConf.Rows.Clear();

            NpgsqlConnection conn;
            conn = banco.ini;
            conn.Open();

            string query_ic = "select i.codigo_ic, i.nome_ic, c.nome_categoria, a.nome_ambiente from item_conf i inner join categoria c on i.codigo_categoria = c.codigo_categoria inner join ambiente a on i.codigo_ambiente = a.codigo_ambiente";
            string query_ic_aux = "";

            int codigo = 0;
            if (!Int32.TryParse(txtPesquisar.Text, out codigo))
            {
                codigo = -1;
            }

            if (txtPesquisar.Text == "")
            {
                query_ic = query_ic + " order by codigo_ic";
            }
            else
            {
                query_ic_aux = " where nome_ic LIKE '%" + txtPesquisar.Text + "%' or codigo_ic =" + codigo;
                query_ic = query_ic + query_ic_aux + " order by codigo_ic";
            }

            NpgsqlCommand query = new NpgsqlCommand(query_ic, conn);
            NpgsqlCommand query2 = new NpgsqlCommand("select count (codigo_ic) from item_conf" + query_ic_aux + "", conn);
            NpgsqlDataReader ic, count;

            ic = query.ExecuteReader();

            while (ic.HasRows)
            {
                ic.Read();
                dgvItemConf.Rows.Add(ic["codigo_ic"].ToString(), ic["nome_ic"].ToString(), ic["nome_categoria"].ToString(), ic["nome_ambiente"].ToString());
            }
            ic.Close();
            query.Dispose();

            count = query2.ExecuteReader();
            count.Read();
            if (count["count"].ToString() != "1")
            {
                lblcont.Text = count["count"].ToString() + " Itens de configuração cadastrados";
            }
            else
            {
                lblcont.Text = count["count"].ToString() + " Item de configuração cadastrado";
            }
            count.Close();
            query2.Dispose();


            conn.Close();
            conn.Dispose();
        }

        //Verifica se existem ambientes cadastrados, senão oferece a opção de cadastrar
        private void checkreq_amb()
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn = banco.ini;
            DataSet ds = new DataSet();
            string query_amb = "select count(*) from ambiente";

            try
            {
                conn.Open();
                NpgsqlDataAdapter amb = new NpgsqlDataAdapter(query_amb, conn);
                amb.Fill(ds, "ambiente");
                conn.Close();

                if (ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1]["count"].ToString() == "0")
                {
                    DialogResult decisao = MessageBox.Show("Não há ambientes cadastrados. Deseja cadastrar agora?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (decisao == DialogResult.Yes)
                    {
                        FormAmbiente1 formAmbiente1 = new FormAmbiente1();
                        formAmbiente1.ShowDialog();
                        amb.Dispose();
                        conn.Dispose();
                        query_amb = null;
                        amb = null;
                        conn = null;
                        combo();
                        checkreq_amb();
                    }
                    else
                    {
                        MessageBox.Show("É necessário cadastrar ao menos um ambiente para registrar novos itens de configuração!");
                        amb.Dispose();
                        conn.Dispose();
                        query_amb = null;
                        amb = null;
                        conn = null;
                        grid();
                        panel1.Enabled = false;
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        //Verifica se existem categorias cadastradas, senão oferece a opção de cadastrar
        private void checkreq_cat()
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn = banco.ini;
            DataSet ds = new DataSet();
            string query_cat = "select count(*) from categoria";


            try
            {
                conn.Open();
                NpgsqlDataAdapter cat = new NpgsqlDataAdapter(query_cat, conn);
                cat.Fill(ds, "categoria");
                conn.Close();

                if (ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["count"].ToString() == "0")
                {
                    DialogResult decisao = MessageBox.Show("Não há categorias cadastradas. Deseja cadastrar agora?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (decisao == DialogResult.Yes)
                    {
                        FormCategoria1 formCategoria1 = new FormCategoria1();
                        formCategoria1.ShowDialog();
                        cat.Dispose();
                        conn.Dispose();
                        query_cat = null;
                        cat = null;
                        conn = null;
                        combo();
                        checkreq_cat();
                    }
                    else
                    {
                        MessageBox.Show("É necessário cadastrar ao menos uma categoria para registrar novos itens de configuração!");
                        cat.Dispose();
                        conn.Dispose();
                        query_cat = null;
                        cat = null;
                        conn = null;
                        grid();
                        panel1.Enabled = false;
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        public FormItemConf1()
        {
            InitializeComponent();
        }

        //Salva os valores selecionados no painel
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Insira o nome do Item!");
                return;
            }

            if (Convert.ToString(cmbAmbiente.SelectedItem) == "")
            {
                MessageBox.Show("Selecione um ambiente válido!");
                return;
            }

            if (Convert.ToString(cmbCategoria.SelectedItem) == "")
            {
                MessageBox.Show("Selecione uma categoria válida!");
                return;
            }

            string selectAmb = Convert.ToString(cmbAmbiente.SelectedItem);
            selectAmb = (selectAmb.Split(' ')[0]);
            string selectCat = Convert.ToString(cmbCategoria.SelectedItem);
            selectCat = (selectCat.Split(' ')[0]);

            string query_string;
            NpgsqlConnection conn = banco.ini;

            if (txtCodigo.Text.Trim() == "")
            {
                query_string = "insert into item_conf values (DEFAULT, " + selectAmb + ", " + selectCat + ", '" + txtNome.Text.ToUpper().Trim() + "')";
            }
            else
            {
                query_string = "update item_conf set nome_ic = '" + txtNome.Text.ToUpper().Trim() + "', codigo_ambiente = " + selectAmb + ", codigo_categoria = " + selectCat + " where codigo_ic = " + txtCodigo.Text;
            }
            NpgsqlCommand query = new NpgsqlCommand(query_string, conn);
            NpgsqlDataReader salvar;
            Console.WriteLine(query_string);
            conn.Open();
            try
            {
                salvar = query.ExecuteReader();
                panel1.Enabled = false;
                limpar();
                grid();
                dgvItemConf.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o item de configuração: " + ex);
            }

            conn.Close();
            conn.Dispose();
            return;
        }

        //Ações executadas ao carregar o form
        private void FormItemConf1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            limpar();
            grid();
            dgvItemConf.ClearSelection();
            panel1.Enabled = false;
        }

        //Habilita os campos para criar novo item de configuração
        private void btnNovo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtCodigo.Enabled = false;
            txtNome.Focus();
            limpar();
            combo();
            checkreq_amb();
            checkreq_cat();
        }

        //Cancela a operação em andamento
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpar();
            grid();
            panel1.Enabled = false;
            txtPesquisar.Focus();
        }

        //Filtra o grid de acordo com o texto pesquisado
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            grid();
        }

        //Exclui o record selecionado e os filhos
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult decisao;
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhum item selecionado para exclusão");
                return;
            }
            else
            {
                decisao = MessageBox.Show("Deseja mesmo excluir o item selecionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decisao == DialogResult.Yes)
                {
                    NpgsqlConnection conn = banco.ini;
                    conn.Open();
                    NpgsqlCommand query = new NpgsqlCommand("delete from item_conf where codigo_ic = " + txtCodigo.Text, conn);
                    NpgsqlDataReader excluir;

                    try
                    {
                        excluir = query.ExecuteReader();
                        panel1.Enabled = false;
                        limpar();
                        grid();
                        dgvItemConf.Enabled = true;
                        txtPesquisar.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível excluir o item! " + ex);
                    }
                    conn.Close();
                    conn.Dispose();
                }
                else
                {
                    return;
                }
            }
        }

        //Preenche os campos do painel de acordo com o item de configuração selecionado no grid
        private void dgvItemConf_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItemConf.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvItemConf.SelectedRows[0];
                NpgsqlConnection conn;
                conn = banco.ini;
                conn.Open();

                string selectaux = Convert.ToString(select.Cells["colCodigo"].Value);

                NpgsqlDataReader preenc;
                NpgsqlCommand cmdSelecGrid = new NpgsqlCommand("select i.codigo_ic, i.nome_ic, c.codigo_categoria, c.nome_categoria, a.codigo_ambiente, a.nome_ambiente from item_conf i, categoria c, ambiente a where i.codigo_ambiente = a.codigo_ambiente and i.codigo_categoria = c.codigo_categoria and codigo_ic = " + selectaux + ";", conn); //+ Convert.ToInt32(selectaux) + ";", conn);

                preenc = cmdSelecGrid.ExecuteReader();

                if (preenc.HasRows == true)
                {
                    preenc.Read();
                    txtCodigo.Text = preenc["codigo_ic"].ToString();
                    txtNome.Text = preenc["nome_ic"].ToString();
                    cmbAmbiente.Text = preenc["codigo_ambiente"].ToString() + " - " + preenc["nome_ambiente"].ToString();
                    cmbCategoria.Text = preenc["codigo_categoria"].ToString() + " - " + preenc["nome_categoria"].ToString();

                    preenc.Close();
                    cmdSelecGrid.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }
        }

        //Habilita o item de configuração selecionado para alteração
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhum item selecionado para alteração");
                return;
            }
            panel1.Enabled = true;
            txtCodigo.Enabled = false;
            combo();
            cmbAmbiente.SelectedItem = cmbAmbiente.Text;
            cmbCategoria.SelectedItem = cmbCategoria.Text;
        }

        //Fecha o form atual e retorna ao form de origem
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Determina o modo de seleção do grid
        private void dgvItemConf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvItemConf.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
