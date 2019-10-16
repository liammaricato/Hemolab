using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using prj_Hemolab.Classes;

namespace prj_Hemolab
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;UID=root;PASSWORD=root;DATABASE=hemolab");
            try
            {
                conexao.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possível se conectar ao servidor! Por favor tente novamente mais tarde.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            clsDadosGerais.conexao = conexao;
            frmLogin login;
            do
            {
                login = new frmLogin();
                if (login.ShowDialog() == DialogResult.Yes)
                {
                    clsDadosGerais.troca_usuario = false;
                    Application.Run(new frmPrincipal());
                }
                else
                {
                    clsDadosGerais.troca_usuario = false;
                    conexao.Close();
                }
            }
            while (clsDadosGerais.troca_usuario);
        }
    }
}
