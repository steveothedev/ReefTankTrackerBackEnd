using ReefTankTracker.Dto.v1.Requests.ReefTank;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Interfaces.v1
{
    public interface IReefTankRepository
    {
        Task CreateAsync(ReefTankModelV1 reefTank);
        Task<IEnumerable<ReefTankModelV1>> GetAllByUserIdAsync(String userId);
        Task<ReefTankModelV1?> GetByIdAsync(Guid id);
        Task<Boolean> IfExistsAsync(Guid id);
        Task UpdateAsync(ReefTankUpdateRequest reefTank, DateTime dateTime);
        Task DeleteByIdAsync(Guid id, DateTime currentDateTime);
    }
}
