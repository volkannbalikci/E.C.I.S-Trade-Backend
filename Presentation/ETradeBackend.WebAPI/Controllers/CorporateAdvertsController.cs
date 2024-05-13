using ETradeBackend.Application.Features.CorporateAdverts.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdverts.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetByI;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetById;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CorporateAdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateAdvertCommand createCorporateAdvertCommand)
    {
        CreatedCorporateAdvertResponse createdCorporateAdvertResponse = await Mediator.Send(createCorporateAdvertCommand);
        return Ok(createdCorporateAdvertResponse);
    }

    [HttpDelete("{corporateAdvertId},{advertId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid corporateAdvertId, [FromRoute] Guid advertId)
    {
        DeleteCorporateAdvertCommand deletecorporateAdvertCommand = new() { CorporateAdvertId = corporateAdvertId, AdvertId = advertId };
        DeletedCorporateAdvertResponse deletedCorporateAdvertResponse = await Mediator.Send(deletecorporateAdvertCommand);
        return Ok(deletedCorporateAdvertResponse);
    }

    //[HttpPut]
    //public async Task<IActionResult> Update([FromBody] UpdateCorporateAdvertCommand updateIndividualAdvertCommand)
    //{
    //    UpdatedIndividualAdvertResponse updatedIndividualAdvertReponse = await Mediator.Send(updateIndividualAdvertCommand);
    //    return Ok(updatedIndividualAdvertReponse);
    //}

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCorporateAdvertQuery getListCorporateAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCorporateAdvertListItemDto> getListCorporateAdvertResponse = await Mediator.Send(getListCorporateAdvertQuery);
        return Ok(getListCorporateAdvertResponse);
    }

    [HttpGet("{corporateAdvertId}")]
    public async Task<IActionResult> GetById([FromRoute] Guid corporateAdvertId)
    {
        GetByIdCorporateAdvertQuery getByIdCorporateAdvertQuery = new() { CorporateAdvertId = corporateAdvertId };
        GetByIdCorporateAdvertResponse getByIdCorporateAdvertResponse = await Mediator.Send(getByIdCorporateAdvertQuery);
        return Ok(getByIdCorporateAdvertResponse);
    }
}

