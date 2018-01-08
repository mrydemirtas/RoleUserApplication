
using EFRoleUserApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext():base("name=MyConn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectContext>());
        }

        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<ApplicationRole> AppRoles { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

    }
}
