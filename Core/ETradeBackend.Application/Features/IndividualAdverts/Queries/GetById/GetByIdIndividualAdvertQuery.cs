using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualAdverts.Queries.GetById;

public class GetByIdIndividualAdvertQuery : IRequest<GetByIdIndividualAdvertResponse>
{
    public Guid IndividualAdvertId { get; set; }

    public class GetByIdIndividualAdvertCommandHandler : IRequestHandler<GetByIdIndividualAdvertQuery, GetByIdIndividualAdvertResponse>
    {
        private readonly IIndividualAdvertRepository _individualAdvertRepository;
        private readonly IMapper _mapper;

        public GetByIdIndividualAdvertCommandHandler(IIndividualAdvertRepository individualAdvertRepository, IMapper mapper)
        {
            _individualAdvertRepository = individualAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdIndividualAdvertResponse> Handle(GetByIdIndividualAdvertQuery request, CancellationToken cancellationToken)
        {
            IndividualAdvert individualAdvert = await _individualAdvertRepository.GetAsync(
                predicate: i => i.Id == request.IndividualAdvertId,
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
            GetByIdIndividualAdvertResponse getByIdIndividualAdvertResponse = _mapper.Map<GetByIdIndividualAdvertResponse>(individualAdvert);
            return getByIdIndividualAdvertResponse;
        }
    }
}
