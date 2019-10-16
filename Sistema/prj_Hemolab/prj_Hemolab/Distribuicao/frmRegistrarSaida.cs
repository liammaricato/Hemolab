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

namespace prj_Hemolab.Distribuicao
{
    public partial class frmRegistrarSaida : Form
    {
        public frmRegistrarSaida()
        {
            InitializeComponent();
        }

        #region Função que insere a ocorrência
        private void InsereOcorrencia(string cd_bolsa_fracionada)
        {
            string dia, mes, ano;
            string data = DateTime.Now.ToString().Substring(0, 10);
            data = data.Replace("/", "");
            dia = data.Substring(0, 2);
            mes = data.Substring(2, 2);
            ano = data.Substring(4, 4);
            data = ano + "-" + mes + "-" + dia;

            string hora = DateTime.Now.ToString().Substring(11, 8);

            string dt_coleta;
            string cd_rg_doador;
            string cd_tipo_fracionamento;

            string comando = "select dt_coleta, cd_rg_doador, cd_tipo_fracionamento from bolsa_fracionada where cd_bolsa_fracionada = " + cd_bolsa_fracionada;
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            dados.Read();
            dt_coleta = dados[0].ToString().Substring(0, 10);
            cd_rg_doador = dados[1].ToString();
            cd_tipo_fracionamento = dados[2].ToString();
            dados.Close();

            dt_coleta = dt_coleta.Replace("/", "");
            dia = dt_coleta.Substring(0, 2);
            mes = dt_coleta.Substring(2, 2);
            ano = dt_coleta.Substring(4, 4);
            dt_coleta = ano + "-" + mes + "-" + dia;

            comando = "insert into ocorrencia_situacao_bolsa values ('" + data + "', '" + hora + "', 2, '" + dt_coleta + "', '" + cd_rg_doador + "', ";
            comando += cd_tipo_fracionamento + ", " + clsDadosGerais.cd_usuario + ", true)";
            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
        }
        #endregion

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Form frmBuscarBolsa = new frmBuscarBolsa();
            clsAbreForm.AbreForm(frmBuscarBolsa);
        }
        #endregion

        #region Botão Adicionar
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string cd_bolsa_fracionada;

            cd_bolsa_fracionada = txtCdBolsa.Text.Trim();

            string comando = "select osb.cd_situacao_bolsa from ocorrencia_situacao_bolsa osb inner join bolsa_fracionada bf on ";
            comando += "bf.dt_coleta = osb.dt_coleta and bf.cd_rg_doador = osb.cd_rg_doador and bf.cd_tipo_fracionamento = osb.cd_tipo_fracionamento ";
            comando += "where cd_bolsa_fracionada = " + cd_bolsa_fracionada;
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                if (dados[0].ToString() == "2")
                {
                    MessageBox.Show("Essa bolsa já foi levada para transfusão! Busque outra.", "Distribuição", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dados.Close();
                    dados.Dispose();
                    return;
                }
                if (dados[0].ToString() == "3")
                {
                    MessageBox.Show("Essa bolsa foi descartada! Busque outra.", "Distribuição", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dados.Close();
                    dados.Dispose();
                    return;
                }
            }
            dados.Close();
            dados.Dispose();

            comando = "select bf.cd_bolsa_fracionada, tf.nm_tipo_fracionamento, bf.cd_rg_doador, bf.dt_coleta, bf.cd_tipo_fracionamento ";
            comando += "from bolsa_fracionada bf inner join tipo_fracionamento tf on tf.cd_tipo_fracionamento = bf.cd_tipo_fracionamento ";
            comando += "where cd_bolsa_fracionada = " + cd_bolsa_fracionada;

            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                for (int i = 0; i < tblAdicionar.RowCount; i++)
                {
                    if (dados[0].ToString() == Convert.ToString(tblAdicionar.Rows[i].Cells[0].Value))
                    {
                        MessageBox.Show("Essa bolsa já foi adicionada na lista! Digite outro código.", "Distribuição", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dados.Close();
                        dados.Dispose();
                        return;
                    }
                }
                tblAdicionar.Rows.Add(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString().Substring(0, 10));
            }
            else
            {
                MessageBox.Show("Nenhuma bolsa foi encontrada com esse código! Digite outro.", "Distribuição", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dados.Close();
                dados.Dispose();
                txtCdBolsa.Clear();
                txtCdBolsa.Focus();
                return;
            }
            dados.Close();
            dados.Dispose();

            tblAdicionar.AutoResizeColumns();
            tblAdicionar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            txtCdBolsa.Clear();
            txtCdBolsa.Focus();
        }
        #endregion

        #region Form Load
        private void frmRegistrarSaida_Load(object sender, EventArgs e)
        {
            tblAdicionar.Rows.Clear();
            tblAdicionar.Columns.Clear();
            tblAdicionar.Columns.Add("c1", "Código da Bolsa");
            tblAdicionar.Columns.Add("c2", "Tipo de Fracionamento");
            tblAdicionar.Columns.Add("c3", "RG do Doador");
            tblAdicionar.Columns.Add("c4", "Data da Coleta");
            clsDadosGerais.tabela_distribuicao = tblAdicionar;
        }
        #endregion

        #region Botão Remover
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblAdicionar.Rows[tblAdicionar.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione uma bolsa para remover!", "Distribuição", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                foreach (DataGridViewCell celula in tblAdicionar.SelectedCells)
                {
                    if (celula.Selected)
                        tblAdicionar.Rows.RemoveAt(celula.RowIndex);
                }
            }
        }
        #endregion

        #region Keypress e Keydown do txtCdBolsa
        private void txtCdBolsa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidar.Codigo(e.KeyChar))
                e.Handled = true;
        }

        private void txtCdBolsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnAdicionar_Click(sender, e);
            }
        }
        #endregion

        #region Botão Confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tblAdicionar.RowCount; i++)
            {
                if (Convert.ToString(tblAdicionar.Rows[i].Cells[0].Value) != "")
                {
                    InsereOcorrencia(Convert.ToString(tblAdicionar.Rows[i].Cells[0].Value));
                }
            }

            MessageBox.Show("Saída registrada com sucesso!", "Distribuição");
            tblAdicionar.Rows.Clear();
            tblAdicionar.Columns.Clear();
            tblAdicionar.Columns.Add("c1", "Código da Bolsa");
            tblAdicionar.Columns.Add("c2", "Tipo de Fracionamento");
            tblAdicionar.Columns.Add("c3", "RG do Doador");
            tblAdicionar.Columns.Add("c4", "Data da Coleta");
        }
        #endregion
    }
}
