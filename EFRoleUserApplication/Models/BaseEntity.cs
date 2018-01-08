using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Models
{
    public abstract class BaseEntity<TKey> where TKey:struct
    {
        public virtual TKey Id { get; protected set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }

    }
}
