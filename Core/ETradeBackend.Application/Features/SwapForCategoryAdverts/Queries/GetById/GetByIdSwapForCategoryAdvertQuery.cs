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

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Queries.GetById;

public class GetByIdSwapForCategoryAdvertQuery : IRequest<GetByIdSwapForCategoryAdvertResponse>
{
    public Guid SwapForCategoryAdvertId { get; set; }

    public class GetByIdSwapForCategoryQueryHandler : IRequestHandler<GetByIdSwapForCategoryAdvertQuery, GetByIdSwapForCategoryAdvertResponse>
    {
        private readonly ISwapForCategoryAdvertRepository _swapForCategoryAdvertRepository;
        private readonly IMapper _mapper;

        public GetByIdSwapForCategoryQueryHandler(ISwapForCategoryAdvertRepository swapForCategoryAdvertRepository, IMapper mapper)
        {
            _swapForCategoryAdvertRepository = swapForCategoryAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdSwapForCategoryAdvertResponse> Handle(GetByIdSwapForCategoryAdvertQuery request, CancellationToken cancellationToken)
        {
            SwapForCategoryAdvert swapForCategoryAdvert = await _swapForCategoryAdvertRepository.GetAsync(
                predicate: s => s.Id == request.SwapForCategoryAdvertId,
                include: s => s.Include(s => s.SwapAdvert.Advert)
                .Include(s => s.SwapAdvert.Advert.Address)
                .Include(s => s.SwapAdvert.Advert.Address.Country)
                .Include(s => s.SwapAdvert.Advert.Address.City)
                .Include(s => s.SwapAdvert.Advert.Address.District)
                .Include(s => s.SwapAdvert.Advert.Address.Neighbourhood)
                .Include(s => s.SwapAdvert.Advert.Product)
                .Include(s => s.SwapAdvert.Advert.Product.Brand)
                .Include(s => s.SwapAdvert.Advert.Product.Category)
                .Include(s => s.SwapAdvert.IndividualUser)
                .Include(s => s.DesiredCategory),
                cancellationToken: cancellationToken
                );

            GetByIdSwapForCategoryAdvertResponse getByIdSwapForCategoryAdvertResponse = _mapper.Map<GetByIdSwapForCategoryAdvertResponse>(swapForCategoryAdvert);
            return getByIdSwapForCategoryAdvertResponse;
            
        }
    }
}
