using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using prj_Hemolab.Classes;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace prj_Hemolab.RELATORIOWSSS
{
    public partial class frmRelatoriosDoacoes : Form
    {
        public frmRelatoriosDoacoes()
        {
            InitializeComponent();
        }

        clsExcel excel = new clsExcel();
        object misValue = System.Reflection.Missing.Value;        

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbAnoComeco.SelectedIndex == -1 || cmbAnoFim.SelectedIndex == -1 || cmbMesComeco.SelectedIndex == -1 || cmbMesFim.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve especificar a data de início e a data de fim do relatório!", "Erro");
                return;
            }
            if (cmbTipoRelatorio.SelectedIndex == -1)
            {
                MessageBox.Show("Você deve especificar um tipo de relatório", "Erro");
                return;
            }
            string anoInicio, mesInicio, diaInicio, dataInicio;
            string anoFim, mesFim, diaFim, dataFim;            
            string titulo = "";
            string filtrotipo;
            filtrotipo = FiltroTipo(ckbAPos, ckbANeg, ckbBPos, ckbBNeg, ckbABPos, ckbABNeg, ckbOPos, ckbONeg);            
            diaInicio = "01";
            diaFim = "01";

            if (cmbMesComeco.SelectedIndex <= 9)
            {
                mesInicio = "0" + (cmbMesComeco.SelectedIndex + 1).ToString();
            }
            else
            {
                mesInicio = (cmbMesComeco.SelectedIndex + 1).ToString();
            }
            anoInicio = cmbAnoComeco.SelectedItem.ToString();
            dataInicio = anoInicio + "-" + mesInicio + "-" + diaInicio;

            if (cmbMesFim.SelectedIndex <= 9)
            {
                mesFim = "0" + (cmbMesFim.SelectedIndex + 1).ToString();
            }
            else
            {
                mesFim = (cmbMesFim.SelectedIndex + 1).ToString();
            }
            anoFim = cmbAnoFim.SelectedItem.ToString();
            dataFim = anoFim + "-" + mesFim + "-" + diaFim;

            if (!clsValidar.DataInicioDataFim(dataInicio, dataFim))
            {
                MessageBox.Show("A data final do relatório deve ser posterior à data inicial!", "Erro");
                return;
            }

            excel.AbreArquivo(Application.StartupPath + @"\RelatorioBase.xlsx");
            excel.EscolhaPlan(1);

            int i = 6;
            string comando = "";

            switch (cmbTipoRelatorio.SelectedIndex)
            {
                case 0:
                    comando = "select count(cd_bolsa_coletada) from bolsa_coletada where dt_coleta between '";
                    excel.Adiciona("a1","Relatório de Bolsas Coletadas");
                    titulo = "Bolsas Coletadas";
                    break;
                case 1:
                    comando = "select count(cd_bolsa_fracionada) from bolsa_fracionada bf ";
                    comando += " inner join bolsa_coletada bc on bf.dt_coleta = bc.dt_coleta ";
                    comando += " inner join ocorrencia_situacao_bolsa osb on osb.dt_coleta = bf.dt_coleta ";
                    comando += " and osb.cd_rg_doador = bf.cd_rg_doador and osb.cd_tipo_fracionamento = bf.cd_tipo_fracionamento ";
                    comando += " where osb.cd_situacao_bolsa = 2 ";
                    comando += filtrotipo;
                    comando += "and dt_ocorrencia between '";
                    excel.Adiciona("a1","Relatório de Bolsas Encaminhadas para Transfusão");
                    titulo = "Bolsas Encaminhadas para Transfusão";
                    break;
                case 2:
                    comando = "select count(cd_bolsa_fracionada) from bolsa_fracionada bf ";
                    comando += " inner join bolsa_coletada bc on bf.dt_coleta = bc.dt_coleta ";
                    comando += " inner join ocorrencia_situacao_bolsa osb on osb.dt_coleta = bf.dt_coleta ";
                    comando += " and osb.cd_rg_doador = bf.cd_rg_doador and osb.cd_tipo_fracionamento = bf.cd_tipo_fracionamento ";
                    comando += " where osb.cd_situacao_bolsa = 3 ";
                    comando += filtrotipo;
                    comando += "and dt_ocorrencia between '";
                    excel.Adiciona("a1", "Relatório de Bolsas Descartadas");
                    titulo = "Bolsas Descartadas";
                    break;
                case 3: comando = " select count(bc.dt_coleta) from bolsa_coletada bc where bc.dt_coleta = ";
                    comando += " (select min(bcc.dt_coleta) from bolsa_coletada bcc where bc.cd_rg_doador = bcc.cd_rg_doador) ";
                    comando += "and bc.dt_coleta between '";
                    excel.Adiciona("a1", "Relatório de Novos Doadores");
                    titulo = "Novos doadores";
                    break;
            }


            string data_ = dataInicio;
            do
            {             
                string comando_ = comando + data_ + "' and '" + data_.Remove(8, 2) + "31" + "' ";
                if (cmbTipoRelatorio.SelectedIndex != 3)
                {
                comando_ += filtrotipo;
                }
                MySqlCommand cSQL = new MySqlCommand(comando_, clsDadosGerais.conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                if (dados.Read())
                {
                        excel.Adiciona("a" + i.ToString(), clsFuncoes.ConverterData(data_).Remove(0, 3));
                        excel.Adiciona("b" + i.ToString(), dados[0].ToString());
                        i++;
                }
                dados.Close();
                data_ = clsFuncoes.Soma1Mes(data_);
            } while (data_ != clsFuncoes.Soma1Mes(dataFim));

            excel.Adiciona("p3", Filtros(ckbAPos, ckbANeg, ckbBPos, ckbBNeg, ckbABPos, ckbABNeg, ckbOPos, ckbONeg));
            excel.Adiciona("d3", "=a6");
            excel.Adiciona("d4", "=a" + (i - 1).ToString());
            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)clsExcel.xlsPlanilha.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(105, 62, 767, 300);
            Excel.Chart chartPage = myChart.Chart;
            myChart.Chart.HasTitle = true;
            myChart.Chart.ChartTitle.Text = titulo;
            chartRange = clsExcel.xlsPlanilha.get_Range("A5", "B" + (i - 1).ToString());
            chartPage.SetSourceData(chartRange, misValue);
            myChart.Chart.ChartType = Excel.XlChartType.xlColumnClustered;

            excel.Salvar("Relatorio");
            excel.Exibir();
        }
    

        public static string FiltroTipo(CheckBox APos, CheckBox ANeg, CheckBox BPos, CheckBox BNeg, CheckBox ABPos, CheckBox ABNeg, CheckBox OPos, CheckBox ONeg)
        {
            string comando = "";
            if (APos.Checked)
                comando += "cd_tipo_sanguineo = 4 or ";            
            if (ANeg.Checked)
                comando += "cd_tipo_sanguineo = 3 or ";
            if (BPos.Checked)
                comando += "cd_tipo_sanguineo = 6 or ";
            if (BNeg.Checked)
                comando += "cd_tipo_sanguineo = 5 or ";
            if (ABPos.Checked)
                comando += "cd_tipo_sanguineo = 8 or ";
            if (ABNeg.Checked)
                comando += "cd_tipo_sanguineo = 7 or ";
            if (OPos.Checked)
                comando += "cd_tipo_sanguineo = 2 or ";
            if (ONeg.Checked)
                comando += "cd_tipo_sanguineo = 1 or ";
            if (comando != "")
            {
                return " and (" + comando.Substring(0, comando.Length - 3) + ")";
            }
            else
            {
                return "";
            }
        }

        public static string Filtros(CheckBox APos, CheckBox ANeg, CheckBox BPos, CheckBox BNeg, CheckBox ABPos, CheckBox ABNeg, CheckBox OPos, CheckBox ONeg)
        {
            string tipos = "";
            if (APos.Checked)
                tipos += "A+; ";
            if (ANeg.Checked)
                tipos += "A-; ";
            if (BPos.Checked)
                tipos += "B+; ";
            if (BNeg.Checked)
                tipos += "B-; ";
            if (ABPos.Checked)
                tipos += "AB+; ";
            if (ABNeg.Checked)
                tipos += "AB-; ";
            if (OPos.Checked)
                tipos += "O+; ";
            if (ONeg.Checked)
                tipos += "O-; ";
            if (tipos == "")
            {
                return "A+; A-; B+; B-; AB+; AB-; O+; O-;";
            }
            else
            {
                return tipos;
            }
        }

        private void frmRelatoriosDoacoes_Load(object sender, EventArgs e)
        {
            cmbTipoRelatorio.SelectedIndex = 0;
            gpbFiltroTipo.Focus();
            ckbAPos.Checked = true;
            ckbANeg.Checked = true;
            ckbBPos.Checked = true;
            ckbBNeg.Checked = true;
            ckbABPos.Checked = true;
            ckbABNeg.Checked = true;
            ckbOPos.Checked = true;
            ckbONeg.Checked = true;                   
        }

        private void cmbTipoRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoRelatorio.SelectedIndex == 3)
            {
                gpbFiltroTipo.Enabled = false;
                ckbAPos.Checked = true;
                ckbANeg.Checked = true;
                ckbBPos.Checked = true;
                ckbBNeg.Checked = true;
                ckbABPos.Checked = true;
                ckbABNeg.Checked = true;
                ckbOPos.Checked = true;
                ckbONeg.Checked = true;
            }
            else
            {
                gpbFiltroTipo.Enabled = true;
            }

        }       
    }
}
