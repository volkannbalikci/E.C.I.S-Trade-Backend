using ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Delete;
using ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Update;
using ETradeBackend.Application.Features.SwapForProductAdverts.Queries.GetById;
using ETradeBackend.Application.Features.SwapForProductAdverts.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]


public class SwapForProductAdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSwapForProductAdvertCommand createSwapForProductAdvertCommand)
    {
        CreatedSwapForProductAdvertResponse createdSwapForProductAdvertResponse = await Mediator.Send(createSwapForProductAdvertCommand);
        return Ok(createdSwapForProductAdvertResponse);
    }

    [HttpDelete("{swapForProductAdvertId},{swapAdvertId},{advertId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid swapForProductAdvertId, [FromRoute] Guid swapAdvertId, [FromRoute] Guid advertId)
    {
        DeleteSwapForProductAdvertCommand deleteSwapForProductAdvertCommand = new() { SwapForProductAdvertId = swapForProductAdvertId, SwapAdvertId = swapAdvertId, AdvertId = advertId };
        DeletedSwapForProductAdvertResponse deletedSwapForProductAdvertResponse = await Mediator.Send(deleteSwapForProductAdvertCommand);
        return Ok(deletedSwapForProductAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSwapForProductAdvertCommand updateSwapForProductAdvertCommand)
    {
        UpdatedSwapForProductAdvertResponse updatedSwapForProductAdvertReponse = await Mediator.Send(updateSwapForProductAdvertCommand);
        return Ok(updatedSwapForProductAdvertReponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSwapForProductAdvertQuery getListSwapForProductAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSwapForProductAdvertListItemDto> getListSwapForProductAdvertResponse = await Mediator.Send(getListSwapForProductAdvertQuery);
        return Ok(getListSwapForProductAdvertResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSwapForProductAdvertQuery getByIdSwapForProductAdvertQuery = new() { SwapForProductAdvertId = id };
        GetByIdSwapForProductAdvertResponse getByIdSwapForProductAdvertResponse = await Mediator.Send(getByIdSwapForProductAdvertQuery);
        return Ok(getByIdSwapForProductAdvertResponse);
    }
}


