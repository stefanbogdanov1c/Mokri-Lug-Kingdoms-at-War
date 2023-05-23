using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MokriLug.Startup))]
namespace MokriLug
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
