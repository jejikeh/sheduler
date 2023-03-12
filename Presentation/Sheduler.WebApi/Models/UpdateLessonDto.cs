using AutoMapper;
using Sheduler.Application.Commands.LessonCommands.CreateLesson;
using Sheduler.Application.Commands.LessonCommands.UpdateLesson;
using Sheduler.Application.Common.Mappings;
using Sheduler.Domain.Models.Types;

namespace Sheduler.WebApi.Models;

public class UpdateLessonDto : IMapWith<UpdateLessonCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string TeacherName { get; set; } = string.Empty;
    public LessonType LessonType { get; set; }
    public DateTime DateTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateLessonDto, UpdateLessonCommand>()
            .ForMember(
                command => command.Id,
                expression => expression.MapFrom(expression => expression.Id))
            .ForMember(
                command => command.Title,
                expression => expression.MapFrom(expression => expression.Title))
            .ForMember(
                command => command.TeacherName,
                expression => expression.MapFrom(expression => expression.TeacherName))
            .ForMember(
                command => command.LessonType,
                expression => expression.MapFrom(expression => expression.LessonType))
            .ForMember(
                command => command.DateTime,
                expression => expression.MapFrom(expression => expression.DateTime));
    }
}
