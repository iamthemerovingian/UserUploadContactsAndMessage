using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserUploadContactsAndMessage.Startup))]
namespace UserUploadContactsAndMessage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
