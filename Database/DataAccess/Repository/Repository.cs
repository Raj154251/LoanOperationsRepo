using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T :class
    {
        private readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }
        public void Add(T entity)
        {
           Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Update(T entity)
        { 
            Context.Entry(entity).State =EntityState.Modified;
        }
    }

}
