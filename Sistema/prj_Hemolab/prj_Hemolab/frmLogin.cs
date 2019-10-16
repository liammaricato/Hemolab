using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using prj_Hemolab.Classes;

namespace prj_Hemolab
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Botão Fechar
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
        #endregion

        #region Botão Entrar
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            #region Validação de Existência
            if (clsValidar.Vazio(txtLogin.Text))
            {
                lblIncorreto.Text = "O login é obrigatório";
                txtLogin.Focus();
                return;
            }

            if (clsValidar.Vazio(txtSenha.Text))
            {
                lblIncorreto.Text = "A senha é obrigatória";
                txtSenha.Focus();
                return;
            }
            #endregion

            string comando = "select cd_funcionario, nm_funcionario, cd_tipo_funcionario from funcionario where cd_funcionario = " + txtLogin.Text.Trim();
            comando += " and cd_senha_funcionario = md5('" + txtSenha.Text.Trim() + "')";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();

            if (dados.Read())
            {
                clsDadosGerais.cd_usuario = dados[0].ToString();
                clsDadosGerais.nm_usuario = dados[1].ToString();
                clsDadosGerais.cd_tipo_usuario = dados[2].ToString();
                DialogResult = DialogResult.Yes;
            }
            else
            {
                lblIncorreto.Text = "Login e/ou senha incorretos";
                txtLogin.Clear();
                txtSenha.Clear();
                txtLogin.Focus();
            }
            dados.Close();
        }
        #endregion

        #region KeyPress
        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = clsValidar.Codigo(e.KeyChar);
                if (e.KeyChar == 13)
                {
                    btnEntrar_Click(sender, e);
                    e.Handled = true;
                }
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = clsValidar.Texto(e.KeyChar);
            if (e.KeyChar == 13)
            {
                btnEntrar_Click(sender, e);
                e.Handled = true;
            }
        }
        #endregion

    }
}
