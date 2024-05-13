using ETradeBackend.Application.Features.CorporateUsers.Commands.Create;
using ETradeBackend.Application.Features.CorporateUsers.Commands.Delete;
using ETradeBackend.Application.Features.CorporateUsers.Commands.Update;
using ETradeBackend.Application.Features.CorporateUsers.Queries.GetById;
using ETradeBackend.Application.Features.CorporateUsers.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateUsersController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateUserCommand createCorporateUserCommand)
    {
        CreatedCorporateUserResponse createdCorporateUserResponse = await Mediator.Send(createCorporateUserCommand);
        return Ok(createdCorporateUserResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCorporateUserCommand deleteCorporateUserCommand = new() { Id = id };
        DeletedCorporateUserResponse deletedCorporateUserResponse = await Mediator.Send(deleteCorporateUserCommand);
        return Ok(deletedCorporateUserResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateUserCommand updateCorporateUserCommand)
    {
        UpdatedCorporateUserResponse updatedCorporateUserResponse = await Mediator.Send(updateCorporateUserCommand);
        return Ok(updatedCorporateUserResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCorporateUserQuery getListCorporateUserQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCorporateUserListItemDto> getListCorporateUserResponse = await Mediator.Send(getListCorporateUserQuery);
        return Ok(getListCorporateUserResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCorporateUserQuery getByIdCorporateUserQuery = new() { Id = id };
        GetByIdCorporateUserResponse getByIdCorporateUserResponse = await Mediator.Send(getByIdCorporateUserQuery);
        return Ok(getByIdCorporateUserResponse);
    }
}