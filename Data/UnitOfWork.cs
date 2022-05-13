using Data.Interfaces;
using Data.Repositorios;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _myDbContext;
        private readonly UsuariosRepository _usuariosRepository;

        public UnitOfWork(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;

            _usuariosRepository = new UsuariosRepository(_myDbContext);
        }

        public UsuariosRepository UsuarioRepository => _usuariosRepository;

        public async Task SaveChangesAsync()
        {
            await _myDbContext.SaveChangesAsync();
        }

    }
}
