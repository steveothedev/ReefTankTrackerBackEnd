using ReefTankTracker.Data;
using ReefTankTracker.Interfaces.v1;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Repositories.v1
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) {
            _context = context;
        }

        public ICollection<UserModelV1> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
