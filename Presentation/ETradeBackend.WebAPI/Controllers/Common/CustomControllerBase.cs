using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers.Common;

public class CustomControllerBase : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
