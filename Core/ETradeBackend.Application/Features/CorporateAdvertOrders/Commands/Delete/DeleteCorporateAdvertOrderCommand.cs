using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrders.Commands.Delete;

public class DeleteCorporateAdvertOrderCommand : IRequest<DeletedCorporateAdvertOrderResponse>
{
    public Guid Id { get; set; }


    public class DeleteCorporateAdvertOrderCommandHandler : IRequestHandler<DeleteCorporateAdvertOrderCommand, DeletedCorporateAdvertOrderResponse>
    {
        private readonly ICorporateAdvertOrderRepository _corporateAdvertOrderRepository;
        private readonly IMapper _mapper;

        public DeleteCorporateAdvertOrderCommandHandler(ICorporateAdvertOrderRepository corporateAdvertOrderRepository, IMapper mapper)
        {
            _corporateAdvertOrderRepository = corporateAdvertOrderRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCorporateAdvertOrderResponse> Handle(DeleteCorporateAdvertOrderCommand request, CancellationToken cancellationToken)
        {
            CorporateAdvertOrder? corporateAdvertOrder = await _corporateAdvertOrderRepository.GetAsync(c => c.Id == request.Id);
            await _corporateAdvertOrderRepository.DeleteAsync(corporateAdvertOrder);

            DeletedCorporateAdvertOrderResponse deletedCorporateAdvertOrderResponse = _mapper.Map<DeletedCorporateAdvertOrderResponse>(corporateAdvertOrder);
            return deletedCorporateAdvertOrderResponse;
        }
    }
}
