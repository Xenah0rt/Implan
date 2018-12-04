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
    public partial class FormPlano3 : Form
    {
        public bool novo;
        public string codigo;
        public string ambiente;
        BD banco = new BD();

        public FormPlano3(string cod, string amb)
        {
            InitializeComponent();
            codigo = cod;
            ambiente = amb;
        }

        //Preencher o combo box de categoria
        private void combo()
        {
            cmbCategoria.Items.Clear();
            NpgsqlConnection conn;
            conn = banco.ini;

            string sql_cat = "select * from categoria";
            string sql_cat_aux = "";

            NpgsqlDataReader cat;

            NpgsqlCommand query_cat = new NpgsqlCommand(sql_cat, conn);

            try
            {
                conn.Open();

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
                MessageBox.Show("Não há ambientes ou categorias cadastrados" + ex);
            }
        }

        //Função para preencher os campos de acordo com a linha selecionada do grid
        private void preencher()
        {

            if (dgvPlanoInst.SelectedRows.Count != 0)
            {
                DataGridViewRow select = dgvPlanoInst.SelectedRows[0];
                NpgsqlConnection conn;
                conn = banco.ini;
                conn.Open();

                string selectaux = Convert.ToString(select.Cells["colCodigo"].Value);

                NpgsqlDataReader preenc;
                NpgsqlCommand cmdSelecGrid = new NpgsqlCommand("select pi.*, c.nome_categoria from plano_inst pi left join categoria c on c.codigo_categoria = pi.codigo_categoria where pi.codigo_plano = "+ codigo +" and pi.codigo_inst = " + selectaux, conn);
                preenc = cmdSelecGrid.ExecuteReader();

                if (preenc.HasRows == true)
                {
                    preenc.Read();
                    txtCodigo.Text = preenc["codigo_inst"].ToString();
                    rtxtAcao.Text = preenc["comando"].ToString();
                    txtDesc.Text = preenc["desc_inst"].ToString();
                    mtxtTempo.Text = DateTime.Parse(Convert.ToString(select.Cells["colTempo"].Value)).ToString("HH:mm:ss");
                    rtxtNotas.Text = preenc["nota"].ToString();
         
                    if (preenc["codigo_categoria"].ToString() != "")
                    {
                        cmbCategoria.Text = preenc["codigo_categoria"].ToString() + " - " + preenc["nome_categoria"].ToString();
                    }
                    else
                    {
                        cmbCategoria.Text = "";
                    }
                    preenc.Close();
                    cmdSelecGrid.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }
        }

        //Função para preencher o grid. Caso o txt box de pesquisa seja preenchido, o grid será filtrado.
        private void grid()
        {

            dgvPlanoInst.Rows.Clear();

            string query_inst = "select * from plano_inst where codigo_plano = " + this.codigo;
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
            conn.Open();

            NpgsqlCommand query = new NpgsqlCommand(query_inst, conn);
            
            NpgsqlDataReader plano_inst, ic;

            try
            {
                plano_inst = query.ExecuteReader();

                while (plano_inst.HasRows)
                {
                    plano_inst.Read();

                    NpgsqlConnection conn2;
                    conn2 = banco.ini;
                    ComboBox CB = new ComboBox();
                    if (plano_inst["codigo_categoria"].ToString()!="")
                    {
                        NpgsqlCommand query_ic = new NpgsqlCommand("select nome_ic from item_conf where codigo_ambiente = " + this.ambiente + " and codigo_categoria = " + plano_inst["codigo_categoria"].ToString(), conn2);
                        conn2.Open();
                        ic = query_ic.ExecuteReader();
                        while (ic.HasRows)
                        {
                            ic.Read();
                            CB.Items.Add(ic["nome_ic"]);
                        }
                        conn2.Close();
                        conn2.Dispose();
                        ic.Close();
                        query_ic.Dispose();
                    }
                    if (CB.Items.Count == 0)
                    {
                        CB.Items.Add("");
                    }
                    dgvPlanoInst.Rows.Add(plano_inst["codigo_inst"].ToString(), plano_inst["desc_inst"].ToString(), CB.Items[0] , /*plano_inst["comando"].ToString(),*/ plano_inst["tempo_est"]);
                    ((DataGridViewComboBoxCell)dgvPlanoInst.Rows[dgvPlanoInst.Rows.Count-1].Cells[2]).DataSource = CB.Items;
                    dgvPlanoInst.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";
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

        //Função para limpar os campos ao selecionar a opção "novo"
        private void limpar()
        {
            rtxtAcao.Clear();
            txtDesc.Clear();
            mtxtTempo.Clear();
            rtxtNotas.Clear();
            cmbCategoria.Text = "";
            
        }

        //Função para inserir codigo 1 caso não exista nenhuma instrução cadastrada ou o proximo codigo
        private void pega_cod()
        {
            if (txtCodigo.Text == "")
            {
                NpgsqlConnection conn_id;
                conn_id = banco.ini;
                NpgsqlCommand query_id = new NpgsqlCommand("select codigo_inst from plano_inst where codigo_plano = " + this.codigo + " order by codigo_inst desc limit 1", conn_id);
                NpgsqlDataReader id;


                conn_id.Open();

                try
                {
                    id = query_id.ExecuteReader();
                    if (id.HasRows)
                    {
                        id.Read();
                        int cod_atual;
                        if (Int32.TryParse(id["codigo_inst"].ToString(), out cod_atual))
                        {
                            txtCodigo.Text = (cod_atual + 1).ToString();
                        }
                        conn_id.Close();
                        conn_id.Dispose();
                    }
                    else
                    {
                        txtCodigo.Text = "1";
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
            else
            {
                int cod_atual;
                if (Int32.TryParse(txtCodigo.Text, out cod_atual))
                {
                     txtCodigo.Text = (cod_atual + 1).ToString();
                }
            }
        }

        //Ações executadas ao carregar o form
        private void FormPlano3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            panel1.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            dgvPlanoInst.ClearSelection();
            limpar();
            grid();
        }

        //Habilita a instrução selecionada para alteração
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhuma instrução selecionada para alteração!");
                return;
            }
            else

                novo = false;
            panel1.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            dgvPlanoInst.Enabled = false;
            txtPesquisar.Enabled = false;
            combo();
        }
        
        //Função para abrir o combobox do grid com apenas 1 clique.
        private void dgvPlanoInst_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); 
            var datagridview = sender as DataGridView;

            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        //preencher os campos ao selecionar uma linha do grid.
        private void dgvPlanoInst_SelectionChanged(object sender, EventArgs e)
        {
            preencher();
        }

        //Habilita os campos do painel para inserção de nova instrução
        private void btnNovo_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            txtCodigo.Enabled = false;
            pega_cod();
            txtDesc.Focus();
            limpar();
            combo();
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            dgvPlanoInst.Enabled = false;
            txtPesquisar.Enabled = false;
            novo = true;
        }

        //Cancela a operação em andamento
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult decisao;
            decisao = MessageBox.Show("Deseja cancelar a operação?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (decisao == DialogResult.Yes)
            {
                limpar();
                txtCodigo.Clear();
                panel1.Enabled = false;
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                btnExcluir.Enabled = true;
                btnNovo.Enabled = true;
                btnAlterar.Enabled = true;
                dgvPlanoInst.Enabled = true;
                txtPesquisar.Enabled = true;
                grid();
            }
        }

        //insere ou atualiza a instrução no banco de dados. Reorganiza os registros em caso de sobreposição
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            //verifica se os campos obrigatórios foram preenchidos
            if (txtDesc.Text.Trim() == "" || txtCodigo.Text == "" || mtxtTempo.MaskFull == false || rtxtAcao.Text == "" )
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
                return;
            }

            //tratamento de ' no campo de comando
            string acao;
            acao = rtxtAcao.Text;
            acao = acao.Replace("'", "''");

            //Atribui valor null ao campo categoria caso nenhuma seja selecionada
            string selectCat;

            if (Convert.ToString(cmbCategoria.SelectedItem) != "")
            {
                selectCat = Convert.ToString(cmbCategoria.SelectedItem);
                selectCat = (selectCat.Split(' ')[0]);
            }
            else
            {
                selectCat = "null";
            }

            //Atribui valor null ao campo nota caso nenhuma nota seja inserida
            string nota;

            if (rtxtNotas.Text != "")
            {
                nota = rtxtNotas.Text;
                nota = nota.Replace("'", "''");
            }
            else
            {
                nota = null;
            }

            //Procedimento realizado caso um novo record esteja sendo criado
            if (novo == true)
            {
                NpgsqlConnection conn_novo;
                conn_novo = banco.ini;
                NpgsqlCommand query_update = new NpgsqlCommand("update plano_inst set codigo_inst = codigo_inst + 1 where codigo_plano = " + codigo + " and codigo_inst >= " + txtCodigo.Text, conn_novo);
                NpgsqlCommand query_insert = new NpgsqlCommand("insert into plano_inst values (" + codigo + ", " + txtCodigo.Text + ", " + selectCat + ", '" + txtDesc.Text + "', '" + acao + "', FALSE, '" + nota + "', '" + mtxtTempo.Text + "')", conn_novo);
                NpgsqlDataReader plano_updade, plano_insert;
                conn_novo.Open();

                try
                {
                    plano_updade = query_update.ExecuteReader();
                    plano_updade.Close();
                    query_update.Dispose();
                    plano_insert = query_insert.ExecuteReader();
                    plano_insert.Close();
                    query_insert.Dispose();
                    conn_novo.Close();
                    conn_novo.Dispose();
                    grid();
                    dgvPlanoInst.Enabled = true;
                    btnNovo.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    txtPesquisar.Enabled = true;
                    panel1.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnCancelar.Enabled = false;
                    dgvPlanoInst.Rows[0].Selected = false;
                    dgvPlanoInst.Rows[dgvPlanoInst.Rows.Count - 1].Selected = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Não foi possível salvar a instrução: " + ex);
                    conn_novo.Close();
                    conn_novo.Dispose();
                    return;
                }

            }
            //procedimento realizado para alteração de record ja existente
            else
            {
                NpgsqlConnection conn_novo;
                conn_novo = banco.ini;
                NpgsqlCommand query_update = new NpgsqlCommand("update plano_inst set codigo_categoria = " + selectCat + ", desc_inst = '" + txtDesc.Text + "', comando = '" + acao + "', nota = '" + nota + "', tempo_est = '" + mtxtTempo.Text + "', status = FALSE where codigo_plano = " + codigo + " and codigo_inst = " + txtCodigo.Text, conn_novo);
                NpgsqlDataReader plano_updade;
                conn_novo.Open();

                try
                {
                    plano_updade = query_update.ExecuteReader();
                    plano_updade.Close();
                    query_update.Dispose();
                    conn_novo.Close();
                    conn_novo.Dispose();
                    grid();
                    dgvPlanoInst.Enabled = true;
                    btnNovo.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    txtPesquisar.Enabled = true;
                    panel1.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnCancelar.Enabled = false;
                    dgvPlanoInst.Rows[0].Selected = false;
                    dgvPlanoInst.Rows[dgvPlanoInst.Rows.Count - 1].Selected = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível salvar a instrução: " + ex);
                    conn_novo.Close();
                    conn_novo.Dispose();
                    return;
                }
            }
        }

        //Exclui a instrução selecionada e reorganiza os registros restantes
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult decisao;
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Nenhuma instrução selecionada para exclusão!");
                return;
            }
            else
            {
                decisao = MessageBox.Show("Deseja mesmo excluir a instrução selecionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (decisao == DialogResult.Yes)
                {
                    NpgsqlConnection conn_excluir;
                    conn_excluir = banco.ini;
                    NpgsqlCommand query_excluir = new NpgsqlCommand("delete from plano_inst where codigo_plano = " + codigo + " and codigo_inst = " + txtCodigo.Text, conn_excluir);
                    NpgsqlCommand query_update = new NpgsqlCommand("update plano_inst set codigo_inst = codigo_inst - 1 where codigo_plano = " + codigo + " and codigo_inst > " + txtCodigo.Text, conn_excluir);

                    NpgsqlDataReader inst_excluir, inst_update;

                    try
                    {
                        conn_excluir.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                        return;
                    }

                    try
                    {
                        inst_excluir = query_excluir.ExecuteReader();
                        inst_excluir.Close();
                        query_excluir.Dispose();

                        inst_update = query_update.ExecuteReader();
                        inst_update.Close();
                        query_update.Dispose();
                        conn_excluir.Close();
                        conn_excluir.Dispose();
                    }
                    catch(NpgsqlException ex)
                    {
                        MessageBox.Show("Não foi possível excluir a instrução! " + ex);
                        conn_excluir.Close();
                        conn_excluir.Dispose();
                        return;
                    }

                    grid();
                }
            }
        }

        //Filtra o grid
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            grid();
        }

        //Fecha o form atual e retorna para o form de cadastro de plano
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
