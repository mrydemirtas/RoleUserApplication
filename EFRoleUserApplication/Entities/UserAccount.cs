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
    public class UserAccount:AuditableEntity<Guid>
    {
        private Guid _id;

        #region Constructor

        public UserAccount(Guid id)
        {
            _id = id;
        }

        #endregion

        #region Scalar

        [Key, ForeignKey("ApplicationUser")]
        public override Guid Id
        {
            get
            {
                return _id;
            }

            protected set
            {
                _id = value;
            }
        }

  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfilePictureURL { get; set; }

        #endregion

        #region Navigation

        public virtual ApplicationUser ApplicationUser { get; set; }

        #endregion

    }
}
