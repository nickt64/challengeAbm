using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUsuariosServicios
    {
        Task<IEnumerable<UsuarioDto>> GetUsuarios (bool? estado);

        Task<NuevoUsuarioDto> Detalle(int entidadId);

        Task InsertUsuario(NuevoUsuarioDto usuario);

        Task UpdateUsuario(NuevoUsuarioDto usuario);

        Task Delete(int id);
        
        Task ReActivar(int id);
    }
}
