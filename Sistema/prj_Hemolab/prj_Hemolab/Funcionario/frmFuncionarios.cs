using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using prj_Hemolab.Classes;

namespace prj_Hemolab
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }

        #region Manda MessageBox se o cara não selecionar nada da DataGrid
        private bool MandaMessageBox(string fazer)
        {
            if (Convert.ToString(tblFuncionario.SelectedRows[0].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione um funcionário para " + fazer.ToLower() + "!", fazer + " Funcionário");
                return true;
            }
            return false;
        }
        #endregion

        #region Form Load
        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            tblFuncionario.DataSource = null;
            tblFuncionario.Rows.Clear();
            tblFuncionario.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            string comando = "select f.cd_funcionario as 'Código do Funcionário', tf.nm_tipo_funcionario as 'Usuário', f.nm_funcionario as 'Nome do Funcionário' ";
            comando += "from funcionario f inner join tipo_funcionario tf on tf.cd_tipo_funcionario = f.cd_tipo_funcionario";

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblFuncionario.DataSource = tabela;
            tblFuncionario.AutoResizeColumns();
            tblFuncionario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string comando;

            if (rdbSetor.Checked)
            {
                if (cmbSetor.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione um setor para buscar!", "Buscar Funcionários");
                    return;
                }

                comando = "select f.cd_funcionario as 'Código do Funcionário', tf.nm_tipo_funcionario as 'Usuário', f.nm_funcionario as 'Nome do Funcionário' ";
                comando += "from funcionario f inner join tipo_funcionario tf on tf.cd_tipo_funcionario = f.cd_tipo_funcionario where f.cd_tipo_funcionario = " + Convert.ToString(cmbSetor.SelectedIndex + 1);
            }
            else
            {
                if (txtCdBolsa.Text == "")
                {
                    if (MessageBox.Show("Deseja buscar todos os funcionários? Esse procedimento pode demorar um pouco.", "Buscar Funcionários", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmFuncionarios_Load(sender, e);
                    }
                    return;
                }

                if (rdbCodigo.Checked)
                {
                    comando = "select f.cd_funcionario as 'Código do Funcionário', tf.nm_tipo_funcionario as 'Usuário', f.nm_funcionario as 'Nome do Funcionário' ";
                    comando += "from funcionario f inner join tipo_funcionario tf on tf.cd_tipo_funcionario = f.cd_tipo_funcionario where f.cd_funcionario = " + txtCdBolsa.Text;
                }
                else
                {
                    comando = "select f.cd_funcionario as 'Código do Funcionário', tf.nm_tipo_funcionario as 'Usuário', f.nm_funcionario as 'Nome do Funcionário' ";
                    comando += "from funcionario f inner join tipo_funcionario tf on tf.cd_tipo_funcionario = f.cd_tipo_funcionario where f.nm_funcionario like '%" + txtCdBolsa.Text + "%'";
                }
            }
            
            tblFuncionario.DataSource = null;
            tblFuncionario.Rows.Clear();
            tblFuncionario.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblFuncionario.DataSource = tabela;
            tblFuncionario.AutoResizeColumns();
            tblFuncionario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Form frmNovoFuncionario = new Funcionario.frmNovoFuncionario();
            frmNovoFuncionario.StartPosition = FormStartPosition.CenterScreen;
            if (frmNovoFuncionario.ShowDialog() == DialogResult.Yes)
            {
                frmFuncionarios_Load(sender, e);
            }
        }
        #endregion

        #region Botão Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MandaMessageBox("Editar"))
                return;

            clsDadosGerais.cd_funcionario = tblFuncionario.SelectedRows[0].Cells[0].Value.ToString();
            clsDadosGerais.nm_tipo_funcionario = tblFuncionario.SelectedRows[0].Cells[1].Value.ToString();
            clsDadosGerais.nm_funcionario = tblFuncionario.SelectedRows[0].Cells[2].Value.ToString();

            string comando = "select cd_cpf_funcionario from funcionario where cd_funcionario = " + clsDadosGerais.cd_funcionario;
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            dados.Read();
            clsDadosGerais.cd_cpf_funcionario = dados[0].ToString();
            dados.Close();
            dados.Dispose();

            Form frmEditarFuncionario = new Funcionario.frmEditarFuncionario();
            frmEditarFuncionario.StartPosition = FormStartPosition.CenterScreen;
            if (frmEditarFuncionario.ShowDialog() == DialogResult.Yes)
            {
                frmFuncionarios_Load(sender, e);
            }
        }
        #endregion

        #region Botão Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MandaMessageBox("Excluir"))
                return;

            if (MessageBox.Show("Tem certeza que deseja excluir o funcionário: \n" + tblFuncionario.SelectedRows[0].Cells[2].Value.ToString(), "Excluir Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string comando = "delete from funcionario where cd_funcionario = " + tblFuncionario.SelectedRows[0].Cells[0].Value.ToString();
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();
                MessageBox.Show("Funcionário excluído com sucesso!", "Excluir Funcionário");
                frmFuncionarios_Load(sender, e);
            }
        }
        #endregion

        #region KeyPress txtCdBolsa
        private void txtCdBolsa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbCodigo.Checked)
            {
                if (clsValidar.Codigo(e.KeyChar))
                    e.Handled = true;
            }
            else
            {
                if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
                    e.Handled = true;
            }
        }
        #endregion

        #region Limpa TXT quando mudar o RadioButton
        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtCdBolsa.Clear();
        }
        #endregion        

        #region Check do RadioButton Setor
        private void rdbSetor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSetor.Checked)
            {
                txtCdBolsa.Clear();
                cmbSetor.Visible = true;
            }
            else
            {
                cmbSetor.SelectedIndex = -1;
                cmbSetor.Visible = false;
            }
        }
        #endregion
    }
}
