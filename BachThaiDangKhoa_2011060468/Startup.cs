using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BachThaiDangKhoa_2011060468.Startup))]
namespace BachThaiDangKhoa_2011060468
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
