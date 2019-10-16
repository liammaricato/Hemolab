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
    public partial class frmBuscarDoador : Form
    {
        public frmBuscarDoador()
        {
            InitializeComponent();
        }

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frmRecepcao = new frmRecepcao();
            clsAbreForm.AbreForm(frmRecepcao);
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

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnEditar.Cursor = Cursors.Hand;
            mtbRG.Enabled = false;
            mtbCPF.Enabled = false;
            mtbNascimento.Enabled = false;
            mtbCelular.Enabled = false;
            mtbTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            cmbSexo.Enabled = false;

            string cd_rg_doador;
            cd_rg_doador = mtbRG.Text;

            string comando = "select nm_doador, sg_sexo_doador, cd_cpf_doador, dt_nascimento_doador, nm_email_doador, ";
            comando += "cd_telefone_residencial_doador, cd_telefone_celular_doador, cd_funcionario from doador where cd_rg_doador = '" + cd_rg_doador + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                txtNome.Text = dados[0].ToString();
                switch (dados[1].ToString())
                {
                    case "Masc":
                        cmbSexo.SelectedIndex = 0;
                        break;
                    case "Fem":
                        cmbSexo.SelectedIndex = 1;
                        break;
                }
                mtbCPF.Text = (dados[2].ToString());
                mtbNascimento.Text = dados[3].ToString().Substring(0,10).Replace("/","");
                txtEmail.Text = dados[4].ToString();
                mtbTelefone.Text = dados[5].ToString();
                mtbCelular.Text = dados[6].ToString();
                lblFuncionario.Text = dados[7].ToString();

                btnEditar.Enabled = true;
                btnHistorico.Enabled = true;
                btnNovaDoacao.Enabled = true;
            }
            else
            {
                mtbRG.Enabled = true;
                if (mtbRG.Text.Replace(".", "").Replace("-", "").Trim() == "")
                {
                    MessageBox.Show("Você deve digitar um RG!", "Atenção", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Este RG não consta na lista de doadores, tente outro!", "Doador não cadastrado", MessageBoxButtons.OK);
                }
            }
            dados.Close();
        }
        #endregion

        #region Click da MaskedTextBox RG
        private void mtbRG_Click(object sender, EventArgs e)
        {
            string rg = mtbRG.Text;
            rg = rg.Replace(".", "");
            rg = rg.Replace("-", "");
            rg = rg.Trim();
            

            if (rg == "")
            {
                mtbRG.SelectionStart = 0;
            }
        }
        #endregion

        #region Botão Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            lblEditar.Visible = false;
            lblHistorico.Visible = false;
            lblNovaDoacao.Visible = false;
            btnEditar.Visible = false;
            btnSalvar.Visible = true;
            btnCancelar.Visible = true;
            btnHistorico.Visible = false;
            btnNovaDoacao.Visible = false;
            mtbCPF.Enabled = true;
            mtbNascimento.Enabled = true;
            mtbCelular.Enabled = true;
            mtbTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtNome.Enabled = true;
            cmbSexo.Enabled = true;
            lblNovaDoacao.Visible = false;
        }
        #endregion

        #region Botão Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
            btnHistorico.Visible = true;
            btnNovaDoacao.Visible = true;
            lblEditar.Visible = true;
            lblHistorico.Visible = true;
            lblNovaDoacao.Visible = true;
            btnEditar.Visible = true;
            mtbRG.Enabled = false;
            mtbCPF.Enabled = false;
            mtbNascimento.Enabled = false;
            mtbCelular.Enabled = false;
            mtbTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            cmbSexo.Enabled = false;
            btnBuscar.PerformClick();
        }
        #endregion

        #region Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome, sexo, cpf, nascimento, email, telefone, celular;
            bool alterou = false;

            string comando = "select nm_doador, sg_sexo_doador, cd_cpf_doador, dt_nascimento_doador, nm_email_doador, ";
            comando += "cd_telefone_residencial_doador, cd_telefone_celular_doador from doador where cd_rg_doador = '" + mtbRG.Text + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                nome = dados[0].ToString();
                sexo = dados[1].ToString();
                cpf = dados[2].ToString();
                nascimento = dados[3].ToString();
                email = dados[4].ToString();
                telefone = dados[5].ToString();
                celular = dados[06].ToString();
                dados.Close();

                if (txtNome.Text != nome)
                {
                    if (clsValidar.Nome(txtNome.Text))
                    {
                    //update nome
                    comando = "update doador set nm_doador = '" + txtNome.Text + "', cd_funcionario = " + clsDadosGerais.cd_usuario + " where cd_rg_doador = '" + mtbRG.Text + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();
                    alterou = true;
                    }
                    else
                    {
                        MessageBox.Show("Você deve digitar um nome válido","Atenção!");
                        txtNome.Focus();
                        return;
                    }
                }
                if (cmbSexo.SelectedItem.ToString() != sexo)
                {
                    //update sexo
                    comando = "update doador set sg_sexo_doador = '" + cmbSexo.SelectedItem.ToString() + "', cd_funcionario = " + clsDadosGerais.cd_usuario + " where cd_rg_doador = '" + mtbRG.Text + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();
                    alterou = true;
                }
                if (mtbCPF.Text != cpf)
                {
                    if (clsValidar.CPF(mtbCPF.Text))
                    {
                    //update cpf
                        comando = "update doador set cd_cpf_doador = '" + mtbCPF.Text + "', cd_funcionario = " + clsDadosGerais.cd_usuario + " where cd_rg_doador = '" + mtbRG.Text + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();
                    alterou = true;
                    }
                    else
                    {
                        MessageBox.Show("Você deve digitar um CPF válido", "Atenção!");
                        mtbCPF.Focus();
                        return;
                    }
                }
                if (mtbNascimento.Text != nascimento.Substring(0,10))
                {
                    if (clsValidar.DataNascimento(mtbNascimento.Text))
                    {
                        //update nascimento
                        comando = "update doador set dt_nascimento_doador = '" + clsFuncoes.ConverterData(mtbNascimento.Text) + "', cd_funcionario = " + clsDadosGerais.cd_usuario + " where cd_rg_doador = '" + mtbRG.Text + "'";
                        cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                        cSQL.ExecuteNonQuery();
                        alterou = true;
                    }
                    else
                    {
                        MessageBox.Show("Você deve digitar uma data de nascimento", "Atenção!");
                        mtbNascimento.Focus();
                        return;
                    }
                }
                if (txtEmail.Text != email)
                {
                    if (clsValidar.Email(txtEmail.Text))
                    {
                    //update email
                        comando = "update doador set nm_email_doador = '" + txtEmail.Text + "', cd_funcionario = " + clsDadosGerais.cd_usuario + " where cd_rg_doador = '" + mtbRG.Text + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();
                    alterou = true;
                    }
                    else
                    {
                        MessageBox.Show("Você deve digitar um email válido","Atenção!");
                        txtEmail.Focus();
                        return;
                    }
                }                
                if (mtbTelefone.Text != telefone)
                {
                    if (clsValidar.Telefone(mtbTelefone.Text))
                    {
                    //update nome
                        comando = "update doador set cd_telefone_residencial_doador = '" + mtbTelefone.Text + "', cd_funcionario = " + clsDadosGerais.cd_usuario + " where cd_rg_doador = '" + mtbRG.Text + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();
                    alterou = true;
                    }
                    else
                    {
                        MessageBox.Show("Você deve digitar um telefone válido","Atenção!");
                        txtNome.Focus();
                        return;
                    }
                }
                if (mtbCelular.Text != celular)
                {
                    if (clsValidar.Telefone(mtbTelefone.Text))
                    {
                    //update nome
                        comando = "update doador set cd_telefone_celular_doador = '" + mtbCelular.Text + "', cd_funcionario = " + clsDadosGerais.cd_usuario + " where cd_rg_doador = '" + mtbRG.Text + "'";
                    cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();
                    alterou = true;
                    }
                    else
                    {
                        MessageBox.Show("Você deve digitar um celular válido","Atenção!");
                    }
                }           
            }

            if (alterou)
            {
                MessageBox.Show("Alterações realizadas com sucesso!", "Sucesso");
                btnBuscar_Click(sender, e);
            }

            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
            btnHistorico.Visible = true;
            btnNovaDoacao.Visible = true;
            mtbRG.Enabled = false;
            mtbCPF.Enabled = false;
            mtbNascimento.Enabled = false;
            mtbCelular.Enabled = false;
            mtbTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            cmbSexo.Enabled = false;
            lblEditar.Visible = true;
            lblHistorico.Visible = true;
            lblNovaDoacao.Visible = true;
            btnEditar.Visible = true;

            dados.Close();
        }
        #endregion

        #region KeyPress MaskedTextBox RG
        private void mtbRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar_Click(sender, e);
                e.Handled = true;
            }
        }
        #endregion

        #region Botão Histórico
        private void btnHistorico_Click(object sender, EventArgs e)
        {
            clsDadosGerais.cd_rg_doador = mtbRG.Text;
            clsDadosGerais.nm_doador = txtNome.Text;
            Form frmSelecionarHistorico = new Historico.frmSelecionarHistorico();
            clsAbreForm.AbreForm(frmSelecionarHistorico);
            this.Close();
        }
        #endregion

        #region Botão Nova Doação
        private void btnNovaDoacao_Click(object sender, EventArgs e)
        {
            clsDadosGerais.cd_rg_doador = "*" + mtbRG.Text;
            Form frmNovaDoacao = new frmNovaDoacao();
            clsAbreForm.AbreForm(frmNovaDoacao);
            this.Close();
        }
        #endregion
    }
}
