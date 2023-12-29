using Microsoft.AspNetCore.Mvc;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

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
