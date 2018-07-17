using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutorizFilterApp.Startup))]
namespace AutorizFilterApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
