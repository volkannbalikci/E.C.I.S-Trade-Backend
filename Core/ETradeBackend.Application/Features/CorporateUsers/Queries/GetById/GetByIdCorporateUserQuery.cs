using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateUsers.Queries.GetById;

public class GetByIdCorporateUserQuery : IRequest<GetByIdCorporateUserResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCorporateUserQueryHandler : IRequestHandler<GetByIdCorporateUserQuery, GetByIdCorporateUserResponse>
    {
        private readonly ICorporateUserRepository _corporateUserRepository;
        private readonly IMapper _mapper;

        public GetByIdCorporateUserQueryHandler(ICorporateUserRepository corporateUserRepository, IMapper mapper)
        {
            _corporateUserRepository = corporateUserRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCorporateUserResponse> Handle(GetByIdCorporateUserQuery request, CancellationToken cancellationToken)
        {
            CorporateUser corporateUser = await _corporateUserRepository.GetAsync(
                predicate: c => c.Id == request.Id
                );
            GetByIdCorporateUserResponse getByIdCorporateUserResponse = _mapper.Map<GetByIdCorporateUserResponse>(corporateUser);
            return getByIdCorporateUserResponse;
        }
    }
}
