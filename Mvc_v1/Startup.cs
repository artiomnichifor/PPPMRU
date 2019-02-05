using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc_v1.Startup))]
namespace Mvc_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
