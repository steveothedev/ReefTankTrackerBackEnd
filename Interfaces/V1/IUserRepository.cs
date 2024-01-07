using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Interfaces.v1
{
    public interface IUserRepository
    {
        ICollection<UserModelV1> GetUsers();
    }
}
