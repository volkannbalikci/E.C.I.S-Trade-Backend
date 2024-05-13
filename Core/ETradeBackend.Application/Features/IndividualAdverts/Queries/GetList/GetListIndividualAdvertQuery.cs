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

namespace ETradeBackend.Application.Features.IndividualAdverts.Queries.GetList;

public class GetListIndividualAdvertQuery : IRequest<GetListResponse<GetListIndividualAdvertListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListIndividualAdvertQueryHandler : IRequestHandler<GetListIndividualAdvertQuery, GetListResponse<GetListIndividualAdvertListItemDto>>
    {
        private readonly IIndividualAdvertRepository _individualAdvertRepository;
        private readonly IMapper _mapper;

        public GetListIndividualAdvertQueryHandler(IIndividualAdvertRepository individualAdvertRepository, IMapper mapper)
        {
            _individualAdvertRepository = individualAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListIndividualAdvertListItemDto>> Handle(GetListIndividualAdvertQuery request, CancellationToken cancellationToken)
        {
            Paginate<IndividualAdvert> paginate = await _individualAdvertRepository.GetListByPaginateAsync(
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
            GetListResponse<GetListIndividualAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListIndividualAdvertListItemDto>>(paginate);
            return getListResponse;
        }
    }
}
