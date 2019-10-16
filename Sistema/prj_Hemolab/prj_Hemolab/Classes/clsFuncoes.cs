using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace prj_Hemolab.Classes
{
    public static class clsFuncoes
    {
        public static void PosicionarCursor(MaskedTextBox txt)
        {
            string texto = txt.Text;
            texto = texto.Replace(".", "");
            texto = texto.Replace("-", "");
            texto = texto.Replace("/", "");
            texto = texto.Replace("(", "");
            texto = texto.Replace(")", "");
            texto = texto.Trim();

            if (texto == "")
            {
                txt.SelectionStart = 0;
            } 
        }

        public static string ConverterData(string data)
        {
            string dia, mes, ano;

            if (data.Contains("-"))
            {
                ano = data.Substring(0, 4);
                mes = data.Substring(5, 2);
                dia = data.Substring(7, 2);

                return dia + "/" + mes + "/" + ano;
            }
            else
            {
                dia = data.Substring(0, 2);
                mes = data.Substring(3, 2);
                ano = data.Substring(6, 4);

                return ano + "-" + mes + "-" + dia;
            }            
        }

        public static string Soma1Mes(string data)
        {
            string comando = "select date_add('" + data + "', interval 1 month)";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read())
            {
                data = dados[0].ToString();
            }
            dados.Close();

            return data;
        }
    }
}
