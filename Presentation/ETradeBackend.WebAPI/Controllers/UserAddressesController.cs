using ETradeBackend.Application.Features.UserAddresses.Commands.Create;
using ETradeBackend.Application.Features.UserAddresses.Commands.Delete;
using ETradeBackend.Application.Features.UserAddresses.Commands.Update;
using ETradeBackend.Application.Features.UserAddresses.Queries.GetById;
using ETradeBackend.Application.Features.UserAddresses.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAddressesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserAddressCommand createUserAddressCommand)
    {
        CreatedUserAddressResponse createdUserAddressResponse = await Mediator.Send(createUserAddressCommand);
        return Ok(createdUserAddressResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteUserAddressCommand deleteUserAddressCommand = new() { Id = id };
        DeletedUserAddressResponse deletedUserAddressResponse = await Mediator.Send(deleteUserAddressCommand);
        return Ok(deletedUserAddressResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserAddressCommand updateUserAddressCommand)
    {
        UpdatedUserAddressResponse updatedUserAddressResponse = await Mediator.Send(updateUserAddressCommand);
        return Ok(updatedUserAddressResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserAddressQuery getListUserAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserAddressListItemDto> getListUserAddressResponse = await Mediator.Send(getListUserAddressQuery);
        return Ok(getListUserAddressResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserAddressQuery getByIdUserAddressQuery = new() { Id = id };
        GetByIdUserAddressResponse getByIdUserAddressResponse = await Mediator.Send(getByIdUserAddressQuery);
        return Ok(getByIdUserAddressResponse);
    }
}
