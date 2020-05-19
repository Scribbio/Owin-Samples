using Owin;
using Microsoft.Owin;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Owin01_Helloworld {

    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup {

        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                context.Response.Write("Hello World");
                return Task.FromResult(0);
            });
        }
    }
}

