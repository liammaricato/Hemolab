using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prj_Hemolab.Classes
{
    public static class clsAbreForm
    {
        public static Form formularioPrincipal { get; set; }

        public static void AbreForm(Form formulario)
        {
            formulario.MdiParent = formularioPrincipal;
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.Show();
        }

        public static void LimpaTodos()
        {
            foreach (Form frm in formularioPrincipal.MdiChildren)
            {
                frm.Close();
            }
        }
    }
}
