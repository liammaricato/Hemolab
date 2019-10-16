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

namespace prj_Hemolab.Pre_Triagem
{
    public partial class frmPreTriagem : Form
    {
        public frmPreTriagem()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmPreTriagem_Load(object sender, EventArgs e)
        {
            tblPreTriagem.DataSource = null;
            tblPreTriagem.Rows.Clear();
            tblPreTriagem.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            string comando = "select d.nm_doador as 'Nome do Doador', d.cd_rg_doador as 'RG do Doador', d.cd_cpf_doador as 'CPF do Doador', ";
            comando += "t.hr_triagem as 'Hora de Chegada' from triagem t inner join doador d on d.cd_rg_doador = t.cd_rg_doador ";
            comando += "where t.qt_quilos_doador is null order by t.hr_triagem";

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblPreTriagem.DataSource = tabela;
            tblPreTriagem.AutoResizeColumns();
            tblPreTriagem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblPreTriagem.Rows[tblPreTriagem.SelectedRows[0].Index].Cells[1].Value) == "")
            {
                MessageBox.Show("Selecione um doador para prosseguir!", "Pré-Triagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsDadosGerais.nm_doador = tblPreTriagem.Rows[tblPreTriagem.SelectedRows[0].Index].Cells[0].Value.ToString();
                clsDadosGerais.cd_rg_doador = tblPreTriagem.Rows[tblPreTriagem.SelectedRows[0].Index].Cells[1].Value.ToString();

                string comando = "select max(cd_triagem) from triagem where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "'";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                dados.Read();
                clsDadosGerais.cd_triagem = dados[0].ToString();
                dados.Close();

                Form frmPreTriagemDoador = new Pre_Triagem.frmPreTriagemDoador();
                clsAbreForm.AbreForm(frmPreTriagemDoador);
                this.Close();
            }
            
        }
        #endregion

        #region Botão Cancelar Doação
        private void btnCancelarDoacao_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblPreTriagem.Rows[tblPreTriagem.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione um doador para cancelar a doação!", "Pré-Triagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("Tem certeza que deseja cancelar essa doação? Todos os dados dessa doação serão excluídos.", "Cancelar Doação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string cd_rg_doador = tblPreTriagem.Rows[tblPreTriagem.SelectedRows[0].Index].Cells[1].Value.ToString();
                    string cd_triagem;

                    string comando = "select max(cd_triagem) from triagem where cd_rg_doador = '" + cd_rg_doador + "'";
                    MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    MySqlDataReader dados = cSQL.ExecuteReader();
                    dados.Read();
                    cd_triagem = dados[0].ToString();
                    dados.Close();

                    comando = "delete from triagem where cd_rg_doador = '" + cd_rg_doador + "' and cd_triagem = " + cd_triagem;
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();

                    MessageBox.Show("Doação cancelada com sucesso! Os dados dessa doação foram excluídos.", "Cancelar Doação");

                    frmPreTriagem_Load(sender, e);
                }
            }
        }
        #endregion

        #region Timer
        private void tmrPreTriagem_Tick(object sender, EventArgs e)
        {
            frmPreTriagem_Load(sender, e);
        }
        #endregion
    }
}
