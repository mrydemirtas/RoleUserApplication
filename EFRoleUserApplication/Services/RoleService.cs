using EFRoleUserApplication.Entities;
using EFRoleUserApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using EFRoleUserApplication.Data;

namespace EFRoleUserApplication.Services
{
    public class RoleService : IEntityService<ApplicationRole>
    {
        ApplicationRoleRepository repo;

        public RoleService(ApplicationRoleRepository _repo)
        {
            repo = _repo;
        }


        public ValidationResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Insert(ApplicationRole entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<ApplicationRole> Select()
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(ApplicationRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
