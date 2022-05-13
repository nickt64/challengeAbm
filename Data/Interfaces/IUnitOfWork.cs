using Data.Repositorios;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        UsuariosRepository UsuarioRepository { get; }
        
        Task SaveChangesAsync();
    }
}
