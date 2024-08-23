using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLogProj.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationInfraStructure(this IServiceCollection services, IConfiguration configuration )
        {
            services
                .AddApplication(configuration)
                .AddInfrastructure(configuration);

            return services;
        }
    }
}
