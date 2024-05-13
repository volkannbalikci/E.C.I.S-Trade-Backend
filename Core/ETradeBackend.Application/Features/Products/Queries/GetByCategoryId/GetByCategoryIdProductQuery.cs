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

namespace ETradeBackend.Application.Features.Products.Queries.GetByCategoryId;

public class GetByCategoryIdProductQuery : IRequest<GetListResponse<GetByCategoryIdProductListItemDto>>
{
    public Guid CategoryId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetByCategoryIdProductQueryHandler : IRequestHandler<GetByCategoryIdProductQuery, GetListResponse<GetByCategoryIdProductListItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByCategoryIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetByCategoryIdProductListItemDto>> Handle(GetByCategoryIdProductQuery request, CancellationToken cancellationToken)
        {
            Paginate<Product> products = await _productRepository.GetListByPaginateAsync(
                include: p => p.Include(p => p.Brand).Include(p => p.Category),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                predicate: p => p.CategoryId == request.CategoryId,
                cancellationToken: cancellationToken
    );
            GetListResponse<GetByCategoryIdProductListItemDto> getListResponse = _mapper.Map<GetListResponse<GetByCategoryIdProductListItemDto>>(products);
            return getListResponse;
        }
    }
}
