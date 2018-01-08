using EFRoleUserApplication.Entities;
using EFRoleUserApplication.Interfaces;
using EFRoleUserApplication.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Validation
{
    public class _AppUserValidator : _AbstractValidator<ApplicationUser>,IUserValidator
    {
        private const string Required = "Alan Boş Geçilemez";
        private const string EmailIsValid = "EPosta adresi Geçerli Değil";
        private const string ComplexPassword = "Parola En az 8 karakter olmalıdır ve numeric veya alfanumeric formatta oluşturulmalıdır.";
        private const string UserNameIsNotUnique = "Kullanıcı adı daha önce alınmıştır";

      
        public override bool IsValid(ApplicationUser model)
        {
            IsValidEmail(model.Email);
            IsComplex(model.Password);
            IsRequired(model.UserName);
            IsRequired(model.Email);

            if (Errors.Count>0)
            {
                return false;
            }

            return true;
           
        }

        public void IsValidEmail(string email)
        {
            if(!Regex.IsMatch(email, @"^\S+@\S+$"))
            {
                Errors.Add("EmailIsValid", EmailIsValid);
            }
        }

        public void IsComplex(string password)
        {
            if(!Regex.IsMatch(password, @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$"))
            {
                Errors.Add("ComplexPassword", ComplexPassword);
            }
        }

        public void IsRequired(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                Errors.Add("Required", Required);
            }
        }

       
    }
}
