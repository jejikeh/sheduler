using AutoMapper;
using Sheduler.Application.Common.Mappings;
using Sheduler.Domain.Models;
using Sheduler.Domain.Models.Types;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonList;

public class LessonLookupDto : IMapWith<Lesson>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public LessonType LessonType { get; set; }
    public DateTime DateTime { get; set; }

    public void Mapping(Profile profile)
    {
        var map = profile.CreateMap<Lesson, LessonLookupDto>();
        map.ForMember(lessonVm => lessonVm.Title, member => member.MapFrom(lesson => lesson.Title));
        map.ForMember(lessonVm => lessonVm.LessonType, member => member.MapFrom(lesson => lesson.LessonType));
        map.ForMember(lessonVm => lessonVm.DateTime, member => member.MapFrom(lesson => lesson.DateTime));
    }
}