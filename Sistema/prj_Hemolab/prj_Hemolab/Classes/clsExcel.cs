using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace prj_Hemolab
{
    class clsExcel
    {

        public static Excel.Application xlsAplicativo { get; set; }
        public static Excel.Workbook xlsArquivo { get; set; }
        public static Excel.Worksheet xlsPlanilha { get; set; }

        #region Cria Excel
        public void CriaExcel()
        {
            object misValue = System.Reflection.Missing.Value;
            xlsAplicativo = new Excel.Application();
            xlsArquivo = xlsAplicativo.Workbooks.Add(misValue);
        }
        #endregion

        #region Abre Arquivo
        public void AbreArquivo(string nomeArquivo)
        {
            object misValue = System.Reflection.Missing.Value;
            xlsAplicativo = new Excel.Application();
            xlsArquivo = xlsAplicativo.Workbooks.Open(nomeArquivo, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
        }
        #endregion

        #region Escolhe Plan
        public void EscolhaPlan(int qual)
        {
            xlsPlanilha = (Excel.Worksheet)xlsArquivo.Worksheets.get_Item(qual);
        }
        #endregion

        #region Adicionar Valor
        public void Adiciona(string celula, string valor)
        {
            Excel.Range regiao = xlsPlanilha.get_Range(celula, celula);
            regiao.Value = valor;
        }
        #endregion

        #region Salva Arquivo
        public void Salvar(string nomeArq)
        {
            xlsAplicativo.DisplayAlerts = false;
            object misValue = System.Reflection.Missing.Value;
            xlsArquivo.SaveAs(Application.StartupPath.ToString() + "\\" + nomeArq + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlsAplicativo.DisplayAlerts = true;
        }
        #endregion

        #region Fechar
        public void Fechar()
        {
            object misValue = System.Reflection.Missing.Value;
            xlsArquivo.Close(true, misValue, misValue);
            xlsAplicativo.Quit();
        }
        #endregion

        #region Exibir
        public void Exibir()
        {
            xlsAplicativo.Visible = true;
        }
        #endregion

        #region Recebe de um DataGridView
        public void RecebeDataGrid(DataGridView dg)
        {
            int i = 0;
            int j = 0;

            for (i = 0; i <= dg.RowCount - 1; i++)
            {
                for (j = 0; j <= dg.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dg[j, i];
                    xlsPlanilha.Cells[i + 1, j + 1] = cell.Value;
                }
            }
        }
        #endregion

        #region Mesclar
        public void Mesclar(string inicio, string fim)
        {
            xlsPlanilha.get_Range(inicio, fim).Merge(true);
        }
        #endregion

        #region Borda ao Redor
        public void Borda(string inicio, string fim)
        {
            Excel.Range regiao = xlsPlanilha.get_Range(inicio, fim);
            regiao.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
        }
        #endregion

        #region Negrito
        public void Negrito(string inicio, string fim)
        {
            Excel.Range regiao = xlsPlanilha.get_Range(inicio, fim);
            regiao.Font.Bold = true;
        }
        #endregion

        #region Alinhamento
        public void Alinhamento(string inicio, string fim, string tipo)
        {
            int numTipo=0;
            Excel.Range regiao = xlsPlanilha.get_Range(inicio, fim);
            switch (tipo)
            {
                case "esquerda": numTipo = 1; break;
                case "direita": numTipo = 2; break;
                case "centro": numTipo = 3; break;
            }
            regiao.HorizontalAlignment = numTipo;
            regiao.VerticalAlignment = numTipo;
        }
        #endregion


    }
}
