using ETradeBackend.Application.Features.CorporateAdvertOrders.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetById;
using ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CorporateAdvertOrdersController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateAdvertOrderCommand createCorporateAdvertOrderCommand)
    {
        CreatedCorporateAdvertOrderResponse createdCorporateAdvertOrderResponse = await Mediator.Send(createCorporateAdvertOrderCommand);
        return Ok(createdCorporateAdvertOrderResponse);
    }

    [HttpDelete("{corporateAdvertOrderId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid corporateAdvertOrderId)
    {
        DeleteCorporateAdvertOrderCommand deleteCorporateAdvertOrderCommand = new() { Id = corporateAdvertOrderId };
        DeletedCorporateAdvertOrderResponse deletedCorporateAdvertOrderResponse = await Mediator.Send(deleteCorporateAdvertOrderCommand);
        return Ok(deletedCorporateAdvertOrderResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCorporateAdvertOrderQuery getListCorporateAdvertOrderQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCorporateAdvertOrderListItemDto> getListCorporateAdvertOrderResponse = await Mediator.Send(getListCorporateAdvertOrderQuery);
        return Ok(getListCorporateAdvertOrderResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCorporateAdvertOrderQuery getByIdCorporateAdvertOrderQuery = new() { Id = id };
        GetByIdCorporateAdvertOrderResponse getByIdCorporateAdvertOrderResponse = await Mediator.Send(getByIdCorporateAdvertOrderQuery);
        return Ok(getByIdCorporateAdvertOrderResponse);
    }
}

