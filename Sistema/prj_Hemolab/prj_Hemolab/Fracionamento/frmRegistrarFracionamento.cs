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

namespace prj_Hemolab.Fracionamento
{
    public partial class frmRegistrarFracionamento : Form
    {
        public frmRegistrarFracionamento()
        {
            InitializeComponent();
        }

        #region Função que gera a etiqueta
        public static void GerarEtiqueta(string codigo)
        {
            clsExcel excel = new clsExcel();

            string bolsa = "";

            string somadata = "";

            switch (codigo.Substring(codigo.Length - 1, 1))
            {
                case "1": somadata = " date_add(bf.dt_coleta, interval 35 day) ";
                    break;
                case "2": somadata = " date_add(bf.dt_coleta, interval 1 year)";
                    break;
                case "3": somadata = " date_add(bf.dt_coleta, interval 5 day) ";
                    break;
            }

            string comando = "select bf.dt_coleta, bc.hr_coleta, " + somadata + " , bf.cd_rg_doador, bf.cd_bolsa_fracionada, ts.nm_tipo_sanguineo, bf.qt_gramas_bolsa_fracionada from ";
            comando += " bolsa_fracionada bf inner join bolsa_coletada bc on bf.cd_rg_doador = bc.cd_rg_doador and bf.dt_coleta = bc.dt_coleta ";
            comando += " left join tipo_sanguineo ts on bc.cd_tipo_sanguineo = ts.cd_tipo_sanguineo where bf.cd_bolsa_fracionada = " + codigo + ";";


            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                excel.AbreArquivo(Application.StartupPath + @"\etiqueta.xlsx");
                excel.EscolhaPlan(1);
                excel.Adiciona("A4", clsFuncoes.ConverterData(dados[0].ToString()));
                excel.Adiciona("A7", "Nº da Bolsa: " + dados[4].ToString());
                excel.Adiciona("C4", dados[1].ToString());
                excel.Adiciona("E4", dados[2].ToString().Substring(0, 10));
                excel.Adiciona("A6", "Doador: " + dados[3].ToString());
                excel.Adiciona("A8", "*" + dados[4].ToString() + "*");
                excel.Adiciona("E6", dados[5].ToString());
                excel.Adiciona("G15", "Peso: " + dados[6].ToString() + "g");
                bolsa = dados[4].ToString();
                switch (codigo.Substring(codigo.Length - 1, 1))
                {
                    case "1": excel.Adiciona("A14", "Concentrado de Hemácias");
                        excel.Adiciona("A15", "NÃO ADICIONAR MEDICAMENTOS   Armazenar a: 4°C");
                        break;
                    case "2": excel.Adiciona("A14", "Plasma Fresco Congelado");
                        excel.Adiciona("A15", "NÃO ADICIONAR MEDICAMENTOS   Armazenar a: -30°C");
                        break;
                    case "3": excel.Adiciona("A14", "Concentrado de Plaquetas");
                        excel.Adiciona("A15", "NÃO ADICIONAR MEDICAMENTOS   Armazenar a: 22°C");
                        break;
                }
            }

            else
            {
                MessageBox.Show("Essa bolsa não existe!", "Erro");
                dados.Close();
                return;
            }
            dados.Close();

            excel.Salvar("EtiquetaBolsa");
            clsExcel.xlsArquivo.PrintOut();
            clsExcel.xlsArquivo.Close();
        }
        #endregion

        #region Função que insere a bolsa fracionada no banco de dados
        private void InsereFracionamento(string cd_tipo_fracionamento, string qt_gramas_bolsa_fracionada)
        {
            string comando = "insert into bolsa_fracionada values ('" + clsDadosGerais.dt_coleta + "', '" + clsDadosGerais.cd_rg_doador + "', " + cd_tipo_fracionamento + ", '" + clsDadosGerais.cd_bolsa_coletada + cd_tipo_fracionamento + "', " + qt_gramas_bolsa_fracionada + ")";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();

            comando = "insert into ocorrencia_situacao_bolsa values ('" + clsDadosGerais.data_hoje() + "', ";
            comando += "'" + clsDadosGerais.hora_atual() + "', 1, '" + clsDadosGerais.dt_coleta + "', ";
            comando += "'" + clsDadosGerais.cd_rg_doador + "', " + cd_tipo_fracionamento + ", " + clsDadosGerais.cd_usuario + ", false)";
            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
        }
        #endregion

        #region Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string impressao = "";
            bool imprimiu = false;

            if (txtPesoHemacias.Enabled == true && txtPesoHemacias.Text != "")
            {
                InsereFracionamento("1", txtPesoHemacias.Text);
                impressao += "1";
            }
            if (txtPesoPlasma.Enabled == true && txtPesoPlasma.Text != "")
            {
                InsereFracionamento("2", txtPesoPlasma.Text);
                impressao += "2";
            }
            if (txtPesoPlaquetas.Enabled == true && txtPesoPlaquetas.Text != "")
            {
                InsereFracionamento("3", txtPesoPlaquetas.Text);
                impressao += "3";
            }

            if (impressao == "")
            {
                MessageBox.Show("Preencha o peso das bolsas que você quiser registrar o fracionamento!");
                return;
            }
            else
            {
                while (!imprimiu)
                {
                    bool repete = false;
                    try
                    {
                        if (impressao.Length == 1)
                        {
                            if (!repete)
                                MessageBox.Show("Fracionamento registrado com sucesso! A etiqueta será impressa agora.", "Fracionamento");
                            GerarEtiqueta(clsDadosGerais.cd_bolsa_coletada + impressao);
                            imprimiu = true;
                        }
                        else
                        {
                            if (!repete)
                                MessageBox.Show("Fracionamento registrado com sucesso! As etiquetas serão impressas agora.", "Fracionamento");
                            for (int i = 0; i < impressao.Length; i++)
                            {
                                GerarEtiqueta(clsDadosGerais.cd_bolsa_coletada + impressao.Substring(i, 1));
                            }
                            imprimiu = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível imprimir a etiqueta agora! O sistema tentará imprimir novamente.", "Erro na impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        repete = true;
                    }
                }
            }
            Form frmFracionamento = new frmFracionamento();
            clsAbreForm.AbreForm(frmFracionamento);
            this.Close();
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Essas alterações não serão salvas!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Form frmFracionamento = new frmFracionamento();
                clsAbreForm.AbreForm(frmFracionamento);
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
        private void frmRegistrarFracionamento_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 4; i++)
            {
                string comando = "select qt_gramas_bolsa_fracionada from bolsa_fracionada where cd_bolsa_fracionada = '" + clsDadosGerais.cd_bolsa_coletada + i.ToString() + "'";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                if (dados.Read())
                {
                    switch (i)
                    {
                        case 1:
                            txtPesoHemacias.Text = dados[0].ToString();
                            txtPesoHemacias.Enabled = false;
                            break;
                        case 2:
                            txtPesoPlasma.Text = dados[0].ToString();
                            txtPesoPlasma.Enabled = false;
                            break;
                        case 3:
                            txtPesoPlaquetas.Text = dados[0].ToString();
                            txtPesoPlaquetas.Enabled = false;
                            break;
                    }
                }
                dados.Close();
                dados.Dispose();
            }
            lblCdBolsa.Text = clsDadosGerais.cd_bolsa_coletada;
        }
        #endregion

        
    }
}
