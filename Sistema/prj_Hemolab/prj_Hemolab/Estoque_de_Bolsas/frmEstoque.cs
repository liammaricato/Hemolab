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
    public partial class frmEstoque : Form
    {
        public frmEstoque()
        {
            InitializeComponent();
        }

        MySqlConnection conexao2 = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PASSWORD=root;DATABASE=hemolab");

        #region Função que abre a notificação
        private void AbreNotificacao(object sender, EventArgs e)
        {
            if (Convert.ToString(tblEstoque.SelectedRows[0].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione uma notifiação para ver!", "Estoque de Bolsas");
                return;
            }

            clsDadosGerais.cd_bolsa_fracionada = tblEstoque.SelectedRows[0].Cells[0].Value.ToString();
            clsDadosGerais.nm_tipo_fracionamento = tblEstoque.SelectedRows[0].Cells[1].Value.ToString();
            if (tblEstoque.SelectedRows[0].Cells[2].Value.ToString() == "Bolsa liberada")
                clsDadosGerais.cd_ocorrencia = "1";
            else
            {
                if (tblEstoque.SelectedRows[0].Cells[2].Value.ToString() == "Bolsa reprovada na Sorologia")
                    clsDadosGerais.cd_ocorrencia = "2";
                else
                    clsDadosGerais.cd_ocorrencia = "3";
            }
            Form frmNotificacaoBolsa = new frmNotificacaoBolsa();
            frmNotificacaoBolsa.StartPosition = FormStartPosition.CenterScreen;
            if (frmNotificacaoBolsa.ShowDialog() == DialogResult.Yes)
            {
                tmrSelect_Tick(sender, e);
            }
        }
        #endregion

        #region Função que insere no banco quando uma bolsa passou da validade
        private void PassouDaValidade()
        {
            conexao2.Open();
            string comando1 = "select bf.dt_coleta, bf.cd_rg_doador, bf.cd_tipo_fracionamento from bolsa_fracionada bf ";
            comando1 += "left join ocorrencia_situacao_bolsa osb on bf.dt_coleta = osb.dt_coleta and bf.cd_rg_doador = osb.cd_rg_doador ";
            comando1 += "and bf.cd_tipo_fracionamento = osb.cd_tipo_fracionamento where case bf.cd_tipo_fracionamento ";
            comando1 += "when 1 then curdate() > date_add(bf.dt_coleta, interval 35 day) ";
            comando1 += "when 2 then curdate() > date_add(bf.dt_coleta, interval 1 year) ";
            comando1 += "when 3 then curdate() > date_add(bf.dt_coleta, interval 5 day)	end ";
            comando1 += "and not exists(select 1 from ocorrencia_situacao_bolsa osbb where osbb.dt_coleta = bf.dt_coleta ";
            comando1 += "and osbb.cd_rg_doador = bf.cd_rg_doador and osbb.cd_tipo_fracionamento = bf.cd_tipo_fracionamento ";
            comando1 += "and (osbb.cd_situacao_bolsa = 3 or osbb.cd_situacao_bolsa = 2))";
            MySqlCommand cSQL = new MySqlCommand(comando1, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                string dt_coleta = dados[0].ToString().Substring(0, 10);
                string dia, mes, ano;
                dt_coleta = dt_coleta.Replace("/", "");
                dia = dt_coleta.Substring(0, 2);
                mes = dt_coleta.Substring(2, 2);
                ano = dt_coleta.Substring(4, 4);
                dt_coleta = ano + "-" + mes + "-" + dia;
                string comando2 = "insert into ocorrencia_situacao_bolsa values ('" + clsDadosGerais.data_hoje() + "', ";
                comando2 += "'" + clsDadosGerais.hora_atual() + "', 3, '" + dt_coleta + "', '" + dados[1].ToString() + "', ";
                comando2 += dados[2].ToString() + ", " + clsDadosGerais.cd_usuario + ", false)";
                MySqlCommand cSQL2 = new MySqlCommand(comando2, conexao2);
                cSQL2.ExecuteNonQuery();
            }
            dados.Close();
            dados.Dispose();
        }
        #endregion

        #region Função que faz o select
        public void SelectNotificacoes()
        {
            tblEstoque.Rows.Clear();
            tblEstoque.Columns.Clear();
            tblEstoque.Columns.Add("c1", "Código da Bolsa");
            tblEstoque.Columns.Add("c2", "Tipo de Fracionamento");
            tblEstoque.Columns.Add("c3", "Procedimento");
            tblEstoque.Columns.Add("c4", "Data da Ocorrência");
            tblEstoque.Columns.Add("c5", "Hora da Ocorrência");

            string comando = "select bf.cd_bolsa_fracionada, tf.nm_tipo_fracionamento, osb.cd_situacao_bolsa, osb.dt_ocorrencia, ";
            comando += "osb.hr_ocorrencia from ocorrencia_situacao_bolsa osb inner join bolsa_fracionada bf on bf.dt_coleta = osb.dt_coleta ";
            comando += "and bf.cd_rg_doador = osb.cd_rg_doador and bf.cd_tipo_fracionamento = osb.cd_tipo_fracionamento	inner join ";
            comando += "tipo_fracionamento tf on tf.cd_tipo_fracionamento = bf.cd_tipo_fracionamento where osb.ic_procedimento_realizado = ";
            comando += "false and (osb.cd_situacao_bolsa = 1 or osb.cd_situacao_bolsa = 3)";

            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while(dados.Read())
            {
                string ocorrencia;
                if (dados[2].ToString() == "1")
                    ocorrencia = "Bolsa liberada";
                else
                    ocorrencia = "Bolsa fora da validade";

                tblEstoque.Rows.Add(dados[0].ToString(), dados[1].ToString(), ocorrencia, dados[3].ToString().Substring(0, 10), dados[4].ToString());
            }
            dados.Close();
            dados.Dispose();

            comando = "select bc.cd_bolsa_coletada, e.dt_exame from bolsa_coletada bc inner join exame e on e.dt_coleta = bc.dt_coleta ";
            comando += "and e.cd_rg_doador = bc.cd_rg_doador where exists (select 1 from exame ee where bc.dt_coleta = ee.dt_coleta ";
            comando += "and bc.cd_rg_doador = ee.cd_rg_doador and ee.ic_resultado_exame = true) and bc.dt_descarte_bolsa is null group by bc.cd_bolsa_coletada";

            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                tblEstoque.Rows.Add(dados[0].ToString(), " -", "Bolsa reprovada na Sorologia", dados[1].ToString().Substring(0, 10), " -");
            }
            dados.Close();
            dados.Dispose();

            tblEstoque.AutoResizeColumns();
            tblEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Form Load
        private void frmEstoque_Load(object sender, EventArgs e)
        {
            PassouDaValidade();
            SelectNotificacoes();
        }
        #endregion

        #region Timer
        private void tmrSelect_Tick(object sender, EventArgs e)
        {
            if (rdbTodos.Checked)
                SelectNotificacoes();

            if (rdbLiberada.Checked)
                rdbLiberada_CheckedChanged(sender, e);

            if (rdbReprovada.Checked)
                rdbReprovada_CheckedChanged(sender, e);

            if (rdbValidade.Checked)
                rdbValidade_CheckedChanged(sender, e);
        }
        #endregion

        #region Double Click na linha da DataGrid
        private void tblEstoque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbreNotificacao(sender, e);
        }
        #endregion

        #region Botão Ver
        private void btnVer_Click(object sender, EventArgs e)
        {
            AbreNotificacao(sender, e);
        }
        #endregion

        #region RadioButton Todos
        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTodos.Checked == true)
                SelectNotificacoes();
        }
        #endregion

        #region RadioButton Liberada
        private void rdbLiberada_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLiberada.Checked == true)
            {
                tblEstoque.Rows.Clear();
                tblEstoque.Columns.Clear();
                tblEstoque.Columns.Add("c1", "Código da Bolsa");
                tblEstoque.Columns.Add("c2", "Tipo de Fracionamento");
                tblEstoque.Columns.Add("c3", "Procedimento");
                tblEstoque.Columns.Add("c4", "Data da Ocorrência");
                tblEstoque.Columns.Add("c5", "Hora da Ocorrência");

                string comando = "select bf.cd_bolsa_fracionada, tf.nm_tipo_fracionamento, osb.cd_situacao_bolsa, osb.dt_ocorrencia, ";
                comando += "osb.hr_ocorrencia from ocorrencia_situacao_bolsa osb inner join bolsa_fracionada bf on bf.dt_coleta = osb.dt_coleta ";
                comando += "and bf.cd_rg_doador = osb.cd_rg_doador and bf.cd_tipo_fracionamento = osb.cd_tipo_fracionamento	inner join ";
                comando += "tipo_fracionamento tf on tf.cd_tipo_fracionamento = bf.cd_tipo_fracionamento where osb.ic_procedimento_realizado = ";
                comando += "false and osb.cd_situacao_bolsa = 1";

                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                while (dados.Read())
                {
                    string ocorrencia = "Bolsa liberada";
                    tblEstoque.Rows.Add(dados[0].ToString(), dados[1].ToString(), ocorrencia, dados[3].ToString().Substring(0, 10), dados[4].ToString());
                }
                dados.Close();
                dados.Dispose();

                tblEstoque.AutoResizeColumns();
                tblEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        #endregion

        #region RadioButton Reprovada
        private void rdbReprovada_CheckedChanged(object sender, EventArgs e)
        {
            tblEstoque.Rows.Clear();
            tblEstoque.Columns.Clear();
            tblEstoque.Columns.Add("c1", "Código da Bolsa");
            tblEstoque.Columns.Add("c2", "Tipo de Fracionamento");
            tblEstoque.Columns.Add("c3", "Procedimento");
            tblEstoque.Columns.Add("c4", "Data da Ocorrência");
            tblEstoque.Columns.Add("c5", "Hora da Ocorrência");

            string comando = "select bc.cd_bolsa_coletada, e.dt_exame from bolsa_coletada bc inner join exame e on e.dt_coleta = bc.dt_coleta ";
            comando += "and e.cd_rg_doador = bc.cd_rg_doador where exists (select 1 from exame ee where bc.dt_coleta = ee.dt_coleta ";
            comando += "and bc.cd_rg_doador = ee.cd_rg_doador and ee.ic_resultado_exame = true) and bc.dt_descarte_bolsa is null group by bc.cd_bolsa_coletada";

            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                tblEstoque.Rows.Add(dados[0].ToString(), " -", "Bolsa reprovada na Sorologia", dados[1].ToString().Substring(0, 10), " -");
            }
            dados.Close();
            dados.Dispose();

            tblEstoque.AutoResizeColumns();
            tblEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region RadioButton Validade
        private void rdbValidade_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbValidade.Checked == true)
            {
                tblEstoque.Rows.Clear();
                tblEstoque.Columns.Clear();
                tblEstoque.Columns.Add("c1", "Código da Bolsa");
                tblEstoque.Columns.Add("c2", "Tipo de Fracionamento");
                tblEstoque.Columns.Add("c3", "Procedimento");
                tblEstoque.Columns.Add("c4", "Data da Ocorrência");
                tblEstoque.Columns.Add("c5", "Hora da Ocorrência");

                string comando = "select bf.cd_bolsa_fracionada, tf.nm_tipo_fracionamento, osb.cd_situacao_bolsa, osb.dt_ocorrencia, ";
                comando += "osb.hr_ocorrencia from ocorrencia_situacao_bolsa osb inner join bolsa_fracionada bf on bf.dt_coleta = osb.dt_coleta ";
                comando += "and bf.cd_rg_doador = osb.cd_rg_doador and bf.cd_tipo_fracionamento = osb.cd_tipo_fracionamento	inner join ";
                comando += "tipo_fracionamento tf on tf.cd_tipo_fracionamento = bf.cd_tipo_fracionamento where osb.ic_procedimento_realizado = ";
                comando += "false and osb.cd_situacao_bolsa = 3";

                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                while(dados.Read())
                {
                    string ocorrencia = "Bolsa fora da validade";
                    tblEstoque.Rows.Add(dados[0].ToString(), dados[1].ToString(), ocorrencia, dados[3].ToString().Substring(0, 10), dados[4].ToString());
                }
                dados.Close();
                dados.Dispose();

                tblEstoque.AutoResizeColumns();
                tblEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        #endregion
    }
}
