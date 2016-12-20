using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaBlueTest.Startup))]
namespace MediaBlueTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
