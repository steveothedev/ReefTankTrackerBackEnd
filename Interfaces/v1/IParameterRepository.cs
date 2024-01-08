using ReefTankTracker.Dto.v1.Requests.Parameter;
using ReefTankTracker.Dto.v1.Requests.ReefTank;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Interfaces.v1
{
    public interface IParameterRepository
    {
        Task CreateAsync(ParameterModelV1 parameter);
        Task<IEnumerable<ParameterModelV1>> GetAllByUserIdAsync(String userId);
        Task<ParameterModelV1?> GetByIdAsync(Guid id);
        Task<Boolean> IfExistsAsync(Guid id);
        Task UpdateAsync(ParameterUpdateRequestDtoV1 parameter, DateTime dateTime);
        Task DeleteByIdAsync(Guid id, DateTime currentDateTime);
    }
}
