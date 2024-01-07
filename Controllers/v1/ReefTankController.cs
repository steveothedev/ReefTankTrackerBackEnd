using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ReefTankTracker.Dto.v1.Requests.ReefTank;
using ReefTankTracker.Dto.v1.Responses.ReefTank;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;
using ReefTankTracker.Repositories.v1;
using System.Security.Claims;

namespace ReefTankTracker.Controllers.v1
{

    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class ReefTankController : Controller 
    {
        private readonly IReefTankRepository _repository;
        private readonly IMapper _mapper;

        public ReefTankController(IReefTankRepository reefTankRepository, IMapper mapper)
        {
            _repository = reefTankRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ReefTankResponseDtoV1>> Create(ReefTankCreateRequestDtoV1 reefTankCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ReefTankModelV1 reefTank = new ReefTankModelV1
            {
                Id = Guid.NewGuid(),
                UserId = userId!,
                Name = reefTankCreateRequest.Name,
                Description = reefTankCreateRequest.Description,
                CreatedDateTime = DateTime.UtcNow,
                IsDeleted = false,
            };

            await _repository.CreateAsync(reefTank);

            return _mapper.Map<ReefTankResponseDtoV1>(reefTankCreateRequest);

        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReefTankResponseDtoV1>>> Get() {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId == null) { return BadRequest("User Id is missing from token"); }

            var reefTanks = await _repository.GetAllByUserIdAsync(userId);

            return Ok(reefTanks.Select(reefTank => _mapper.Map<ReefTankResponseDtoV1>(reefTank)));

        }

        [HttpGet("ReefTankId")]
        public async Task<ActionResult<ReefTankCreateRequestDtoV1>> Get(Guid reefTankId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = await _repository.IfExistsAsync(reefTankId);

            if (!exists)
            {
                return NotFound("No reef tank with that ID exists");
            }

            var reefTank = await _repository.GetByIdAsync(reefTankId);

            return Ok(_mapper.Map<ReefTankResponseDtoV1>(reefTank));
        }

        [HttpPut]
        public async Task<ActionResult<ReefTankResponseDtoV1>> Put(ReefTankUpdateRequest reefTank)
        {
            if (!ModelState.IsValid) { 
               return BadRequest(ModelState);
            }

            var exists = await _repository.IfExistsAsync(reefTank.Id);

            if (!exists)
            {
                return NotFound("No reef tank with that ID exists");
            }

            var dateTime = DateTime.Now;

            await _repository.UpdateAsync(reefTank, dateTime);

            return Ok(_mapper.Map<ReefTankResponseDtoV1>(reefTank));
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
                return NotFound("No reef tank with that ID exists");
            }

            var dateTime = DateTime.Now;

            await _repository.DeleteByIdAsync(id, dateTime);

            return Ok();
        }
    }
}
