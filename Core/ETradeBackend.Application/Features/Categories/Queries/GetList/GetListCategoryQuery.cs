using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery : IRequest<GetListResponse<GetListCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, GetListResponse<GetListCategoryListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public GetListCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetListResponse<GetListCategoryListItemDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Category> categories = await _categoryRepository.GetListByPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            GetListResponse<GetListCategoryListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListCategoryListItemDto>>(categories);
            return getListResponse;
        }
    }
}
