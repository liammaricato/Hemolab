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
    public partial class frmEditarFuncionario : Form
    {
        public frmEditarFuncionario()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmEditarFuncionario_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = clsDadosGerais.cd_funcionario;
            txtNome.Text = clsDadosGerais.nm_funcionario;
            mtbCPF.Text = clsDadosGerais.cd_cpf_funcionario;
            cmbUsuario.Text = clsDadosGerais.nm_tipo_funcionario;
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Suas alterações não serão salvas!", "Controle de Funcionários", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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

        #region Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool and = false;
            bool mudou_nada = true;
            string comando = "update funcionario set ";

            if (txtNome.Text != clsDadosGerais.nm_funcionario)
            {
                comando += "nm_funcionario = '" + txtNome.Text + "'";
                and = true;
                mudou_nada = false;
            }

            if (mtbCPF.Text != clsDadosGerais.cd_cpf_funcionario)
            {
                if (and)
                    comando += ", ";
                comando += "cd_cpf_funcionario = '" + mtbCPF.Text + "'";
                and = true;
                mudou_nada = false;
            }

            if (Convert.ToString(cmbUsuario.SelectedItem) != clsDadosGerais.nm_tipo_funcionario)
            {
                if (and)
                    comando += ", ";
                comando += "cd_tipo_funcionario = " + Convert.ToString(cmbUsuario.SelectedIndex + 1);
                mudou_nada = false;
            }

            if (!mudou_nada)
            {
                comando += " where cd_funcionario = " + clsDadosGerais.cd_funcionario;
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();
            }

            MessageBox.Show("As alterações foram salvas com sucesso!", "Editar Funcionário");
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

        #region Botão Trocar Senha
        private void btnTrocarSenha_Click(object sender, EventArgs e)
        {
            Form frmTrocarSenha = new frmTrocarSenha();
            frmTrocarSenha.StartPosition = FormStartPosition.CenterScreen;
            if (frmTrocarSenha.ShowDialog() == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region KeyPress txtNome
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
                e.Handled = true;
        }
        #endregion
    }
}
