using AutoMapper;

namespace Health_Insurance.Application.Mapper.Profiles
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            //CreateMap<FileUploadParameters, FileCreateModel>()
            //  .ForMember(dest => dest.ContentType, opt => opt.MapFrom(source => source.File.ContentType))
            //  .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.File.FileName))
            //  .ForMember(dest => dest.FileData, opt => opt.MapFrom(source => GetData(source.File)));
        }
    }
}
