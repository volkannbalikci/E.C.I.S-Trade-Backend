using AutoMapper;
using ETradeBackend.Application.Features.Brands.Queries.GetById;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetById;

public class GetByIdCorporateAdvertOrderItemQuery : IRequest<GetByIdCorporateAdvertOrderItemResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCorporateAdvertQueryHandler : IRequestHandler<GetByIdCorporateAdvertOrderItemQuery, GetByIdCorporateAdvertOrderItemResponse>
    {
        private readonly ICorporateAdvertOrderItemRepository _corporateAdvertOrderItemRepository;
        private readonly IMapper _mapper;

        public GetByIdCorporateAdvertQueryHandler(ICorporateAdvertOrderItemRepository corporateAdvertOrderItemRepository, IMapper mapper)
        {
            _corporateAdvertOrderItemRepository = corporateAdvertOrderItemRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCorporateAdvertOrderItemResponse> Handle(GetByIdCorporateAdvertOrderItemQuery request, CancellationToken cancellationToken)
        {
            CorporateAdvertOrderItem corporateAdvertOrderItem = await _corporateAdvertOrderItemRepository.GetAsync(
                    predicate: c => c.Id == request.Id,
                    include: c => c.Include(c => c.CorporateAdvert.Advert),
                    cancellationToken: cancellationToken
            );
            GetByIdCorporateAdvertOrderItemResponse getByIdCorporateAdvertOrderItemResponse = _mapper.Map<GetByIdCorporateAdvertOrderItemResponse>(corporateAdvertOrderItem);
            return getByIdCorporateAdvertOrderItemResponse;
        }
    }
}
