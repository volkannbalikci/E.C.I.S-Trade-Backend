using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualUsers.Queries.GetById;

public class GetByIdIndividualUserQuery : IRequest<GetByIdIndividualUserResponse>
{
    public Guid Id { get; set; }

    public class GetByIdIndividualUserQueryHandler : IRequestHandler<GetByIdIndividualUserQuery, GetByIdIndividualUserResponse>
    {
        private readonly IIndividualUserRepository _ındividualUserRepository;
        private readonly IMapper _mapper;

        public GetByIdIndividualUserQueryHandler(IIndividualUserRepository ındividualUserRepository, IMapper mapper)
        {
            _ındividualUserRepository = ındividualUserRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdIndividualUserResponse> Handle(GetByIdIndividualUserQuery request, CancellationToken cancellationToken)
        {
            IndividualUser individualUser = await _ındividualUserRepository.GetAsync(i => i.Id == request.Id);
            GetByIdIndividualUserResponse getByIdIndividualUserResponse = _mapper.Map<GetByIdIndividualUserResponse>(individualUser);
            return getByIdIndividualUserResponse;
        }
    }
}
