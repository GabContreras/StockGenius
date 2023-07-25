using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cargo
    {
        private int id_cargo;
        private string nombre;

        public int Id_cargo { get => id_cargo; set => id_cargo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
