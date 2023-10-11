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
            Producto P = new Producto();
            bool existencias = P.ExistenProductos();

            if (!existencias)
            {
                MessageBox.Show("No se puede generar un reporte de inventario si no hay productos en el sistema", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // No continuar la ejecución del código
            }
            else
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

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada en el DateTimePicker
            DateTime fechaSeleccionada = dtpFechaInicial.Value;

            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Verificar si la fecha seleccionada es una fecha futura
            if (fechaSeleccionada > fechaActual)
            {
                MessageBox.Show("No se permite seleccionar fechas futuras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Restaurar la fecha del DateTimePicker a la fecha actual
                dtpFechaInicial.Value = fechaActual;
            }
        }

        private void dtpCierre_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada en el DateTimePicker
            DateTime fechaSeleccionada = dtpCierre.Value;

            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Verificar si la fecha seleccionada es una fecha futura
            if (fechaSeleccionada > fechaActual)
            {
                MessageBox.Show("No se permite seleccionar fechas futuras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Restaurar la fecha del DateTimePicker a la fecha actual
                dtpCierre.Value = fechaActual;
            }
        }
    }
}
