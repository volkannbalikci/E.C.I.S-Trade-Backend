using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Update;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetById;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CorporateAdvertOrderItemsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateAdvertOrderItemCommand createCorporateAdvertOrderItemCommand)
    {
        CreatedCorporateAdvertOrderItemResponse createdCorporateAdvertOrderItemResponse = await Mediator.Send(createCorporateAdvertOrderItemCommand);
        return Ok(createdCorporateAdvertOrderItemResponse);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid corporateAdvertOrderItemId, [FromRoute] Guid advertId)
    {
        DeleteCorporateAdvertOrderItemCommand deleteCorporateAdvertOrderItemCommand = new() { Id = corporateAdvertOrderItemId};
        DeletedCorporateAdvertOrderItemResponse deletedCorporateAdvertOrderItemResponse = await Mediator.Send(deleteCorporateAdvertOrderItemCommand);
        return Ok(deletedCorporateAdvertOrderItemResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateAdvertOrderItemCommand updateCorporateAdvertOrderItemCommand)
    {
        UpdatedCorporateAdvertOrderItemResponse updatedCorporateAdvertOrderItemResponse = await Mediator.Send(updateCorporateAdvertOrderItemCommand);
        return Ok(updatedCorporateAdvertOrderItemResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCorporateAdvertOrderItemQuery getListCorporateAdvertOrderItemQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCorporateAdvertOrderItemListItemDto> getListCorporateAdvertOrderItemResponse = await Mediator.Send(getListCorporateAdvertOrderItemQuery);
        return Ok(getListCorporateAdvertOrderItemResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCorporateAdvertOrderItemQuery getByIdCorporateAdvertOrderItemQuery = new() { Id = id };
        GetByIdCorporateAdvertOrderItemResponse getByIdCorporateAdvertOrderItemResponse = await Mediator.Send(getByIdCorporateAdvertOrderItemQuery);
        return Ok(getByIdCorporateAdvertOrderItemResponse);
    }
}

