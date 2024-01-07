using AutoMapper;
using ReefTankTracker.Dto.v1.Requests.User;
using ReefTankTracker.Dto.v1.Responses.ReefTank;
using ReefTankTracker.Dto.v1.Responses.User;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserSignUpRequestsDtoV1, UserSignUpResponseDtoV1>();
            CreateMap<ReefTankModelV1, ReefTankResponseDtoV1>();
        }
    }
}
