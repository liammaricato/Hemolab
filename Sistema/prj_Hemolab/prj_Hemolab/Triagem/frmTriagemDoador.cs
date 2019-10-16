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

namespace prj_Hemolab.Triagem
{
    public partial class frmTriagemDoador : Form
    {
        public frmTriagemDoador()
        {
            InitializeComponent();
        }

        #region Função que insere o resultado da triagem no banco
        private void InsereResultado(string true_false)
        {
            string comando = "update triagem set ic_triagem_doador = " + true_false + " where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' ";
            comando += "and cd_triagem = " + clsDadosGerais.cd_triagem;
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();

            MessageBox.Show("Dados salvos com sucesso!", "Triagem");
            Form frmTriagem = new frmTriagem();
            clsAbreForm.AbreForm(frmTriagem);
            this.Close();
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Essas alterações não serão salvas!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Form frmTriagem = new frmTriagem();
                clsAbreForm.AbreForm(frmTriagem);
                this.Close();
            }
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

        #region Form Load
        private void frmTriagemDoador_Load(object sender, EventArgs e)
        {
            lblRG.Text = clsDadosGerais.cd_rg_doador;
            lblNome.Text = clsDadosGerais.nm_doador;
        }
        #endregion

        #region Botão Aprovar
        private void btnAprovar_Click(object sender, EventArgs e)
        {
            InsereResultado("true");

            string cd_bolsa_coletada;

            string comando = "select max(cd_triagem) from triagem where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            dados.Read();
            cd_bolsa_coletada = dados[0].ToString();
            dados.Close();

            cd_bolsa_coletada = clsDadosGerais.cd_rg_doador + cd_bolsa_coletada;
            cd_bolsa_coletada = cd_bolsa_coletada.Replace(".", "");
            cd_bolsa_coletada = cd_bolsa_coletada.Replace("-", "");

            comando = "insert into bolsa_coletada values ('" + clsDadosGerais.data_hoje() + "', '" + clsDadosGerais.cd_rg_doador + "', ";
            comando += "null, " + clsDadosGerais.cd_usuario + " , '" + cd_bolsa_coletada + "' , null, null, null, false)";
            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
        }
        #endregion

        #region Botão Reprovar
        private void btnReprovar_Click(object sender, EventArgs e)
        {
            InsereResultado("false");
        }
        #endregion
    }
}
