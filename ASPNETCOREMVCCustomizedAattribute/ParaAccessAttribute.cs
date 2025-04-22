using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static ASPNETCOREMVCCustomizedAattribute.ParaAccessAttributeEnum;
namespace ASPNETCOREMVCCustomizedAattribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]

    public class ParaAccessAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserRole _keyName;

        public ParaAccessAttribute(UserRole keyName)
        {
            _keyName = keyName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_keyName != UserRole.Admin)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
