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

namespace prj_Hemolab.ImunoHematologia
{
    public partial class frmImunoHematologia : Form
    {
        public frmImunoHematologia()
        {
            InitializeComponent();
        }

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblImunoHematologia.Rows[tblImunoHematologia.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione uma bolsa para prosseguir!", "Imuno-Hematologia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsDadosGerais.cd_bolsa_coletada = tblImunoHematologia.Rows[tblImunoHematologia.SelectedRows[0].Index].Cells[0].Value.ToString();

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

                Form frmRegistrarImunoHematologia = new frmRegistrarImunoHematologia();
                clsAbreForm.AbreForm(frmRegistrarImunoHematologia);
                this.Close();
            }
        }
        #endregion

        #region Form Load
        private void frmImunoHematologia_Load(object sender, EventArgs e)
        {
            tblImunoHematologia.DataSource = null;
            tblImunoHematologia.Rows.Clear();
            tblImunoHematologia.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            string comando = "select cd_bolsa_coletada as 'Código da Bolsa', cd_rg_doador as 'RG do Doador', dt_coleta as 'Data da Coleta', ";
            comando += "hr_coleta as 'Hora da Coleta' from bolsa_coletada where cd_tipo_sanguineo is null";

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblImunoHematologia.DataSource = tabela;
            tblImunoHematologia.AutoResizeColumns();
            tblImunoHematologia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCdBolsa.Text.Trim() == "")
            {
                if (MessageBox.Show("Deseja exibir todas as bolsas?", "Sorologia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmImunoHematologia_Load(sender, e);
                    return;
                }
            }
            else
            {
                string cd_bolsa_coletada;

                cd_bolsa_coletada = txtCdBolsa.Text.Trim();

                tblImunoHematologia.DataSource = null;
                tblImunoHematologia.Rows.Clear();
                tblImunoHematologia.Columns.Clear();

                MySqlDataAdapter dadosLocal;
                DataTable tabela;

                string comando = "select cd_bolsa_coletada as 'Código da Bolsa', cd_rg_doador as 'RG do Doador', dt_coleta as 'Data da Coleta', ";
                comando += "hr_coleta as 'Hora da Coleta' from bolsa_coletada where cd_tipo_sanguineo is null and cd_bolsa_coletada = " + cd_bolsa_coletada;

                dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
                tabela = new DataTable();
                dadosLocal.Fill(tabela);

                tblImunoHematologia.DataSource = tabela;
                tblImunoHematologia.AutoResizeColumns();
                tblImunoHematologia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                btnBuscar_Click(sender, e);
            }
        }
        #endregion

        #region Timer
        private void tmrImunoHematologia_Tick(object sender, EventArgs e)
        {
            frmImunoHematologia_Load(sender, e);
        }
        #endregion
    }
}
