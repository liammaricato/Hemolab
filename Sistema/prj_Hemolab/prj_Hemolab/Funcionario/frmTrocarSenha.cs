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

namespace prj_Hemolab.Funcionario
{
    public partial class frmTrocarSenha : Form
    {
        public frmTrocarSenha()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmTrocarSenha_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = clsDadosGerais.cd_funcionario;
            lblNome.Text = clsDadosGerais.nm_funcionario;
        }
        #endregion

        #region Botão Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string comando = "update funcionario set cd_senha_funcionario = md5('" + txtSenha.Text + "') where cd_funcionario = " + clsDadosGerais.cd_funcionario;
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
            MessageBox.Show("Senha alterada com sucesso!", "Trocar Senha");
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

        #region KeyPress
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = clsValidar.Texto(e.KeyChar);
        }
        #endregion
    }
}
