using Application.DTOs;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserInfraService _userInfraService;
        public UserService(IUserInfraService userInfraService)
        {
            _userInfraService = userInfraService;
        }
        public int AddUser(UserDto userDetails)
        {
            User user = new User();
            user.UserName = userDetails.UserName;
            user.Password = userDetails.Password;
            _userInfraService.AddUser(user);
            return 1;
        }
    }
    public interface IUserService
    {
        public int AddUser(UserDto userDetails);
    }
}
