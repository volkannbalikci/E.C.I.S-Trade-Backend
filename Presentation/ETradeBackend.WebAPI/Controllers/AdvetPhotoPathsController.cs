using ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Create;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Delete;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Update;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Queries.GetById;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvetPhotoPathsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertPhotoPathCommand createAdvertPhotoPathCommand)
    {
        CreatedAdvertPhotoPathResponse createdAdvertPhotoPathResponse = await Mediator.Send(createAdvertPhotoPathCommand);
        return Ok(createdAdvertPhotoPathResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteAdvertPhotoPathCommand deleteAdvertPhotoPathCommand = new() { Id = id };
        DeletedAdvertPhotoPathResponse deletedAdminResponse = await Mediator.Send(deleteAdvertPhotoPathCommand);
        return Ok(deletedAdminResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertPhotoPathCommand updateAdvertPhotoPathCommand)
    {
        UpdatedAdvertPhotoPathResponse updatedAdvertPhotoPathResponse = await Mediator.Send(updateAdvertPhotoPathCommand);
        return Ok(updatedAdvertPhotoPathResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertPhotoPathQuery getListAdvertPhotoPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvertPhotoPathListItemDto> getListAdvertPhotoPathResponse = await Mediator.Send(getListAdvertPhotoPathQuery);
        return Ok(getListAdvertPhotoPathResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertPhotoPathQuery getByIdAdvertPhotoPathQuery = new() { Id = id };
        GetByIdAdvertPhotoPathResponse getByIdAdvertPhotoPathResponse = await Mediator.Send(getByIdAdvertPhotoPathQuery);
        return Ok(getByIdAdvertPhotoPathResponse);
    }
}