using AutoMapper;
using support_app.Persons;
using support_app.Projects;
using support_app.Tasks;

namespace support_app.Utils;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<CreateProjectDto, Project>();
        CreateMap<CreateProjectDto, ProjectDto>();
        CreateMap<Project, CreateProjectDto>();
        
        CreateMap<Worker, WorkerDto>();
        CreateMap<CreateWorkerDto, Worker>();
        CreateMap<CreateWorkerDto, WorkerDto>();
        CreateMap<Worker, CreateWorkerDto>();
        
        CreateMap<Duty, DutyDto>();
        CreateMap<CreateDutyDto, Duty>();
        CreateMap<CreateDutyDto, DutyDto>();
        CreateMap<Duty, CreateDutyDto>();

    }
    
}