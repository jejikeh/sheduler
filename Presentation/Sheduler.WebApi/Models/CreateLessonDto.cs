using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Sheduler.Application.Commands.LessonCommands.CreateLesson;
using Sheduler.Application.Common.Mappings;
using Sheduler.Domain.Models.Types;

namespace Sheduler.WebApi.Models;

public class CreateLessonDto : IMapWith<CreateLessonCommand>
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string TeacherName { get; set; } = string.Empty;
    public LessonType LessonType { get; set; }
    [Required]
    public DateTime DateTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateLessonDto, CreateLessonCommand>()
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
