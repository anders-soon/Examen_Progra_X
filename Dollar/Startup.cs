using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dollar.Startup))]
namespace Dollar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
