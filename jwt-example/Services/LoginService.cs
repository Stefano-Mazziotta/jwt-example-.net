using jwt_example.Constants;
using jwt_example.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt_example.Services
{
    public class LoginService
    {
        private readonly IConfiguration _configuration;

        public LoginService(IConfiguration config)
        {
            _configuration = config;
        }

        public UserModel? authenticate(LoginUserModel loginUser)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(user => user.username.ToLower() == loginUser.username.ToLower()
                && user.password == loginUser.password);

            if (currentUser == null)
            {
                return null;
            }

            return currentUser;
        }

        public string generateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // create claims for token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.username),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.GivenName, user.firstname),
                new Claim(ClaimTypes.Surname, user.lastname),
                new Claim(ClaimTypes.Role, user.role),
            };

            // create token
            var token = new JwtSecurityToken(
                        _configuration["jwt"],
                        _configuration["jwt:audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(15),
                        signingCredentials: credentials
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel? getCurrentUser(ClaimsIdentity? identity) 
        { 
        
            if (identity == null)
            {
                return null;
            }

            var userClaims = identity.Claims;

            return new UserModel
            {
                username = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value,
                email = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value,
                firstname = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.GivenName)?.Value,
                lastname = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Surname)?.Value,
                role = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value
            };
        }


    }
}
