using EFRoleUserApplication.Context;
using EFRoleUserApplication.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Validation.FluentValidator
{
    public class AppUserValidator:AbstractValidator<ApplicationUser>
    {
        public AppUserValidator()
        {

            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("Username alanı Boş geçilemez");
            //RuleFor(x => x.UserName).Must(IsUnique).WithMessage("Böyle bir kullanıcı mevcuttur");
            RuleFor(x => x.Password).Must(IsComplex).WithMessage("Parola en az 8 karakter uzunluğunda ve karmaşık olmalıdır");

        }

        public bool IsUnique(string username)
        {
            using (ProjectContext context = new ProjectContext())
            {
                return context.AppUsers.FirstOrDefault(x => x.UserName == username) == null ? true : false ;
            }
        }

        public bool IsComplex(string password)
        {
            return Regex.IsMatch(password, @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$");
        }
    }
}
