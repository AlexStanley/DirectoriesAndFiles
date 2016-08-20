using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DirectoriesFilesWebAPIAngularJSApp.Startup))]
namespace DirectoriesFilesWebAPIAngularJSApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
