using jwt_example.Models;
using System.Security.Claims;

namespace jwt_example.Interfaces
{
    public interface ILoginService
    {
        public UserModel? Authenticate(LoginUserModel loginUser);
        public string GenerateToken(UserModel user);
        public UserModel? GetCurrentUser(ClaimsIdentity? identity);
    }
}
