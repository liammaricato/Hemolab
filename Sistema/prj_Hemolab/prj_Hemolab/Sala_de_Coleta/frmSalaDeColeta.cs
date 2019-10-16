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
    public partial class frmSalaDeColeta : Form
    {
        public frmSalaDeColeta()
        {
            InitializeComponent();
        }

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblEspera.Rows[tblEspera.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione um doador para prosseguir!", "Sala de Espera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                string nome, rg, cpf, hora;
                nome = tblEspera.SelectedRows[0].Cells[0].Value.ToString();
                rg = tblEspera.SelectedRows[0].Cells[1].Value.ToString();
                cpf = tblEspera.SelectedRows[0].Cells[2].Value.ToString();
                hora = tblEspera.SelectedRows[0].Cells[3].Value.ToString();
                tblColeta.Rows.Add(nome, rg, cpf, hora);

                foreach (DataGridViewCell celula in tblEspera.SelectedCells)
                {
                    if (celula.Selected)
                        tblEspera.Rows.RemoveAt(celula.RowIndex);
                }

                btnTrocaSala_Click(sender, e);

                GerarEtiquetaBolsaInteira(rg);
            }
        }
        #endregion

        #region Form Load
        private void frmSalaDeColeta_Load(object sender, EventArgs e)
        {
            tblEspera.Rows.Clear();
            tblEspera.Columns.Clear();
            tblEspera.Columns.Add("c1", "Nome do Doador");
            tblEspera.Columns.Add("c2", "RG do Doador");
            tblEspera.Columns.Add("c3", "CPF do Doador");
            tblEspera.Columns.Add("c4", "Hora de Chegada");

            tblColeta.Rows.Clear();
            tblColeta.Columns.Clear();
            tblColeta.Columns.Add("c1", "Nome do Doador");
            tblColeta.Columns.Add("c2", "RG do Doador");
            tblColeta.Columns.Add("c3", "CPF do Doador");
            tblColeta.Columns.Add("c4", "Hora de Chegada");

            string comando = "select d.nm_doador as 'Nome do Doador', d.cd_rg_doador as 'RG do Doador', d.cd_cpf_doador as 'CPF do Doador', ";
            comando += "t.hr_triagem as 'Hora de Chegada' from triagem t inner join doador d on d.cd_rg_doador = t.cd_rg_doador ";
            comando += "inner join bolsa_coletada bc on t.cd_rg_doador = bc.cd_rg_doador where t.ic_triagem_doador = true and bc.hr_coleta is null order by t.hr_triagem";

            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                tblEspera.Rows.Add(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString().Substring(0, 8));
            }
            dados.Close();
            dados.Dispose();

            tblEspera.AutoResizeColumns();
            tblEspera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Cancelar Doação
        private void btnCancelarDoacao_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblEspera.Rows[tblEspera.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione um doador para cancelar a doação!", "Sala de Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("Tem certeza que deseja cancelar essa doação? Todos os dados dessa doação serão excluídos.", "Cancelar Doação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string cd_rg_doador = tblEspera.Rows[tblEspera.SelectedRows[0].Index].Cells[1].Value.ToString();
                    string cd_triagem;
                    string cd_bolsa_coletada;

                    string comando = "select max(cd_triagem) from triagem where cd_rg_doador = '" + cd_rg_doador + "'";
                    MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    MySqlDataReader dados = cSQL.ExecuteReader();
                    dados.Read();
                    cd_triagem = dados[0].ToString();
                    dados.Close();

                    comando = "delete from triagem where cd_rg_doador = '" + cd_rg_doador + "' and cd_triagem = " + cd_triagem;
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();

                    comando = "select max(cd_bolsa_coletada) from bolsa_coletada where cd_rg_doador = '" + cd_rg_doador + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    dados = cSQL.ExecuteReader();
                    dados.Read();
                    cd_bolsa_coletada = dados[0].ToString();
                    dados.Close();

                    comando = "delete from bolsa_coletada where cd_rg_doador = '" + cd_rg_doador + "' and cd_bolsa_coletada =  '" + cd_bolsa_coletada + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();

                    MessageBox.Show("Doação cancelada com sucesso! Os dados dessa doação foram excluídos.", "Cancelar Doação");

                    frmSalaDeColeta_Load(sender, e);
                }
            }
        }
        #endregion

        #region Botão Troca Sala
        private void btnTrocaSala_Click(object sender, EventArgs e)
        {
            if (lblSala.Text == "Sala de Espera")
            {
                lblSala.Text = "Sala de Coleta";
                btnTrocaSala.Text = "Ver Sala de Espera";
                pnlSaladeColeta.Visible = true;
            }
            else
            {
                lblSala.Text = "Sala de Espera";
                btnTrocaSala.Text = "Ver Sala de Coleta";
                pnlSaladeColeta.Visible = false;
            }
        }
        #endregion

        #region Botão Concluir
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblColeta.Rows[tblColeta.SelectedRows[0].Index].Cells[1].Value) == "")
            {
                MessageBox.Show("Selecione um doador para prosseguir!", "Sala de Coleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                
                clsDadosGerais.nm_doador = tblColeta.Rows[tblEspera.SelectedRows[0].Index].Cells[0].Value.ToString();
                clsDadosGerais.cd_rg_doador = tblColeta.Rows[tblEspera.SelectedRows[0].Index].Cells[1].Value.ToString();

                Form frmBolsaColetada = new frmBolsaColetada();
                frmBolsaColetada.StartPosition = FormStartPosition.CenterScreen;
                if (frmBolsaColetada.ShowDialog() == DialogResult.Yes)
                {
                    foreach (DataGridViewCell celula in tblColeta.SelectedCells)
                    {
                        if (celula.Selected)
                            tblColeta.Rows.RemoveAt(celula.RowIndex);
                    }
                }
            }
        }
        #endregion

        #region Timer
        private void tmrColeta_Tick(object sender, EventArgs e)
        {
            tblEspera.Rows.Clear();
            tblEspera.Columns.Clear();
            tblEspera.Columns.Add("c1", "Nome do Doador");
            tblEspera.Columns.Add("c2", "RG do Doador");
            tblEspera.Columns.Add("c3", "CPF do Doador");
            tblEspera.Columns.Add("c4", "Hora de Chegada");

            string comando = "select d.nm_doador as 'Nome do Doador', d.cd_rg_doador as 'RG do Doador', d.cd_cpf_doador as 'CPF do Doador', ";
            comando += "t.hr_triagem as 'Hora de Chegada' from triagem t inner join doador d on d.cd_rg_doador = t.cd_rg_doador ";
            comando += "inner join bolsa_coletada bc on t.cd_rg_doador = bc.cd_rg_doador where t.ic_triagem_doador = true and bc.hr_coleta is null order by t.hr_triagem";

            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                tblEspera.Rows.Add(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString().Substring(0, 8));
            }
            dados.Close();
            dados.Dispose();

            for (int i = 0; i < tblEspera.Rows.Count; i++)
            {
                if (Convert.ToString(tblEspera.Rows[i].Cells[0].Value) == "")
                    break;

                for (int t = 0; t < tblColeta.Rows.Count; t++)
                {
                    if (Convert.ToString(tblColeta.Rows[i].Cells[0].Value) == "")
                        break;

                    if (Convert.ToString(tblEspera.Rows[i].Cells[0].Value) == Convert.ToString(tblEspera.Rows[t].Cells[0].Value))
                    {
                        tblEspera.Rows.RemoveAt(i);
                    }
                }
            }

            tblEspera.AutoResizeColumns();
            tblEspera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Gerar Etiqueta
        public static void GerarEtiquetaBolsaInteira(string rg)
        {
            clsExcel excel = new clsExcel();

            string comando = " select dt_coleta,cd_rg_doador,cd_bolsa_coletada,time(now()) from bolsa_coletada ";
            comando += "where cd_rg_doador = '"+rg+"'";

            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                excel.AbreArquivo(System.Windows.Forms.Application.StartupPath + @"\etiquetabolsainteira.xlsx");
                excel.EscolhaPlan(1);
                excel.Adiciona("A4", clsFuncoes.ConverterData(dados[0].ToString()));
                excel.Adiciona("A6", "Doador: " + dados[1].ToString());
                excel.Adiciona("A7", "Nº da Bolsa: " + dados[2].ToString());
                excel.Adiciona("A8", "*" + dados[2].ToString() + "*");
                excel.Adiciona("D4", dados[3].ToString().Substring(0,5));
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

    }
}
