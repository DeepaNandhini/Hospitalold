using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserInfraService : IUserInfraService
    {
        private AppDbContext _appDbContext;
        public UserInfraService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int AddUser(User user)
        {
           var saved = _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return 1;
        }
    }
}
