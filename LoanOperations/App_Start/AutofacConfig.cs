using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using BusinessLogic.LoanData;
using Database.LoanData;
using Database.LoanData.DataAccess.Repository;
using LoanOperations.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using static Database.LoanData.DataAccess.Repository.UnitOfWork;

namespace LoanOperations.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            SetupAutofacContainer();
        }

        public static void SetupAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<LoanDetailBusiness>().As<ILoanDetailBusiness>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            // builder.RegisterModule<AutoMapperConfig>();
            builder.Register(x => AutoMapperConfig.Configure()).As<IMapper>().SingleInstance();
            IContainer container = builder.Build();
            container.Resolve<LoanDetailController>();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}