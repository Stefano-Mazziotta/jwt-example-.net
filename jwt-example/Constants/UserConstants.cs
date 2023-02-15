using jwt_example.Models;

namespace jwt_example.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() {username = "lMessi", password = "admin1234", firstname = "Lionel", lastname = "Messi", email = "lmessi@gmail.com", role = "admin"},
            new UserModel() {username = "lScaloni", password = "admin1234", firstname = "Lionel", lastname = "Scaloni", email = "lscaloni@gmail.com", role = "entrenador"}
        };
    }
}
