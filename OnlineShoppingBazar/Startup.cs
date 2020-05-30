using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShoppingBazar.Startup))]
namespace OnlineShoppingBazar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
