using AutoMapper;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetById;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Queries.GetByI;

public class GetByIdCorporateAdvertQuery : IRequest<GetByIdCorporateAdvertResponse>
{
    public Guid CorporateAdvertId { get; set; }

    public class GetByIdCorporateAdvertQueryHandler : IRequestHandler<GetByIdCorporateAdvertQuery, GetByIdCorporateAdvertResponse>
    {
        private readonly ICorporateAdvertRepository _corporateAdvertRepository;
        private readonly IMapper _mapper;

        public GetByIdCorporateAdvertQueryHandler(ICorporateAdvertRepository corporateAdvertRepository, IMapper mapper)
        {
            _corporateAdvertRepository = corporateAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCorporateAdvertResponse> Handle(GetByIdCorporateAdvertQuery request, CancellationToken cancellationToken)
        {
            CorporateAdvert corporateAdvert = await _corporateAdvertRepository.GetAsync(
                predicate: c => c.Id == request.CorporateAdvertId,
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
            GetByIdCorporateAdvertResponse getByIdCorporateAdvertResponse = _mapper.Map<GetByIdCorporateAdvertResponse>(corporateAdvert);
            return getByIdCorporateAdvertResponse;

        }
    }
}
