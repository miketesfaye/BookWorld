using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookWorld.Startup))]
namespace BookWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
