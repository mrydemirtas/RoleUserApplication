using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Interfaces
{
    public interface IEntityService<TEntity> 
    {
        ValidationResult Insert(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Delete(object id);
        ICollection<TEntity> Select();

    }
}
