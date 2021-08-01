using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BWG_UniversityManager_MVC.Startup))]
namespace BWG_UniversityManager_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
