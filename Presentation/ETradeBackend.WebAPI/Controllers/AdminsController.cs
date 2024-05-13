using ETradeBackend.Application.Features.Addresses.Queries.GetById;
using ETradeBackend.Application.Features.Admins.Commands.Create;
using ETradeBackend.Application.Features.Admins.Commands.Delete;
using ETradeBackend.Application.Features.Admins.Commands.Update;
using ETradeBackend.Application.Features.Admins.Queries.GetById;
using ETradeBackend.Application.Features.Admins.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdminCommand createAdminCommand)
    {
        CreatedAdminResponse createdAdminResponse = await Mediator.Send(createAdminCommand);
        return Ok(createdAdminResponse);
    }

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete([FromRoute] Guid id)
    //{
    //    DeleteAdminCommand deleteAdminCommand = new() { Id = id };
    //    DeletedAdminResponse deletedAdminResponse = await Mediator.Send(deleteAdminCommand);
    //    return Ok(deletedAdminResponse);
    //}

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdminCommand updateAdminCommand)
    {
        UpdatedAdminResponse updatedAdminResponse = await Mediator.Send(updateAdminCommand);
        return Ok(updatedAdminResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdminQuery getListAdminQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdminListItemDto> getListAdminResponse = await Mediator.Send(getListAdminQuery);
        return Ok(getListAdminResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdminQuery getByIdAdminQuery = new() { Id = id };
        GetByIdAdminResponse getByIdAdminResponse = await Mediator.Send(getByIdAdminQuery);
        return Ok(getByIdAdminResponse);
    }
}
