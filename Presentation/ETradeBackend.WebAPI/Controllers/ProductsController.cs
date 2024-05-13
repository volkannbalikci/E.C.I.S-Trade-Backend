using ETradeBackend.Application.Features.Products.Commands.Create;
using ETradeBackend.Application.Features.Products.Commands.Delete;
using ETradeBackend.Application.Features.Products.Commands.Update;
using ETradeBackend.Application.Features.Products.Queries.GetByBrandId;
using ETradeBackend.Application.Features.Products.Queries.GetByCategoryId;
using ETradeBackend.Application.Features.Products.Queries.GetById;
using ETradeBackend.Application.Features.Products.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : CustomControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        CreatedProductResponse createdProductResponse = await Mediator.Send(createProductCommand);
        return Ok(createdProductResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteProductCommand deleteProductCommand = new() { Id = id };
        DeletedProductResponse deletedProductResponse = await Mediator.Send(deleteProductCommand);
        return Ok(deletedProductResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        UpdatedProductResponse updatedProductResponse = await Mediator.Send(updateProductCommand);
        return Ok(updatedProductResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductListItemDto> getListProductResponse = await Mediator.Send(getListProductQuery);
        return Ok(getListProductResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductQuery getByIdProductQuery = new() { Id = id };
        GetByIdProductResponse getByIdProductResponse = await Mediator.Send(getByIdProductQuery);
        return Ok(getByIdProductResponse);
    }

    [HttpGet("getByCategoryId/{categoryId}")]
    public async Task<IActionResult> GetListByCategoryId([FromRoute] Guid categoryId, [FromQuery] PageRequest pageRequest)
    {
        GetByCategoryIdProductQuery getByCategoryIdProductQuery = new() {  CategoryId = categoryId ,PageRequest = pageRequest };
        GetListResponse<GetByCategoryIdProductListItemDto> getByCategoryIdProductResponse = await Mediator.Send(getByCategoryIdProductQuery);
        return Ok(getByCategoryIdProductResponse);
    }

    [HttpGet("getByBrandId/{brandId}")]
    public async Task<IActionResult> GetListByBrandId([FromRoute] Guid brandId, [FromQuery] PageRequest pageRequest)
    {
        GetByBrandIdProductQuery getByBrandIdProductQuery = new() { BrandId = brandId, PageRequest = pageRequest };
        GetListResponse<GetByBrandIdProductListItemDto> getByBrandIdProductResponse = await Mediator.Send(getByBrandIdProductQuery);
        return Ok(getByBrandIdProductResponse);
    }
}
