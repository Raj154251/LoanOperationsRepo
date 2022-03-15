using BusinessLogic.LoanData;
using Database.LoanData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanOperations.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        ILoanDetailBusiness _loanDetailBusiness;
        public ValuesController(ILoanDetailBusiness loanDetailBusiness)
        {
            _loanDetailBusiness = loanDetailBusiness;
        }
        public IEnumerable<LoanDetail> Get()
        {
           
            List<LoanDetail> LoanDetailsLst = _loanDetailBusiness.GetAllLoanDetails().ToList();
            return LoanDetailsLst;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}