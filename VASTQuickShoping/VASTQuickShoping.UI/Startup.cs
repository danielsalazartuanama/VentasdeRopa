using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VASTQuickShoping.UI.Startup))]
namespace VASTQuickShoping.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
