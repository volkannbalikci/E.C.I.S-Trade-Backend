using ETradeBackend.Application.Features.OperationClaims.Commands.Create;
using ETradeBackend.Application.Features.OperationClaims.Commands.Delete;
using ETradeBackend.Application.Features.OperationClaims.Commands.Update;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetById;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetByPrefix;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaimResponse createdOperationClaimResponse = await Mediator.Send(createOperationClaimCommand);
        return Ok(createdOperationClaimResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteOperationClaimCommand deleteOperationClaimCommand = new() { Id = id };
        DeletedOperationClaimResponse deletedOperationClaimResponse = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(deletedOperationClaimResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        UpdatedOperationClaimResponse updatedOperationClaimResponse = await Mediator.Send(updateOperationClaimCommand);
        return Ok(updatedOperationClaimResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOperationClaimListItemDto> getListOperationClaimResponse = await Mediator.Send(getListOperationClaimQuery);
        return Ok(getListOperationClaimResponse);
    }

    [HttpGet("GetByPrefix")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromQuery] String prefix)
    {
        GetListByPrefixOperationClaimQuery getListByPrefixOperationClaimQuery = new() { PageRequest = pageRequest, Prefix = prefix };
        GetListResponse<GetListByPrefixOperationClaimListItemDto> getListByPrefixOperationClaimResponse = await Mediator.Send(getListByPrefixOperationClaimQuery);
        return Ok(getListByPrefixOperationClaimResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdOperationClaimQuery getByIdOperationClaimQuery = new() { Id = id };
        GetByIdOpereationClaimResponse getByIdOpereationClaimResponse = await Mediator.Send(getByIdOperationClaimQuery);
        return Ok(getByIdOpereationClaimResponse);
    }
}
