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
    public partial class FormPlano1 : Form
    {
        BD banco = new BD();

        public FormPlano1()
        {
            InitializeComponent();
        }

        //Função para alterar o status do plano de acordo com o status das instruções
        private void update_status(string cod)
        {
            NpgsqlConnection conn_status;
            conn_status = banco.ini;
            NpgsqlCommand query_status = new NpgsqlCommand("select 1 from plano_inst where codigo_plano = " + cod + " and status = FALSE", conn_status);
            NpgsqlCommand query_true = new NpgsqlCommand("update plano set status = TRUE where codigo_plano = "+ cod ,conn_status);
            NpgsqlCommand query_false = new NpgsqlCommand("update plano set status = FALSE where codigo_plano = " + cod, conn_status);

            NpgsqlDataReader plano_status, set_true, set_false ;

            try
            {
                conn_status.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex);
                return;
            }

            try
            {
                plano_status = query_status.ExecuteReader();
                if (plano_status.HasRows)
                {
                    plano_status.Close();
                    query_status.Dispose();
                    try
                    {
                        set_false = query_false.ExecuteReader();
                        conn_status.Close();
                        conn_status.Dispose();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar o status do plano! " + ex);
                        conn_status.Close();
                        conn_status.Dispose();
                        return;
                    }
                }
                else
                {
                    plano_status.Close();
                    query_status.Dispose();
                    try
                    {
                        set_true = query_true.ExecuteReader();
                        conn_status.Close();
                        conn_status.Dispose();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar o status do plano! " + ex);
                        conn_status.Close();
                        conn_status.Dispose();
                        return;
                    }
                }

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Não foi possível atualizar o status do plano:" + ex);
                conn_status.Close();
                conn_status.Dispose();
            }
        }

        //Função para preencher o grid. Caso o txt box de pesquisa seja preenchido, o grid será filtrado.
        private void grid()

        {
            dgvPlano.Rows.Clear();

            NpgsqlConnection conn;
            conn = banco.ini;
            conn.Open();

            string query_plano = "select p.codigo_plano, p.nome_plano, a.nome_ambiente, p.data_inicio, p.status from plano p inner join ambiente a on p.codigo_ambiente = a.codigo_ambiente ";
            string query_plano_aux = "";

            //
            int cnt = 0;
            if (ckbPend.Checked == true)
            {
                if (cnt == 0)
                {
                    query_plano_aux = query_plano_aux + "where (p.status = FALSE ";
                    cnt = 1;
                }
                else
                {
                    query_plano_aux = query_plano_aux + "or p.status = FALSE ";
                }
            }
            else
            {
                if (cnt == 0)
                {
                    query_plano_aux = query_plano_aux + " where (p.status = TRUE ";
                    cnt = 1;
                }
                else
                {
                    query_plano_aux = query_plano_aux + "or p.status = TRUE ";
                }
            }

            if (ckbArq.Checked == true)
            {
                if (cnt == 0)
                {
                    query_plano_aux = query_plano_aux + "where (p.status = TRUE ";
                    cnt = 1;
                }
                else
                {
                    query_plano_aux = query_plano_aux + "or p.status = TRUE ";
                }
            }
            else
            {
                if (cnt == 0)
                {
                    query_plano_aux = query_plano_aux + "where (p.status = FALSE ";
                    cnt = 1;
                }
                else
                {
                    query_plano_aux = query_plano_aux + "or p.status = FALSE ";
                }
            }
            //

            int codigo = 0;
            if (!Int32.TryParse(txtPesquisar.Text, out codigo))
            {
                codigo = -1;
            }

            if (txtPesquisar.Text == "")
            {
                query_plano_aux = query_plano_aux + ") ";
                query_plano = query_plano + query_plano_aux + " order by codigo_plano";
            }
            else
            {
                query_plano_aux = query_plano_aux + ") and nome_plano LIKE '%" + txtPesquisar.Text + "%' or codigo_plano =" + codigo;
                query_plano = query_plano + query_plano_aux + " order by codigo_plano";
            }

            NpgsqlCommand query = new NpgsqlCommand(query_plano, conn);
            NpgsqlCommand query2 = new NpgsqlCommand("select count (codigo_plano) from plano p " + query_plano_aux + "", conn);
            NpgsqlDataReader plano, count;
            plano = query.ExecuteReader();

            while (plano.HasRows)
            {
                plano.Read();
                string status = "";
                if (plano["status"].ToString() == "False")
                {
                    status = "Incompleto";
                }
                else
                {
                    status = "Completo";
                }

                dgvPlano.Rows.Add(plano["codigo_plano"].ToString(), plano["nome_plano"].ToString(), plano["nome_ambiente"].ToString(), plano["data_inicio"].ToString(), status);
            }
            plano.Close();
            query.Dispose();

            count = query2.ExecuteReader();
            count.Read();
            if (count["count"].ToString() != "1")
            {
                lblcont.Text = count["count"].ToString() + " planos cadastrados";
            }
            else
            {
                lblcont.Text = count["count"].ToString() + " plano cadastrado";
            }
            count.Close();
            query2.Dispose();


            conn.Close();
            conn.Dispose();
        }

        //Ações executadas ao carregar o form
        private void FormPlano1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            grid();
        }

        //Filtra o grid de acordo com o valor pesquisado
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            grid();
        }

        //Chama o form de cadastro de plano
        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormPlano2 formPlano2 = new FormPlano2("");
            formPlano2.ShowDialog();
            grid();
        }

        //Chama o form de cadastro para alteração do plano selecionado no grid
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvPlano.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvPlano.SelectedRows[0];
                string selectaux = Convert.ToString(select.Cells["colCodigo"].Value);
                FormPlano2 formPlano2 = new FormPlano2(selectaux);
                formPlano2.ShowDialog();
                update_status(selectaux);
                grid();
            }
            else
            {
                MessageBox.Show("Selecione um plano para alteração!");
                return;
            }
        }

        //Exclui o plano selecionado
        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (dgvPlano.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvPlano.SelectedRows[0];
                string selectaux = Convert.ToString(select.Cells["colCodigo"].Value);
                DialogResult decisao;

                decisao = MessageBox.Show("Deseja mesmo excluir o plano selecionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decisao == DialogResult.Yes)
                {
                    NpgsqlConnection conn = banco.ini;
                    conn.Open();
                    NpgsqlCommand query = new NpgsqlCommand("delete from plano where codigo_plano = " + selectaux, conn);
                    NpgsqlCommand query2 = new NpgsqlCommand("delete from plano_inst where codigo_plano = " + selectaux, conn);
                    NpgsqlDataReader excluir, excluir_inst;

                    try
                    {
                        excluir_inst = query2.ExecuteReader();
                        excluir = query.ExecuteReader();
                        grid();
                        txtPesquisar.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível excluir o plano! " + ex);
                    }
                    conn.Close();
                    conn.Dispose();
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("Selecione um plano para excluir!");
                return;
            }

            
        }

        //Chama o form de visualização do plano
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (dgvPlano.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvPlano.SelectedRows[0];
                string selectaux = Convert.ToString(select.Cells["colCodigo"].Value);
                string plano_nome = Convert.ToString(select.Cells["colNome"].Value);
                FormPlano4 formPlano4 = new FormPlano4(selectaux);
                formPlano4.Text = plano_nome;
                formPlano4.ShowDialog();
                update_status(selectaux);
                grid();
            }
            else
            {
                MessageBox.Show("Selecione um plano para visualizar!");
                return;
            }
        }

        //Fecha o form atual e retorna ao form inicial
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            grid();
        }

        private void ckbArq_CheckedChanged(object sender, EventArgs e)
        {
            grid();
        }
    }
}
