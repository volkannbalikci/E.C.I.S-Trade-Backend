using ETradeBackend.Application.Features.Users.Commands.Create;
using ETradeBackend.Application.Features.Users.Commands.Delete;
using ETradeBackend.Application.Features.Users.Commands.Update;
using ETradeBackend.Application.Features.Users.Queries.GetById;
using ETradeBackend.Application.Features.Users.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        CreatedUserResponse createdUserResponse = await Mediator.Send(createUserCommand);
        return Ok(createdUserResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteUserCommand deleteUserCommand = new() { Id = id };
        DeletedUserResponse deletedUserResponse = await Mediator.Send(deleteUserCommand);
        return Ok(deletedUserResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        UpdatedUserResponse updatedUserResponse = await Mediator.Send(updateUserCommand);
        return Ok(updatedUserResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserListItemDto> getListUserResponse = await Mediator.Send(getListUserQuery);
        return Ok(getListUserResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserQuery getByIdUserQuery = new() { Id = id };
        GetByIdUserResponse getByIdUserResponse = await Mediator.Send(getByIdUserQuery);
        return Ok(getByIdUserResponse);
    }
}
