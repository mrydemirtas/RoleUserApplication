using EFRoleUserApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Entities
{
    [Table("RoleTablosu")]
    public class ApplicationRole:BaseEntity<int>
    {
        #region Constructor

        public ApplicationRole()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public ApplicationRole(string roleName) : this()
        {
            this.RoleName = roleName;
        }

        [NotMapped] //sql tarafında göstermez
        public override bool IsDeleted
        {
            get
            {
                return base.IsDeleted;
            }

            set
            {
                base.IsDeleted = value;
            }
        }

        #endregion

        #region Scalar

        [Required]//NotNull
        [Column("Role Adi")] //Database de sütun ismi 
        public string RoleName { get; set; }
        [StringLength(500)] //nvarchar(500)
        [Column("Role Açıklaması")] 
        public string Description { get; set; }
        #endregion

        #region Navigation
        public virtual ICollection<ApplicationUser> Users { get; set; }
        #endregion
    }
}
