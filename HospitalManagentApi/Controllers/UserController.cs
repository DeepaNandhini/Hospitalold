using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _roleService;
        private readonly IHttpcallServices _httpcallServices;
        public UserController(IUserService userService, IUserRoleService roleService, IHttpcallServices httpcallServices)
        {
            _userService = userService;
            _roleService = roleService;
            _httpcallServices = httpcallServices;
        }

        [Authorize]
        [HttpPost]
        public IActionResult RegisterUser(UserDto userDto)
        {
            _userService.AddUser(userDto);
            return Ok("Inserted succesfully");
        }
        [Authorize]
        [HttpPost("map")]
        
        public IActionResult MapUserRoles(UserRoleDto userRoleDto)
        {
            _roleService.AddUserRole(userRoleDto);
            return Ok("Inserted succesfully");
        }

        [HttpGet("GetDoctors")]
        public async Task<IActionResult> GetDoctorsAsync()
        {
            return Ok(await _httpcallServices.GetDoctors().ConfigureAwait(false));

        }

    }
}
