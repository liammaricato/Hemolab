using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using prj_Hemolab.Classes;

namespace prj_Hemolab
{
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
        }

        private void btnRecepcao_Click(object sender, EventArgs e)
        {
            Form frmRecepcao = new frmRecepcao();
            clsAbreForm.AbreForm(frmRecepcao);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnPreTriagem_Click(object sender, EventArgs e)
        {
            Form frmPreTriagem = new Pre_Triagem.frmPreTriagem();
            clsAbreForm.AbreForm(frmPreTriagem);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnTriagem_Click(object sender, EventArgs e)
        {
            Form frmTriagem = new Triagem.frmTriagem();
            clsAbreForm.AbreForm(frmTriagem);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnSalaDeColeta_Click(object sender, EventArgs e)
        {
            Form frmSalaDeColeta = new Sala_de_Coleta.frmSalaDeColeta();
            clsAbreForm.AbreForm(frmSalaDeColeta);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnSorologia_Click(object sender, EventArgs e)
        {
            Form frmSorologia = new Sorologia.frmSorologia();
            clsAbreForm.AbreForm(frmSorologia);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnImunoHematologia_Click(object sender, EventArgs e)
        {
            Form frmImunoHematologia = new ImunoHematologia.frmImunoHematologia();
            clsAbreForm.AbreForm(frmImunoHematologia);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnFracionamento_Click(object sender, EventArgs e)
        {
            Form frmFracionamento = new Fracionamento.frmFracionamento();
            clsAbreForm.AbreForm(frmFracionamento);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnEstoqueDeBolsas_Click(object sender, EventArgs e)
        {
            Form frmEstoque = new Estoque_de_Bolsas.frmEstoque();
            clsAbreForm.AbreForm(frmEstoque);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnDistribuicao_Click(object sender, EventArgs e)
        {
            Form frmDistribuicao = new Distribuicao.frmRegistrarSaida();
            clsAbreForm.AbreForm(frmDistribuicao);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnGerarRelatorios_Click(object sender, EventArgs e)
        {
            Form frmRelatoriosDoacoes = new RELATORIOWSSS.frmRelatoriosDoacoes();
            clsAbreForm.AbreForm(frmRelatoriosDoacoes);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnCadastrarFuncionario_Click(object sender, EventArgs e)
        {
            Form frmCadastrarFuncionario = new frmFuncionarios();
            clsAbreForm.AbreForm(frmCadastrarFuncionario);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Form frmEmailDoador = new frmEmailDoador();
            clsAbreForm.AbreForm(frmEmailDoador);
            clsDadosGerais.btnVoltar.Visible = true;
            this.Close();
        }
    }
}
