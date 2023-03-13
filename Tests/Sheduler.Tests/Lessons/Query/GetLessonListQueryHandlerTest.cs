using AutoMapper;
using Sheduler.Application.Queries.TeacherQuery.GetTeacherList;
using Sheduler.Persistence;
using Sheduler.Tests.Common;
using Sheduler.Tests.Common.TeacherRelated;
using Shouldly;

namespace Sheduler.Tests.Lessons.Query;

[Collection("QueryCollection")]
public class GetTeacherListQueryHandlerTest
{
    private readonly TeachersDbContext _context;
    private readonly IMapper _mapper;

    public GetTeacherListQueryHandlerTest(QueryTeacherTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }
    
    [Fact]
    public async Task GetTeacherListQueryHandler_Success()
    {
        var handler = new GetTeacherListQueryHandler(_context, _mapper);
        var result = await handler.Handle(
            new GetTeacherListQuery()
            {
                UserId = DbContextFactory.UserAId
            },
            CancellationToken.None);

        result.ShouldBeOfType<TeacherListVm>();
        result.Teachers.Count.ShouldBe(2);
    }
}