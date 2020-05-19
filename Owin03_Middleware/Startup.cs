using System;
using Owin;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Owin03_Middleware {

    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup {

        public void Configuration(IAppBuilder app) {

            // Blog section 4, Using func
            app.Use(new Func<AppFunc, AppFunc>(next => (async env => {
                Console.WriteLine("Middleware with AppFunc begin.");
                await next.Invoke(env);
                Console.WriteLine("Middleware with AppFunc end.");
            })));

            // Blog section 7, using IOwinContext
            app.Use(async (context, next) => {
                Console.WriteLine("Middleware with Lambda begin.");
                await next();
                Console.WriteLine("Middleware with Lambda end.");
            });

            //  Blog section 9, Owin as type Use Middleware as a type
            app.Use<LogMiddleware>();

            // Blog section 9, Use Middleware as an instance
            var instance = new InstanceMiddleware();
            app.Use(instance);

            // Blog section 8, Use Middleware as a type     
            app.Use<LogOwinMiddleware>();

        }
    }
}

