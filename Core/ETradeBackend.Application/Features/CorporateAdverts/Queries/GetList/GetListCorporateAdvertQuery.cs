using AutoMapper;
using ETradeBackend.Application.Features.AdvertImageFiles.Queries.GetList;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IAdvertImageFileRepository _advertImageFileRepository;
        readonly IConfiguration configuration;
        private readonly IMapper _mapper;

        public GetListCorporateUserQueryHandler(ICorporateAdvertRepository corporateAdvertRepository, IMapper mapper, IAdvertImageFileRepository advertImageFileRepository, IConfiguration configuration)
        {
            _corporateAdvertRepository = corporateAdvertRepository;
            _mapper = mapper;
            _advertImageFileRepository = advertImageFileRepository;
            this.configuration = configuration;
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
                .Include(c => c.CorporateUser)
                .Include(c => c.Advert.AdvertImageFiles),
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListCorporateAdvertListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCorporateAdvertListItemDto>>(paginate);
            foreach (var item in getListResponse.Items)
            {
                item.Images = _advertImageFileRepository.GetListByQueryable(predicate: a => a.AdvertId == item.AdvertId).Select(a => new GetListAdvertImageFileListItemDto
                {
                    Path = $"{configuration["BaseStorageUrl"]}/{a.Path}",
                    FileName = a.FileName,
                    Id = a.Id
                }).ToList();
            }
            return getListResponse;
        }
    }
}
