using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanData.DataAccess.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoanDBConection _dbContext;

        public UnitOfWork()
        {
            _dbContext = new LoanDBConection();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }

}
