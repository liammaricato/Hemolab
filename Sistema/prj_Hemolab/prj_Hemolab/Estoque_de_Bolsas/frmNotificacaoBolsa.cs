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

namespace prj_Hemolab.Estoque_de_Bolsas
{
    public partial class frmNotificacaoBolsa : Form
    {
        public frmNotificacaoBolsa()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmNotificacaoBolsa_Load(object sender, EventArgs e)
        {
            if (clsDadosGerais.cd_ocorrencia == "1")
            {
                lblOcorrencia.Text = "Bolsa liberada: A bolsa de sangue passou nos exames, coloque-a na respectiva geladeira de sangue liberado.";
                lblOcorrencia.BackColor = Color.PaleGreen;
            }
            else
            {
                if (clsDadosGerais.cd_ocorrencia == "2")
                {
                    lblOcorrencia.Text = "Bolsa reprovada na Sorologia: A bolsa de sangue teve resultado positivo em algum dos exames, faça o devido descarte da mesma.";
                    lblOcorrencia.BackColor = Color.DarkSalmon;
                }
                else
                {
                    lblOcorrencia.Text = "Bolsa fora da validade: A bolsa de sangue passou da sua data de validade, faça o devido descarte da mesma.";
                    lblOcorrencia.BackColor = Color.DarkSalmon;
                }
            }

            lblCdBolsa.Text = clsDadosGerais.cd_bolsa_fracionada;
            lblTipoFracionamento.Text = clsDadosGerais.nm_tipo_fracionamento;
        }
        #endregion

        #region Botão Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion

        #region Botão Feito
        private void btnFeito_Click(object sender, EventArgs e)
        {
            if (clsDadosGerais.cd_ocorrencia != "2")
            {
                string cd_rg_doador;
                string dt_coleta;
                string cd_tipo_fracionamento;

                string comando = "select cd_rg_doador, dt_coleta, cd_tipo_fracionamento from bolsa_fracionada where cd_bolsa_fracionada = " + clsDadosGerais.cd_bolsa_fracionada;
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                dados.Read();
                cd_rg_doador = dados[0].ToString();
                dt_coleta = dados[1].ToString().Substring(0, 10);
                cd_tipo_fracionamento = dados[2].ToString();
                dados.Close();
                dados.Dispose();

                string dia, mes, ano;
                dt_coleta = dt_coleta.Replace("/", "");
                dia = dt_coleta.Substring(0, 2);
                mes = dt_coleta.Substring(2, 2);
                ano = dt_coleta.Substring(4, 4);
                dt_coleta = ano + "-" + mes + "-" + dia;

                comando = "update ocorrencia_situacao_bolsa set ic_procedimento_realizado = true ";
                comando += "where dt_coleta = '" + dt_coleta + "' and cd_rg_doador = '" + cd_rg_doador + "' ";
                comando += "and cd_tipo_fracionamento = " + cd_tipo_fracionamento + " and cd_situacao_bolsa = " + clsDadosGerais.cd_ocorrencia;
                cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();
            }
            else
            {
                string dt_coleta;
                string cd_rg_doador;

                string comando = "select cd_rg_doador, dt_coleta from bolsa_coletada where cd_bolsa_coletada = " + clsDadosGerais.cd_bolsa_fracionada;
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                dados.Read();
                cd_rg_doador = dados[0].ToString();
                dt_coleta = dados[1].ToString().Substring(0, 10);
                dados.Close();
                dados.Dispose();

                string dia, mes, ano;
                dt_coleta = dt_coleta.Replace("/", "");
                dia = dt_coleta.Substring(0, 2);
                mes = dt_coleta.Substring(2, 2);
                ano = dt_coleta.Substring(4, 4);
                dt_coleta = ano + "-" + mes + "-" + dia;

                comando = "update bolsa_coletada set dt_descarte_bolsa = '" + clsDadosGerais.data_hoje() + "' where dt_coleta = '" + dt_coleta + "' and cd_rg_doador = '" + cd_rg_doador + "'";
                cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();
            }

            MessageBox.Show("Ocorrência registrada com sucesso!", "Estoque");
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion
    }
}
