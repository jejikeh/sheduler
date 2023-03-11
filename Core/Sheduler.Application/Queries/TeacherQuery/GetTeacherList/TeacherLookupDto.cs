using AutoMapper;
using Sheduler.Application.Common.Mappings;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherList;

public class TeacherLookupDto : IMapWith<Teacher>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Teacher, TeacherLookupDto>()
            .ForMember(teacherVm => teacherVm.Id, member => member.MapFrom(teacher => teacher.Id))
            .ForMember(teacherVm => teacherVm.Name, member => member.MapFrom(teacher => teacher.Name));
    }
}