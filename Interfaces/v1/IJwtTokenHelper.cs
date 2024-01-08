using Microsoft.AspNetCore.Identity;
using ReefTankTracker.Dto.v1.Responses.User;


namespace ReefTankTracker.Interfaces.v1
{
    public interface IJwtTokenHelper
    {
        LoginResponseDtoV1 CreateJwt(IdentityUser user);
    }
}
