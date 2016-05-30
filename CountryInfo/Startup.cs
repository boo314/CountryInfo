using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CountryInfo.Startup))]
namespace CountryInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
