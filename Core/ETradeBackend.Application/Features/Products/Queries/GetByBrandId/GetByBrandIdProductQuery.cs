using AutoMapper;
using ETradeBackend.Application.Features.Products.Queries.GetByCategoryId;
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

namespace ETradeBackend.Application.Features.Products.Queries.GetByBrandId;

public class GetByBrandIdProductQuery : IRequest<GetListResponse<GetByBrandIdProductListItemDto>>
{
    public Guid BrandId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetByBrandIdProductQueryHandler : IRequestHandler<GetByBrandIdProductQuery, GetListResponse<GetByBrandIdProductListItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByBrandIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetByBrandIdProductListItemDto>> Handle(GetByBrandIdProductQuery request, CancellationToken cancellationToken)
        {
            Paginate<Product> products = await _productRepository.GetListByPaginateAsync(
                 include: p => p.Include(p => p.Brand).Include(p => p.Category),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                predicate: p => p.BrandId == request.BrandId,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetByBrandIdProductListItemDto> getListResponse = _mapper.Map<GetListResponse<GetByBrandIdProductListItemDto>>(products);
            return getListResponse;
        }
    }
}
