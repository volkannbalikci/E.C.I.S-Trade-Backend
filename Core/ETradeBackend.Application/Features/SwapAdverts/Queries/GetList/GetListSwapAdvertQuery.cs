using AutoMapper;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetList;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Queries.GetList;

public class GetListSwapAdvertQuery : IRequest<GetListResponse<GetListSwapAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSwapAdvertQueryHandler : IRequestHandler<GetListSwapAdvertQuery, GetListResponse<GetListSwapAdvertListItemDto>>
    {
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IMapper _mapper;

        public GetListSwapAdvertQueryHandler(ISwapAdvertRepository swapAdvertRepository, IMapper mapper)
        {
            _swapAdvertRepository = swapAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSwapAdvertListItemDto>> Handle(GetListSwapAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<SwapAdvert> paginate = await _swapAdvertRepository.GetListByPaginateAsync(
                 index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: i => i.Include(i => i.Advert)
                .Include(i => i.Advert.Address.Country)
                .Include(i => i.Advert.Address.City)
                .Include(i => i.Advert.Address.District)
                .Include(i => i.Advert.Address.Neighbourhood)
                .Include(i => i.Advert.Product.Brand)
                .Include(i => i.Advert.Product.Category)
                .Include(i => i.IndividualUser),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListSwapAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListSwapAdvertListItemDto>>(paginate);
            return getListResponse;
        }
    }
}
