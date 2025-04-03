using AutoMapper;

namespace BackendWebService.Api.Profiles;

public interface ICreateMapper<TSource> : IMapper
{
    void Map(Profile profile)
    {
        profile.CreateMap(typeof(TSource), GetType()).ReverseMap();
    }
}