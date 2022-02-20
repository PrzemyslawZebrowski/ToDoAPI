using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ToDoAPI.Entities;

namespace ToDoAPI.Authorization
{
    public class ToDoAuthorizationtHandler : AuthorizationHandler<SameAuthorRequirement, Todo>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameAuthorRequirement requirement, Todo resource)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (resource.CreatedById == userId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
            
        }
    }
}
