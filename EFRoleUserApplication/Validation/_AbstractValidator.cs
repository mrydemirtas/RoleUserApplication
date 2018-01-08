using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Validation
{
    public abstract class _AbstractValidator<T> where T:class
    {

        public _AbstractValidator()
        {
            Errors = new Dictionary<string, string>();
        }

        public Dictionary<string,string> Errors { get; set; }
        public abstract bool IsValid(T model);

    }
}
