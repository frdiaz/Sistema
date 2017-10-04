using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lunes.Startup))]
namespace Lunes
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
