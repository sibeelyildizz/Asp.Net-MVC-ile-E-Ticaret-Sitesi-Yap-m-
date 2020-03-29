using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(benimalisverissitem.App_Start.Startup1))]

namespace benimalisverissitem.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType="ApplicationCookie",
                LoginPath=new PathString("/ClientHome/list")
            });
                
        }


    }
}
