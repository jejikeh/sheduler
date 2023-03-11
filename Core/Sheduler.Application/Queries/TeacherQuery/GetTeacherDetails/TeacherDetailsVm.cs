using AutoMapper;
using Sheduler.Application.Common.Mappings;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherDetails;

public class TeacherDetailsVm : IMapWith<Teacher>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Teacher, TeacherDetailsVm>()
            .ForMember(teacherVm => teacherVm.Id, member => member.MapFrom(teacher => teacher.Id))
            .ForMember(teacherVm => teacherVm.Name, member => member.MapFrom(teacher => teacher.Name));
    }
}