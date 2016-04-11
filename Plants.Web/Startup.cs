using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plants.Web.Startup))]
namespace Plants.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
