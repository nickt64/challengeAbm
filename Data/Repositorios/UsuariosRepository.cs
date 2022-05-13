using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class UsuariosRepository : Repository<Usuario>
    {
        public UsuariosRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        public async Task<List<Usuario>> ObtenerPorEstado(bool estado)
        {
            return await dbSet.Where(x => x.Borrado == estado).ToListAsync();
        }

        public void ReActivar(Usuario usuario)
        {
            usuario.Borrado = false;
            dbSet.Update(usuario);
        }
    }
}
