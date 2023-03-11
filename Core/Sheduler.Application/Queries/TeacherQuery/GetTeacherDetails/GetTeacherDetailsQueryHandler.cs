using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Application.Common.Exceptions;
using Sheduler.Application.Interfaces;
using Sheduler.Domain.Models;

namespace Sheduler.Application.Queries.TeacherQuery.GetTeacherDetails;

public class GetTeacherDetailsQueryHandler : IRequestHandler<GetTeacherDetailsQuery, TeacherDetailsVm>
{
    private ITeachersDbContext _teachersDbContext;
    private IMapper _mapper;

    public GetTeacherDetailsQueryHandler(ITeachersDbContext teachersDbContext, IMapper mapper)
    {
        _teachersDbContext = teachersDbContext;
        _mapper = mapper;
    }
    
    public async Task<TeacherDetailsVm> Handle(GetTeacherDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _teachersDbContext.Set()
            .FirstOrDefaultAsync(teacher => teacher.Id == request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId )
            throw new NotFoundException(nameof(Lesson), request.Id);

        return _mapper.Map<TeacherDetailsVm>(entity);
    }
}