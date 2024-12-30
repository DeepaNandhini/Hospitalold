using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace HospitalManagentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly JwtSettings _jwtOptions;
        private static Dictionary<string, string> _refreshTokens = new Dictionary<string, string>();
        public AuthController(IOptions<JwtSettings> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        [HttpPost]
        public IActionResult Login()
        {


            //get userdetails --name, roles from db and pass to the method
            var token = GenerateAccessToken();
            var accessToken=new JwtSecurityTokenHandler().WriteToken(token);

            // Generate refresh token, store refresh token in DB
            var refreshToken = Guid.NewGuid().ToString();

            // Store the refresh token (in-memory for simplicity)
            _refreshTokens[refreshToken] = "Deepa";

            return Ok(new {AccessToken=accessToken, RefreshToken = refreshToken });
        }



        private JwtSecurityToken GenerateAccessToken()
        {
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name, "Deepa"),
              new Claim(ClaimTypes.Role, "Admin") // Correctly create a Role claim
    // Add additional claims as needed (e.g., roles, etc.)
            };
            // Create a JWT
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1), // Token expiration time
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                    SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
       
        [Authorize]
        [HttpGet]
        public IActionResult CheckAuth()
        {
            return Ok("Authenticated");
        }

        [HttpPost("refresh")]
        public IActionResult Refresh(RefreshRequest request)
        {
            if (_refreshTokens.TryGetValue(request.RefreshToken, out var userId))
            {
                // Generate a new access token
                var token = GenerateAccessToken();

                // Return the new access token to the client
                return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Invalid refresh token");
        }

        public class RefreshRequest
        {
            public string RefreshToken { get; set; }
        }

    }
}

