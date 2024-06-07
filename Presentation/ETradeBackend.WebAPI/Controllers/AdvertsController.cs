using ETradeBackend.Application.Features.AdvertImageFiles.Commands.Upload;
using ETradeBackend.Application.Features.AdvertImageFiles.Queries.GetList;
using ETradeBackend.Application.Features.Adverts.Commands.Create;
using ETradeBackend.Application.Features.Adverts.Commands.Delete;
using ETradeBackend.Application.Features.Adverts.Commands.Update;
using ETradeBackend.Application.Features.Adverts.Queries.GetById;
using ETradeBackend.Application.Features.Adverts.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertCommand createAdvertCommand)
    {
        CreatedAdvertResponse createdAdvertResponse = await Mediator.Send(createAdvertCommand);
        return Ok(createdAdvertResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteAdvertCommand deleteAdvertCommand = new() { Id = id };
        DeletedAdvertResponse deletedAdvertResponse = await Mediator.Send(deleteAdvertCommand);
        return Ok(deletedAdvertResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertCommand updateAdvertCommand)
    {
        UpdatedAdvertResponse updatedAdvertResponse = await Mediator.Send(updateAdvertCommand);
        return Ok(updatedAdvertResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertQuery getListAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvertListItemDto> getListAdvertResponse = await Mediator.Send(getListAdvertQuery);
        return Ok(getListAdvertResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertQuery getByIdAdvertQuery = new() { Id = id };
        GetByIdAdvertResponse getByIdAdvertResponse = await Mediator.Send(getByIdAdvertQuery);
        return Ok(getByIdAdvertResponse);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload([FromQuery] UploadAdvertImageFileCommand uploadAdvertImageFileCommand)
    {
        uploadAdvertImageFileCommand.Files = Request.Form.Files;
        UploadAdvertImageFileResponse uploadAdvertImageFileResponse = await Mediator.Send(uploadAdvertImageFileCommand);
        return Ok();
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetAdvertImageFilesByAdvertId([FromRoute] GetListAdvertImageFileQuery getListAdvertImageFileQuery)
    {
        List<GetListAdvertImageFileListItemDto> response = await Mediator.Send(getListAdvertImageFileQuery);
        return Ok(response);
    }
}
