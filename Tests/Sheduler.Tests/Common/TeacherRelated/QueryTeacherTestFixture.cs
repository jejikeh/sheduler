using AutoMapper;
using Sheduler.Application.Common.Mappings;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;
using Sheduler.Persistence;

namespace Sheduler.Tests.Common.TeacherRelated;

public class QueryTeacherTestFixture : IDisposable
{
    public TeachersDbContext Context;
    public IMapper Mapper;

    public QueryTeacherTestFixture()
    {
        Context = DbContextFactory.Create<TeachersDbContext, Teacher>(
            options => new TeachersDbContext(options), 
            TestDataCollection.Teachers);
        var configurationProvider = new MapperConfiguration(conigure => 
                conigure.AddProfile(new AssemblyMappingProfile(typeof(ITeachersDbContext).Assembly)));
        Mapper = configurationProvider.CreateMapper();
    }
    
    public void Dispose()
    {
        DbContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class
    QueryCollection : ICollectionFixture<QueryTeacherTestFixture>
{
    
}