using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Data;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces;
using Shared.Models;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Repository<T> : IRepository<T> where T : EntidadBase
    {
        private readonly MyDbContext _myDbContext;
        protected DbSet<T> dbSet;

        public Repository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            dbSet = myDbContext.Set<T>();
        }

        public async Task Add(T entidad)
        {
            await dbSet.AddAsync(entidad);

        }

        public void Delete(T entidad)
        {
            entidad.Borrado = true;
            dbSet.Update(entidad);
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int entidadId)
        {
            return await dbSet.SingleOrDefaultAsync(x => x.Id == entidadId);
        }

        public void Update(T entidad)
        {
            dbSet.Attach(entidad);
            _myDbContext.Entry(entidad).State = EntityState.Modified;
        }
    }
}