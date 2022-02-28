using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZenAchitecture.Domain.Entities;
using ZenAchitecture.Infrastructure.Persistence;

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