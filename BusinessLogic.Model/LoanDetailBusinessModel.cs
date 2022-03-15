using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class LoanDetailBusinessModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string PostCode { get; set; }
        public int LoanAmount { get; set; }
        public int Valuation { get; set; }
        public string ChargeType { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
