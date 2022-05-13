using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class UsuarioVM
    {
        public IEnumerable<UsuarioDto> ListaUsuarios { get; set; }
    }
}
