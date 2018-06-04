using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Callboard.App.Web.Startup))]

namespace Callboard.App.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
