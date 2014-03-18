using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIDE.Startup))]
namespace SIDE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
