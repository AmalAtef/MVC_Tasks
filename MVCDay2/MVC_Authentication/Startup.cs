using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Authentication.Startup))]
namespace MVC_Authentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
