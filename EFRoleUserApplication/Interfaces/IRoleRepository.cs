using EFRoleUserApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<ApplicationUser> GetUserByRoleName(string roleName);
        int RoleCount(string roleName);
        int TotalRolCount { get; }
    }
}
