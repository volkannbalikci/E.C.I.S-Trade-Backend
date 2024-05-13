using ETradeBackend.Application.Features.Cities.Commands.Create;
using ETradeBackend.Application.Features.Cities.Commands.Delete;
using ETradeBackend.Application.Features.Cities.Commands.Update;
using ETradeBackend.Application.Features.Cities.Queries.GetById;
using ETradeBackend.Application.Features.Cities.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCityCommand createCityCommand)
    {
        CreatedCityResponse createdCityResponse = await Mediator.Send(createCityCommand);
        return Ok(createdCityResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCityCommand deleteCityCommand = new() { Id = id };
        DeletedCityResponse deletedCityResponse = await Mediator.Send(deleteCityCommand);
        return Ok(deletedCityResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCityCommand)
    {
        UpdatedCityResponse updatedCityResponse = await Mediator.Send(updateCityCommand);
        return Ok(updatedCityResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCityQuery getListCityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCityListItemDto> getListCityResponse = await Mediator.Send(getListCityQuery);
        return Ok(getListCityResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCityQuery getByIdCityQuery = new() { Id = id };
        GetByIdCityResponse getByIdCityResponse = await Mediator.Send(getByIdCityQuery);
        return Ok(getByIdCityResponse);
    }
}
