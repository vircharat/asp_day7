using BookTheShowDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using BookTheShowEntity;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace MovieAppCoreApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokennController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MovieDBcontextv _context;

        public TokennController(IConfiguration config, MovieDBcontextv context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("Login")] // if no login then Post is used in url
        public async Task<IActionResult> Post(Userv _userData)
        {

            if (_userData != null && _userData.UservEmail != null && _userData.UserPassword != null)
            {
                var user = await GetUser(_userData.UservEmail, _userData.UserPassword);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UservId", user.UservId.ToString()),
                    new Claim("UservName", user.UservName),
                    new Claim("UservEmail", user.UservEmail),

                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); //it will gwenerate key

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Userv> GetUser(string email, string password)
        {
            Userv userInfo = null;
            var result = _context.userv.Where(u => u.UservEmail == email && u.UserPassword == password);
            foreach (var item in result)
            {
                userInfo = new Userv();
                userInfo.UservId = item.UservId;
                userInfo.UservName = item.UservName;

                userInfo.UservEmail = item.UservEmail;

            }
            return userInfo;

        }
    }
}
