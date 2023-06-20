using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Trainee
    {
        public int Id { get; set; }

        public String Email { get; set; }

        public String Pass { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public String ImgPerfil { get; set; }

        public bool Admin { get; set; }
    }
}
