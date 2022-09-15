using Microsoft.AspNetCore.Authorization;

namespace IdentityAndAccess.API.PolicyRequirements
{
    public class WorkingHoursHandler : AuthorizationHandler<WorkingHoursRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WorkingHoursRequirement requirement)
        {
            var currentHour = TimeOnly.FromDateTime(DateTime.Now);
            if (currentHour.Hour >= 8 && currentHour.Hour <= 18)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}