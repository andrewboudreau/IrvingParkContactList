using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IrvingParkContactList.Startup))]
namespace IrvingParkContactList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
