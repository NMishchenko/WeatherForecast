/*
using AutoMapper;
using WeatherForecast.BLL.Models.SomeModel;
using WeatherForecast.DAL.Entities;

namespace WeatherForecast.BLL.Mapping;

public class SomeModelMappingProfile : Profile
{
    public SomeModelMappingProfile()
    {
        CreateMap<SomeModel, SomeEntity>()
            .ForMember(g => g.CreationDate, cfg => cfg.MapFrom(gcm => DateTime.UtcNow));
    }
}

THIS IS AN EXAMPLE OF THE MAPPING PROFILE

*/