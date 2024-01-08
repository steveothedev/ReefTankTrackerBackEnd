using AutoMapper;
using ReefTankTracker.Dto.v1.Requests.Parameter;
using ReefTankTracker.Dto.v1.Requests.ReefTank;
using ReefTankTracker.Dto.v1.Requests.User;
using ReefTankTracker.Dto.v1.Responses.Parameter;
using ReefTankTracker.Dto.v1.Responses.ReefTank;
using ReefTankTracker.Dto.v1.Responses.User;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Users
            CreateMap<UserSignUpRequestsDtoV1, UserSignUpResponseDtoV1>();
            //Reef Tanks
            CreateMap<ReefTankModelV1, ReefTankResponseDtoV1>();
            CreateMap<ReefTankCreateRequestDtoV1, ReefTankResponseDtoV1>();
            CreateMap<ReefTankUpdateRequestDtoV1, ReefTankResponseDtoV1>();
            //Parameter
            CreateMap<ParameterModelV1, ParameterResponseDtoV1>();
            CreateMap<ParameterCreateRequestDtoV1, ParameterResponseDtoV1>();
            CreateMap<ReefTankUpdateRequestDtoV1, ParameterResponseDtoV1>();
        }
    }
}
