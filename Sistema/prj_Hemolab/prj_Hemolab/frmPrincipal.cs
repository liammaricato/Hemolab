using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using prj_Hemolab.Classes;

namespace prj_Hemolab
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        int altura_panel = 30;
        bool fechado = true;

        #region Botão do Usuário
        private void pcbUsuario_Click(object sender, EventArgs e)
        {
            tmrPainelUsuario.Enabled = true;
        }

        private void tmrPainelUsuario_Tick(object sender, EventArgs e)
        {
            if (fechado)
            {
                altura_panel += 5;
                if (altura_panel < 100)
                    pnlUsuario.Location = new Point(pnlUsuario.Location.X, altura_panel);
                else
                {
                    fechado = false;
                    tmrPainelUsuario.Enabled = false;
                }
            }
            else
            {
                altura_panel -= 5;
                if (altura_panel > 8)
                    pnlUsuario.Location = new Point(pnlUsuario.Location.X, altura_panel);
                else
                {
                    fechado = true;
                    tmrPainelUsuario.Enabled = false;
                }
            }
        }
        #endregion

        #region Botão sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsDadosGerais.conexao.Close();
                Close();
            }
            else
            {
                pcbUsuario_Click(sender, e);
            }
        }
        #endregion

        #region Form load
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            #region Muda a cor do fundo do MDI
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                }
            }
            #endregion

            clsDadosGerais.cd_rg_doador = "0";
            lblUsuario.Text += clsDadosGerais.nm_usuario;
            clsAbreForm.formularioPrincipal = this;
            clsDadosGerais.btnVoltar = btnVoltar;
            btnVoltar.Visible = false;

            switch (clsDadosGerais.cd_tipo_usuario)
            {
                case "1":
                    clsAbreForm.LimpaTodos();
                    Form frmAdministrador = new frmAdministrador();
                    clsAbreForm.AbreForm(frmAdministrador);
                    break;
                case "2":
                    clsAbreForm.LimpaTodos();
                    Form frmRecepcao = new frmRecepcao();
                    clsAbreForm.AbreForm(frmRecepcao);
                    break;
                case "3":
                    clsAbreForm.LimpaTodos();
                    Form frmPreTriagem = new Pre_Triagem.frmPreTriagem();
                    clsAbreForm.AbreForm(frmPreTriagem);
                    break;
                case "4":
                    clsAbreForm.LimpaTodos();
                    Form frmTriagem = new Triagem.frmTriagem();
                    clsAbreForm.AbreForm(frmTriagem);
                    break;
                case "5":
                    clsAbreForm.LimpaTodos();
                    Form frmSalaDeColeta = new Sala_de_Coleta.frmSalaDeColeta();
                    clsAbreForm.AbreForm(frmSalaDeColeta);
                    break;
                case "6":
                    clsAbreForm.LimpaTodos();
                    Form frmSorologia = new Sorologia.frmSorologia();
                    clsAbreForm.AbreForm(frmSorologia);
                    break;
                case "7":
                    clsAbreForm.LimpaTodos();
                    Form frmImunoHematologia = new ImunoHematologia.frmImunoHematologia();
                    clsAbreForm.AbreForm(frmImunoHematologia);
                    break;
                case "8":
                    clsAbreForm.LimpaTodos();
                    Form frmFracionamento = new Fracionamento.frmFracionamento();
                    clsAbreForm.AbreForm(frmFracionamento);
                    break;
                case "9":
                    clsAbreForm.LimpaTodos();
                    Form frmEstoque = new Estoque_de_Bolsas.frmEstoque();
                    clsAbreForm.AbreForm(frmEstoque);
                    break;
                case "10":
                    clsAbreForm.LimpaTodos();
                    Form frmRegistrarSaida = new Distribuicao.frmRegistrarSaida();
                    clsAbreForm.AbreForm(frmRegistrarSaida);
                    break;
            }
        }
        #endregion

        #region Botão Trocar Usuario
        private void btnTrocarUsuario_Click(object sender, EventArgs e)
        {
            clsDadosGerais.troca_usuario = true;
            Close();
        }
        #endregion          

        #region Botão Voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            clsAbreForm.LimpaTodos();
            Form frmAdministrador = new frmAdministrador();
            clsAbreForm.AbreForm(frmAdministrador);
            btnVoltar.Visible = false;
        }

        private void btnVoltar_MouseEnter(object sender, EventArgs e)
        {
            btnVoltar.BackgroundImage = Properties.Resources.voltar_preto2;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            btnVoltar.BackgroundImage = Properties.Resources.voltar;
        }
        #endregion
    }
}
