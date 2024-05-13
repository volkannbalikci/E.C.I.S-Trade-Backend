using AutoMapper;
using ETradeBackend.Application.Features.Addresses.Commands.Create;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommand : IRequest<UpdatedAddressResponse>
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdatedAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = await _addressRepository.GetAsync(p => p.Id == request.Id);
            address = _mapper.Map(request,address);    
            await _addressRepository.UpdateAsync(address);
            UpdatedAddressResponse updatedAddressResponse = _mapper.Map<UpdatedAddressResponse>(address);
            return updatedAddressResponse;
        }
    }
}
