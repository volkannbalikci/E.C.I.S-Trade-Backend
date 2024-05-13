using ETradeBackend.Application.Features.SwapAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Delete;
using ETradeBackend.Application.Features.SwapAdverts.Commands.Update;
using ETradeBackend.Application.Features.SwapAdverts.Queries.GetById;
using ETradeBackend.Application.Features.SwapAdverts.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class SwapAdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSwapAdvertCommand createSwapAdvertCommand)
    {
        CreatedSwapAdvertResponse createdSwapAdvertResponse = await Mediator.Send(createSwapAdvertCommand);
        return Ok(createdSwapAdvertResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteSwapAdvertCommand deleteSwapAdvertCommand = new() { Id = id };
        DeletedSwapAdvertResponse deletedSwapAdvertResponse = await Mediator.Send(deleteSwapAdvertCommand);
        return Ok(deletedSwapAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSwapAdvertCommand updateSwapAdvertCommand)
    {
        UpdatedSwapAdvertResponse updatedSwapAdvertReponse = await Mediator.Send(updateSwapAdvertCommand);
        return Ok(updatedSwapAdvertReponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSwapAdvertQuery getListSwapAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSwapAdvertListItemDto> getListSwapAdvertResponse = await Mediator.Send(getListSwapAdvertQuery);
        return Ok(getListSwapAdvertResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSwapAdvertQuery getByIdSwapAdvertQuery = new() { SwapAdvertId = id };
        GetByIdSwapAdvertResponse getByIdSwapAdvertResponse = await Mediator.Send(getByIdSwapAdvertQuery);
        return Ok(getByIdSwapAdvertResponse);
    }
}


