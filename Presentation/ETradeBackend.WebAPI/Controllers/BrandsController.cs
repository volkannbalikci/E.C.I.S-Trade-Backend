using ETradeBackend.Application.Features.Addresses.Queries.GetById;
using ETradeBackend.Application.Features.Brands.Commands.Create;
using ETradeBackend.Application.Features.Brands.Commands.Delete;
using ETradeBackend.Application.Features.Brands.Commands.Update;
using ETradeBackend.Application.Features.Brands.Queries.GetById;
using ETradeBackend.Application.Features.Brands.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandResponse createdBrandResponse = await Mediator.Send(createBrandCommand);
        return Ok(createdBrandResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteBrandCommand deleteBrandCommand = new() { Id = id };
        DeletedBrandResponse deletedBrandResponse = await Mediator.Send(deleteBrandCommand);
        return Ok(deletedBrandResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandResponse updatedBrandResponse = await Mediator.Send(updateBrandCommand);
        return Ok(updatedBrandResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBrandListItemDto> getListBrandResponse = await Mediator.Send(getListBrandQuery);
        return Ok(getListBrandResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
        GetByIdBrandResponse getByIdBrandResponse = await Mediator.Send(getByIdBrandQuery);
        return Ok(getByIdBrandResponse);
    }
}
