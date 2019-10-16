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
    public partial class frmBuscarBolsa : Form
    {
        public frmBuscarBolsa()
        {
            InitializeComponent();
        }

        string index_abo = "";
        string index_rh = "";

        #region Função que descobre o cd_tipo_sanguineo a partir do index das duas combobox
        private string AchaOCodigoDoTipo(string index1, string index2)
        {
            switch (index1)
            {
                case "1":
                    if (index2 == "0")
                        return "34";
                    else
                        if (index2 == "1")
                            return "4";
                        else
                            return "3";
                case "2":
                    if (index2 == "0")
                        return "56";
                    else
                        if (index2 == "1")
                            return "6";
                        else
                            return "5";
                case "3":
                    if (index2 == "0")
                        return "78";
                    else
                        if (index2 == "1")
                            return "8";
                        else
                            return "7";
                case "4":
                    if (index2 == "0")
                        return "12";
                    else
                        if (index2 == "1")
                            return "2";
                        else
                            return "1";
            }

            if (index2 != "0")
            {
                if (index2 == "1")
                    return "2468";
                else
                    return "1357";
            }

            return "0";
        }
        #endregion

        #region Função que constroi o comando para fazer o select
        private string ConstroiComando(int fracionamento, string cd_tipo_sanguineo)
        {
            string comando;

            comando = "select bf.cd_bolsa_fracionada as 'Código da Bolsa', tf.nm_tipo_fracionamento as 'Tipo de Fracionamento', if(bf.cd_tipo_fracionamento = 3, ' *', ts.nm_tipo_sanguineo) as 'Tipo Sanguíneo', ";
            comando += "bf.cd_rg_doador as 'RG do Doador', bf.dt_coleta as 'Data da Coleta' ";
            comando += "from bolsa_fracionada bf inner join tipo_fracionamento tf on tf.cd_tipo_fracionamento = bf.cd_tipo_fracionamento ";
            comando += "inner join bolsa_coletada bc on bc.cd_rg_doador = bf.cd_rg_doador and bc.dt_coleta = bf.dt_coleta ";
            comando += "inner join tipo_sanguineo ts on ts.cd_tipo_sanguineo = bc.cd_tipo_sanguineo ";
            comando += "inner join ocorrencia_situacao_bolsa osb on osb.dt_coleta = bf.dt_coleta and osb.cd_rg_doador = bf.cd_rg_doador and osb.cd_tipo_fracionamento = bf.cd_tipo_fracionamento ";
            comando += "where not exists(select osbb.cd_situacao_bolsa from ocorrencia_situacao_bolsa osbb where osbb.dt_coleta = osb.dt_coleta ";
	        comando += "and osbb.cd_rg_doador = osb.cd_rg_doador and osbb.cd_tipo_fracionamento = osb.cd_tipo_fracionamento and (osbb.cd_situacao_bolsa = 2 or osbb.cd_situacao_bolsa = 3)) ";

            if (fracionamento != 0)
            {
                comando += "and bf.cd_tipo_fracionamento = " + fracionamento + " ";

                if (fracionamento == 3)
                    cd_tipo_sanguineo = "0";
            }

            if (cd_tipo_sanguineo != "0")
            {
                comando += "and ";

                if (cd_tipo_sanguineo.Length > 1)
                {
                    bool or = false;
                    for (int i = 0; i < cd_tipo_sanguineo.Length; i++)
                    {
                        if (or)
                            comando += "or ";

                        comando += "bc.cd_tipo_sanguineo = " + cd_tipo_sanguineo.Substring(i, 1) + " ";
                        or = true;
                    }
                }
                else
                {
                    comando += "bc.cd_tipo_sanguineo = " + cd_tipo_sanguineo;
                }
            }
            return comando;
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
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

        #region Muda os index das ComboBoxes quando for selecionado 'Plaquetas'
        private void cmbFracionamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFracionamento.SelectedIndex == 3)
            {
                cmbABO.Enabled = false;
                index_abo = cmbABO.SelectedIndex.ToString();
                cmbABO.SelectedIndex = 0;
                cmbRh.Enabled = false;
                index_rh = cmbRh.SelectedIndex.ToString();
                cmbRh.SelectedIndex = 0;
            }
            else
            {
                if (index_abo != "")
                {
                    cmbABO.SelectedIndex = Convert.ToInt16(index_abo);
                    cmbRh.SelectedIndex = Convert.ToInt16(index_rh);
                    index_abo = "";
                    index_rh = "";
                }
                cmbABO.Enabled = true;
                cmbRh.Enabled = true;
            }
        }
        #endregion

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbABO.SelectedIndex == 0 && cmbRh.SelectedIndex == 0 && cmbFracionamento.SelectedIndex == 0)
            {
                if (!(MessageBox.Show("Buscar sem nenhum filtro trará como resultado todas as bolsas em estoque, isso pode demorar alguns minutos, deseja prosseguir?", "Buscar Bolsa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                    return;
            }
            string comando = ConstroiComando(cmbFracionamento.SelectedIndex, AchaOCodigoDoTipo(cmbABO.SelectedIndex.ToString(), cmbRh.SelectedIndex.ToString()));

            tblBuscarBolsa.DataSource = null;
            tblBuscarBolsa.Rows.Clear();
            tblBuscarBolsa.Columns.Clear();

            MySqlDataAdapter dadosLocal;
            DataTable tabela;

            dadosLocal = new MySqlDataAdapter(comando, clsDadosGerais.conexao);
            tabela = new DataTable();
            dadosLocal.Fill(tabela);

            tblBuscarBolsa.DataSource = tabela;
            tblBuscarBolsa.AutoResizeColumns();
            tblBuscarBolsa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region Form Load
        private void frmBuscarBolsa_Load(object sender, EventArgs e)
        {
            cmbABO.SelectedIndex = 0;
            cmbRh.SelectedIndex = 0;
            cmbFracionamento.SelectedIndex = 0;
        }
        #endregion

        #region Botão Prosseguir
        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tblBuscarBolsa.SelectedRows.Count; i++)
            {
                if (Convert.ToString(tblBuscarBolsa.SelectedRows[i].Cells[0].Value) == "")
                {
                    if (tblBuscarBolsa.SelectedRows.Count == 1)
                    {
                        MessageBox.Show("Selecione uma bolsa para prosseguir!", "Buscar Bolsa");
                        return;
                    }
                }
                else
                {
                    bool adiciona = true;

                    for (int t = 0; t < clsDadosGerais.tabela_distribuicao.RowCount; t++)
                    {
                        if (Convert.ToString(tblBuscarBolsa.SelectedRows[i].Cells[0].Value) == Convert.ToString(clsDadosGerais.tabela_distribuicao.Rows[t].Cells[0].Value))
                        {
                            MessageBox.Show("A bolsa de código " + Convert.ToString(tblBuscarBolsa.SelectedRows[i].Cells[0].Value) + " já foi adicionada na lista! Ela não foi adicionada à lista.", "Buscar Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            adiciona = false;
                        }
                    }

                    if (adiciona)
                        clsDadosGerais.tabela_distribuicao.Rows.Add(Convert.ToString(tblBuscarBolsa.SelectedRows[i].Cells[0].Value), Convert.ToString(tblBuscarBolsa.SelectedRows[i].Cells[1].Value), Convert.ToString(tblBuscarBolsa.SelectedRows[i].Cells[2].Value), Convert.ToString(tblBuscarBolsa.SelectedRows[i].Cells[3].Value).Substring(0, 10));
                }
            }

            clsDadosGerais.tabela_distribuicao.AutoResizeColumns();
            clsDadosGerais.tabela_distribuicao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.Close();
        }
        #endregion
    }
}
