using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

        /// <summary>
        /// Test API that returns a list of users
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<UserV1>))]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }
    }
}
