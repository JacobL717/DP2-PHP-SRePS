using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PHP_SRePS.Startup))]
namespace PHP_SRePS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
