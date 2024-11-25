using System.Net;
using System.Text.Json;
using API.Error;

namespace API.Middleware
{
    public static class ExceptionMiddleware
    {

        public static void AddInterServerMiddleware(this IApplicationBuilder app,bool env)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (Exception ex)
                {
                    var res = new ApplicationErrors((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace);
                    await HostExceptionAsync(context,ex,env);
                }
            });
        }

        
        private static Task HostExceptionAsync(HttpContext context, Exception ex,bool env)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = env ?  new ApplicationErrors(context.Response.StatusCode,ex.Message,ex.StackTrace) : new ApplicationErrors(context.Response.StatusCode,ex.Message,"Internal Server Error");
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

}


// // public async Task InokeAsync(HttpContext context)
//         {
//             try
//             {
//                 await next(context);
//             }
//             catch (Exception ex)
//             {
//                 var ApplicationErrors = new ApplicationErrors((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace);
//             }
//         }

