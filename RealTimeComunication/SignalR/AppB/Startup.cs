using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppB.Startup))]
namespace AppB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
