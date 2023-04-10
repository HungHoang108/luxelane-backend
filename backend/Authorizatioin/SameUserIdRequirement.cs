using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Luxelane.Authorizatioin
{
    public class SameUserIdRequirement : IAuthorizationRequirement
    {
    }

    public class SameUserIdHandler : AuthorizationHandler<SameUserIdRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        SameUserIdRequirement requirement)
        {
            var userIdClaim = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(string.IsNullOrEmpty(userIdClaim))
            {
                System.Console.WriteLine("user id is null or empty");
            }
            else
            {
                System.Console.WriteLine("user id is : " + userIdClaim);
            }
            var userRole = context.User.FindFirstValue(ClaimTypes.Role);
            var httpContext = context.Resource as HttpContext;
            var id = httpContext?.Request.RouteValues["id"]?.ToString();

            if (userIdClaim == id || userRole == "Admin")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}