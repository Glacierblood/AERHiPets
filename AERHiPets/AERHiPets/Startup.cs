using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AERHiPets.Startup))]
namespace AERHiPets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
