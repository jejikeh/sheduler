using AutoMapper;
using Sheduler.Application.Queries.LessonQuery.GetLessonList;
using Sheduler.Persistence;
using Sheduler.Tests.Common;
using Sheduler.Tests.Common.LessonRelated;
using Shouldly;

namespace Sheduler.Tests.Lessons.Query;

[Collection("QueryLessonCollection")]
public class GetLessonListQueryHandlerTest
{
    private readonly LessonsDbContext _context;
    private readonly IMapper _mapper;

    public GetLessonListQueryHandlerTest(QueryLessonTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }
    
    [Fact]
    public async Task GetLessonListQueryHandler_Success()
    {
        var handler = new GetLessonListQueryHandler(_context, _mapper);
        var result = await handler.Handle(
            new GetLessonListQuery()
            {
                UserId = DbContextFactory.UserBId
            },
            CancellationToken.None);

        result.ShouldBeOfType<LessonListVm>();
        result.Lessons.Count.ShouldBe(1);
    }
}