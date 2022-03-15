using BusinessLogic.Model;
using Contract.LoanOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanOperations.MappingProfile
{
    public class BusinessToContractMapping : AutoMapper.Profile
    {
        public BusinessToContractMapping()
        {
            CreateMap< LoanDetailBusinessModel, RequestLoanModel>();
        }
    }
}