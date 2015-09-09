using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(D3Graphs.Startup))]
namespace D3Graphs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
