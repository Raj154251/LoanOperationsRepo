using Autofac;
using AutoMapper;
using BusinessLogic.LoanData.MappingProfile;
using Contract.LoanOperations;
using LoanOperations.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanOperations.App_Start
{
    public static class AutoMapperConfig
    {
       /* protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(x =>
            {
                //Register Mapper Profile
                x.AddProfile<ContractToBusinessMapping>();
                x.AddProfile<BusinessToContractMapping>();  
            }
            )).AsSelf().InstancePerRequest();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>().InstancePerRequest();
        }*/
         public static IMapper Configure()
         {
             var config = new MapperConfiguration(x =>
             {
                 x.AddProfile<ContractToBusinessMapping>();
                 x.AddProfile<BusinessToContractMapping>();
                 x.AddProfile<BusinessToDBModelMapping>();
                 x.AddProfile<DBModelToBusinessMapping>();
             });
             return config.CreateMapper();
         }
    }
}