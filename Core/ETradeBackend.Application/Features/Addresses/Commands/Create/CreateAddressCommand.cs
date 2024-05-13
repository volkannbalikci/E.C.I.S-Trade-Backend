using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Addresses.Commands.Create;

public class CreateAddressCommand : IRequest<CreatedAddressResponse>
{
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            this._addressRepository = addressRepository;
        }

        public async Task<CreatedAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);
            address.Id = Guid.NewGuid();
            await _addressRepository.AddAsync(address);
            CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(address);
            return createdAddressResponse;
        }
    }
}
