using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojos
{
    public class Mascota
    {
        [Key]
        public Guid _id { get; set; }

        public string nombre { get; set; }

        public string raza { get; set; }

        public string[] fotoUrl { get; set; }

        public string tipo { get; set; }
         
        public string sexo { get; set; }

        public string descripcion { get; set; }

        public string idUsuario { get; set; }
    }
}
