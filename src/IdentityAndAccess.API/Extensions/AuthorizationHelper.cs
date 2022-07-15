using Microsoft.AspNetCore.Authorization;

namespace IdentityAndAccess.API.Extensions
{
    public class NecessaryPermission : IAuthorizationRequirement
    {
        public string Permission { get; }

        public NecessaryPermission(string permission)
        {
            Permission = permission;
        }
    }

    public class NecessaryPermissionHandler : AuthorizationHandler<NecessaryPermission>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NecessaryPermission requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains(requirement.Permission)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}