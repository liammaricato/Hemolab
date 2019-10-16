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
    public partial class frmRegistrarImunoHematologia : Form
    {
        public frmRegistrarImunoHematologia()
        {
            InitializeComponent();
        }

        #region Função que altera o tipo sanguíneo no banco
        private void InsertTipoSanguineo(string cd_tipo_sanguineo)
        {
            string comando = "update bolsa_coletada set cd_tipo_sanguineo = " + cd_tipo_sanguineo + " where dt_coleta = ";
            comando += "'" + clsDadosGerais.dt_coleta + "' and cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
        }
        #endregion

        #region Função que descobre o cd_tipo_sanguineo a partir do index das duas combobox
        private string AchaOCodigoDoTipo(string index1, string index2)
        {
            switch (index1)
            {
                case "0":
                    if (index2 == "0")
                        return "4";
                    else
                        return "3";
                case "1":
                    if (index2 == "0")
                        return "6";
                    else
                        return "5";
                case "2":
                    if (index2 == "0")
                        return "8";
                    else
                        return "7";
                case "3":
                    if (index2 == "0")
                        return "2";
                    else
                        return "1";
            }
            return "";
        }
        #endregion

        #region Botão Concluir
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (cmbABO.SelectedItem == "" || cmbRh.SelectedItem == "")
            {
                MessageBox.Show("Selecione a tipagem da bolsa para concluir esse exame!", "Imuno-Hematologia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            InsertTipoSanguineo(AchaOCodigoDoTipo(cmbABO.SelectedIndex.ToString(), cmbRh.SelectedIndex.ToString()));
            
            MessageBox.Show("Dados salvos com sucesso!");
            Form frmImunoHematologia = new frmImunoHematologia();
            clsAbreForm.AbreForm(frmImunoHematologia);
            this.Close();
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Estes dados nãos serão salvos!", "Imuno-Hematologia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Form frmImunoHematologia = new frmImunoHematologia();
                clsAbreForm.AbreForm(frmImunoHematologia);
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
        private void frmRegistrarImunoHematologia_Load(object sender, EventArgs e)
        {
            lblCdBolsa.Text = clsDadosGerais.cd_bolsa_coletada;
        }
        #endregion

        
    }
}
