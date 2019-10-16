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
    public partial class frmNovaDoacao : Form
    {
        public frmNovaDoacao()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmNovaDoacao_Load(object sender, EventArgs e)
        {
            btnConcluir.Enabled = false;
            btnLimpar.Visible = false;

            if (clsDadosGerais.cd_rg_doador.IndexOf("*") != -1)
            {
                clsDadosGerais.cd_rg_doador = clsDadosGerais.cd_rg_doador.Replace("*", "");
                mtbRG.Text = clsDadosGerais.cd_rg_doador;
            }
        }
        #endregion

        #region Botão Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (clsValidar.RG(mtbRG.Text) && clsValidar.Vazio(mtbRG.Text) == false)
            {
                string cd_rg_doador;
                cd_rg_doador = mtbRG.Text;

                string comando = "select nm_doador, cd_cpf_doador from doador where cd_rg_doador = '" + cd_rg_doador + "'";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                if (dados.Read())
                {
                    lblNome.Text = dados[0].ToString();
                    lblCPF.Text = dados[1].ToString();
                    btnConcluir.Enabled = true;
                    btnBuscar.Visible = false;
                    btnLimpar.Visible = true;
                    mtbRG.Enabled = false;
                }
                else
                {
                    if (MessageBox.Show("Este RG não consta na lista de doadores, deseja cadastrar um novo?", "Doador não cadastrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsDadosGerais.cd_rg_doador = mtbRG.Text;
                        Form frmCadastrarDoador = new frmCadastrarDoador();
                        clsAbreForm.AbreForm(frmCadastrarDoador);
                    }
                }
                dados.Close();
            }
            else
            {
                string rg = mtbRG.Text.Replace("-","");
                rg = rg.Replace(".","");
                rg = rg.Trim();

                if (rg.Length == 0)
                {
                    MessageBox.Show("Digite um RG", "Erro");
                }
                else
                {
                    MessageBox.Show("Digite um RG válido!", "RG Inexistente");
                }
            }
        }
        #endregion

        #region Botão Limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblNome.Text = "";
            lblCPF.Text = "";
            btnConcluir.Enabled = false;
            btnLimpar.Visible = false;
            btnBuscar.Visible = true;
            mtbRG.Clear();
            mtbRG.Enabled = true;
            mtbRG.Focus();
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair agora? Esta doação não será registrada!", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
                Form frmRecepcao = new frmRecepcao();
                clsAbreForm.AbreForm(frmRecepcao);
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

        #region Botão Concluir
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            int cd_triagem;
            string comando = "select ifnull(max(cd_triagem), 0) from triagem where cd_rg_doador = '" + mtbRG.Text + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            dados.Read();
            cd_triagem = (Convert.ToInt32(dados[0].ToString()) + 1);
            dados.Close();

            string cd_doador = mtbRG.Text;
            cd_doador = cd_doador.Replace(".", "");
            cd_doador = cd_doador.Replace("-", "");
            
            comando = "insert into triagem (cd_rg_doador, cd_triagem, cd_funcionario, dt_triagem, hr_triagem) values ";
            comando += "('" + mtbRG.Text + "', " + cd_triagem + ", " + clsDadosGerais.cd_usuario + ", '" + clsDadosGerais.data_hoje() + "', '" + clsDadosGerais.hora_atual() + "')";
            cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();

            MessageBox.Show("Doação cadastrada com sucesso!", "Nova doação");
            Form frmRecepcao = new frmRecepcao();
            clsAbreForm.AbreForm(frmRecepcao);
            this.Close();
        }
        #endregion

        #region Click da txtRG
        private void mtbRG_Click(object sender, EventArgs e)
        {
            clsFuncoes.PosicionarCursor(mtbRG);
        }
        #endregion

        #region KeyPress MtbRG
        private void mtbRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar_Click(sender, e);
                e.Handled = true;
            }
        }
        #endregion
    }
}
