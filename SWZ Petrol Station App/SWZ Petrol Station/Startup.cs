using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SWZ_Petrol_Station.Startup))]
namespace SWZ_Petrol_Station
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
