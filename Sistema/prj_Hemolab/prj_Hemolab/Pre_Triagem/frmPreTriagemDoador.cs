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

namespace prj_Hemolab.Pre_Triagem
{
    public partial class frmPreTriagemDoador : Form
    {
        public frmPreTriagemDoador()
        {
            InitializeComponent();
        }

        #region Função que retorna a sugestão
        private string RetornaSugestao(TextBox txt)
        {
            switch (txt.Tag.ToString())
            {
                case "1":
                    return "\n - Peso: 65.0 kg";
                case "2":
                    return "\n - Pulso: 72 btm";
                case "3":
                    return "\n - Pressão: 120/80 mmHg";
                case "4":
                    return "\n - Temperatura: 36.2 ºC";
                case "5":
                    return "\n - Hematócritos: 43 %";
                case "6":
                    return "\n - Hemoglobina: 15 g/dL";
            }
            return "";
        }
        #endregion

        #region Função que Valida as TXTs
        private bool Valida()
        {
            string messagebox = "";
            bool pressao_certa = false;

            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Text.Trim() == "")
                {
                    messagebox += RetornaSugestao(txt);
                }
            }

            if (txtPeso.Text.IndexOf(".") == -1)
            {
                if(messagebox == "")
                    txtPeso.Text += ".0";
            }

            if (txtTemperatura.Text.IndexOf(".") == -1)
            {
                if (messagebox == "")
                    txtTemperatura.Text += ".0";
            }

            if (txtHemoglobinas.Text.IndexOf(".") == -1)
            {
                if (messagebox == "")
                    txtHemoglobinas.Text += ".0";
            }

            for (int i = 1; i < txtPressao.Text.Length; i++)
            {
                if (txtPressao.Text.Substring(i - 1, 1) == "/")
                    pressao_certa = true;
            }

            if (!pressao_certa && messagebox.IndexOf("/") == -1)
                messagebox += RetornaSugestao(txtPressao);

            if (messagebox != "")
            {
                MessageBox.Show("Alguma das informações está formatada incorretamente! Veja alguns exemplos como sugestões para o que você possa ter errado: " + messagebox, "Pré-Triagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }
        #endregion

        #region Botão Concluir
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                string comando = "update triagem set hr_triagem = '" + clsDadosGerais.hora_atual() + "', qt_quilos_doador = " + txtPeso.Text + ", qt_pressao_doador = '" + txtPressao.Text + "', ";
                comando += "qt_temperatura_doador = " + txtTemperatura.Text + ", qt_bpm_doador = " + txtPulso.Text + ", qt_hemoglobina_doador = " + txtHemoglobinas.Text + ", qt_hematocrito_doador = " + txtHematocritos.Text + " ";
                comando += "where cd_triagem = " + clsDadosGerais.cd_triagem + " and cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "'";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();

                Form frmConfirmarPreTriagem = new frmConfirmarPreTriagem();
                clsAbreForm.AbreForm(frmConfirmarPreTriagem);
                this.Close();
            }
        }
        #endregion

        #region Form Load
        private void frmPreTriagemDoador_Load(object sender, EventArgs e)
        {
            lblRG.Text = clsDadosGerais.cd_rg_doador;
            lblNome.Text = clsDadosGerais.nm_doador;
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Essas alterações não serão salvas!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Form frmPreTriagem = new frmPreTriagem();
                clsAbreForm.AbreForm(frmPreTriagem);
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

        #region KeyPress
        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46))
                e.Handled = true;
        }

        private void txtPulso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtPressao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPressao.Text.IndexOf("/") == -1)
            {
                if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 47))
                    e.Handled = true;
            }
            else
            {
                if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8))
                    e.Handled = true;
            }
        }

        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46))
                e.Handled = true;
        }

        private void txtHematocritos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtHemoglobinas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46))
                e.Handled = true;
        }
        #endregion
    }
}
