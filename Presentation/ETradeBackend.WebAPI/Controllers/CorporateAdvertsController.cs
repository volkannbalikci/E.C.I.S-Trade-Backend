using ETradeBackend.Application.Abstractions.Storage;
using ETradeBackend.Application.Features.AdvertImageFiles.Commands.Change;
using ETradeBackend.Application.Features.AdvertImageFiles.Commands.Upload;
using ETradeBackend.Application.Features.AdvertImageFiles.Queries.GetList;
using ETradeBackend.Application.Features.CorporateAdverts.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdverts.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetByI;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetById;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetList;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CorporateAdvertsController : CustomControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IStorageService _storageService;
    private readonly IFileRepository _fileRepository;
    private readonly IAdvertImageFileRepository _advertImageFileRepository;

    public CorporateAdvertsController(IWebHostEnvironment webHostEnvironment, IStorageService storageService, IFileRepository fileRepository, IAdvertImageFileRepository advertImageFileRepository)
    {
        _webHostEnvironment = webHostEnvironment;
        _storageService = storageService;
        _fileRepository = fileRepository;
        _advertImageFileRepository = advertImageFileRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateAdvertCommand createCorporateAdvertCommand, [FromQuery] IFormFileCollection files)
    {
        createCorporateAdvertCommand.Files = Request.Form.Files;
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

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload([FromQuery] UploadAdvertImageFileCommand uploadAdvertImageFileCommand)
    {
        uploadAdvertImageFileCommand.Files = Request.Form.Files;
        UploadAdvertImageFileResponse uploadAdvertImageFileResponse = await Mediator.Send(uploadAdvertImageFileCommand);
        return Ok();
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetProductImages([FromRoute] GetListAdvertImageFileQuery getListAdvertImageFileQuery)
    {
        List<GetListAdvertImageFileListItemDto> response = await Mediator.Send(getListAdvertImageFileQuery);
        return Ok(response);
    }

    //public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseAdvertImageFileCommand changeShowcaseAdvertImageFileCommand)
    //{
    //    ChangedShowcaseAdvertImageFileResponse response = await Mediator.Send(changeShowcaseAdvertImageFileCommand);
    //    return Ok(response);
    //}
}

