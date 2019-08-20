using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.Middlewares
{
    public static class StoreUserDataMiddlewareExtensions
    {
        public static IApplicationBuilder UseStoreUserData(this IApplicationBuilder app)
        {
            return app.UseMiddleware<StoreUserDataMiddleware>();
        }
    }
}
