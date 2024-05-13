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

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Queries.GetList;

public class GetListSwapForCategoryAdvertQuery : IRequest<GetListResponse<GetListSwapForCategoryAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSwapForCategoryAdvertQueryHandler : IRequestHandler<GetListSwapForCategoryAdvertQuery, GetListResponse<GetListSwapForCategoryAdvertListItemDto>>
    {
        private readonly ISwapForCategoryAdvertRepository _swapForCategoryAdvertRepository;
        private readonly IMapper _mapper;

        public GetListSwapForCategoryAdvertQueryHandler(ISwapForCategoryAdvertRepository swapForCategoryAdvertRepository, IMapper mapper)
        {
            _swapForCategoryAdvertRepository = swapForCategoryAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSwapForCategoryAdvertListItemDto>> Handle(GetListSwapForCategoryAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<SwapForCategoryAdvert> paginate = await _swapForCategoryAdvertRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: s => s.Include(s => s.SwapAdvert.Advert)
                .Include(s => s.SwapAdvert.Advert.Address)
                .Include(s => s.SwapAdvert.Advert.Address.Country)
                .Include(s => s.SwapAdvert.Advert.Address.City)
                .Include(s => s.SwapAdvert.Advert.Address.District)
                .Include(s => s.SwapAdvert.Advert.Address.Neighbourhood)
                .Include(s => s.SwapAdvert.Advert.Product)
                .Include(s => s.SwapAdvert.Advert.Product.Brand)
                .Include(s => s.SwapAdvert.Advert.Product.Category)
                .Include(s => s.SwapAdvert.IndividualUser)
                .Include(s => s.DesiredCategory),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListSwapForCategoryAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListSwapForCategoryAdvertListItemDto>>(paginate);
            return getListResponse;
        }
    }
}
