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

namespace prj_Hemolab
{
    public partial class frmEmailDoador : Form
    {
        public frmEmailDoador()
        {
            InitializeComponent();
        }

        #region Função que mostra o e-mail / abre o frmVerificarEmail
        private void VerEmail(object sender, EventArgs e)
        {
            if (Convert.ToString(tblEmail.SelectedRows[0].Cells[0].Value) == "")
	        {
                MessageBox.Show("Selecione um doador para ver a notificação!", "Ver E-mail");
                return;
	        }
            clsDadosGerais.cd_rg_doador = tblEmail.SelectedRows[0].Cells[0].Value.ToString();
            clsDadosGerais.nm_doador = tblEmail.SelectedRows[0].Cells[1].Value.ToString();
            clsDadosGerais.sg_sexo_doador = tblEmail.SelectedRows[0].Cells[2].Value.ToString();
            clsDadosGerais.nm_email_doador = tblEmail.SelectedRows[0].Cells[3].Value.ToString();
            clsDadosGerais.dt_coleta = tblEmail.SelectedRows[0].Cells[4].Value.ToString();
            string data = clsDadosGerais.dt_coleta;
            string dia, mes, ano;
            data = data.Replace("/", "");
            dia = data.Substring(0, 2);
            mes = data.Substring(2, 2);
            ano = data.Substring(4, 4);
            data = ano + "-" + mes + "-" + dia;
            clsDadosGerais.dt_coleta = data;

            Form frmVerificarEmail = new Email.frmVerificarEmail();
            frmVerificarEmail.StartPosition = FormStartPosition.CenterScreen;
            if (frmVerificarEmail.ShowDialog() == DialogResult.Yes)
            {
                frmEmailDoador_Load(sender, e);
            }
        }
        #endregion

        #region Form Load
        private void frmEmailDoador_Load(object sender, EventArgs e)
        {
            tblEmail.Rows.Clear();
            tblEmail.Columns.Clear();
            tblEmail.Columns.Add("c1", "RG do Doador");
            tblEmail.Columns.Add("c2", "Nome do Doador");
            tblEmail.Columns.Add("c3", "Sexo do Doador");
            tblEmail.Columns.Add("c4", "E-mail do Doador");
            tblEmail.Columns.Add("c5", "Data da Coleta");

            string comando = "select d.cd_rg_doador, d.nm_doador, d.sg_sexo_doador, d.nm_email_doador, bc.dt_coleta from doador d ";
            comando += "inner join bolsa_coletada bc on d.cd_rg_doador = bc.cd_rg_doador where ";
            comando += "if(d.sg_sexo_doador = 'Masc', curdate() > date_add(bc.dt_coleta, interval 3 month), ";
            comando += "curdate() > date_add(bc.dt_coleta, interval 4 month)) and bc.dt_coleta = (select max(bcc.dt_coleta) ";
            comando += "from bolsa_coletada bcc where bcc.cd_rg_doador = bc.cd_rg_doador) and bc.ic_mandou_email = false";

            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            while (dados.Read())
            {
                tblEmail.Rows.Add(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), dados[3].ToString(), dados[4].ToString().Substring(0, 10));
            }
            dados.Close();
            dados.Dispose();

            tblEmail.AutoResizeColumns();
            tblEmail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion

        #region DoubleClick da célula da DataGrid
        private void tblEmail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VerEmail(sender, e);
        }
        #endregion

        #region Botão Mandar Todos
        private void btnMandarTodos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja mandar esses e-mails? Isso pode demorar um tempo", "Mandar Todos os E-mails", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("sistema.hemolab@gmail.com", "sistemahemolab123");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                for (int i = 0; i < tblEmail.Rows.Count; i++)
                {
                    clsDadosGerais.cd_rg_doador = tblEmail.SelectedRows[0].Cells[0].Value.ToString();
                    clsDadosGerais.nm_doador = tblEmail.SelectedRows[0].Cells[1].Value.ToString();
                    clsDadosGerais.sg_sexo_doador = tblEmail.SelectedRows[0].Cells[2].Value.ToString();
                    clsDadosGerais.nm_email_doador = tblEmail.SelectedRows[0].Cells[3].Value.ToString();
                    clsDadosGerais.dt_coleta = tblEmail.SelectedRows[0].Cells[4].Value.ToString();
                    string data = clsDadosGerais.dt_coleta;
                    string dia, mes, ano;
                    data = data.Replace("/", "");
                    dia = data.Substring(0, 2);
                    mes = data.Substring(2, 2);
                    ano = data.Substring(4, 4);
                    data = ano + "-" + mes + "-" + dia;
                    clsDadosGerais.dt_coleta = data;

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
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu uma falha no envio do e-mail ao doador: " + clsDadosGerais.cd_rg_doador + ". Verifique sua conexão com a internet e tente novamente. Se o problema persistir, é provável que o e-mail cadastrado do doador esteja errado.", "Falha ao Enviar e-mail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                MessageBox.Show("Todos os e-mails foram enviados com sucesso!", "Mandar todos");
            }
        }
        #endregion

        #region Botão Ver
        private void btnVer_Click(object sender, EventArgs e)
        {
            VerEmail(sender, e);
        }
        #endregion

        #region Botão Remover Todos
        private void btnRemoverTodos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja remover essas notificações?", "Remover Todos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                for (int i = 0; i < tblEmail.Rows.Count; i++)
                {
                    if (Convert.ToString(tblEmail.Rows[i].Cells[0].Value) == "")
                    {
                        MessageBox.Show("Notificações removidas com sucesso!", "Remover Notificações");
                        return;
                    }
                    string data = tblEmail.Rows[i].Cells[4].Value.ToString();
                    string dia, mes, ano;
                    data = data.Replace("/", "");
                    dia = data.Substring(0, 2);
                    mes = data.Substring(2, 2);
                    ano = data.Substring(4, 4);
                    data = ano + "-" + mes + "-" + dia;
                    string comando = "update bolsa_coletada set ic_mandou_email = true where cd_rg_doador = '" + tblEmail.Rows[i].Cells[0].Value.ToString() + "' and dt_coleta = '" + data + "'";
                    MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
                    cSQL.ExecuteNonQuery();
                }
                frmEmailDoador_Load(sender, e);
            }
        }
        #endregion
    }
}
