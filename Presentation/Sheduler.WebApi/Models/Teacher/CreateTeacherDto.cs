using AutoMapper;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Application.Common.Mapping;

namespace Sheduler.WebApi.Models.Teacher;

public class CreteTeacherDto : IMapWith<CreateTeacherCommand>
{
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTe, CreateTeacherCommand>()
            
    }
}