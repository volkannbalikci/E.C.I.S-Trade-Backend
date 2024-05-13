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

namespace ETradeBackend.Application.Features.Adverts.Queries.GetList;

public class GetListAdvertQuery : IRequest<GetListResponse<GetListAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAdvertQueryHandler : IRequestHandler<GetListAdvertQuery, GetListResponse<GetListAdvertListItemDto>>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public GetListAdvertQueryHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvertListItemDto>> Handle(GetListAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<Advert> adverts = await _advertRepository.GetListByPaginateAsync(
                include: a => a
                .Include(a => a.Address.Country)
                .Include(a => a.Address.City)
                .Include(a => a.Address.District)
                .Include(a => a.Address.Neighbourhood)
                .Include(a => a.Product.Brand)
                .Include(a => a.Product.Category),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetListAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListAdvertListItemDto>>(adverts);
            return getListResponse;
        }
    }
}