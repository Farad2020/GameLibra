using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameLibra.Startup))]
namespace GameLibra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
