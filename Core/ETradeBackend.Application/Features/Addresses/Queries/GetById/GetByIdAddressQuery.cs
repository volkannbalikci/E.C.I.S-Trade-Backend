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

namespace ETradeBackend.Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressQuery : IRequest<GetByIdAddressResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GetByIdAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetByIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAddressResponse> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            Address address = await _addressRepository.GetAsync(
                predicate: a => a.Id == request.Id,
                include: a => a.Include(a => a.Country)
                .Include(a => a.City)
                .Include(a => a.District)
                .Include(a => a.Neighbourhood)
                );
            GetByIdAddressResponse getByIdAddressResponse = _mapper.Map<GetByIdAddressResponse>(address);
            return getByIdAddressResponse;
        }
    }
}
