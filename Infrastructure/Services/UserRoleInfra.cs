using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserRoleInfra : IUserRoleInfra
    {
        private readonly AppDbContext _appDbContext;
        public UserRoleInfra(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int AddUserRoles(UserRoles userRoles)
        {
            _appDbContext.UserRoles.Add(userRoles);
            _appDbContext.SaveChanges();
            return 1;
        }
    }
}
