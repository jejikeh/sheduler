using Sheduler.WebApi.Endpoints;
using Sheduler.WebApi.Extensions;
using Sheduler.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServiceMiddlewares();

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCustomExceptionHandler();

    var teacherLambdas = new TeacherEndpointLambdas();
    var userTeachers = app.MapGroup("/api/{userId}/teachers");
    
    userTeachers.MapGet("/{name}", teacherLambdas.GetTeacherByName)
        .WithName("GetTeacherById");
    userTeachers.MapGet("/", teacherLambdas.GetAllTeachers);
    userTeachers.MapPost("/", teacherLambdas.CreateTeacher);
    userTeachers.MapPut("/", teacherLambdas.UpdateTeacher);
    userTeachers.MapDelete("/{name}", teacherLambdas.DeleteTeacher);
    
    app.InitializeServiceContextProvider();
    app.UseHttpsRedirection();
}

app.Run();  