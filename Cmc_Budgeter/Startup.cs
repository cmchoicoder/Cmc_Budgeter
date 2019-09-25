using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cmc_Budgeter.Startup))]
namespace Cmc_Budgeter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
