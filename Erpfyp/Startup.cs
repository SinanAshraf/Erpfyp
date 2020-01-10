using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Erpfyp.Startup))]
namespace Erpfyp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
