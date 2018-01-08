using EFRoleUserApplication.Context;
using EFRoleUserApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRoleUserApplication.Services
{
    public class ServicePoint : IServicePoint
    {
        private ProjectContext context;
        private static object lockObject = new object();
        private static ServicePoint service = new ServicePoint();
        private UserService _userService;
        private RoleService _roleService;

        //null ise instance null değilse servis üzerinden işlem.
        public UserService userService {
            get {
                return _userService ?? new UserService(new Data.ApplicationUserRepository(context));
            }
        }

        public RoleService roleService
        {
            get
            {
                return _roleService ?? new RoleService(new Data.ApplicationRoleRepository(context));
            }
        }

        private ServicePoint()
        {
            context = new ProjectContext();
        }

        public static ServicePoint GetInstance()
        {
            if (service==null)
            {
                lock (lockObject)
                {
                    return new ServicePoint();
                }
            }

            return service;
        }

        public void Dispose(bool disposing)
        {
            if (disposing==true)
            {
                this.Dispose();
            }
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
            service = null;
        }
    }
}
