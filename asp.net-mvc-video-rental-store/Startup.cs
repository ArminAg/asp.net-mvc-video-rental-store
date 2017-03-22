using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.net_mvc_video_rental_store.Startup))]
namespace asp.net_mvc_video_rental_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
