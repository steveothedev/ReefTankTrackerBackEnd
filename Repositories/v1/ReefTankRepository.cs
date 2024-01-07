using ReefTankTracker.Data;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Repositories.v1
{
    public class ReefTankRepository : IReefTankRepository
    {
        private readonly DataContext _context;

        public ReefTankRepository(DataContext context)
        {
            _context = context;
        }

        public Task<ReefTankModelV1> Create(ReefTankModelV1 reefTank)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReefTankModelV1>> GetAllByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReefTankModelV1> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ReefTankModelV1> UpdateAsync(ReefTankModelV1 reefTank)
        {
            throw new NotImplementedException();
        }
    }
}
