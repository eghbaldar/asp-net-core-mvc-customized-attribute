using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CookieAccessAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        HttpContext httpContext = context.HttpContext;

        if (CheckAccessLogic(httpContext))
        {
            RefreshCookie(httpContext); // Refresh the cookie if valid
        }
        else
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }

    private bool CheckAccessLogic(HttpContext httpContext)
    {
        var cookies = httpContext.Request.Cookies;
        return cookies.TryGetValue("HasAccess", out string? value) && value?.ToLower() == "true";
    }

    private void RefreshCookie(HttpContext httpContext)
    {
        httpContext.Response.Cookies.Append("HasAccess", "true", new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddMinutes(1)
        });
    }
}
