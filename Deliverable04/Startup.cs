using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Deliverable04.Startup))]
namespace Deliverable04
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
