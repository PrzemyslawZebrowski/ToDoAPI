using Microsoft.AspNetCore.Authorization;

namespace ToDoAPI.Authorization;

public class SameAuthorRequirement : IAuthorizationRequirement
{
}