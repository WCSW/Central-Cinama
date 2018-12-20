using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperMovie.Startup))]
namespace SuperMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
