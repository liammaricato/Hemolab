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
    public partial class frmNovoFuncionario : Form
    {
        public frmNovoFuncionario()
        {
            InitializeComponent();
        }

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

        #region Botão Concluir
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            string cd_tipo_funcionario = Convert.ToString(cmbUsuario.SelectedIndex + 1);
            string comando = "insert into funcionario values (" + txtCodigo.Text + ", " + cd_tipo_funcionario + ", '" + txtNome.Text + "', '" + mtbCPF + "', md5('" + txtSenha.Text + "'))";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            try
            {
                cSQL.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Este código de usuário já existe! Digite outro.", "Novo Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MessageBox.Show("Funcionário cadastrado com sucesso!", "Novo Funcionário");
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

        #region KeyPress
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsValidar.Codigo(e.KeyChar))
                e.Handled = true;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32))
                e.Handled = true;
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = clsValidar.Texto(e.KeyChar);
        }
        #endregion

        
    }
}
