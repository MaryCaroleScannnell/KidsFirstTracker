using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidsFirstTracker.WebMVC.Startup))]
namespace KidsFirstTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
