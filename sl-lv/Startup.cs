using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sl_lv.Startup))]
namespace sl_lv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
