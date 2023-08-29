using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces_ptc
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Usuario.VerificarUsuarios() == true)
            {
                Application.Run(new frmLogin());
            }
            else
            {
                Application.Run(new frmPrimerUso());
            }
        }
    }
}
