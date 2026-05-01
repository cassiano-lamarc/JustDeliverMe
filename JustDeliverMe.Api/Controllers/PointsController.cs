using JustDeliverMe.Application.Handlers.Commands.Point.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustDeliverMe.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class PointsController : Controller
{
    private readonly IMediator _mediator;

    public PointsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePointCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
}
