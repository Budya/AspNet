using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RolesIdentityApp.Startup))]
namespace RolesIdentityApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
