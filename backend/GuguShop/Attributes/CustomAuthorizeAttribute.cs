using GuguShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GuguShop.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public CustomAuthorizeAttribute()
        {

        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            bool isAuthorized = true;

            // define your custom authorize logic here
            await Task.CompletedTask;
            //

            if(!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        /// <summary>
        /// Get required service instance
        /// </summary>
        /// <param name="context"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        private T? GetService<T>(AuthorizationFilterContext context) where T: class
        {
            return context.HttpContext.RequestServices.GetRequiredService(typeof(T)) as T;
        }


    }
}
