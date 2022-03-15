using AutoMapper;
using BusinessLogic.LoanData;
using BusinessLogic.Model;
using Contract.LoanOperations;
using Database.LoanData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanOperations.Controllers
{
    [RoutePrefix("api/LoanDetail")]
    public class LoanDetailController : ApiController
    {


        ILoanDetailBusiness _loanDetailBusiness;
        IMapper _mappingService;
        public LoanDetailController(ILoanDetailBusiness loanDetailBusiness, IMapper mappingService)
        {
            _loanDetailBusiness = loanDetailBusiness;
            _mappingService = mappingService;
        }
        // GET: api/LoanDetail
        public IHttpActionResult Get()
        {
            var LoanDetailsLst = _loanDetailBusiness.GetAllLoanDetails().ToList();

            if (LoanDetailsLst.Count == 0)
            {
                return Content(HttpStatusCode.NotFound,"Data not available");
            }
            return Ok(_mappingService.Map<List<RequestLoanModel>>(LoanDetailsLst));
        }
        // GET: api/LoanDetail/5
        public IHttpActionResult Get(int id)
        {
            LoanDetailBusinessModel loanDetail = _loanDetailBusiness.GetLoanDetailsById(id);
            if (loanDetail == null)
            {
                return Content(HttpStatusCode.NotFound,"Id Not Found");
            }
            return Ok(_mappingService.Map<RequestLoanModel>(loanDetail));
        }

        // POST: api/LoanDetail
        [HttpPost]
        [Route("InsertOrUpdateLoan")]
        public IHttpActionResult Post([FromBody] RequestLoanModel loan)
        {
            if (loan == null)
                return Ok("Please provide loan details");
            string result = _loanDetailBusiness.InsertLoanDetail(_mappingService.Map<LoanDetailBusinessModel>(loan));
            return Ok(result);
        }

        // DELETE: api/LoanDetail/5
        public IHttpActionResult Delete(int id)
        {
            string result = _loanDetailBusiness.Delete(id);
            return Ok(result);
        }
/* Commented
        public string Delete([FromBody] LoanDetail loan)
        {
            string result = _loanDetailBusiness.Delete(loan);
            return result;
        }*/
    }
}
