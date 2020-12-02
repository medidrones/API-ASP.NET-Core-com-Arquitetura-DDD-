using AutoMapper;
using src.Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace src.Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
