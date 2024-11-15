using Evently.Events.Application.Interfaces;
using Evently.Events.Application.Interfaces.Repositories;
using MediatR;

namespace Evently.Events.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventHandler(IEventsRepository repo): IRequestHandler<DeleteEventCommand, DeleteEventResponse>
{
    private readonly IEventsRepository _repo = repo;
    
    public async Task<DeleteEventResponse> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await _repo.GetByIdAsync(request.Id);

        if (@event == null)
        {
            throw new NullReferenceException($"No event with id {request.Id} was found.");
        }
        
        await _repo.DeleteAsync(@event);

        return new DeleteEventResponse();
    }
}

public class DeleteEventCommand : IRequest<DeleteEventResponse>
{
    public Guid Id { get; set; }
}

public class DeleteEventResponse;