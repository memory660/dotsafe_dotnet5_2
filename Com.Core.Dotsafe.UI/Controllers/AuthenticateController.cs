using Com.Core.Dotsafe.UI.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        #region Fields
        private UserManager<IdentityUser> _userManager = null;
        private IConfiguration _configuration = null;
        #endregion

        #region Constructors
        public AuthenticateController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._configuration = configuration;
        }
        #endregion

        #region Public methods
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticateUserDto dtoUser)
        {
            IActionResult result = this.BadRequest();

            var user = new IdentityUser(dtoUser.Login);
            user.Email = dtoUser.Login;
            user.UserName = dtoUser.Name;
            var success = await this._userManager.CreateAsync(user, dtoUser.Password);

            if (success.Succeeded)
            {
                dtoUser.Token = this.GenerateJwtToken(user);
                result = this.Ok(dtoUser);
            }

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserDto dtoUser)
        {
            IActionResult result = this.BadRequest();

            var user = await this._userManager.FindByEmailAsync(dtoUser.Login);
            if (user != null)
            {
                var verif = await this._userManager.CheckPasswordAsync(user, dtoUser.Password);
                if (verif)
                {

                    result = this.Ok(new AuthenticateUserDto()
                    {
                        Login = user.Email,
                        Name = user.UserName,
                        Token = this.GenerateJwtToken(user)
                    });
                }
            }

            return result;
        }
        #endregion

        #region Internal methods
        private string GenerateJwtToken(IdentityUser user)
        {
            // Now its ime to define the jwt token which will be responsible of creating our tokens
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // We get our secret from the appsettings
            var key = Encoding.UTF8.GetBytes(this._configuration["Jwt:Key"]); 

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                // the JTI is used for our refresh token which we will be convering in the next video
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        #endregion
    }
}

/*

{
"login": "user1@test.fr",
"name": "user1",
"Password": "Za22!tRt"
}


{
"login": "user1@test.fr",
"Password": "Za22!tRt"
}

*/