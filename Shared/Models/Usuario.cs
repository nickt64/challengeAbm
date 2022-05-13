using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    
    public class Usuario: EntidadBase
    {
        [Required]
        [MaxLength(20)]
        public string  Nombre { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Apellido { get; set; }

        public string NombreCompleto
        {
            get { return Nombre + ", " + Apellido; }
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }
       

       

    }
}
