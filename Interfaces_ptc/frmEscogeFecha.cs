using Interfaces_ptc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos
{
    public partial class frmEscogeFecha : Form
    {
        public frmEscogeFecha(Usuario u)
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas en los DateTimePickers
            DateTime fechaInicio = dtpFechaInicial.Value;
            DateTime fechaFin = dtpCierre.Value;

            // Verificar si las fechas son válidas (por ejemplo, fechaFin >= fechaInicio)
            if (fechaFin < fechaInicio)
            {
                MessageBox.Show("La fecha de cierre debe ser mayor o igual que la fecha inicial.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // No continuar la ejecución del código
            }

            // Llamar al formulario de informe de inventario y pasar las fechas como parámetros
            frmReporteDeInventario frmInformeInventario = new frmReporteDeInventario(fechaInicio, fechaFin);
            frmInformeInventario.ShowDialog();
        }
    }
}
