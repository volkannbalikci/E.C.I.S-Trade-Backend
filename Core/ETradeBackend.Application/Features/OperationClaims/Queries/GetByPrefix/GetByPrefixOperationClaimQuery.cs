using AutoMapper;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetById;
using ETradeBackend.Application.Features.OperationClaims.Queries.GetList;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Requests;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ETradeBackend.Application.Features.OperationClaims.Queries.GetByPrefix.GetListByPrefixOperationClaimQuery;

namespace ETradeBackend.Application.Features.OperationClaims.Queries.GetByPrefix
{
    public class GetListByPrefixOperationClaimQuery : IRequest<GetListResponse<GetListByPrefixOperationClaimListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        public String Prefix { get; set; }

        public class GetListByPrefixOperationClaimQueryHandler : IRequestHandler<GetListByPrefixOperationClaimQuery, GetListResponse<GetListByPrefixOperationClaimListItemDto>>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetListByPrefixOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListByPrefixOperationClaimListItemDto>> Handle(GetListByPrefixOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IQueryable<OperationClaim> operationClaims = _operationClaimRepository.GetListByQueryable();

                List<OperationClaim> filteredperationClaims = this.GetFilteredListByPrefix(operationClaims, request.Prefix);

                IQueryable<OperationClaim> filteredQueryable = filteredperationClaims.AsQueryable<OperationClaim>();

                Paginate<OperationClaim> paginate = filteredQueryable.ToPaginate(request.PageRequest.PageIndex, request.PageRequest.PageSize);

                GetListResponse<GetListByPrefixOperationClaimListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListByPrefixOperationClaimListItemDto>>(paginate);
                return getListResponse;
            }

            private List<OperationClaim> GetFilteredListByPrefix(IQueryable<OperationClaim> operationClaims, String prefix)
            {
                List<OperationClaim> filteredOperationClaims = new List<OperationClaim>();

                foreach (var operationClaim in operationClaims)
                {
                    if (this.GetOperationClaimPrefix(operationClaim).Equals(prefix))
                        filteredOperationClaims.Add(operationClaim);

                }

                return filteredOperationClaims;
            }

            private String GetOperationClaimPrefix(OperationClaim operationClaim) => operationClaim.Name.Split('.')[0];
        }
    }
}
