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

namespace prj_Hemolab.Recepcao
{
    public partial class frmCadastrarDoador : Form
    {
        public frmCadastrarDoador()
        {
            InitializeComponent();
        }

        #region Botão Concluir Cadastro
        private void btnCadastrarDoador_Click(object sender, EventArgs e)
        {           

            if (clsValidar.CPF(mtbCPF.Text) && clsValidar.RG(mtbRG.Text) && clsValidar.Email(txtEmail.Text) && clsValidar.Telefone(mtbCelular.Text) && clsValidar.Telefone(mtbTelefone.Text) && clsValidar.DataNascimento(mtbNascimento.Text))
            {
                string rg;
                string nome;
                string sexo;
                string cpf;
                string nascimento;
                string ano; string mes; string dia;
                string email;
                string telefone = " null ";
                string celular = " null ";

                rg = mtbRG.Text.Trim();
                nome = txtNome.Text.Trim();
                if (rdbMasc.Checked)
                {
                    sexo = "Masc";
                }
                else
                {
                    sexo = "Fem";
                }
                cpf = mtbCPF.Text;
                nascimento = mtbNascimento.Text;
                nascimento = nascimento.Replace("/", "");
                dia = nascimento.Substring(0, 2);
                mes = nascimento.Substring(2, 2);
                ano = nascimento.Substring(4, 4);
                nascimento = ano + "-" + mes + "-" + dia;
                email = txtEmail.Text;
                if (!clsValidar.Telefone(mtbTelefone.Text))
                {
                    telefone = " null ";
                    celular = mtbCelular.Text;
                }
                if (!clsValidar.Telefone(mtbCelular.Text))
                {
                    celular = " null ";
                    telefone = mtbTelefone.Text;
                }
                if (clsValidar.Telefone(mtbCelular.Text) && clsValidar.Telefone(mtbTelefone.Text))
                {
                    telefone = mtbTelefone.Text;
                    celular = mtbCelular.Text;
                }
                

                string comando = "insert into doador values ('" + rg + "', '" + cpf + "', " + clsDadosGerais.cd_usuario + ", '" + nome + "', '" + sexo + "', '" + nascimento + "', '" + email + "', '" + telefone + "', '" + celular + "')";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();

                MessageBox.Show("Doador cadastrado com sucesso!", "Cadastro de doador");
                this.Close();
            }
            else
            {
                if (!clsValidar.RG(mtbRG.Text))
                {
                    MessageBox.Show("Digite um RG válido!", "Erro!");
                    mtbRG.Focus();
                    return;
                }
                if (!clsValidar.Nome(txtNome.Text))
                {
                    MessageBox.Show("Digite um nome!", "Erro!");
                    txtNome.Focus();
                    return;
                }
                if (!clsValidar.CPF(mtbCPF.Text))
                {
                    MessageBox.Show("Digite um CPF válido!", "Erro!");
                    mtbCPF.Focus();
                    return;
                }
                if (!clsValidar.Email(txtEmail.Text))
                {
                    MessageBox.Show("Digite um e-mail válido!", "Erro!");
                    txtEmail.Focus();
                    return;
                }
                if (!clsValidar.Telefone(mtbCelular.Text) && !clsValidar.Telefone(mtbTelefone.Text))
                {
                    MessageBox.Show("Digite um telefone ou celular válido!", "Erro!");
                    mtbTelefone.Focus();
                    return;
                }
                if (!clsValidar.DataNascimento(mtbNascimento.Text))
                {
                    MessageBox.Show("Digite uma data de nascimento válida!", "Erro!");
                    mtbNascimento.Focus();
                    return;
                }
            }
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair antes de terminar esse cadastro? Essas informações não serão salvas!", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
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

        private void frmCadastrarDoador_Load(object sender, EventArgs e)
        {
            mtbRG.Text = clsDadosGerais.cd_rg_doador;
            txtNome.Focus();
        }

        private void mtbNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(Convert.ToChar(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(Convert.ToChar(e.KeyChar)) && e.KeyChar != 32 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void mtbTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(Convert.ToChar(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void mtbCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(Convert.ToChar(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void mtbCPF_Click(object sender, EventArgs e)
        {
            clsFuncoes.PosicionarCursor(mtbCPF);
        }

        private void mtbTelefone_Click(object sender, EventArgs e)
        {
            clsFuncoes.PosicionarCursor(mtbTelefone);
        }

        private void mtbCelular_Click(object sender, EventArgs e)
        {
            clsFuncoes.PosicionarCursor(mtbCelular);
        }

        private void mtbNascimento_Click(object sender, EventArgs e)
        {
            clsFuncoes.PosicionarCursor(mtbNascimento);
        }

        
    }
}
