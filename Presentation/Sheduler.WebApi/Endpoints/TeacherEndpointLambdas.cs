namespace Sheduler.WebApi.Endpoints;

public class TeacherEndpointDefinitions
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
}