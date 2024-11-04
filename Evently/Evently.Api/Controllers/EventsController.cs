using Evently.Events.Application.Features.Events.Commands.CreateEvent;
using Evently.Events.Application.Features.Events.Commands.DeleteAllEvents;
using Evently.Events.Application.Features.Events.Commands.DeleteEvent;
using Evently.Events.Application.Features.Events.Queries.GetAllEvents;
using Evently.Events.Application.Features.Events.Queries.GetEventById;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Evently.Api.Controllers;

[ApiController]
[Route("events")]
public class EventsController : ControllerBase
{  
    private readonly ILogger<EventsController> _logger;
    private readonly IMediator _mediator;

    public EventsController(ILogger<EventsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<GetAllEventsResponse>> GetAll()
    {
        var request = new GetAllEventsQuery();
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetEventByIdResponse>> GetById(Guid id)
    {
        var request = new GetEventByIdQuery { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEventResponse>> Post(CreateEventCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<DeleteEventResponse>> Delete(Guid id)
    {
        var request = new DeleteEventCommand { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteAllEventsResponse>> DeleteAll()
    {
        var request = new DeleteAllEventsCommand();
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}