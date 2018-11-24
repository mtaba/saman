using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(saman.Startup))]
namespace saman
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
