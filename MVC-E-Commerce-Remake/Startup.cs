using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_E_Commerce_Remake.Startup))]
namespace MVC_E_Commerce_Remake
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
