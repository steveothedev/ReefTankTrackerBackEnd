using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReefTankTracker.Dto.v1.Requests.Parameter;
using ReefTankTracker.Dto.v1.Responses.Parameter;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;
using System.Security.Claims;

namespace ReefTankTracker.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class ParameterController : Controller
    {
        private readonly IParameterRepository _repository;
        private readonly IMapper _mapper;

        public ParameterController(IParameterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<ParameterResponseDtoV1>> Create(ParameterCreateRequestDtoV1 parameterCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ParameterModelV1 newParameter = new ParameterModelV1
            {
                Id = Guid.NewGuid(),
                UserId = userId!,
                Name = parameterCreateRequest.Name,
                Description = parameterCreateRequest.Description,
                Default = parameterCreateRequest.Default,
                CreatedDateTime = DateTime.UtcNow,
                IsDeleted = false,
            };

            await _repository.CreateAsync(newParameter);

            return _mapper.Map<ParameterResponseDtoV1>(newParameter);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParameterResponseDtoV1>>> Get()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) { return BadRequest("User Id is missing from token"); }

            var parameters = await _repository.GetAllByUserIdAsync(userId);

            return Ok(parameters.Select(parameter => _mapper.Map<ParameterResponseDtoV1>(parameter)));

        }

        [HttpGet("ParameterId")]
        public async Task<ActionResult<ParameterResponseDtoV1>> Get(Guid parameterId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = await _repository.IfExistsAsync(parameterId);

            if (!exists)
            {
                return NotFound("No parameter with that ID exists");
            }

            var parameter = await _repository.GetByIdAsync(parameterId);

            return Ok(_mapper.Map<ParameterResponseDtoV1>(parameter));
        }

        [HttpPut]
        public async Task<ActionResult<ParameterResponseDtoV1>> Put(ParameterUpdateRequestDtoV1 parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = await _repository.IfExistsAsync(parameter.Id);

            if (!exists)
            {
                return NotFound("No parameter with that ID exists");
            }

            var dateTime = DateTime.Now;

            await _repository.UpdateAsync(parameter, dateTime);

            return Ok(_mapper.Map<ParameterResponseDtoV1>(parameter));
        }

        [HttpDelete("Id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = await _repository.IfExistsAsync(id);

            if (!exists)
            {
                return NotFound("No parameter with that ID exists");
            }

            var dateTime = DateTime.Now;

            await _repository.DeleteByIdAsync(id, dateTime);

            return Ok();
        }
    }
}
