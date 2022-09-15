using Microsoft.AspNetCore.Authorization;

namespace IdentityAndAccess.API.PolicyRequirements
{
    public class WorkingHoursRequirement : IAuthorizationRequirement
    {
        public WorkingHoursRequirement() { }
    }
}