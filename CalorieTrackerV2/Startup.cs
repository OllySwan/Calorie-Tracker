using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalorieTrackerV2.Startup))]
namespace CalorieTrackerV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
