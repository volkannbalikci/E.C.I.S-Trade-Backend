using ETradeBackend.Application.Features.Districts.Commands.Create;
using ETradeBackend.Application.Features.Districts.Commands.Delete;
using ETradeBackend.Application.Features.Districts.Commands.Update;
using ETradeBackend.Application.Features.Districts.Queries.GetById;
using ETradeBackend.Application.Features.Districts.Queries.GetList;
using ETradeBackend.Application.Features.Neighbourhoods.Commands.Create;
using ETradeBackend.Application.Features.Neighbourhoods.Commands.Delete;
using ETradeBackend.Application.Features.Neighbourhoods.Commands.Update;
using ETradeBackend.Application.Features.Neighbourhoods.Queries.GetById;
using ETradeBackend.Application.Features.Neighbourhoods.Queries.GetList;
using ETradeBackend.WebAPI.Controllers.Common;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ETradeBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodsController : CustomControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateNeighbourhoodCommand createNeighbourhoodCommand)
        {
            CreatedNeighbourhoodResponse createdNeighbourhoodResponse = await Mediator.Send(createNeighbourhoodCommand);
            return Ok(createdNeighbourhoodResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteNeighbourhoodCommand deleteNeighbourhoodCommand = new() { Id = id };
            DeletedNeighbourhoodResponse deletedNeighbourhoodResponse = await Mediator.Send(deleteNeighbourhoodCommand);
            return Ok(deletedNeighbourhoodResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNeighbourhoodCommand updateNeighbourhoodCommand)
        {
            UpdatedNeighbourhoodResponse updatedNeighbourhoodResponse = await Mediator.Send(updateNeighbourhoodCommand);
            return Ok(updatedNeighbourhoodResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListNeighbourhoodQuery getListNeighbourhoodQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListNeighbourhoodListItemDto> getListNeighbourhoodResponse = await Mediator.Send(getListNeighbourhoodQuery);
            return Ok(getListNeighbourhoodResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdNeighbourhoodQuery getByIdNeighbourhoodQuery = new() { Id = id };
            GetByIdNeighbourhoodResponse getByIdNeighbourhoodResponse = await Mediator.Send(getByIdNeighbourhoodQuery);
            return Ok(getByIdNeighbourhoodResponse);
        }

    }
}
