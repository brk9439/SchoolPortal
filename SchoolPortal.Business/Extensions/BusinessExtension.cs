using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolPortal.Infrastruct.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPortal.Business.Account;
using SchoolPortal.Business.School;
using SchoolPortal.Business.User;

namespace SchoolPortal.Business.Extensions
{
    public static class BusinessExtension
    {
        public static IServiceCollection Service(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IAccountBusiness, AccountBusiness>();
            services.AddScoped<ISchoolBusiness, SchoolBusiness>();
            SchoolPortal.Infrastruct.Extension.InfrastructExtension.Service(services, configuration);
            return services;
        }
    }
}
