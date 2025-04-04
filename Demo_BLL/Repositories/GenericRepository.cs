using Demo_BLL.Interfaces;
using Demo_Dal.Context;
using Demo_Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo_BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepositorie<T> where T : Base
    {
        private readonly MVCDbContext context;

        public GenericRepository(MVCDbContext _context)  
        {
            context = _context;
        }
        public int Add(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public int Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
            => context.Set<T>().AsNoTracking().ToList();

        public T GetById(int? id)
            => context.Set<T>().Find(id);

        public int Update(T entity)
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges();
        }
    }
}
