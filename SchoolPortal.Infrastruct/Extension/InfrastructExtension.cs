using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolPortal.Infrastruct.Domain.Context;

namespace SchoolPortal.Infrastruct.Extension
{
    public static class InfrastructExtension
    {
        public static IServiceCollection Service(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolPortalDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetSection("ConnectionStrings:SchoolDbConnection").Value);
            });
            return services;
        }
    }
}
