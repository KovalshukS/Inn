using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inn.Startup))]
namespace Inn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
