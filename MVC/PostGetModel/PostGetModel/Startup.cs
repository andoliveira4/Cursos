using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PostGetModel.Startup))]
namespace PostGetModel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
