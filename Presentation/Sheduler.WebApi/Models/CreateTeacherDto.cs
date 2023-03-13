using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Application.Common.Mappings;

namespace Sheduler.WebApi.Models;

public class CreateTeacherDto : IMapWith<CreateTeacherCommand>
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTeacherDto, CreateTeacherCommand>()
            .ForMember(
                command => command.Name, 
                expression => expression.MapFrom(expression => expression.Name));
    }
}