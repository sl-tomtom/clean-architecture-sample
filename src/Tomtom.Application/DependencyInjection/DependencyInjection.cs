using System;
using System.Linq;
using System.Reflection;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Tomtom.Application.Core.Behaviors;
using Tomtom.Application.Core.Pipeline;

namespace Tomtom.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(CommandPipelineBehavior<>), typeof(CommandValidationBehavior<>));
            services.AddTransient(typeof(RequestPipelineBehavior<,>),typeof(RequestValidationBehavior<,>));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>))
            return services;
        }


        public static IServiceCollection Bind<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : class, TService
            where TService : class
        {
            return services.AddTransient<TService>(sp => sp.GetRequiredService<TImplementation>());
        }
    }
}
