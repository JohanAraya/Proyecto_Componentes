using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojos
{
    public class Usuario
    { 
        public Guid _id { get; set; }

        public string nombre { get; set; }

        public string apellido1 { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }

        public string correo { get; set; }

        public string password { get; set; }

        public string[] fotoUrl { get; set; }

    }
}
