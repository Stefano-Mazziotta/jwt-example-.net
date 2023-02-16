using jwt_example.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var listCountry = CountryConstants.Countries;
            return Ok(listCountry);
        }
    }
}
