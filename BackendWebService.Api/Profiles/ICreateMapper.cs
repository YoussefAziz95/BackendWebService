using AutoMapper;

namespace Api.Profiles;

public interface ICreateMapper<TSource> : IMapper
{
    void Map(Profile profile)
    {
        profile.CreateMap(typeof(TSource), GetType()).ReverseMap();
    }
}