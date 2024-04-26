using Knilla.Data;
using Knilla.IRepository;
using Knilla.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Knilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public LoginController(IConfiguration configuration, DataContext context)
        {
            _context = context;
            _config = configuration;
        }
        private string GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserMasterModel model)
        {
            IActionResult response = Unauthorized();
            var user = _context.UserMasterTBL.FirstOrDefault(u => u.User_Name == model.User_Name && u.Password==model.Password);
            if (user == null)
            {
                response = Unauthorized();
            }

            var token=GenerateToken();
            if(token!=null)
            {
                user.Token = token;
                _context.SaveChanges();
            }
            
            return Ok(new { Token = token });

        }
        

    }
}
