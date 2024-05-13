using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<DeletedProductResponse>
{
    public Guid Id { get; set; }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<DeletedProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetAsync(p => p.Id == request.Id);
            await _productRepository.DeleteAsync(product);
            DeletedProductResponse deletedProductResponse = _mapper.Map<DeletedProductResponse>(product);
            return deletedProductResponse;
        }
    }
}
