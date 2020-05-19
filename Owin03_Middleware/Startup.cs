using System;
using Owin;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Owin03_Middleware {

    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup {

        public void Configuration(IAppBuilder app) {

            // Using func
            app.Use(new Func<AppFunc, AppFunc>(next => (async env => {
                Console.WriteLine("Middleware with AppFunc begin.");
                await next.Invoke(env);
                Console.WriteLine("Middleware with AppFunc end.");
            })));

            // Using IOwinContext
            app.Use(async (context, next) => {
                Console.WriteLine("Middleware with Lambda begin.");
                await next();
                Console.WriteLine("Middleware with Lambda end.");
            });

            // Use Middleware as a type
            app.Use<LogMiddleware>();

            // Use Middleware as an instance
            var instance = new InstanceMiddleware();
            app.Use(instance);

            // Use Middleware as a type     
            app.Use<LogOwinMiddleware>();

        }
    }
}

