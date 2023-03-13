using AutoMapper;
using Sheduler.Application.Interfaces;
using Sheduler.Application.Queries.TeacherQuery.GetTeacherList;
using Sheduler.Domain.Models;
using Sheduler.Persistence;
using Sheduler.Tests.Common;
using Shouldly;

namespace Sheduler.Tests.Teachers.Commands;

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
                UserId = DbContextFactory<TeachersDbContext, Teacher>.UserAId
            },
            CancellationToken.None);

        result.ShouldBeOfType<TeacherListVm>();
        result.Teachers.Count.ShouldBe(2);
    }
}