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
    public class ApplicationRoleRepository : IEntityRepository<ApplicationRole>,IRoleRepository
    {

        private ProjectContext _context;
        private DbSet<ApplicationRole> _dbSet;

        public ApplicationRoleRepository(ProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<ApplicationRole>();
        }

        public int TotalRolCount
        {
            get
            {
                return _dbSet.Count();
            }
        }

        public void Add(ApplicationRole entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public ICollection<ApplicationUser> GetUserByRoleName(string roleName)
        {
            return _dbSet.FirstOrDefault(x => x.RoleName == roleName).Users;
        }

        public int RoleCount(string roleName)
        {
            return _dbSet.Where(x => x.RoleName == roleName).Count();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public ICollection<ApplicationRole> Select()
        {
            return _dbSet.ToList();
        }

        public void Update(ApplicationRole entity)
        {
            var dbEntity = _dbSet.Find(entity.Id);
            //_context.Entry(dbEntity).State = EntityState.Modified;
            _context.Entry(dbEntity).CurrentValues.SetValues(entity);

        }
    }
}
