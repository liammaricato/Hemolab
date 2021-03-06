﻿using System;
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
    public partial class frmTriagem : Form
    {
        public frmTriagem()
        {
            InitializeComponent();
        }

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblTriagem.Rows[tblTriagem.SelectedRows[0].Index].Cells[1].Value) == "")
            {
                MessageBox.Show("Selecione um doador para prosseguir!", "Triagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsDadosGerais.nm_doador = tblTriagem.Rows[tblTriagem.SelectedRows[0].Index].Cells[0].Value.ToString();
                clsDadosGerais.cd_rg_doador = tblTriagem.Rows[tblTriagem.SelectedRows[0].Index].Cells[1].Value.ToString();

                string comando = "select max(cd_triagem) from triagem where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "'";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                dados.Read();
                clsDadosGerais.cd_triagem = dados[0].ToString();
                dados.Close();

                Form frmTriagemDoador = new Triagem.frmTriagemDoador();
                clsAbreForm.AbreForm(frmTriagemDoador);
                this.Close();
            }
        }
        #endregion

        #region Form Load
        private void frmTriagem_Load(object sender, EventArgs e)
        {
            tblTriagem.DataSource = null;
            tblTriagem.Rows.Clear();
            tblTriagem.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            string comando = "select d.nm_doador as 'Nome do Doador', d.cd_rg_doador as 'RG do Doador', d.cd_cpf_doador as 'CPF do Doador', ";
            comando += "t.hr_triagem as 'Hora de Chegada' from triagem t inner join doador d on d.cd_rg_doador = t.cd_rg_doador ";
            comando += "where t.ic_triagem_doador is null and t.qt_quilos_doador is not null order by t.hr_triagem";

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblTriagem.DataSource = tabela;
            tblTriagem.AutoResizeColumns();
            tblTriagem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Cancelar Doação
        private void btnCancelarDoacao_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblTriagem.Rows[tblTriagem.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione um doador para cancelar a doação!", "Triagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("Tem certeza que deseja cancelar essa doação? Todos os dados dessa doação serão excluídos.", "Cancelar Doação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string cd_rg_doador = tblTriagem.Rows[tblTriagem.SelectedRows[0].Index].Cells[1].Value.ToString();
                    string cd_triagem;

                    string comando = "select max(cd_triagem) from triagem where cd_rg_doador = '" + cd_rg_doador + "'";
                    MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    MySqlDataReader dados = cSQL.ExecuteReader();
                    dados.Read();
                    cd_triagem = dados[0].ToString();
                    dados.Close();

                    comando = "delete from triagem where cd_rg_doador = '" + cd_rg_doador + "' and cd_triagem = " + cd_triagem;
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();

                    MessageBox.Show("Doação cancelada com sucesso! Os dados dessa doação foram excluídos.", "Cancelar Doação");

                    frmTriagem_Load(sender, e);
                }
            }
        }
        #endregion

        #region Timer
        private void tmrTriagem_Tick(object sender, EventArgs e)
        {
            frmTriagem_Load(sender, e);
        }
        #endregion
    }
}
