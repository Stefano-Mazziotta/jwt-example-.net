using jwt_example.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = ("admin"))]
        public IActionResult GetAll() 
        {
            var listEmployee = EmployeeConstants.Employees;
            return Ok(listEmployee);
        }
    }
}
