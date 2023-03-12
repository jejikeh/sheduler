using AutoMapper;
using Sheduler.Application.Common.Mappings;
using Sheduler.Domain.Models;
using Sheduler.Domain.Models.Types;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonDetails;

public class LessonDetailsVm : IMapWith<Lesson>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string TeacherName { get; set; } = string.Empty;
    public LessonType LessonType { get; set; }
    public DateTime DateTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Lesson, LessonDetailsVm>()
            .ForMember(lessonVm => lessonVm.Id , member => member.MapFrom(lesson => lesson.Id))
            .ForMember(lessonVm => lessonVm.Title, member => member.MapFrom(lesson => lesson.Title))
            .ForMember(lessonVm => lessonVm.TeacherName, member => member.MapFrom(lesson => lesson.Teacher.Name))
            .ForMember(lessonVm => lessonVm.LessonType, member => member.MapFrom(lesson => lesson.LessonType))
            .ForMember(lessonVm => lessonVm.DateTime, member => member.MapFrom(lesson => lesson.DateTime));

    }
}