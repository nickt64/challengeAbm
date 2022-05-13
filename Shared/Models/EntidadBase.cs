using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class EntidadBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Borrado { get; set; }
    }
}
