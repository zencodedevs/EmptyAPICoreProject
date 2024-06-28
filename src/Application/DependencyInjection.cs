using ZenAchitecture.Application.Common.Behaviours;
using ZenAchitecture.Application.Common.Services;
using ZenAchitecture.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Zen.Application;
using Application.Shared;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ZenAchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddApplicationShared(configuration);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));



            //app services
            services.AddTransient<IActivityService, ActivityService>();

            return services;
        }
    }
}
