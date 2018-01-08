using EFRoleUserApplication.Context;
using EFRoleUserApplication.Entities;
using EFRoleUserApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Data
{
    public class ApplicationUserRepository : IEntityRepository<ApplicationUser>,IUserRepository
    {
        private ProjectContext _context;
        private DbSet<ApplicationUser> _dbSet;

        public ApplicationUserRepository(ProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<ApplicationUser>();
        }

        public void Add(ApplicationUser entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            
        }

        public ApplicationUser FindByName(string username)
        {
            return _dbSet.FirstOrDefault(x => x.UserName == username);
        }

        public ApplicationUser FindById(object ID)
        {
            return _dbSet.FirstOrDefault(x => x.Id.Equals(ID));
        }

        public UserAccount FindUserProfile(Guid userId)
        {
            return _dbSet.FirstOrDefault(x => x.Id == userId).UserAccount;
        }

        public ICollection<ApplicationRole> GetRoles(Guid userId)
        {
            return _dbSet.FirstOrDefault(x => x.Id == userId).Roles;
        }

        public bool HasRole(string roleName)
        {
            return _dbSet.Any(x => x.Roles.Where(a => a.RoleName == roleName) == null ? false : true);
        }


        public int Save()
        {
            return _context.SaveChanges();
        }

        public ICollection<ApplicationUser> Select()
        {
            return _dbSet.ToList();
        }

        public void Update(ApplicationUser entity)
        {
            var dbEntity = _dbSet.Find(entity.Id);
            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
           
        }
    }
}
