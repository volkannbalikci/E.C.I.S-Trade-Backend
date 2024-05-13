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

namespace ETradeBackend.Application.Features.UserAddresses.Queries.GetById;

public class GetByIdUserAddressQuery : IRequest<GetByIdUserAddressResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserAddressQueryHandler : IRequestHandler<GetByIdUserAddressQuery, GetByIdUserAddressResponse>
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public GetByIdUserAddressQueryHandler(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserAddressResponse> Handle(GetByIdUserAddressQuery request, CancellationToken cancellationToken)
        {
            UserAddress userAddress = await _userAddressRepository.GetAsync(
                predicate: u => u.Id == request.Id,
                include: u => u.Include(u => u.Address),
                cancellationToken: cancellationToken
                );
            GetByIdUserAddressResponse getByIdUserAddressResponse = _mapper.Map<GetByIdUserAddressResponse>(userAddress);
            return getByIdUserAddressResponse;
        }
    }
}
