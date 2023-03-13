using AutoMapper;
using Sheduler.Application.Common.Mappings;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;
using Sheduler.Persistence;

namespace Sheduler.Tests.Common.LessonRelated;

public class QueryLessonTestFixture
{
    public LessonsDbContext Context;
    public IMapper Mapper;

    public QueryLessonTestFixture()
    {
        Context = DbContextFactory.Create<LessonsDbContext, Lesson>(
            options => new LessonsDbContext(options), 
            TestDataCollection.Lessons);
        var configurationProvider = new MapperConfiguration(conigure => 
            conigure.AddProfile(new AssemblyMappingProfile(typeof(ILessonsDbContext).Assembly)));
        Mapper = configurationProvider.CreateMapper();
    }
    
    public void Dispose()
    {
        DbContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryLessonCollection")]
public class
    QueryLessonCollection : ICollectionFixture<QueryLessonTestFixture>
{
    
}