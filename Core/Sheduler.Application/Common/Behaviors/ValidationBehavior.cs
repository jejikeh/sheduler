using FluentValidation;
using MediatR;

namespace Sheduler.Application.Common.Behaviors;

public class ValidationBehavior<TReq, TRes> : IPipelineBehavior<TReq, TRes> where TReq : IRequest<TRes>
{
    private readonly IEnumerable<IValidator<TReq>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TReq>> validators)
    {
        _validators = validators;
    }

    public Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TReq>(request);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return next();
    }
}