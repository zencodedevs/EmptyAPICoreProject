namespace ZenAchitecture.WebUI
{
    using ZenAchitecture.Domain.Interfaces;
    using ZenAchitecture.WebUI.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Zen.EventProcessor;
    using Zen.Mvc;

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
