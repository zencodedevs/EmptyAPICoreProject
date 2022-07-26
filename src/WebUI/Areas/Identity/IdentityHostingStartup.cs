using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ZenAchitecture.WebUIAdmin.Areas.Identity.IdentityHostingStartup))]
namespace ZenAchitecture.WebUIAdmin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}