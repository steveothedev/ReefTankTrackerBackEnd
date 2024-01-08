using Microsoft.EntityFrameworkCore;
using ReefTankTracker.Data;
using ReefTankTracker.Dto.v1.Requests.Parameter;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Repositories.v1
{
    public class ParameterRepository : IParameterRepository
    {

        private readonly DataContext _context;

        public ParameterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ParameterModelV1 parameter)
        {
            await _context.Parameters.AddAsync(parameter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id, DateTime currentDateTime)
        {
            var result = await _context.Parameters.SingleOrDefaultAsync(parameter => parameter.Id == id);
            if (result != null)
            {
                result.IsDeleted = true;
                result.DeletedDateTime = currentDateTime;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ParameterModelV1>> GetAllByUserIdAsync(string userId)
        {
            return await _context.Parameters.Where(parameter => parameter.UserId == userId && parameter.IsDeleted == false).ToListAsync();
        }

        public async Task<ParameterModelV1?> GetByIdAsync(Guid id)
        {
            return await _context.Parameters.FirstOrDefaultAsync(parameter => parameter.Id == id);
        }

        public async Task<bool> IfExistsAsync(Guid id)
        {
            return await _context.Parameters.AnyAsync(parameter => parameter.Id == id && parameter.IsDeleted == false);
        }

        public async Task UpdateAsync(ParameterUpdateRequestDtoV1 parameter, DateTime dateTime)
        {
            var result = await _context.Parameters.FirstOrDefaultAsync(parameter => parameter.Id == parameter.Id);
            if (result != null)
            {
                result.Name = parameter.Name;
                result.Description = parameter.Description;
                result.Default = parameter.Default;
                result.UpdatedDateTime = dateTime;
                await _context.SaveChangesAsync();
            }
        }
    }
}
