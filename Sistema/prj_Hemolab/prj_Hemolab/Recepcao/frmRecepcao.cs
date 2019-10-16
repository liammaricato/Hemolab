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
    public partial class frmRecepcao : Form
    {
        public frmRecepcao()
        {
            InitializeComponent();
        }
        
        #region Botão Nova Doação
        private void btnNovaDoacao_Click(object sender, EventArgs e)
        {
            Form frmDoacao = new Recepcao.frmNovaDoacao();
            clsAbreForm.AbreForm(frmDoacao);
            this.Close();
        }
        #endregion

        private void btnDoador_Click(object sender, EventArgs e)
        {
            Form frmBuscarDoador = new Recepcao.frmBuscarDoador();
            clsAbreForm.AbreForm(frmBuscarDoador);
            this.Close();
        }
    }
}
