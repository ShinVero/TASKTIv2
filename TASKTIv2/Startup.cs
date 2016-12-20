using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TASKTIv2.Startup))]
namespace TASKTIv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
