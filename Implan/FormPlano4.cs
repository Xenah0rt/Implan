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
    public partial class FormPlano4 : Form
    {
        BD banco = new BD();
        public string codigo;

        public FormPlano4(string cod)
        {
            InitializeComponent();
            codigo = cod;
        }

        //Função para alterar o status dos passos.
        private void update_status()
        {
            NpgsqlConnection conn_status;
            conn_status = banco.ini;
            NpgsqlDataReader set_status;

            if (codigo != "" && txtCodigo.Text != "")
            {
                if (ckbCompleto.Checked)
                {
                    NpgsqlCommand query_status = new NpgsqlCommand("update plano_inst set status = TRUE where codigo_plano =" + codigo + " and codigo_inst = " + txtCodigo.Text,conn_status);
                    try
                    {
                        conn_status.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                        return;
                    }
                    try
                    {
                        set_status = query_status.ExecuteReader();
                        conn_status.Close();
                        conn_status.Dispose();
                        set_status.Close();
                        query_status.Dispose();
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show("Não foi possível atualizar o status da instrução");
                        conn_status.Close();
                        conn_status.Dispose();
                    }
                }
                else
                {
                    NpgsqlCommand query_status = new NpgsqlCommand("update plano_inst set status = FALSE where codigo_plano =" + codigo + " and codigo_inst = " + txtCodigo.Text, conn_status);
                    try
                    {
                        conn_status.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                        return;
                    }
                    try
                    {
                        set_status = query_status.ExecuteReader();
                        conn_status.Close();
                        conn_status.Dispose();
                        set_status.Close();
                        query_status.Dispose();
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show("Não foi possível atualizar o status da instrução");
                        conn_status.Close();
                        conn_status.Dispose();
                    }
                }
            }
        }

        //Função para preencher a data de inicio das instruções
        private void data_conta(string data_ini)
        {
            NpgsqlConnection conn_data;
            conn_data = banco.ini;
            NpgsqlDataReader sum_data;
            NpgsqlCommand query_sum = new NpgsqlCommand("select sum(tempo_est) from plano_inst where codigo_plano = " + codigo + " and codigo_inst < " + txtCodigo.Text, conn_data);

            try
            {
                conn_data.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                return;
            }

            try
            {
                sum_data = query_sum.ExecuteReader();
                sum_data.Read();
                if (sum_data["sum"].ToString() != "")
                {
                    try
                    {
                        DateTime data = DateTime.Parse(data_ini);
                        TimeSpan tempo = TimeSpan.Parse(sum_data["sum"].ToString());
                        data = data.Add(tempo);
                        mtxtDataInicio.Text = data.ToString();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao calcular a data/hora inicial! " + ex);
                        return;
                    }
                }
                else
                {
                    mtxtDataInicio.Text = data_ini;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível consultar a data inicial da instrução! " + ex);
                return;
            }
            
        }

        //Função para preencher o grid de itens de configuração
        private void grid_ic(string categoria, string ambiente)
        {
            dgvItemConf.Rows.Clear();
            NpgsqlConnection conn;
            conn = banco.ini;
            NpgsqlCommand query_ic = new NpgsqlCommand("select nome_ic from item_conf where codigo_categoria = " + categoria + " and codigo_ambiente = " + ambiente, conn);
            NpgsqlDataReader ic;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex);
                return;
            }

            try
            {
                ic = query_ic.ExecuteReader();

                while (ic.HasRows)
                {
                    ic.Read();
                    dgvItemConf.Rows.Add(ic["nome_ic"].ToString());
                }
                ic.Close();
                query_ic.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Erro ao preencher os itens de configuração! " + ex);
                conn.Close();
                conn.Dispose();
                return;
            }
        }

        //Função para preencher o grid com as instruções do plano
        private void grid()
        {
            dgvPlanoInst.Rows.Clear();

            string query_inst = "select pi.*, c.nome_categoria from plano_inst pi left join categoria c on pi.codigo_categoria = c.codigo_categoria where pi.codigo_plano = " + this.codigo;
            string query_inst_aux = "";

            int codigoaux = 0;
            if (!Int32.TryParse(txtPesquisar.Text, out codigoaux))
            {
                codigoaux = -1;
            }

            if (txtPesquisar.Text == "")
            {
                query_inst = query_inst + " order by codigo_inst";
            }
            else
            {
                query_inst_aux = " and (desc_inst LIKE '%" + txtPesquisar.Text + "%' or codigo_inst =" + codigoaux + ")";
                query_inst = query_inst + query_inst_aux + " order by codigo_inst";
            }

            NpgsqlConnection conn;
            conn = banco.ini;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                return;
            }

            NpgsqlCommand query = new NpgsqlCommand(query_inst, conn);

            NpgsqlDataReader plano_inst;

            try
            {
                plano_inst = query.ExecuteReader();

                while (plano_inst.HasRows)
                {
                    plano_inst.Read();
                    string status;
                    if (plano_inst["status"].ToString() == "False")
                    {
                        status = "Incompleto";
                    }
                    else
                    {
                        status = "Completo";
                    }
                    dgvPlanoInst.Rows.Add(plano_inst["codigo_inst"].ToString(), plano_inst["desc_inst"].ToString(), plano_inst["nome_categoria"].ToString(), status, plano_inst["tempo_est"]);
                    dgvPlanoInst.Columns[4].DefaultCellStyle.Format = "HH:mm:ss";
                }

                plano_inst.Close();
                query.Dispose();

                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher grid: " + ex);
                return;
            }
        }

        //Função para preencher os campos de acordo com o valor selecionado no grid
        private void preencher()
        {

            if (dgvPlanoInst.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvPlanoInst.SelectedRows[0];
                NpgsqlConnection conn;
                conn = banco.ini;
                NpgsqlConnection conn2;
                conn2 = banco.ini;

                string selectaux = Convert.ToString(select.Cells["colCodigo"].Value);

                NpgsqlDataReader preenc, plano_amb;
                NpgsqlCommand cmdAmb = new NpgsqlCommand("select codigo_ambiente, data_inicio from plano where codigo_plano = " + codigo, conn2);
                NpgsqlCommand cmdSelecGrid = new NpgsqlCommand("select pi.* from plano_inst pi where pi.codigo_plano = " + codigo + " and pi.codigo_inst = " + selectaux, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex);
                    return;
                }

                try
                {
                    preenc = cmdSelecGrid.ExecuteReader();

                    if (preenc.HasRows == true)
                    {
                        preenc.Read();
                        txtCodigo.Text = preenc["codigo_inst"].ToString();
                        rtxtAcao.Text = preenc["comando"].ToString();
                        mtxtTempo.Text = DateTime.Parse(Convert.ToString(select.Cells["colTempo"].Value)).ToString("HH:mm:ss");
                        rtxtNotas.Text = preenc["nota"].ToString();

                        if (preenc["status"].ToString() == "False")
                        {
                            ckbCompleto.Checked = false;
                        }
                        else
                        {
                            ckbCompleto.Checked = true;
                        }
                        //Preenche o grid de item de configuração
                        if (preenc["codigo_categoria"].ToString() != "")
                        {
                            string cod_categoria;
                            cod_categoria = preenc["codigo_categoria"].ToString();

                            try
                            {
                                conn2.Open();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro: " + ex);
                                return;
                            }
                            plano_amb = cmdAmb.ExecuteReader();
                            if (plano_amb.HasRows == true)
                            {
                                plano_amb.Read();
                                string cod_ambiente, data_ini;
                                cod_ambiente = plano_amb["codigo_ambiente"].ToString();
                                data_ini = plano_amb["data_inicio"].ToString();
                                conn2.Close();
                                conn2.Dispose();
                                plano_amb.Close();
                                cmdAmb.Dispose();
                                grid_ic(cod_categoria, cod_ambiente);
                                data_conta(data_ini);
                            }

                        }

                        preenc.Close();
                        cmdSelecGrid.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Erro ao preencher os campos! " + ex);
                    conn.Close();
                    conn.Dispose();
                    return;
                }
            }
        }

        //NA
        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        //Ações executadas no carregamento do form
        private void FormPlano4_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            grid();
        }

        //Preenche os campos do painel de acordo com a instrução selecionada
        private void dgvPlanoInst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            preencher();
        }

        //Preenche os campos do painel de acordo com a instrução selecionada
        private void dgvPlanoInst_SelectionChanged(object sender, EventArgs e)
        {
            preencher();
        }

        //NA
        private void ckbCompleto_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Função para atualizar o status da instrução de acordo com o checkbox Completo
        private void ckbCompleto_Click(object sender, EventArgs e)
        {
            int select;
            try
            {
                select = dgvPlanoInst.CurrentCell.RowIndex;
            }
            catch (Exception)
            {
                return;
            }
 
            update_status();
            grid();

            dgvPlanoInst.ClearSelection();
            dgvPlanoInst.Rows[select].Selected = true;
            dgvPlanoInst.Rows[select].Cells[0].Selected = true;
        }

        //Fecha o form atual e retorna para o form de gerenciamento de planos de implementação
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
