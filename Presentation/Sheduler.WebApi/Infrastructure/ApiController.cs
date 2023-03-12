using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sheduler.WebApi.Infrastructure;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
    private IMediator? _mediator;
    
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    internal Guid UserId => !User.Identity.IsAuthenticated
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    
    
}