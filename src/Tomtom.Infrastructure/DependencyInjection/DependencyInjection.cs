using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using Tomtom.Application.Value;
using Tomtom.Infrastructure.Adapters.Value;

namespace Tomtom.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            services.AddTransient<IValueRepository, ValueRepository>();
            services.AddTransient<IValueService, ValueServiceAdapter>();
            return services; 
        }

    }
}
