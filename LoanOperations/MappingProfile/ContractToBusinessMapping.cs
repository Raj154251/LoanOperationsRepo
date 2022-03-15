using BusinessLogic.Model;
using Contract.LoanOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanOperations.MappingProfile
{
    public class ContractToBusinessMapping : AutoMapper.Profile
    {
        public ContractToBusinessMapping()
        {
            CreateMap<RequestLoanModel, LoanDetailBusinessModel>();
        }
    }
}