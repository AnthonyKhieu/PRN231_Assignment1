using BusinessObject;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly AppDBContext context;
        private readonly IConfiguration _configuration;
        public UserController(AppDBContext myDbContext, IConfiguration configuration)
        {
            this.context = myDbContext;
            this._configuration = configuration;
            
        }
        [HttpPost("login")]
        public IActionResult Validate(UserDTO userRespond)
        {
            var user = context.Users.SingleOrDefault(p => p.UserName == userRespond.UserName && p.Password == userRespond.Password);
            if(user == null)
            {
                return Ok(new BaseDTO<object>
                {
                    Success = false,
                    Message = "Invalid username or password"
                });
            }
            return Ok(new BaseDTO<object>
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            }) ;
        }
        
        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretkey = _configuration.GetValue<string>("AppSettings:SecretKey");
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretkey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []{
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim("UserName",user.UserName),
                    new Claim("Id",user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.UserName),
                    new Claim("TokenId",Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                                          SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }

    }
}
