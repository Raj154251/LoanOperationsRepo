using BusinessLogic.Model;
using Database.LoanData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic.LoanData
{
    public interface ILoanDetailBusiness
    {
        IList<LoanDetailBusinessModel> GetAllLoanDetails();

        LoanDetailBusinessModel GetLoanDetailsById(int id);

        string InsertLoanDetail(LoanDetailBusinessModel loanDetail);

        string Delete(int id);

        string Delete(LoanDetail loanDetail);
    }
}