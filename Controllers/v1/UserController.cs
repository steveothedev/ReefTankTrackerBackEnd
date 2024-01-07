using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReefTankTracker.Dto.v1.Requests.User;
using ReefTankTracker.Dto.v1.Responses.User;
using ReefTankTracker.Interfaces.v1;

namespace ReefTankTracker.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IMapper _mapper;

        public UserController(UserManager<IdentityUser> userManager, IMapper mapper, IJwtTokenHelper jwtTokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenHelper = jwtTokenService;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserSignUpResponseDtoV1>> Register(UserSignUpRequestsDtoV1 userRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = userRequest.UserName, Email = userRequest.Email },
                userRequest.Password
            );

            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(_mapper.Map<UserSignUpResponseDtoV1>(userRequest));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(UserSignUpRequestsDtoV1 userRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(userRequest.UserName);

            if(user == null)
            {
                return BadRequest("Bad Credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, userRequest.Password);

            if(!isPasswordValid)
            {
                return BadRequest("Bad Credentials");
            }

            var token = _jwtTokenHelper.CreateJwt(user);

            return Ok(token);
        }
    }
}
