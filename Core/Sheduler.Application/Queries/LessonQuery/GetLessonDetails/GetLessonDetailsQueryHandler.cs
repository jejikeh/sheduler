using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonDetails;

public class GetLessonDetailsQueryHandler : IRequestHandler<GetLessonDetailsQuery, LessonDetailsVm>
{
    private ILessonsDbContext _lessonsDbContext;
    private IMapper _mapper;

    public GetLessonDetailsQueryHandler(ILessonsDbContext lessonsDbContext, IMapper mapper)
    {
        _lessonsDbContext = lessonsDbContext;
        _mapper = mapper;
    }
    
    public async Task<LessonDetailsVm> Handle(GetLessonDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _lessonsDbContext.Set()
            .FirstOrDefaultAsync(lesson => lesson.Id == request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId )
            throw new NotFoundException(nameof(Lesson), request.Id);

        return _mapper.Map<LessonDetailsVm>(entity);
    }
}