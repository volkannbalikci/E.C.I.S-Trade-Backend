using ETradeBackend.Application.Features.Categories.Commands.Create;
using ETradeBackend.Application.Features.Categories.Commands.Delete;
using ETradeBackend.Application.Features.Categories.Commands.Update;
using ETradeBackend.Application.Features.Categories.Queries.GetById;
using ETradeBackend.Application.Features.Categories.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryResponse createdCategoryResponse = await Mediator.Send(createCategoryCommand);
        return Ok(createdCategoryResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCategoryCommand deleteCategoryCommand = new() { Id = id };
        DeletedCategoryResponse deletedCategoryResponse = await Mediator.Send(deleteCategoryCommand);
        return Ok(deleteCategoryCommand);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        UpdatedCategoryResponse updatedCategoryResponse = await Mediator.Send(updateCategoryCommand);
        return Ok(updatedCategoryResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery getListCategoryListItemDto = new() { PageRequest = pageRequest };
        GetListResponse<GetListCategoryListItemDto> getListCategoryResponse = await Mediator.Send(getListCategoryListItemDto);
        return Ok(getListCategoryResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCategoryQuery getByIdCategoryQuery = new() { Id = id };
        GetByIdCategoryResponse getByIdCategoryResponse = await Mediator.Send(getByIdCategoryQuery);
        return Ok(getByIdCategoryResponse);
    }
}
