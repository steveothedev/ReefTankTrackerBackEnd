using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Interfaces.v1
{
    public interface IReefTankRepository
    {
        Task<ReefTankModelV1> Create(ReefTankModelV1 reefTank);
        Task<IEnumerable<ReefTankModelV1>> GetAllByUserId(Guid userId);
        Task<ReefTankModelV1> GetById(Guid id);
        Task<ReefTankModelV1> UpdateAsync(ReefTankModelV1 reefTank);
        Task<Guid> DeleteById(Guid id);
    }
}
