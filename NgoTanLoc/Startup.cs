using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NgoTanLoc.Startup))]
namespace NgoTanLoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
