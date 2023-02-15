using jwt_example.Models;

namespace jwt_example.Constants
{
    public class EmployeeConstants
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel() {firstname = "Filippo", lastname = "Brunelleschi", email = "brunelleschi@gmail.com"},
            new EmployeeModel() {firstname = "Leonardo", lastname = "Da Vinci", email = "leodavinci@gmail.com"}
        };
    }
}
