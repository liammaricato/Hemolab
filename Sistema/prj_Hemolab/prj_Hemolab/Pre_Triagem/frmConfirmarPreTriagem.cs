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
    public partial class frmConfirmarPreTriagem : Form
    {
        public frmConfirmarPreTriagem()
        {
            InitializeComponent();
        }

        #region Função que executa o Update
        private void Update(string ic_pre_triagem)
        {
            string comando = "update triagem set ic_pre_triagem_doador = " + ic_pre_triagem + " where ";
            comando += "cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and cd_triagem = " + clsDadosGerais.cd_triagem;
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
        }
        #endregion

        #region Form Load
        private void frmConfirmarPreTriagem_Load(object sender, EventArgs e)
        {
            string comando = "select d.cd_rg_doador, d.nm_doador, d.sg_sexo_doador, floor(datediff (now(), d.dt_nascimento_doador)/365), ";
            comando += "t.qt_quilos_doador, t.qt_bpm_doador, t.qt_pressao_doador, t.qt_temperatura_doador, t.qt_hematocrito_doador, ";
            comando += "t.qt_hemoglobina_doador, t.cd_triagem from doador d inner join triagem t on t.cd_rg_doador = d.cd_rg_doador where d.cd_rg_doador ";
            comando += "= '" + clsDadosGerais.cd_rg_doador + "' and t.cd_triagem = (select max(tt.cd_triagem) from triagem tt where tt.cd_rg_doador = d.cd_rg_doador)";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                lblRG.Text += dados[0].ToString();
                clsDadosGerais.cd_rg_doador = dados[0].ToString();
                lblNome.Text += dados[1].ToString();
                lblSexo.Text += dados[2].ToString();
                lblIdade.Text += dados[3].ToString();
                lblPeso.Text += dados[4].ToString() + " kg";
                lblPulso.Text += dados[5].ToString() + " bpm";
                lblPressao.Text += dados[6].ToString() + " mmHg";
                lblTemperatura.Text += dados[7].ToString() + " ºC";
                lblHematocritos.Text += dados[8].ToString() + " %";
                lblHemoglobina.Text += dados[9].ToString() + " g/dL";
                clsDadosGerais.cd_triagem = dados[10].ToString();
            }
            dados.Close();
            dados.Dispose();
        }
        #endregion

        #region Botão Aprovar
        private void btnAprovar_Click(object sender, EventArgs e)
        {
            Update("true");
            MessageBox.Show("Pré-Triagem registrada com sucesso!", "Pré-Triagem");
            Form frmPreTriagem = new frmPreTriagem();
            clsAbreForm.AbreForm(frmPreTriagem);
            this.Close();
        }
        #endregion

        #region Botão Reprovar
        private void btnReprovar_Click(object sender, EventArgs e)
        {
            Update("false");
            MessageBox.Show("Pré-Triagem registrada com sucesso!", "Pré-Triagem");
            Form frmPreTriagem = new frmPreTriagem();
            clsAbreForm.AbreForm(frmPreTriagem);
            this.Close();
        }
        #endregion
    }
}
