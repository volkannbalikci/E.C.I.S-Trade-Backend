using ETradeBackend.Application.Features.IndividualAdverts.Commands.Create;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Delete;
using ETradeBackend.Application.Features.IndividualAdverts.Commands.Update;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetById;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class IndividualAdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIndividualAdvertCommand createIndividualAdvertCommand)
    {
        CreatedIndividualAdvertResponse createdIndividualAdvertResponse = await Mediator.Send(createIndividualAdvertCommand);
        return Ok(createdIndividualAdvertResponse);
    }

    [HttpDelete("{individualAdvertId},{advertId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid individualAdvertId, [FromRoute] Guid advertId)
    {
        DeleteIndividualAdvertCommand deleteIndividualAdvertCommand = new() { IndividualAdvertId = individualAdvertId, AdvertId = advertId };
        DeletedIndividualAdvertResponse deletedIndividualAdvertResponse = await Mediator.Send(deleteIndividualAdvertCommand);
        return Ok(deletedIndividualAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualAdvertCommand updateIndividualAdvertCommand)
    {
        UpdatedIndividualAdvertResponse updatedIndividualAdvertReponse = await Mediator.Send(updateIndividualAdvertCommand);
        return Ok(updatedIndividualAdvertReponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIndividualAdvertQuery getListIndividualAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListIndividualAdvertListItemDto> getListIndividualAdvertResponse = await Mediator.Send(getListIndividualAdvertQuery);
        return Ok(getListIndividualAdvertResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdIndividualAdvertQuery getByIdIndividualAdvertQuery = new() { IndividualAdvertId = id };
        GetByIdIndividualAdvertResponse getByIdIndividualAdvertResponse = await Mediator.Send(getByIdIndividualAdvertQuery);
        return Ok(getByIdIndividualAdvertResponse);
    }
}


