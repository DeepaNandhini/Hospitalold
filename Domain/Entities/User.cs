using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User 
    {
        public Guid UserId { get; set; }
        public string UserName { get;set; }
        public string Password { get;set; }
        
        public User()
        {
            UserId = Guid.NewGuid();
        }

    }
    public class Role
    {
       
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Role()
        {
            RoleId = Guid.NewGuid();
        }
    }

    public class UserRoles
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public UserRoles()
        {
            Id = Guid.NewGuid();
        }
    }
}
