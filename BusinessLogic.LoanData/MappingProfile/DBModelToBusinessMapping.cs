using BusinessLogic.Model;
using Database.LoanData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LoanData.MappingProfile
{
    public class DBModelToBusinessMapping :AutoMapper.Profile
    {
        public DBModelToBusinessMapping()
        {
            CreateMap<LoanDetail, LoanDetailBusinessModel>();
        }
    }
}
