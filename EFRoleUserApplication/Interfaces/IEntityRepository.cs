using EFRoleUserApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Interfaces
{
    public interface IEntityRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity);
        ICollection<TEntity> Select();
        int Save();
    }
}
