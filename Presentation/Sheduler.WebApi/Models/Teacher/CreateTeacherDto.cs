using AutoMapper;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Application.Common.Mapping;

namespace Sheduler.WebApi.Models.Teacher;

public class CreateTeacherDto : IMapWith<CreateTeacherCommand>
{
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTeacherDto, CreateTeacherCommand>()
            .ForMember(
                command => command.Name,
                expression => expression.MapFrom(dto => dto.Name));
    }
}