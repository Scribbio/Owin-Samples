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

        //public void Configuration(IAppBuilder appBuilder) {
        //    appBuilder.Run(HandleRequest);

        //}s

        public void Configuration(IAppBuilder app)
        {
            //app.Run(ctx =>
            //{
            //    ctx.Response.ContentType = "text/plain";
            //    return ctx.Response.WriteAsync("Hello World");
            //});

            app.Use((context, next) =>
            {
                context.Response.Write("Hello World");
                return Task.FromResult(0);
            });

            //app.Use((context, next) =>
            //{
            //    await next.Invoke(OwinHello);
            //    return Task.FromResult(0);
            //});

        }


        public Task OwinHello(IDictionary<string, object> environment)
        {
            string responseText = "Hello World via OWIN";
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);

            // OWIN Environment Keys: https://owin.org/spec/spec/owin-1.0.0.html
            var responseStream = (Stream)environment["owin.ResponseBody"];
            var responseHeaders = (IDictionary<string, string[]>)environment["owin.ResponseHeaders"];

            responseHeaders["Content-Length"] = new string[] { responseBytes.Length.ToString("hey") };
            responseHeaders["Content-Type"] = new string[] { "text/plain" };

            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }

        //app.Use(new Func<AppFunc, AppFunc>(next => (async env => {
        //    Console.WriteLine("Middleware with AppFunc begin.");
        //    await next.Invoke(env);
        //    Console.WriteLine("Middleware with AppFunc end.");
        //})));

        //static Task HandleRequest(IOwinContext context) {
        //    context.Response.ContentType = "text/plain";
        //    return context.Response.WriteAsync("Hello, world!");
        //}
    }
}

