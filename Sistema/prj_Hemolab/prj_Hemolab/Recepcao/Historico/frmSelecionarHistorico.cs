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

namespace prj_Hemolab.Recepcao.Historico
{
    public partial class frmSelecionarHistorico : Form
    {
        public frmSelecionarHistorico()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmSelecionarHistorico_Load(object sender, EventArgs e)
        {
            lblRG.Text = clsDadosGerais.cd_rg_doador;
            lblNome.Text = clsDadosGerais.nm_doador;

            tblHistorico.DataSource = null;
            tblHistorico.Rows.Clear();
            tblHistorico.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            string comando = "select t.dt_triagem as 'Data da Doação', if(bc.ic_coleta_sem_sucesso = false, 'Sim', 'Não') ";
            comando += "as 'Coleta Realizada com Sucesso' from bolsa_coletada bc inner join triagem t on t.cd_rg_doador = bc.cd_rg_doador ";
            comando += "where bc.cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "'";

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblHistorico.DataSource = tabela;
            tblHistorico.AutoResizeColumns();
            tblHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblHistorico.Rows[tblHistorico.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione uma doação para prosseguir!", "Histórico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsDadosGerais.dt_coleta = Convert.ToString(tblHistorico.SelectedRows[0].Cells[0].Value).Substring(0, 10);
                Form frmHistorico = new frmHistorico();
                clsAbreForm.AbreForm(frmHistorico);
                this.Close();
            }
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Form frmRecepcao = new frmRecepcao();
            clsAbreForm.AbreForm(frmRecepcao);
            this.Close();
        }

        private void btnFechar_MouseEnter(object sender, EventArgs e)
        {
            btnFechar.BackgroundImage = Properties.Resources.xfinalagoravai2;
        }

        private void btnFechar_MouseLeave(object sender, EventArgs e)
        {
            btnFechar.BackgroundImage = Properties.Resources.xfinalagoravai;
        }
        #endregion
    }
}
