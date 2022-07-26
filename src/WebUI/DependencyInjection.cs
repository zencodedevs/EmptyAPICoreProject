using ZenAchitecture.WebUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Zen.Mvc;
using ZenAchitecture.Domain.Shared.Interfaces;

namespace ZenAchitecture.WebUI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebUi(this IServiceCollection services)
        {
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.RegisterMvc();

            return services;
        }
    }
}
