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
    public partial class FormPlano2 : Form
    {
        BD banco = new BD();

        public FormPlano2(string cod)
        {
            InitializeComponent();
            txtCodigo.Text = cod;
        }

        //Função para atualizar a data final do plano de acordo com o tempo estimado das instruções. atualiza com o valor da data inicial caso não haja instruções cadastradas
        private void data()
        {
            NpgsqlConnection conn_data;
            conn_data = banco.ini;
            NpgsqlCommand query_inst = new NpgsqlCommand("select 1 from plano_inst where codigo_plano = " + txtCodigo.Text, conn_data);
            
            NpgsqlDataReader plano_fim, checa_inst;

            try
            {
                conn_data.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex);
                return;
            }

            try
            {
                checa_inst = query_inst.ExecuteReader();
                if (checa_inst.HasRows)
                {
                    checa_inst.Close();
                    query_inst.Dispose();
                    NpgsqlCommand query_tempo = new NpgsqlCommand("update plano set data_fim = (data_inicio + (select sum(pi.tempo_est) from plano_inst pi where pi.codigo_plano = " + txtCodigo.Text + ")) where codigo_plano = " + txtCodigo.Text, conn_data);
                    plano_fim = query_tempo.ExecuteReader();
                    plano_fim.Close();
                    query_tempo.Dispose();
                    conn_data.Close();
                    conn_data.Dispose();
                }
                else
                {
                    checa_inst.Close();
                    query_inst.Dispose();
                    NpgsqlCommand query_tempo = new NpgsqlCommand("update plano set data_fim = data_inicio where codigo_plano = " + txtCodigo.Text, conn_data);
                    plano_fim = query_tempo.ExecuteReader();
                    plano_fim.Close();
                    query_tempo.Dispose();
                    conn_data.Close();
                    conn_data.Dispose();
                }
   
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Não foi possível atualizar a data final do plano:" + ex);
                conn_data.Close();
                conn_data.Dispose();
            }
        }

        //Preenche os campos de acordo com o plano selecionado no form anterior (txtCodigo)
        private void preencher()
        {
            if (txtCodigo.Text.Trim() == "")
            {
                return;
            }
            else
            {
                NpgsqlConnection conn;
                conn = banco.ini;
                conn.Open();

                NpgsqlDataReader preenc;
                NpgsqlCommand cmdSelec = new NpgsqlCommand("select p.*, a.nome_ambiente from plano p, ambiente a where a.codigo_ambiente = p.codigo_ambiente and p.codigo_plano = " + txtCodigo.Text , conn);

                try
                {
                    preenc = cmdSelec.ExecuteReader();

                    if (preenc.HasRows == true)
                    {
                        preenc.Read();
                        txtCodigo.Text = preenc["codigo_plano"].ToString();
                        txtNome.Text = preenc["nome_plano"].ToString();
                        cmbAmbiente.Text = preenc["codigo_ambiente"].ToString() + " - " + preenc["nome_ambiente"].ToString();
                        txtCodAtividade.Text = preenc["codigo_atividade"].ToString();
                        mtxtDataInicio.Text = preenc["data_inicio"].ToString();
                        mtxtDataFinal.Text = preenc["data_fim"].ToString();

                        preenc.Close();
                        cmdSelec.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível recuperar os dados para alteração! " + ex);
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        //Preenche o combobox de ambiente
        private void combo()
        {
            cmbAmbiente.Items.Clear();
            NpgsqlConnection conn;
            conn = banco.ini;

            string sql_amb = "select * from ambiente";
            string sql_amb_aux = "";

            NpgsqlDataReader amb;

            NpgsqlCommand query_amb = new NpgsqlCommand(sql_amb, conn);

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

                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não há ambientes cadastrados");
                conn.Close();
            }
        }

        //Verifica se há ambiente cadastrados, senão, oferece a opção de cadastramento
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

                if (ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["count"].ToString() == "0")
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
                        MessageBox.Show("É necessário cadastrar ao menos um ambiente para criar novos planos!");
                        amb.Dispose();
                        conn.Dispose();
                        query_amb = null;
                        amb = null;
                        conn = null;
                        panel1.Enabled = false;
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        //NA
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Cancela a operação em andamento e retorna ao form de seleção de planos
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            DialogResult decisao;
            decisao = MessageBox.Show("Deseja cancelar a operação?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (decisao == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        //NA
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Ações executadas ao carregar o form
        private void FormPlano2_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            mtxtDataFinal.Enabled = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            combo();
            checkreq_amb();
            preencher();
        }

        //Salva o plano inserido e segue para a tela de cadastro de instruções do plano
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == "" || Convert.ToString(cmbAmbiente.SelectedItem) == "" || txtCodAtividade.Text.Trim() == "" || /*mtxtDataFinal.MaskFull == false ||*/ mtxtDataInicio.MaskFull == false)
            {
                MessageBox.Show("Por favor, preencha todos os campos!");
                return;
            }

            try
            {
                Convert.ToDateTime(mtxtDataInicio.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, forneça uma data de início válida");
                return;
            }

            /*try
            {
                if (Convert.ToDateTime(mtxtDataFinal.Text) < Convert.ToDateTime(mtxtDataInicio.Text))
                {
                    MessageBox.Show("A data final deve ser após a data de início");
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, forneça uma data final válida.");
                return;
            }*/


            string selectAmb = Convert.ToString(cmbAmbiente.SelectedItem);
            selectAmb = (selectAmb.Split(' ')[0]);

            string query_string;
            NpgsqlConnection conn = banco.ini;

            if (txtCodigo.Text.Trim() == "")
            {
                query_string = "insert into plano values (DEFAULT, " + selectAmb + ", '" + txtCodAtividade.Text.ToUpper() + "', '" + txtNome.Text.ToUpper() + "', '" + mtxtDataInicio.Text + "', '" + mtxtDataInicio.Text + "', FALSE)";
            }
            else
            {
                query_string = "update plano set nome_plano = '" + txtNome.Text.ToUpper() + "', codigo_ambiente = " + selectAmb + ", codigo_atividade = '" + txtCodAtividade.Text.ToUpper() + "', data_inicio = '" + mtxtDataInicio.Text + "' where codigo_plano = " + txtCodigo.Text;
            }

            NpgsqlCommand query = new NpgsqlCommand(query_string, conn);
            NpgsqlDataReader salvar;

            conn.Open();
            try
            {
                salvar = query.ExecuteReader();
                conn.Close();
                conn.Dispose();

                // Verifica se o valor do código foi passado. Caso seja um novo plano, consulta o ultimo codigo inserido na tabela plano.
                if (txtCodigo.Text == "")
                {
                    NpgsqlConnection conn_id;
                    conn_id = banco.ini;
                    NpgsqlCommand query_id = new NpgsqlCommand("select codigo_plano from plano order by codigo_plano desc limit 1", conn_id);
                    NpgsqlDataReader id;


                    conn_id.Open();

                    try
                    {
                        id = query_id.ExecuteReader();
                        if (id.HasRows)
                        {
                            id.Read();
                            txtCodigo.Text = id["codigo_plano"].ToString();
                            conn_id.Close();
                            conn_id.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Não existe nenhum plano cadastrado. Erro!");
                            conn_id.Close();
                            conn_id.Dispose();
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar o plano: " + ex);
                        conn_id.Close();
                        conn_id.Dispose();
                        this.Close();
                    }
                }

                FormPlano3 formPlano3 = new FormPlano3(txtCodigo.Text, selectAmb);
                formPlano3.Text = txtNome.Text;
                formPlano3.ShowDialog();
                data();
                //preencher();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o plano:" + ex);
                conn.Close();
                conn.Dispose();
            }

            return;
        }
    }
}
