 using ETradeBackend.Application.Features.Addresses.Commands.Create;
using ETradeBackend.Application.Features.Addresses.Commands.Delete;
using ETradeBackend.Application.Features.Addresses.Commands.Update;
using ETradeBackend.Application.Features.Addresses.Queries.GetById;
using ETradeBackend.Application.Features.Addresses.Queries.GetList;
using ETradeBackend.Application.Features.Addresses.Queries.GetListByCityId;
using ETradeBackend.Application.Features.Addresses.Queries.GetListByCountryId;
using ETradeBackend.Application.Features.Addresses.Queries.GetListByDistrictId;
using ETradeBackend.Application.Features.Addresses.Queries.GetListByNeighbourhoodId;
using ETradeBackend.Application.Features.Addresses.Queries.GetListByUserId;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAddressCommand createAddressCommand)
    {
        CreatedAddressResponse createdAddressResponse = await Mediator.Send(createAddressCommand);
        return Ok(createdAddressResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteAddressCommand deleteAddressCommand = new() { Id = id };
        DeletedAddressResponse deletedAddressResponse = await Mediator.Send(deleteAddressCommand);
        return Ok(deletedAddressResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddressCommand)
    {
        UpdatedAddressResponse updatedAddressResponse = await Mediator.Send(updateAddressCommand);
        return Ok(updatedAddressResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAddressQuery getListAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAddressListItemDto> getListAddressResponse = await Mediator.Send(getListAddressQuery);
        return Ok(getListAddressResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAddressQuery getByIdAddressQuery = new() { Id = id };
        GetByIdAddressResponse getByIdAddressResponse = await Mediator.Send(getByIdAddressQuery);
        return Ok(getByIdAddressResponse);
    }

    [HttpGet("getByUserId/{userId}")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, Guid userId)
    {
        GetListByUserIdAddressQuery getListByUserIdAddressQuery = new() { PageRequest = pageRequest , UserId = userId };
        GetListResponse<GetListByUserIdAddressListItemDto> getListByUserIdAddressResponse = await Mediator.Send(getListByUserIdAddressQuery);
        return Ok(getListByUserIdAddressResponse);
    }

    [HttpGet("getByCountryId/{countryId}")]
    public async Task<IActionResult> GetListByCountryId([FromQuery] PageRequest pageRequest, Guid countryId)
    {
        GetListByCountryIdAddressQuery getListByCountryIdAddressQuery = new() { PageRequest = pageRequest, CountryId = countryId };
        GetListResponse<GetListByCountryIdAddressListItemDto> getListResponse = await Mediator.Send(getListByCountryIdAddressQuery);
        return Ok(getListResponse);
    }

    [HttpGet("getByCityId/{cityId}")]
    public async Task<IActionResult> GetListByCityId([FromQuery] PageRequest pageRequest, Guid cityId)
    {
        GetListByCityIdAddressQuery getListByCityIdAddressQuery = new() { PageRequest = pageRequest, CityId = cityId };
        GetListResponse<GetListByCityIdAddressListItemDto> getListResponse = await Mediator.Send(getListByCityIdAddressQuery);
        return Ok(getListResponse);
    }

    [HttpGet("getByDistrictId/{districtId}")]
    public async Task<IActionResult> GetListByDistrictId([FromQuery] PageRequest pageRequest, Guid districtId)
    {
        GetListByDistrictIdAddressQuery getListByDistrictIdAddressQuery = new() { PageRequest = pageRequest, DistrictId = districtId };
        GetListResponse<GetListByDistrictIdAddressListItemDto> getListResponse = await Mediator.Send(getListByDistrictIdAddressQuery);
        return Ok(getListResponse);
    }

    [HttpGet("getByNeighbourhoodId/{neighbourhoodId}")]
    public async Task<IActionResult> GetListByNeighbourhoodId([FromQuery] PageRequest pageRequest, Guid neighbourhoodId)
    {
        GetListByNeighbourhoodIdAddressQuery getListByNeighbourhoodIdAddressQuery = new() { PageRequest = pageRequest, NeighbourhoodId = neighbourhoodId };
        GetListResponse<GetListByNeighbourhoodIdAddressListItemDto> getListResponse = await Mediator.Send(getListByNeighbourhoodIdAddressQuery);
        return Ok(getListResponse);
    }
}
