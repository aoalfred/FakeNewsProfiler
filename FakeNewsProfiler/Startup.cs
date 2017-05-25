using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FakeNewsProfiler.Startup))]
namespace FakeNewsProfiler
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
