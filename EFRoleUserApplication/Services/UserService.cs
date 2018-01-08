using EFRoleUserApplication.Data;
using EFRoleUserApplication.Entities;
using EFRoleUserApplication.Interfaces;
using EFRoleUserApplication.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using EFRoleUserApplication.Validation.FluentValidator;

namespace EFRoleUserApplication.Services
{
    public class UserService : IEntityService<ApplicationUser>
    {
        ApplicationUserRepository repo;

        public UserService(ApplicationUserRepository _repo)
        {
            repo = _repo;
        }

        public ValidationResult Delete(object id)
        {
            AppUserValidator validator = new AppUserValidator();            
            var entity = repo.FindById(id);            
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                repo.Delete(id);
                repo.Save();
            }
            return result;

        }

        public ValidationResult Insert(ApplicationUser entity)
        {
            AppUserValidator validator = new AppUserValidator();
            ValidationResult result = validator.Validate(entity);

            if (result.IsValid)
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.CreatedDate = DateTime.Now;
                repo.Add(entity);
                repo.Save();
            }

            return result;
        }

        public ICollection<ApplicationUser> Select()
        {
            return repo.Select();
        }

        public ValidationResult Update(ApplicationUser entity)
        {
            AppUserValidator validator = new AppUserValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.CreatedDate = DateTime.Now;
                repo.Update(entity);
                repo.Save();
            }

            return result;
        }



        #region MyRegion

        //public Dictionary<string, string> Insert(ApplicationUser entity)
        //{

        //    _AppUserValidator validator = new _AppUserValidator();
        //    bool IsValid = validator.IsValid(entity);

        //    if (IsValid)
        //    {
        //        repo.Add(entity);
        //        return null;
        //    }

        //    return validator.Errors;

        //}

        #endregion

    }
}
