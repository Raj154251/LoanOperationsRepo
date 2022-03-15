using Autofac.Extras.Moq;
using AutoMapper;
using BusinessLogic.LoanData;
using BusinessLogic.Model;
using Contract.LoanOperations;
using LoanOperations.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Http.Results;

namespace Tests.LoanOperations.Controllers
{
    [TestClass]
    public class TestsLoanDetailController
    {

        [TestMethod]
        public void GetLoanDetailById_ShouldReturnLoanDetail()
        {

            using (var mock = AutoMock.GetLoose())
            {
                int id = 5;
                var ExpectedRequestModel = new RequestLoanModel
                {
                    Id = id,
                    FirstName = "TestUser",
                    LastName = "John",
                    Gender = "Female",
                    Contact = "1989781",
                    PostCode = "236245",
                    LoanAmount = 20000,
                    Valuation = 30000,
                    ChargeType = "First"
                };

                   mock.Mock<IMapper>().Setup(m => m.Map<RequestLoanModel>(It.IsAny<LoanDetailBusinessModel>()))
                        .Returns(ExpectedRequestModel);
              
                mock.Mock<ILoanDetailBusiness>().Setup(m => m.GetLoanDetailsById(id))
                    .Returns(new LoanDetailBusinessModel
                    {
                        Id = id,
                        FirstName = "TestUser",
                        LastName = "John",
                        Gender = "Female",
                        Contact = "1989781",
                        PostCode = "236245",
                        LoanAmount = 20000,
                        Valuation = 30000,
                        ChargeType = "First"
                    });

                var inputReqCall = mock.Create<LoanDetailController>();
                var result = inputReqCall.Get(id) as OkNegotiatedContentResult<RequestLoanModel>;
                Assert.AreEqual(ExpectedRequestModel, result.Content);
                //Assert.IsInstanceOfType<OkResult>(result);
            }
        }

        [TestMethod]
        public void GetLoanDetailById_ShouldReturnIdNotFound()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var inputModel = new RequestLoanModel
                {
                    FirstName = "TestUser",
                    LastName = "John",
                    Gender = "Female",
                    Contact = "1989781",
                    PostCode = "236245",
                    LoanAmount = 20000,
                    Valuation = 30000,
                    ChargeType = "First"
                };
                int id = 0;
                string expected = "Id Not Found";
                mock.Mock<ILoanDetailBusiness>().Setup(m => m.GetLoanDetailsById(id)).Returns<RequestLoanModel>(null);

                var inputReqCall = mock.Create<LoanDetailController>();
                var result = inputReqCall.Get(id) as NegotiatedContentResult<string>;
                Assert.AreEqual(expected, result.Content);


            }        

        }
    }
}
