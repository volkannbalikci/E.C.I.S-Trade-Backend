using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserAddresses.Commands.Update;

public class UpdateUserAddressCommand : IRequest<UpdatedUserAddressResponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public bool IsMain { get; set; }

    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, UpdatedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;

        public UpdateUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<UpdatedUserAddressResponse> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            UserAddress userAddress = await _userAddressRepository.GetAsync(u => u.Id == request.Id);
            userAddress = _mapper.Map(request, userAddress);
            await _userAddressRepository.UpdateAsync(userAddress);
            UpdatedUserAddressResponse updatedUserAddressResponse = _mapper.Map<UpdatedUserAddressResponse>(request);
            return updatedUserAddressResponse;
        }
    }
}
