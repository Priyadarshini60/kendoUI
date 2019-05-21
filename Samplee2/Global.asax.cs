using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Samplee2.DAL;
using Samplee2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Samplee2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeViewModel, Employee_tbl>().ReverseMap();

                config.CreateMap<EmployeeViewModel, EmployeeViewModel>()
                .ForMember(evm => evm.Birthdate, opt => opt.Ignore());

                config.CreateMap<Employee_tbl, EmployeeViewModel>()
                .ForMember(o => o.Birthdate, opt => opt.Ignore());

            });
           
        }

    }
}
