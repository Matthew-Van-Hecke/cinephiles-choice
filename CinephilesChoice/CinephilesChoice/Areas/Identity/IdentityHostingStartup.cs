using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CinephilesChoice.Areas.Identity.IdentityHostingStartup))]
namespace CinephilesChoice.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}