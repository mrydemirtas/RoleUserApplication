using EFRoleUserApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Interfaces
{
    public interface IUserRepository
    {
        bool HasRole(string roleName);
        void AddRole(string roleName);
        ICollection<ApplicationRole> GetRoles(Guid userId);
        ApplicationUser FindByName(string username);
        UserAccount FindUserProfile(Guid userId);
    }
}
