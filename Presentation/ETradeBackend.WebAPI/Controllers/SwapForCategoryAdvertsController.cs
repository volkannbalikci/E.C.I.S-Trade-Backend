using ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Create;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Delete;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Update;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Queries.GetById;
using ETradeBackend.Application.Features.SwapForCategoryAdverts.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class SwapForCategoryAdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSwapForCategoryAdvertCommand createSwapForCategoryAdvertCommand)
    {
        CreatedSwapForCategoryAdvertResponse createdSwapForCategoryAdvertResponse = await Mediator.Send(createSwapForCategoryAdvertCommand);
        return Ok(createdSwapForCategoryAdvertResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteSwapForCategoryAdvertCommand deleteSwapForCategoryAdvertCommand = new() {  SwapForCategoryAdvertId = id };
        DeletedSwapForCategoryAdvertResponse deletedSwapForCategoryAdvertResponse = await Mediator.Send(deleteSwapForCategoryAdvertCommand);
        return Ok(deletedSwapForCategoryAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSwapForCategoryAdvertCommand updateSwapForCategoryAdvertCommand)
    {
        UpdatedSwapForCategoryAdvertResponse updatedSwapForCategoryAdvertReponse = await Mediator.Send(updateSwapForCategoryAdvertCommand);
        return Ok(updatedSwapForCategoryAdvertReponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSwapForCategoryAdvertQuery getListSwapForCategoryAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSwapForCategoryAdvertListItemDto> getListSwapForCategoryAdvertResponse = await Mediator.Send(getListSwapForCategoryAdvertQuery);
        return Ok(getListSwapForCategoryAdvertResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSwapForCategoryAdvertQuery getByIdSwapForCategoryAdvertQuery = new() {  SwapForCategoryAdvertId = id };
        GetByIdSwapForCategoryAdvertResponse getByIdSwapForCategoryAdvertResponse = await Mediator.Send(getByIdSwapForCategoryAdvertQuery);
        return Ok(getByIdSwapForCategoryAdvertResponse);
    }
}


