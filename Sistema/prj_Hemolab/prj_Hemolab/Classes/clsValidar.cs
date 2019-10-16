using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using prj_Hemolab.Classes;

namespace prj_Hemolab
{
    class clsValidar
    {
        public static bool Texto(char caracter)
        {
            if (caracter != '\'')
                return false;
            else
                return true;
        }

        public static bool Codigo(char caracter)
        {
            if (char.IsNumber(caracter) || caracter == 8)
                return false;
            else
                return true;
        }

        public static bool Vazio(string texto)
        {
            if (texto.Trim() == "")
                return true;
            else
                return false;
        }

        public static bool CPF(string cpf)
        {
            bool primeiro_digito_certo = false;
            bool segundo_digito_certo = false;

            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            if (cpf.Length != 11)
                return false;

            //Validação do primeiro dígito
            int t = 10;
            double multiplicacao = 0;

            for (int i = 0; i < 9; i++)
            {
                multiplicacao += Convert.ToDouble(cpf.Substring(i, 1)) * t;
                t--;
            }
            if ((multiplicacao) * 10 % 11 == 10)
            {
                if (Convert.ToInt32(cpf.Substring(9, 1)) == 0)
                    primeiro_digito_certo = true;
            }
            else
            {
                if (Convert.ToDouble(cpf.Substring(9, 1)) == (multiplicacao * 10) % 11)
                    primeiro_digito_certo = true;
            }

            //Validação do segundo dígito
            t = 11;
            multiplicacao = 0;

            for (int i = 0; i < 10; i++)
            {
                multiplicacao += Convert.ToDouble(cpf.Substring(i, 1)) * t;
                t--;
            }
            if ((multiplicacao) * 10 % 11 == 10)
            {
                if (Convert.ToInt32(cpf.Substring(10, 1)) == 0)
                    segundo_digito_certo = true;
            }
            else
            {
                if (Convert.ToDouble(cpf.Substring(10, 1)) == (multiplicacao * 10) % 11)
                    segundo_digito_certo = true;
            }

            if (primeiro_digito_certo == true && segundo_digito_certo == true)
                return true;
            else
                return false;
        }

        public static bool RG(string rg)
        {
            rg = rg.Replace(".", "");
            rg = rg.Replace("-", "");

            if (rg.Length != 9)
            {
                return false;
            }

            string validador = "23456789";
            int somatoria = 0;


            int k = 0;
            do
            {
                somatoria += int.Parse(rg.Substring(k, 1)) * int.Parse(validador.Substring(k, 1));
                k++;
            } while (k < validador.Length);


            somatoria += int.Parse(rg.Substring(8, 1)) * 100;

            if (somatoria % 11 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DataNascimento(string data)
        {
            data = data.Replace("/", "");
            data = data.Trim();

            if (data.Length != 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Telefone(string telefone)
        {
            telefone = telefone.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (telefone.Length < 10 || telefone.Length > 12)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Email(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Nome(string nome)
        {
            if (nome.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool DataInicioDataFim(string dataInicio, string dataFim)
        {
            string comando = "select if ('" + dataFim + "' > '" + dataInicio + "', 'True', 'False')";
            MySqlCommand cSQL = new MySqlCommand(comando, clsDadosGerais.conexao);
            MySqlDataReader dados = cSQL.ExecuteReader();
            if (dados.Read() && dados[0].ToString() == "True")
            {
                if (dados[0].ToString() == "True")
                {
                    dados.Close();
                    return true;
                }
                else
                {
                    dados.Close();
                    return false;
                }
            }
            else
            {
                dados.Close();
                return false;
            }
        }
    }
}
