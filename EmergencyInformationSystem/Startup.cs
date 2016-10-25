using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmergencyInformationSystem.Startup))]
namespace EmergencyInformationSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
