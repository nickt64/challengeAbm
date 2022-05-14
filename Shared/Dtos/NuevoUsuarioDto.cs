using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class NuevoUsuarioDto
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-ZñÑ\s]{2,50})$", ErrorMessage = "solo letras minimo 2 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-ZñÑ\s]{2,50})$", ErrorMessage = "solo letras minimo 2 caracteres")]
        public string Apellido { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^([0-9]{5,15})$", ErrorMessage = "Solo numeros minimo 5 numeros.")]
        public string Telefono { get; set; }

        [DisplayName("Estado")]
        public bool Borrado { get; set; }

    }
}
