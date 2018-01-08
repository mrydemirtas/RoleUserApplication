using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Models
{
    public abstract class AuditableEntity<TKey>:BaseEntity<TKey> where TKey:struct
    {
        public DateTime CreatedDate { get; set; }
        [Column(TypeName="date")] //saatsiz tarih atma
        public Nullable<DateTime> UpdatedDate { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }
        public Nullable<DateTime> ActivatedDate { get; set; }


    }
}
