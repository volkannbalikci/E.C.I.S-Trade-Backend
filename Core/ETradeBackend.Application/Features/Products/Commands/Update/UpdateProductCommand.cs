using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Products.Commands.Update;

public class UpdateProductCommand : IRequest<UpdatedProductResponse>
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetAsync(p => p.Id == request.Id);
            product = _mapper.Map(request, product);
            await _productRepository.UpdateAsync(product);
            UpdatedProductResponse updatedProductResponse = _mapper.Map<UpdatedProductResponse>(product);
            return updatedProductResponse;
        }
    }
}
