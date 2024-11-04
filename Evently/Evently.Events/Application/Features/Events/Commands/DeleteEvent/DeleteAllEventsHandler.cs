using Evently.Events.Application.Interfaces;
using MediatR;

namespace Evently.Events.Application.Features.Events.Commands.DeleteAllEvents;

public class DeleteAllEventsHandler(IEventsRepository repo): IRequestHandler<DeleteAllEventsCommand, DeleteAllEventsResponse>
{
    private readonly IEventsRepository _repo = repo;
    
    public async Task<DeleteAllEventsResponse> Handle(DeleteAllEventsCommand request, CancellationToken cancellationToken)
    {
        await _repo.DeleteAllAsync();

        return new DeleteAllEventsResponse();
    }
}

public class DeleteAllEventsCommand : IRequest<DeleteAllEventsResponse>;
public class DeleteAllEventsResponse;