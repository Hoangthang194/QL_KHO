using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MWH.Startup))]
namespace MWH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
