using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(comp2007w2018finalA.Startup))]
namespace comp2007w2018finalA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
