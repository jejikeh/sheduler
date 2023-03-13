using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sheduler.Application.Commands.LessonCommands.CreateLesson;
using Sheduler.Application.Commands.LessonCommands.DeleteLesson;
using Sheduler.Application.Commands.LessonCommands.UpdateLesson;
using Sheduler.Application.Queries.LessonQuery.GetLessonDetails;
using Sheduler.Application.Queries.LessonQuery.GetLessonList;
using Sheduler.WebApi.Infrastructure;
using Sheduler.WebApi.Models;

namespace Sheduler.WebApi.Controllers;

[ApiVersionNeutral]
[Produces("application/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class LessonController : ApiController
{
    private readonly IMapper _mapper;

    public LessonController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    /// <summary>
    /// Gets the list of lessons
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /lesson
    /// </remarks>>
    /// <returns>Returns LessonListVm</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unathorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LessonListVm>> GetAll()
    {
        var query = new GetLessonListQuery()
        {
            UserId = UserId
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<LessonDetailsVm>> Get(Guid id)
    {
        var query = new GetLessonDetailsQuery()
        {
            UserId = UserId,
            Id = id
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateLessonDto createLessonDto)
    {
        var command = _mapper.Map<CreateLessonCommand>(createLessonDto);
        command.UserId = UserId;
        var teacherId = await Mediator.Send(command);
        return Ok(teacherId);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Update([FromBody] UpdateLessonDto updateTeacherDto)
    {
        var command = _mapper.Map<UpdateLessonCommand>(updateTeacherDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteLessonCommand()
        {
            Id = id,
            UserId = UserId
        };
        await Mediator.Send(command);
        return NoContent();
    }
}