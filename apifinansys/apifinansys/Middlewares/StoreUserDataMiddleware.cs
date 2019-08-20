using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Middlewares
{
    public class StoreUserDataMiddleware
    {
        private readonly RequestDelegate _next;

        public StoreUserDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context, IHeaderEvent headerEvent)
        {
            try
            {
                headerEvent.Token = context.Request.Headers["Authorization"];
                if (headerEvent.Token != null)
                    if (headerEvent.Token.Contains("Bearer"))
                    {
                        await context.Response.WriteAsync("Not Autorized!");
                        return;
                    }

            }
            catch (Exception)
            {
                throw;
            }

            await _next(context);
        }
    }
}
