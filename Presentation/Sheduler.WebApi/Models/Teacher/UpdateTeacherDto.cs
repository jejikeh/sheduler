using AutoMapper;
using Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;
using Sheduler.Application.Common.Mapping;

namespace Sheduler.WebApi.Models.Teacher;

public class UpdateTeacherDto : IMapWith<UpdateTeacherCommand>
{
    public string TeacherName { get; set; } = string.Empty;
    public string NewName { get; set; } = string.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTeacherDto, UpdateTeacherCommand>()
            .ForMember(
                command => command.NewName,
                expression => expression.MapFrom(dto => dto.NewName))
            .ForMember(
                command => command.TeacherName,
                expression => expression.MapFrom(dto => dto.TeacherName));
    }
}