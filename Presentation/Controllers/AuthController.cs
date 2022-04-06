
using BusinessLayer.Interfaces;
using CommonLayer.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Consult360.AppUtility;

namespace Consult360.Controllers
{
    //For this [Authorize] don't include
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected User _user = new User();
        private readonly IAuth _iAuth;
        private readonly AppSettings _appSettings;

        public AuthController(IOptions<AppSettings> appSettings, IAuth iAuth)
        {
            _appSettings = appSettings.Value;
            _iAuth = iAuth;
        }


        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> GenerateToken([FromBody] TokenModel objToken)
        {
            try
            {
                //string token1 = HttpContext.Request.Headers["id_token"];
               bool validUser = await _iAuth.ValidateOTP(objToken.PhoneNumber, objToken.OTP);
                if (!validUser)
                {
                    //Unauthorized or Token not passed in header
                    return Unauthorized();
                }
                else
                {
                    _user = await _iAuth.GetPortalUserDetails(objToken.PhoneNumber);
                    string token = generateJwtToken(_user);
                    return Ok(new { token, access = _user });
                }
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                { new Claim("FirstName", user.PortalUser_FirstName),
                new Claim("LastName", user.PortalUser_LastName),
                
                new Claim("PracticeName", user.Practice_Name),
                new Claim("PracticeID", user.Practice_Id),
                new Claim("RoleName", user.PortalUserRole_Name),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [HttpGet]
        [Route("validatePhoneNumber/{PhoneNumber}")]
        public async Task<IActionResult> ValidatePhoneNumber(string PhoneNumber)
        {
            bool result=await Task.Run(()=> _iAuth.ValidatePhoneNumber(PhoneNumber));
            return Ok(new { result });
        }       
    }
}
