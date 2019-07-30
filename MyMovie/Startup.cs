using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMovie.Startup))]
namespace MyMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
