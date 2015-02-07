using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamCityWebTest.Startup))]
namespace TeamCityWebTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
