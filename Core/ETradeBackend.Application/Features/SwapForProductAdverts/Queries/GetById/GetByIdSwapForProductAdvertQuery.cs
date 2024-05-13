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

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Queries.GetById;

public class GetByIdSwapForProductAdvertQuery : IRequest<GetByIdSwapForProductAdvertResponse>
{
    public Guid SwapForProductAdvertId { get; set; }

    public class GetByIdSwapForProductAdvertQueryHandler : IRequestHandler<GetByIdSwapForProductAdvertQuery, GetByIdSwapForProductAdvertResponse>
    {
        private readonly ISwapForProductAdvertRepository _swapForProductAdvertRepository;
        private readonly IMapper _mapper;

        public GetByIdSwapForProductAdvertQueryHandler(ISwapForProductAdvertRepository swapForProductAdvertRepository, IMapper mapper)
        {
            _swapForProductAdvertRepository = swapForProductAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdSwapForProductAdvertResponse> Handle(GetByIdSwapForProductAdvertQuery request, CancellationToken cancellationToken)
        {
            SwapForProductAdvert? swapForProductAdvert = await _swapForProductAdvertRepository.GetAsync(
                predicate: s => s.Id == request.SwapForProductAdvertId,
                include: i => i.Include(i => i.SwapAdvert.Advert)
           .Include(i => i.SwapAdvert.Advert.Address.Country)
           .Include(i => i.SwapAdvert.Advert.Address.City)
           .Include(i => i.SwapAdvert.Advert.Address.District)
           .Include(i => i.SwapAdvert.Advert.Address.Neighbourhood)
           .Include(i => i.SwapAdvert.Advert.Product)
           .Include(i => i.SwapAdvert.Advert.Product.Brand)
           .Include(i => i.SwapAdvert.Advert.Product.Category)
           .Include(i => i.SwapAdvert.IndividualUser)
           .Include(i => i.DesiredProduct)
           .Include(i => i.DesiredProduct.Brand)
           .Include(i => i.DesiredProduct.Category),
           cancellationToken: cancellationToken
                );

            GetByIdSwapForProductAdvertResponse getByIdSwapForProductAdvertResponse = _mapper.Map<GetByIdSwapForProductAdvertResponse>(swapForProductAdvert);
            return getByIdSwapForProductAdvertResponse;
        }
    }
}
