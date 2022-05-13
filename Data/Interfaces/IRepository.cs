using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepository<T> where T : EntidadBase
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int entidadId);
        Task Add(T entidad);
        void Delete(T entidad);
        void Update(T entidad);
    }
}
