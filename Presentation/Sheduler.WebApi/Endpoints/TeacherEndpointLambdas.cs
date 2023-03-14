namespace Sheduler.WebApi.Endpoints;

public class TeacherEndpointLambdas
{
    public async Task<IResult> GetTeacherByName(IMediator mediator, int userId, string name)
    {
        var teacherQuery = new GetTeacherByIdQuery()
        {
            Name = name,
            UserId = userId
        };

        var teacher = await mediator.Send(teacherQuery);
        return TypedResults.Ok(teacher);
    }
    
    public async Task<IResult> GetAllTeachers(IMediator mediator, int userId)
    {
        var command = new GetAllTeachersQuery()
        {
            UserId = userId
        };

        var teachers = await mediator.Send(command);
        return TypedResults.Ok(teachers);
    }
    
    public async Task<IResult> CreateTeacher(IMediator mediator, IMapper mapper, int userId, [FromBody] CreateTeacherDto createTeacherDto)
    {
        var command = mapper.Map<CreateTeacherCommand>(createTeacherDto);
        command.UserId = userId;
        var teacher = await mediator.Send(command);
        return Results.CreatedAtRoute(
            "GetTeacherById",
            new { userId, teacher.Name },
            teacher);
    }
    
    public async Task<IResult> UpdateTeacher(IMediator mediator, IMapper mapper, int userId, [FromBody] UpdateTeacherDto updateTeacherDto)
    {
        var command = mapper.Map<UpdateTeacherCommand>(updateTeacherDto);
        command.UserId = userId;
        var teacher = await mediator.Send(command);
        return TypedResults.Ok(teacher);
    }
    
    public async Task<IResult> DeleteTeacher(IMediator mediator, int userId, string name)
    {
        var command = new DeleteTeacherCommand()
        {
            Name = name,
            UserId = userId
        };

        await mediator.Send(command);
        return TypedResults.NoContent();
    }
}