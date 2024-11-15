using Evently.Events.Application.Interfaces.Data;
using Evently.Events.Application.Interfaces.Repositories;
using Evently.Events.Domain.Models;
using MediatR;

namespace Evently.Events.Application.Features.Events.Commands.CreateEvent;

public class CreateEventHandler(IEventsRepository repo): IRequestHandler<CreateEventCommand, CreateEventResponse>
{
    private readonly IEventsRepository _repo = repo;
    
    public async Task<CreateEventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Event @event = new Event
        {
            Name = request.Name,
            Description = request.Description,
            Location = request.Location,
            StartAtUtc = request.StartAtUtc,
            EndAtUtc = request.EndAtUtc,
        };
        
        await _repo.CreateAsync(@event);

        return new CreateEventResponse();
    }
}

public sealed record CreateEventCommand : IRequest<CreateEventResponse>
{
    public string Name { get; set; }

    public string Description { get; set; }
    
    public string Location { get; set; }
    
    public DateTime StartAtUtc { get; set; }
    
    public DateTime EndAtUtc { get; set; }
}

public class CreateEventResponse;