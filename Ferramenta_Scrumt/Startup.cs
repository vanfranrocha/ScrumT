using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ferramenta_Scrumt.Startup))]
namespace Ferramenta_Scrumt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
