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
    public partial class frmHistorico : Form
    {
        public frmHistorico()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmHistorico_Load(object sender, EventArgs e)
        {
            pnlMais.Location = new Point(12, 53);
            pnlMais.Visible = false;
            lblRG.Text = clsDadosGerais.cd_rg_doador;
            lblNome.Text = clsDadosGerais.nm_doador;
            lblDtColeta.Text = clsDadosGerais.dt_coleta;

            string comando = "select t.qt_quilos_doador, t.qt_bpm_doador, t.qt_pressao_doador, t.qt_temperatura_doador, t.qt_hematocrito_doador, ";
            comando += "t.qt_hemoglobina_doador, if(t.ic_pre_triagem_doador = true, 'Aprovado', 'Reprovado'), if(t.ic_triagem_doador = ";
            comando += "true, 'Aprovado', 'Reprovado'), if(bc.ic_coleta_sem_sucesso = false, 'Coleta Realizada com Sucesso', 'Coleta Realizada sem Sucesso'), ";
            comando += "bc.hr_coleta, bc.cd_bolsa_coletada, ifnull(ts.nm_tipo_sanguineo, '-') from triagem t inner join bolsa_coletada bc on bc.cd_rg_doador = t.cd_rg_doador ";
            comando += "left join tipo_sanguineo ts on ts.cd_tipo_sanguineo = bc.cd_tipo_sanguineo where t.cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                lblPeso.Text += dados[0].ToString() + " kg";
                lblPulso.Text += dados[1].ToString() + " bpm";
                lblPressao.Text += dados[2].ToString() + " mmHg";
                lblTemperatura.Text += dados[3].ToString() + " ºC";
                lblHematocritos.Text += dados[4].ToString() + " %";
                lblHemoglobina.Text += dados[5].ToString() + " g/dL";
                if (dados[6].ToString() == "Aprovado")
                    lblPreTriagem.ForeColor = Color.Green;
                else
                    lblPreTriagem.ForeColor = Color.Red;
                lblPreTriagem.Text = dados[6].ToString();
                if (dados[7].ToString() == "Aprovado")
                    lblTriagem.ForeColor = Color.Green;
                else
                    lblTriagem.ForeColor = Color.Red;
                lblTriagem.Text = dados[7].ToString();
                if (dados[8].ToString() == "Coleta Realizada com Sucesso")
                    lblColeta.ForeColor = Color.Green;
                else
                    lblColeta.ForeColor = Color.Red;
                lblColeta.Text = dados[8].ToString();
                lblHrColeta.Text = dados[9].ToString().Substring(0, 5);
                lblCdBolsa.Text = dados[10].ToString();
                lblTipoSanguineo.Text = dados[11].ToString();
            }
            dados.Close();
            dados.Dispose();

            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                if (lbl.ForeColor == Color.Red)
                {
                    btnVerMais.Visible = false;
                }
            }

            if (btnVerMais.Visible)
            {
                int count = 0;
                string dia, mes, ano;
                string data = clsDadosGerais.dt_coleta;
                data = data.Replace("/", "");
                dia = data.Substring(0, 2);
                mes = data.Substring(2, 2);
                ano = data.Substring(4, 4);
                data = ano + "-" + mes + "-" + dia;
                clsDadosGerais.dt_coleta = data;

                comando = "select if(ic_resultado_exame = false, 'Negativo', 'Positivo') from exame where ";
                comando += "cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and dt_coleta = '" + clsDadosGerais.dt_coleta + "'";
                cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                dados = cSQL.ExecuteReader();
                while (dados.Read())
                {
                    switch (count)
                    {
                        case 0:
                            if (dados[0].ToString() == "Negativo")
                                lblHepatiteB.ForeColor = Color.Green;
                            else
                                lblHepatiteB.ForeColor = Color.Red;
                            lblHepatiteB.Text = dados[0].ToString();
                            break;
                        case 1:
                            if (dados[0].ToString() == "Negativo")
                                lblHepatiteC.ForeColor = Color.Green;
                            else
                                lblHepatiteC.ForeColor = Color.Red;
                            lblHepatiteC.Text = dados[0].ToString();
                            break;
                        case 2:
                            if (dados[0].ToString() == "Negativo")
                                lblHepatiteB.ForeColor = Color.Green;
                            else
                                lblHepatiteB.ForeColor = Color.Red;
                            lblLinfocitos.Text = dados[0].ToString();
                            break;
                        case 3:
                            if (dados[0].ToString() == "Negativo")
                                lblChagas.ForeColor = Color.Green;
                            else
                                lblChagas.ForeColor = Color.Red;
                            lblChagas.Text = dados[0].ToString();
                            break;
                        case 4:
                            if (dados[0].ToString() == "Negativo")
                                lblSifilis.ForeColor = Color.Green;
                            else
                                lblSifilis.ForeColor = Color.Red;
                            lblSifilis.Text = dados[0].ToString();
                            break;
                        case 5:
                            if (dados[0].ToString() == "Negativo")
                                lblHIV.ForeColor = Color.Green;
                            else
                                lblHIV.ForeColor = Color.Red;
                            lblHIV.Text = dados[0].ToString();
                            break;
                    }
                    count++;
                }
                dados.Close();
                dados.Dispose();

                foreach (Label lbl in pnlMais.Controls.OfType<Label>())
                {
                    if (lbl.ForeColor == Color.Red)
                    {
                        lblSorologia.Text = "Reprovado";
                        lblSorologia.ForeColor = Color.Red;
                        lblHemacia.Visible = false;
                        lblPlasma.Visible = false;
                        lblPlaqueta.Visible = false;
                        lblOcorrenciaHemacia.Visible = false;
                        lblOcorrenciaPlasma.Visible = false;
                        lblOcorrenciaPlaqueta.Visible = false;
                        lblDtHemacia.Visible = false;
                        lblDtPlasma.Visible = false;
                        lblDtPlaqueta.Visible = false;
                    }
                    else
                    {
                        for (int i = 1; i < 4; i++)
                        {
                            comando = "select bf.cd_bolsa_fracionada, sb.nm_situacao_bolsa, osb.dt_ocorrencia from bolsa_fracionada bf ";
                            comando += "inner join ocorrencia_situacao_bolsa osb on bf.dt_coleta = osb.dt_coleta and bf.cd_rg_doador = osb.cd_rg_doador ";
                            comando += "and bf.cd_tipo_fracionamento = osb.cd_tipo_fracionamento inner join situacao_bolsa sb on sb.cd_situacao_bolsa = osb.cd_situacao_bolsa ";
                            comando += "where bf.cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and osb.cd_situacao_bolsa = (select max(osbb.cd_situacao_bolsa) from ocorrencia_situacao_bolsa osbb ";
                            comando += "where osbb.cd_rg_doador = osb.cd_rg_doador and osbb.dt_coleta = osb.dt_coleta and osbb.cd_tipo_fracionamento = osb.cd_tipo_fracionamento) ";
                            comando += "and	bf.cd_tipo_fracionamento = " + i.ToString();
                            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                            dados = cSQL.ExecuteReader();
                            if (dados.Read())
                            {
                                switch (i)
                                {
                                    case 1:
                                        lblHemacia.Text = dados[0].ToString() + " - Hemácias:";
                                        lblOcorrenciaHemacia.Text = dados[1].ToString();
                                        lblDtHemacia.Text = dados[2].ToString().Substring(0, 10);
                                        break;
                                    case 2:
                                        lblPlasma.Text = dados[0].ToString() + " - Plasma:";
                                        lblOcorrenciaPlasma.Text = dados[1].ToString();
                                        lblDtPlasma.Text = dados[2].ToString().Substring(0, 10);
                                        break;
                                    case 3:
                                        lblPlaqueta.Text = dados[0].ToString() + " - Plaquetas:";
                                        lblOcorrenciaPlaqueta.Text = dados[1].ToString();
                                        lblDtPlaqueta.Text = dados[2].ToString().Substring(0, 10);
                                        break;
                                }
                            }
                            dados.Close();
                            dados.Dispose();
                        }
                    }
                }
            }
        }
        #endregion

        #region Botão Ver Mais
        private void btnVerMais_Click(object sender, EventArgs e)
        {
            pnlMais.Visible = true;
        }
        #endregion

        #region Botão Voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnlMais.Visible = false;
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
