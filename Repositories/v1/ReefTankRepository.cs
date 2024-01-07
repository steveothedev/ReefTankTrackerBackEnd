using Microsoft.EntityFrameworkCore;
using ReefTankTracker.Data;
using ReefTankTracker.Dto.v1.Requests.ReefTank;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;
using System;
using System.Linq;

namespace ReefTankTracker.Repositories.v1
{
    public class ReefTankRepository : IReefTankRepository
    {
        private readonly DataContext _context;

        public ReefTankRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ReefTankModelV1 reefTank)
        {
            await _context.ReefTanks.AddAsync(reefTank);
            await _context.SaveChangesAsync();
        } 

        public async Task<Boolean> IfExistsAsync(Guid id)
        {
            return await _context.ReefTanks.AnyAsync(reefTank => reefTank.Id == id && reefTank.IsDeleted == false);
        }

        public async Task DeleteByIdAsync(Guid id, DateTime currentDateTime)
        {
           var result = await _context.ReefTanks.SingleOrDefaultAsync(reefTank => reefTank.Id == id);
            if(result != null)
            {
                result.IsDeleted = true;
                result.DeletedDateTime = currentDateTime;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ReefTankModelV1>> GetAllByUserIdAsync(String userId)
        {
            return await _context.ReefTanks.Where(reefTank => reefTank.UserId == userId && reefTank.IsDeleted == false).ToListAsync();
        }

        public async Task<ReefTankModelV1?> GetByIdAsync(Guid id)
        {
            return await _context.ReefTanks.FirstOrDefaultAsync(reefTank => reefTank.Id == id);
        }

        public async Task UpdateAsync(ReefTankUpdateRequest reefTank, DateTime dateTime)
        {
            var result = await _context.ReefTanks.FirstOrDefaultAsync(reefTank => reefTank.Id == reefTank.Id);
            if (result != null)
            {
                result.Name = reefTank.Name;
                result.Description = reefTank.Description;
                result.UpdatedDateTime = dateTime;
                await _context.SaveChangesAsync();
            }
        }
    }
}
