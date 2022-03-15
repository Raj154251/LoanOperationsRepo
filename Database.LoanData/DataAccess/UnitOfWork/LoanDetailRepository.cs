using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.LoanData.DataAccess.Repository
{
    public class LoanDetailRepository : Repository<LoanDetail>
    {
        public LoanDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { 
        }

        
        
        
    }
}
