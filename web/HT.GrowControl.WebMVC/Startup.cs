using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HT.GrowControl.WebMVC.Startup))]
namespace HT.GrowControl.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
