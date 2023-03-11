using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Interfaces;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherList;

public class GetTeacherListQueryHandler : IRequestHandler<GetTeacherListQuery, TeacherListVm>
{
    private ITeachersDbContext _teachersDbContext;
    private IMapper _mapper;

    public GetTeacherListQueryHandler(ITeachersDbContext teachersDbContext, IMapper mapper)
    {
        _teachersDbContext = teachersDbContext;
        _mapper = mapper;
    }
    
    public async Task<TeacherListVm> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _teachersDbContext.Set()
            .Where(x => x.UserId == request.UserId)
            .ProjectTo<TeacherLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new TeacherListVm() { Teachers = teachers };
    }
}