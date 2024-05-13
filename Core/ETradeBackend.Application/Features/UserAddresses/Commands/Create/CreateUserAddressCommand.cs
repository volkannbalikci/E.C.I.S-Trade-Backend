using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserAddresses.Commands.Create;

public class CreateUserAddressCommand : IRequest<CreatedUserAddressResponse>
{
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

    public Guid UserId { get; set; }
    public  bool IsMain { get; set; }       


    public class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, CreatedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IAddressRepository _addressRepository;

        public CreateUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
            _addressRepository = addressRepository;
        }

        public async Task<CreatedUserAddressResponse> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            Address address = _mapper.Map<Address>(request);
            address.Id = Guid.NewGuid();
            UserAddress userAddress = _mapper.Map<UserAddress>(request);
            await _addressRepository.AddAsync(address);
            userAddress.Id = Guid.NewGuid();
            userAddress.AddressId = address.Id;
            await _userAddressRepository.AddAsync(userAddress);
            CreatedUserAddressResponse createdUserAddressResponse = _mapper.Map<CreatedUserAddressResponse>(userAddress);
            return createdUserAddressResponse;
        }
    }
}
