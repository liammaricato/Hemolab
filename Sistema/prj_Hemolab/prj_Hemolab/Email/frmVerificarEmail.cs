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
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace prj_Hemolab.Email
{
    public partial class frmVerificarEmail : Form
    {
        public frmVerificarEmail()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmVerificarEmail_Load(object sender, EventArgs e)
        {
            lblNome.Text = clsDadosGerais.nm_doador;
            lblEmail.Text = clsDadosGerais.nm_email_doador;
            string nome = lblNome.Text.Substring(0, lblNome.Text.IndexOf(" ")); 
            string meses;
            if (clsDadosGerais.sg_sexo_doador == "Masc")
                meses = "3";
            else
                meses = "4";

            clsDadosGerais.sg_sexo_doador = meses;
            clsDadosGerais.nm_doador = nome;
            lblMensagem.Text = lblMensagem.Text.Replace("{DOADOR}", nome);
            lblMensagem.Text = lblMensagem.Text.Replace("{MESES}", meses);
        }
        #endregion

        #region Botão Remover
        private void btnRemover_Click(object sender, EventArgs e)
        {
            string comando = "update bolsa_coletada set ic_mandou_email = true where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and dt_coleta = '" + clsDadosGerais.dt_coleta + "'";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            cSQL.ExecuteNonQuery();
            MessageBox.Show("E-mail removido da lista de e-mails pendentes.", "Remover e-mail");
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

        #region Botão Mandar
        private void btnMandar_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("sistema.hemolab@gmail.com", "sistemahemolab123");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.AlternateViews.Add(clsDadosGerais.getEmbeddedImage("email\\Hemolab.png", "email\\facebook.png", "email\\youtube.png", "email\\twitter.png", "email\\instagram.png"));
            mail.From = new MailAddress("sistema.hemolab@gmail.com", "Sistema Hemolab", Encoding.UTF8);
            mail.To.Add(clsDadosGerais.nm_email_doador);
            mail.Subject = "Você já pode doar novamente!";

            try
            {
                client.Send(mail);

                string comando = "update bolsa_coletada set ic_mandou_email = true where cd_rg_doador = '" + clsDadosGerais.cd_rg_doador + "' and dt_coleta = '" + clsDadosGerais.dt_coleta + "'";
                MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                cSQL.ExecuteNonQuery();
                DialogResult = DialogResult.Yes;
                MessageBox.Show("E-mail enviado com sucesso!", "Enviar e-mail");
            }
            catch
            {
                MessageBox.Show("Ocorreu uma falha no envio do e-mail! Verifique sua conexão com a internet e tente novamente. Se o problema persistir, é provável que o e-mail cadastrado do doador esteja errado.", "Falha ao Enviar e-mail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Close();
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
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
    }
}
