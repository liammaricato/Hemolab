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

namespace prj_Hemolab.Sorologia
{
    public partial class frmResultadosSorologia : Form
    {
        public frmResultadosSorologia()
        {
            InitializeComponent();
        }

        #region Função ApertouBotao
        private void ApertouBotao(Button botao_apertado)
        {
            if (botao_apertado.BackColor == Color.DarkGray)
            {
                botao_apertado.BackColor = Color.Gainsboro;
                botao_apertado.FlatAppearance.BorderColor = Color.Black;
                return;
            }

            if (botao_apertado.Tag.ToString() == "0")
            {
                botao_apertado.BackColor = Color.DarkGray;
                botao_apertado.FlatAppearance.BorderColor = Color.Green;

                foreach (Control controle in botao_apertado.Parent.Controls)
                {
                    Button botao = controle as Button;
                    if (botao != null)
                    {
                        if (controle.Tag.ToString() == "1")
                        {
                            controle.BackColor = Color.Gainsboro;
                            (controle as Button).FlatAppearance.BorderColor = Color.Black;
                        }
                    }
                }
            }
            else
            {
                botao_apertado.BackColor = Color.DarkGray;
                botao_apertado.FlatAppearance.BorderColor = Color.Red;

                foreach (Control controle in botao_apertado.Parent.Controls)
                {
                    Button botao = controle as Button;
                    if (botao != null)
                    {
                        if (controle.Tag.ToString() == "0")
                        {
                            controle.BackColor = Color.Gainsboro;
                            (controle as Button).FlatAppearance.BorderColor = Color.Black;
                        }
                    }
                }
            }
        }
        #endregion

        #region Função que insere o resultado no banco de dados
        private void InsertResultado(string cd_tipo_exame, string ic_resultado_exame)
        {
            string data = clsDadosGerais.data_hoje();

            string comando = "update exame set ic_resultado_exame = " + ic_resultado_exame + ", dt_exame = '" + data + "' where dt_coleta = ";
            comando += "'" + clsDadosGerais.dt_coleta + "' and cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and cd_tipo_exame = " + cd_tipo_exame; 
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
        }
        #endregion

        #region Botão Positivo
        private void btnPositivo_Click(object sender, EventArgs e)
        {
            ApertouBotao(sender as Button);
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Essas alterações não serão salvas!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Form frmSorologia = new frmSorologia();
                clsAbreForm.AbreForm(frmSorologia);
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

        #region Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            foreach (Panel painel in flpExames.Controls)
            {
                if (painel.Enabled == true)
                {
                    foreach (Button botao in painel.Controls.OfType<Button>())
                    {
                        if (botao.BackColor == Color.DarkGray)
                        {
                            if (botao.Tag.ToString() == "1")
                            {
                                InsertResultado(painel.Tag.ToString(), "true");
                            }
                            else
                            {
                                InsertResultado(painel.Tag.ToString(), "false");
                            }
                        }
                    }
                }
            }


            MessageBox.Show("Exames registrados com sucesso!", "Sorologia");
            Form frmSorologia = new frmSorologia();
            clsAbreForm.AbreForm(frmSorologia);
            this.Close();
        }
        #endregion

        #region Form Load
        private void frmResultadosSorologia_Load(object sender, EventArgs e)
        {
            lblCdBolsa.Text = clsDadosGerais.cd_bolsa_coletada;

            string comando = "select e.cd_tipo_exame, e.ic_resultado_exame from exame e inner join bolsa_coletada bc on e.dt_coleta = ";
            comando += "bc.dt_coleta and e.cd_rg_doador = bc.cd_rg_doador where cd_bolsa_coletada = " + clsDadosGerais.cd_bolsa_coletada;

            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                if (!(dados[1].ToString() == "" || dados[1].ToString() == null))
                {
                    switch (dados[0].ToString())
                    {
                        case "1":
                            if (dados[1].ToString() == "True")
                                ApertouBotao(btnPositivoHepatiteB);
                            else
                                ApertouBotao(btnNegativoHepatiteB);
                            pnlHepatiteB.Enabled = false;
                            break;
                        case "2":
                            if (dados[1].ToString() == "True")
                                ApertouBotao(btnPositivoHepatiteC);
                            else
                                ApertouBotao(btnNegativoHepatiteC);
                            pnlHepatiteC.Enabled = false;
                            break;
                        case "3":
                            if (dados[1].ToString() == "True")
                                ApertouBotao(btnPositivoVDL);
                            else
                                ApertouBotao(btnNegativoVDL);
                            pnlVirusDeLinfocitos.Enabled = false;
                            break;
                        case "4":
                            if (dados[1].ToString() == "True")
                                ApertouBotao(btnPositivoDDC);
                            else
                                ApertouBotao(btnNegativoDDC);
                            pnlDoencaDeChagas.Enabled = false;
                            break;
                        case "5":
                            if (dados[1].ToString() == "True")
                                ApertouBotao(btnPositivoSifilis);
                            else
                                ApertouBotao(btnNegativoSifilis);
                            pnlSifilis.Enabled = false;
                            break;
                        case "6":
                            if (dados[1].ToString() == "True")
                                ApertouBotao(btnPositivoHIV);
                            else
                                ApertouBotao(btnNegativoHIV);
                            pnlHIV.Enabled = false;
                            break;
                    }
                }
            }
            dados.Close();
        }
        #endregion

        
    }
}
