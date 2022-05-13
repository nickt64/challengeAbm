using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }
        public string Estado { get; set; } 

        public bool Borrado { get; set; }



    }
}
