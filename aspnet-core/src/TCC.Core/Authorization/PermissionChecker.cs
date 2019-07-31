using Abp.Authorization;
using TCC.Authorization.Roles;
using TCC.Authorization.Users;

namespace TCC.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
