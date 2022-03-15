using AutoMapper;
using BusinessLogic.Model;
using Database.LoanData;
using Database.LoanData.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LoanData
{
    public class LoanDetailBusiness : ILoanDetailBusiness
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly LoanDetailRepository _loanDetailRepository;
        private readonly IMapper _mappingService;

        public LoanDetailBusiness(IUnitOfWork unitofwork, IMapper mappingService)
        {
            _unitofwork = unitofwork;
            _loanDetailRepository = new LoanDetailRepository(_unitofwork);
            _mappingService = mappingService;
        }

        public IList<LoanDetailBusinessModel> GetAllLoanDetails()
        {
            List<LoanDetail> loanDetaillst = _loanDetailRepository.GetAll().OrderByDescending(x => x.CreatedOn).ToList();

            return _mappingService.Map<List<LoanDetailBusinessModel>>(loanDetaillst);
        }

        public LoanDetailBusinessModel GetLoanDetailsById(int id)
        {
            LoanDetail loanDetail = _loanDetailRepository.Get(id);

            return _mappingService.Map<LoanDetailBusinessModel>(loanDetail);
        }

        public string InsertLoanDetail(LoanDetailBusinessModel loanDetail)
        {
            loanDetail.CreatedOn = DateTime.Now;
            if (GetLoanDetailsById(loanDetail.Id)!= null)
            {                
                _loanDetailRepository.Update(_mappingService.Map<LoanDetail>(loanDetail));
                return "Loan Details Updated";
            }
            var insertedRecored = _loanDetailRepository.Insert(_mappingService.Map<LoanDetail>(loanDetail));
            if (insertedRecored != null)
            {
                return "Loan Details Inserted";
            }
            else
            {
                return "Data not inserted";
            }
        }

        public string Delete(int id)
        {
            return _loanDetailRepository.Delete(id);
        }

        public string Delete(LoanDetail loanDetail)
        {
            return _loanDetailRepository.Delete(x => x.Id == loanDetail.Id);
        }
    }
}
