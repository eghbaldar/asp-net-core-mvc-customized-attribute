using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETCOREMVCCustomizedAattribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]

    public class CookieAccessAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool accessGranted = CheckAccessLogic(context);

            if (!accessGranted)
            {
                // Redirect to AccessDenied page
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
        private bool CheckAccessLogic(AuthorizationFilterContext context)
        {
            var cookies = context.HttpContext.Request.Cookies;

            // 🔍 Example: check for cookie named "HasAccess" with value "true"
            return cookies.TryGetValue("HasAccess", out string? value) && value?.ToLower() == "true";
        }
    }
}
