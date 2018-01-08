using EFRoleUserApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DataAnnotations yöntemi


namespace EFRoleUserApplication.Entities
{
    [Table("KullaniciTablosu")]
    public class ApplicationUser : AuditableEntity<Guid>
    {
        #region Constructor

        public ApplicationUser()
        {
            this.Roles = new HashSet<ApplicationRole>();
            Id = Guid.NewGuid();
        }


        #endregion

        #region Scalar

        [Index("IX_Username",IsUnique =true)]
        [Column(TypeName ="varchar")]
        [StringLength(20)]
        public string UserName { get; set; }

        [EmailAddress]
        [Required][Column("EPosta")]
        public string Email { get; set; }

        [MinLength(8)]
        [MaxLength(12)][Column(TypeName ="char")] //nvarchar 12
        public string Password { get; set; }

        #endregion

        #region Navigation

        public virtual ICollection<ApplicationRole> Roles { get; set; }
        public virtual UserAccount UserAccount { get; set; }



        #endregion


    }
}
