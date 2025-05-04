using CleanStudentManagementModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CleanStudentManagementUI.Filter
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly int _role;

        public RoleAuthorizeAttribute(int role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionobj = context.HttpContext.Session.GetString("logindetails");
            if (string.IsNullOrEmpty(sessionobj))
            {
                context.Result = new RedirectToActionResult("Login","Account",null);
                return;
            }
            var loginInfo=JsonConvert.DeserializeObject<LoginViewModel>(sessionobj);
            if (loginInfo.Role!=_role)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
