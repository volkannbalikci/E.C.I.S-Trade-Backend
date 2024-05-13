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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Queries.GetList;

public class GetListCorporateAdvertQuery : IRequest<GetListResponse<GetListCorporateAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCorporateUserQueryHandler : IRequestHandler<GetListCorporateAdvertQuery, GetListResponse<GetListCorporateAdvertListItemDto>>
    {
        private readonly ICorporateAdvertRepository _corporateAdvertRepository;
        private readonly IMapper _mapper;

        public GetListCorporateUserQueryHandler(ICorporateAdvertRepository corporateAdvertRepository, IMapper mapper)
        {
            _corporateAdvertRepository = corporateAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCorporateAdvertListItemDto>> Handle(GetListCorporateAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<CorporateAdvert> paginate = await _corporateAdvertRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.Advert)
                .Include(c => c.Advert.Address)
                .Include(c => c.Advert.Address.Country)
                .Include(c => c.Advert.Address.City)
                .Include(c => c.Advert.Address.District)
                .Include(c => c.Advert.Address.Neighbourhood)
                .Include(c => c.Advert.Product)
                .Include(c => c.Advert.Product.Brand)
                .Include(c => c.Advert.Product.Category)
                .Include(c => c.CorporateUser),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListCorporateAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCorporateAdvertListItemDto>>(paginate);
            return getListResponse;
        }
    }
}
