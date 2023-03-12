using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sheduler.Application.Commands.TeacherCommands.CreateTeacher;
using Sheduler.Application.Commands.TeacherCommands.DeleteTeacher;
using Sheduler.Application.Commands.TeacherCommands.UpdateTeacher;
using Sheduler.Application.Queries.TeacherQuery.GetTeacherDetails;
using Sheduler.Application.Queries.TeacherQuery.GetTeacherList;
using Sheduler.WebApi.Infrastructure;
using Sheduler.WebApi.Models;

namespace Sheduler.WebApi.Controllers;

[Route("api/[controller]")]
public class TeacherController : ApiController
{
    private readonly IMapper _mapper;

    public TeacherController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<TeacherListVm>> GetAll()
    {
        var query = new GetTeacherListQuery()
        {
            UserId = UserId
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDetailsVm>> Get(Guid id)
    {
        var query = new GetTeacherDetailsQuery()
        {
            UserId = UserId,
            Id = id
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateTeacherDto createTeacherDto)
    {
        var command = _mapper.Map<CreateTeacherCommand>(createTeacherDto);
        command.UserId = UserId;
        var teacherId = await Mediator.Send(command);
        return Ok(teacherId);
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateTeacherDto updateTeacherDto)
    {
        var command = _mapper.Map<UpdateTeacherCommand>(updateTeacherDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteTeacherCommand()
        {
            Id = id,
            UserId = UserId
        };
        await Mediator.Send(command);
        return NoContent();
    }
}