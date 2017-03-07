using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(MountainOperations.Startup))]

namespace MountainOperations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            ConfigureAuth(app);
        }
    }
}
