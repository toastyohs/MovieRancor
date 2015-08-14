using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRancor.Startup))]
namespace MovieRancor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
