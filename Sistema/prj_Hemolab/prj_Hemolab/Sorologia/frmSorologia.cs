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
    public partial class frmSorologia : Form
    {
        public frmSorologia()
        {
            InitializeComponent();
        }

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(tblSorologia.Rows[tblSorologia.SelectedRows[0].Index].Cells[0].Value) == "")
            {
                MessageBox.Show("Selecione uma bolsa para prosseguir!", "Sorologia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsDadosGerais.cd_bolsa_coletada = tblSorologia.Rows[tblSorologia.SelectedRows[0].Index].Cells[0].Value.ToString();

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

                Form frmResultadosSorologia = new Sorologia.frmResultadosSorologia();
                clsAbreForm.AbreForm(frmResultadosSorologia);
                this.Close();
            }
        }
        #endregion

        #region Form Load
        private void frmSorologia_Load(object sender, EventArgs e)
        {
            tblSorologia.DataSource = null;
            tblSorologia.Rows.Clear();
            tblSorologia.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            string comando = "select bc.cd_bolsa_coletada as 'Código da Bolsa', bc.cd_rg_doador as 'RG do Doador', bc.dt_coleta as 'Data da Coleta', ";
            comando += "bc.hr_coleta as 'Hora da Coleta' from bolsa_coletada bc inner join exame e on bc.dt_coleta = e.dt_coleta and bc.cd_rg_doador = e.cd_rg_doador ";
            comando += "where ic_resultado_exame is null group by bc.cd_rg_doador";

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblSorologia.DataSource = tabela;
            tblSorologia.AutoResizeColumns();
            tblSorologia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCdBolsa.Text.Trim() == "")
            {
                if (MessageBox.Show("Deseja exibir todas as bolsas?", "Sorologia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmSorologia_Load(sender, e);
                    return;
                }
            }
            else
            {
                string cd_bolsa_coletada;

                cd_bolsa_coletada = txtCdBolsa.Text.Trim();

                tblSorologia.DataSource = null;
                tblSorologia.Rows.Clear();
                tblSorologia.Columns.Clear();

                MySqlDataAdapter dadosLocal;
                DataTable tabela;

                string comando = "select bc.cd_bolsa_coletada as 'Código da Bolsa', bc.cd_rg_doador as 'RG do Doador', bc.dt_coleta as 'Data da Coleta', ";
                comando += "bc.hr_coleta as 'Hora da Coleta' from bolsa_coletada bc inner join exame e on bc.dt_coleta = e.dt_coleta and bc.cd_rg_doador = e.cd_rg_doador ";
                comando += "where ic_resultado_exame is null and cd_bolsa_coletada = " + cd_bolsa_coletada + " group by bc.cd_rg_doador";

                dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
                tabela = new DataTable();
                dadosLocal.Fill(tabela);

                tblSorologia.DataSource = tabela;
                tblSorologia.AutoResizeColumns();
                tblSorologia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
        private void tmrSorologia_Tick(object sender, EventArgs e)
        {
            frmSorologia_Load(sender, e);
        }
        #endregion
    }
}
