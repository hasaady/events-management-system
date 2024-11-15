using Evently.Events.Application.Interfaces;
using Evently.Events.Application.Interfaces.Repositories;
using Evently.Events.Domain.Models;
using MediatR;

namespace Evently.Events.Application.Features.Events.Queries.GetAllEvents;

public class GetAllEventsHandler(IEventsRepository repo): IRequestHandler<GetAllEventsQuery, GetAllEventsResponse>
{
    private readonly IEventsRepository _repo = repo;
    
    public async Task<GetAllEventsResponse> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await _repo.GetAllAsync();

        return new GetAllEventsResponse
        {
            Events = events
        };
    }
}

public class GetAllEventsQuery : IRequest<GetAllEventsResponse>;

public class GetAllEventsResponse
{
    public IEnumerable<Event> Events { get; set; }
}