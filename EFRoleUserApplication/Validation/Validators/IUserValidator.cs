﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Validation.Validators
{
    public interface IUserValidator:IEmailValidator,IComplexPasswordValidator,IRequiredValidator
    {
    }
}
