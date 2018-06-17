using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomBikes.Startup))]
namespace CustomBikes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
