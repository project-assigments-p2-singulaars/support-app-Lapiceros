using AutoMapper;
using support_app.Projects;

namespace support_app.Utils;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<CreateProjectDto, Project>();

    }
    
}