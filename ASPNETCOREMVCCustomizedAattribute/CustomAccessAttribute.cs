using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREMVCCustomizedAattribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CustomAccessAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool accessGranted = CheckAccessLogic(context);

            if (!accessGranted)
            {
                // 🔁 Redirect to a fallback route (e.g., /AccessDenied or /Home/Error)
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }

        private bool CheckAccessLogic(AuthorizationFilterContext context)
        {
            // Example logic (replace with yours):
            var query = context.HttpContext.Request.Query;
            return query.ContainsKey("access") && query["access"] == "true";
        }
    }
}
