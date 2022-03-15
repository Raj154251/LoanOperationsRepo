using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanData.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition);
        T Insert(T entity);
        void Update(T entity);
        string Delete(int id);
        string Delete(Expression<Func<T, bool>> whereCondition);


    }
}
