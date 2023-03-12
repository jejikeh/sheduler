using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Interfaces;
using Sheduler.Application.Queries.LessonQuery.GetLessonDetails;
using Sheduler.Application.Queries.TeacherQuery.GetTeacherList;

namespace Sheduler.Application.Queries.LessonQuery.GetLessonList;

public class GetLessonListQueryHandler : IRequestHandler<GetLessonListQuery, LessonListVm>
{
    private ILessonsDbContext _lessonsDbContext;
    private IMapper _mapper;

    public GetLessonListQueryHandler(ILessonsDbContext lessonsDbContext, IMapper mapper)
    {
        _lessonsDbContext = lessonsDbContext;
        _mapper = mapper;
    }
    
    public async Task<LessonListVm> Handle(GetLessonListQuery request, CancellationToken cancellationToken)
    {
        var lessons = await _lessonsDbContext.Set()
            .Where(x => x.UserId == request.UserId)
            .ProjectTo<LessonLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new LessonListVm() { Lessons = lessons };
    }
}