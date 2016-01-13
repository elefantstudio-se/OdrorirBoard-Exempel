using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OdrorirBoard.Startup))]
namespace OdrorirBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
