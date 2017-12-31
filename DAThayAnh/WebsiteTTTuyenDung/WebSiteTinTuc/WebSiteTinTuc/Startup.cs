using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteTinTuc.Startup))]
namespace WebSiteTinTuc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
