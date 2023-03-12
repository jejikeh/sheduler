using AutoMapper;
using Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;
using Sheduler.Application.Common.Mappings;

namespace Sheduler.WebApi.Models;

public class UpdateTeacherDto : IMapWith<UpdateTeacherCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTeacherDto, UpdateTeacherCommand>()
            .ForMember(
                command => command.Id,
                expression => expression.MapFrom(expression => expression.Id))
            .ForMember(
                command => command.Name,
                expression => expression.MapFrom(expression => expression.Name));
    }
}