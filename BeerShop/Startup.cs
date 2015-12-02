using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerShop.Startup))]
namespace BeerShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
