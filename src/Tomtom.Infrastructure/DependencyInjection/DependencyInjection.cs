using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using Tomtom.Application.Value;
using Tomtom.Domain.Value;
using Tomtom.Infrastructure.Adapters.Value;

namespace Tomtom.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IValueRepository, MemoryValueRepository>();
            services.AddTransient<IValueService, RepositoryValueServiceAdapter>();
            return services; 
        }

    }
}
