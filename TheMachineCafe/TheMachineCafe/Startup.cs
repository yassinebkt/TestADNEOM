using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheMachineCafe.Startup))]
namespace TheMachineCafe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
