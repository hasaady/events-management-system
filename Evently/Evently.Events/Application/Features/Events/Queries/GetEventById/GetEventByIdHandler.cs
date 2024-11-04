using Evently.Events.Application.Interfaces;
using Evently.Events.Domain.Entities;
using MediatR;

namespace Evently.Events.Application.Features.Events.Queries.GetEventById;

public class GetEventByIdHandler(IEventsRepository repo): IRequestHandler<GetEventByIdQuery, GetEventByIdResponse>
{
    private readonly IEventsRepository _repo = repo;
    
    public async Task<GetEventByIdResponse> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var @event = await _repo.GetByIdAsync(request.Id);

        if (@event == null)
        {
            throw new NullReferenceException($"No event with id {request.Id} was found.");
        }

        return new GetEventByIdResponse
        {
            Event = @event
        };
    }
}

public class GetEventByIdQuery : IRequest<GetEventByIdResponse>
{
    public Guid Id { get; set; }
}

public class GetEventByIdResponse
{
    public Event? Event { get; set; }
}