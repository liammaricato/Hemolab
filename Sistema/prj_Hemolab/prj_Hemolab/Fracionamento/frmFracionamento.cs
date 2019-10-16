using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using prj_Hemolab.Classes;
using MySql.Data.MySqlClient;

namespace prj_Hemolab.Fracionamento
{
    public partial class frmFracionamento : Form
    {
        public frmFracionamento()
        {
            InitializeComponent();
        }

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblFracionamento.Rows[tblFracionamento.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione uma bolsa para prosseguir!", "Fracionamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsDadosGerais.cd_bolsa_coletada = tblFracionamento.Rows[tblFracionamento.SelectedRows[0].Index].Cells[0].Value.ToString();

                string comando = "select cd_rg_doador, dt_coleta from bolsa_coletada where cd_bolsa_coletada = " + clsDadosGerais.cd_bolsa_coletada;
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                if (dados.Read())
                {
                    clsDadosGerais.cd_rg_doador = dados[0].ToString();
                    string dia, mes, ano;
                    string data = dados[1].ToString();
                    data = data.Replace("/", "");
                    dia = data.Substring(0, 2);
                    mes = data.Substring(2, 2);
                    ano = data.Substring(4, 4);
                    clsDadosGerais.dt_coleta = ano + "-" + mes + "-" + dia;
                }
                dados.Close();

                Form frmRegistrarFracionamento = new frmRegistrarFracionamento();
                clsAbreForm.AbreForm(frmRegistrarFracionamento);
                this.Close();
            }
        }
        #endregion

        #region Form Load
        private void frmFracionamento_Load(object sender, EventArgs e)
        {
            tblFracionamento.DataSource = null;
            tblFracionamento.Rows.Clear();
            tblFracionamento.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            string comando = "select bc.cd_bolsa_coletada as 'Código da Bolsa', bc.cd_rg_doador as 'RG do Doador', bc.dt_coleta as 'Data da Coleta', ";
            comando += "bc.hr_coleta as 'Hora da Coleta' from bolsa_coletada bc where exists ";
            comando += "(select 1 from exame e where bc.dt_coleta = e.dt_coleta and bc.cd_rg_doador = e.cd_rg_doador) and not exists ";
            comando += "(select 1 from exame e where bc.dt_coleta = e.dt_coleta and bc.cd_rg_doador = e.cd_rg_doador and ";
            comando += "ifnull(ic_resultado_exame, true) = true) and bc.cd_tipo_sanguineo is not null ";
            comando += "and (select count(bf.cd_bolsa_fracionada) from bolsa_fracionada bf where bf.cd_rg_doador = bc.cd_rg_doador and bf.dt_coleta = bc.dt_coleta) < 3";

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblFracionamento.DataSource = tabela;
            tblFracionamento.AutoResizeColumns();
            tblFracionamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCdBolsa.Text.Trim() == "")
            {
                if (MessageBox.Show("Deseja exibir todas as bolsas?", "Fracionamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmFracionamento_Load(sender, e);
                    return;
                }
            }
            else
            {
                string cd_bolsa_coletada;

                cd_bolsa_coletada = txtCdBolsa.Text.Trim();

                tblFracionamento.DataSource = null;
                tblFracionamento.Rows.Clear();
                tblFracionamento.Columns.Clear();

                MySqlDataAdapter dadosLocal;
                DataTable tabela;

                string comando = "select bc.cd_bolsa_coletada as 'Código da Bolsa', bc.cd_rg_doador as 'RG do Doador', bc.dt_coleta as 'Data da Coleta', ";
                comando += "bc.hr_coleta as 'Hora da Coleta' from bolsa_coletada bc where exists ";
                comando += "(select 1 from exame e where bc.dt_coleta = e.dt_coleta and bc.cd_rg_doador = e.cd_rg_doador) and not exists ";
                comando += "(select 1 from exame e where bc.dt_coleta = e.dt_coleta and bc.cd_rg_doador = e.cd_rg_doador and ";
                comando += "ifnull(ic_resultado_exame, true) = true) and bc.cd_tipo_sanguineo is not null and bc.cd_bolsa_coletada = " + cd_bolsa_coletada;
                comando += " and (select count(bf.cd_bolsa_fracionada) from bolsa_fracionada bf where bf.cd_rg_doador = bc.cd_rg_doador and bf.dt_coleta = bc.dt_coleta) < 3";

                dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
                tabela = new DataTable();
                dadosLocal.Fill(tabela);

                tblFracionamento.DataSource = tabela;
                tblFracionamento.AutoResizeColumns();
                tblFracionamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        #endregion

        #region Timer
        private void tmrFracionamento_Tick(object sender, EventArgs e)
        {
            frmFracionamento_Load(sender, e);
        }
        #endregion
    }
}
