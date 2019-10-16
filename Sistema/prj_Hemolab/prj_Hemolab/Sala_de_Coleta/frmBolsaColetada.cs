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

namespace prj_Hemolab.Sala_de_Coleta
{
    public partial class frmBolsaColetada : Form
    {
        public frmBolsaColetada()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmBolsaColetada_Load(object sender, EventArgs e)
        {
            lblRG.Text = clsDadosGerais.cd_rg_doador;
            lblNome.Text = clsDadosGerais.nm_doador;
        }
        #endregion

        #region Botão Concluir Sem Sucesso
        private void btnConcluirSem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo concluir essa doação sem sucesso?", "Concluir Doação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string comando = "update bolsa_coletada set hr_coleta = '" + clsDadosGerais.hora_atual() + "' ";
                comando += "where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and dt_coleta = '" + clsDadosGerais.data_hoje() + "'";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();

                comando = "update bolsa_coletada set ic_coleta_sem_sucesso = true ";
                comando += "where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and dt_coleta = '" + clsDadosGerais.data_hoje() + "'";
                cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();

                MessageBox.Show("Coleta registrada com sucesso!", "Sala de Coleta");
                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
        #endregion

        #region Botão Concluir Com Sucesso
        private void btnConcluirCom_Click(object sender, EventArgs e)
        {
            string comando = "update bolsa_coletada set hr_coleta = '" + clsDadosGerais.hora_atual() + "' where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' ";
            comando += "and dt_coleta = '" + clsDadosGerais.data_hoje() + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();

            comando = "update bolsa_coletada set ic_coleta_sem_sucesso = false ";
            comando += "where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and dt_coleta = '" + clsDadosGerais.data_hoje() + "'";
            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();

            for (int i = 1; i < 7; i++)
            {
                comando = "insert into exame values ('" + clsDadosGerais.data_hoje() + "', '" + clsDadosGerais.cd_rg_doador + "', " + i + ", " + clsDadosGerais.cd_usuario + ", ";
                comando += "'" + clsDadosGerais.data_hoje() + "', null)";
                cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();
            }

            MessageBox.Show("Coleta registrada com sucesso!", "Sala de Coleta");
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Essas alterações não serão salvas!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
