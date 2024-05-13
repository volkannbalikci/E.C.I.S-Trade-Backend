using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserAddresses.Commands.Delete;

public class DeleteUserAddressCommand : IRequest<DeletedUserAddressResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommand, DeletedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;

        public DeleteUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<DeletedUserAddressResponse> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            UserAddress userAddress = await _userAddressRepository.GetAsync(u => u.Id == request.Id);
            await _userAddressRepository.DeleteAsync(userAddress);
            DeletedUserAddressResponse deletedUserAddressResponse = _mapper.Map<DeletedUserAddressResponse>(request);
            return deletedUserAddressResponse;
        }
    }
}
