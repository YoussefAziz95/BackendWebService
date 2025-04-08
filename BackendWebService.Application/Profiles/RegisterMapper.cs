using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Application.Profiles;

public class RegisterMapper : Profile
{
    public RegisterMapper()
    {
        ApplyMappingProfiles(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingProfiles(Assembly assembly)
    {
        var interfaceType = typeof(ICreateMapper<>);

        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType))
            .ToList();

        foreach (var type in types)
        {
            var implementedInterface = type.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);

            var entityType = implementedInterface.GetGenericArguments()[0];
            CreateMap(type, entityType);
            CreateMap(entityType, type);
        }
    }
}