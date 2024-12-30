using Application.DTOs;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserRoleService:IUserRoleService
    {
        private readonly IUserRoleInfra _userRoleService;
        public UserRoleService(IUserRoleInfra userRoleService) {
            _userRoleService = userRoleService;


        }
        public int AddUserRole(UserRoleDto userRoleDto)
        {
            UserRoles userRoles = new UserRoles();
            userRoles.UserId = userRoleDto.UserId;
            userRoles.RoleId = userRoleDto.RoleId;

            _userRoleService.AddUserRoles(userRoles);
            return 1;
        }
    }

    public interface IUserRoleService
    {
        public int AddUserRole(UserRoleDto userRole);
    }
}
