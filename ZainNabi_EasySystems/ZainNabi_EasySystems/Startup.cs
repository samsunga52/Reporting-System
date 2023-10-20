using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZainNabi_EasySystems.Startup))]
namespace ZainNabi_EasySystems
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
