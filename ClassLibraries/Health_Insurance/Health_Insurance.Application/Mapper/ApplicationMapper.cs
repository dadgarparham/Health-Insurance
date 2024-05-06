using AutoMapper;
using Health_Insurance.Application.Mapper.Profiles;

namespace Health_Insurance.Application.Mapper;

public class ApplicationMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            //cfg.AddProfile<FileMappingProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => Lazy.Value;
}