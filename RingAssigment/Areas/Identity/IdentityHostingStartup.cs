using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RingAssigment.Models;

[assembly: HostingStartup(typeof(RingAssigment.Areas.Identity.IdentityHostingStartup))]
namespace RingAssigment.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RingAssigmentContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RingAssigmentContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<RingAssigmentContext>();
            });
        }
    }
}