using AutoMapper;
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

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Queries.GetList;

public class GetListSwapForProductAdvertQuery : IRequest<GetListResponse<GetListSwapForProductAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSwapForProductAdvertQueryHandler : IRequestHandler<GetListSwapForProductAdvertQuery, GetListResponse<GetListSwapForProductAdvertListItemDto>>
    {
        private readonly ISwapForProductAdvertRepository _swapForProductAdvertRepository;
        private readonly IMapper _mapper;

        public GetListSwapForProductAdvertQueryHandler(ISwapForProductAdvertRepository swapForProductAdvertRepository, IMapper mapper)
        {
            _swapForProductAdvertRepository = swapForProductAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSwapForProductAdvertListItemDto>> Handle(GetListSwapForProductAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<SwapForProductAdvert> paginate = await _swapForProductAdvertRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: i => i.Include(i => i.SwapAdvert.Advert)
           .Include(i => i.SwapAdvert.Advert.Address.Country)
           .Include(i => i.SwapAdvert.Advert.Address.City)
           .Include(i => i.SwapAdvert.Advert.Address.District)
           .Include(i => i.SwapAdvert.Advert.Address.Neighbourhood)
           .Include(i => i.SwapAdvert.Advert.Product)
           .Include(i => i.SwapAdvert.Advert.Product.Brand)
           .Include(i => i.SwapAdvert.Advert.Product.Category)
           .Include(i => i.SwapAdvert.IndividualUser)
           .Include(i => i.DesiredProduct)
           .Include(i => i.DesiredProduct.Brand)
           .Include(i => i.DesiredProduct.Category),
           cancellationToken: cancellationToken
                );

            GetListResponse<GetListSwapForProductAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListSwapForProductAdvertListItemDto>>(paginate);
            return getListResponse;
        }
    }
}
