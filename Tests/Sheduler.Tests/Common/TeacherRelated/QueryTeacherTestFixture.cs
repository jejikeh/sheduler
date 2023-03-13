using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Interfaces;
using Sheduler.Application.Common.Mappings;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;
using Sheduler.Persistence;

namespace Sheduler.Tests.Common;

public class QueryTeacherTestFixture : IDisposable
{
    public TeachersDbContext Context;
    public IMapper Mapper;

    public QueryTeacherTestFixture()
    {
        Context = DbContextFactory<TeachersDbContext, Teacher>.Create(
            options => new TeachersDbContext(options), 
            TestDataCollection.Teachers);
        var configurationProvider = new MapperConfiguration(conigure => 
                conigure.AddProfile(new AssemblyMappingProfile(typeof(ITeachersDbContext).Assembly)));
        Mapper = configurationProvider.CreateMapper();
    }
    
    public void Dispose()
    {
        DbContextFactory<TeachersDbContext, Teacher>.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class
    QueryCollection : ICollectionFixture<QueryTeacherTestFixture>
{
    
}