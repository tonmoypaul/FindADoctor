using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindADoctor.Startup))]
namespace FindADoctor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
