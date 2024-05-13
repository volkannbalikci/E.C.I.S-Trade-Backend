using AutoMapper;
using ETradeBackend.Application.Features.IndividualAdverts.Queries.GetById;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Queries.GetById;

public class GetByIdSwapAdvertQuery : IRequest<GetByIdSwapAdvertResponse>
{
    public Guid SwapAdvertId { get; set; }

    public class GetByIdSwapAdvertQueryHandler : IRequestHandler<GetByIdSwapAdvertQuery, GetByIdSwapAdvertResponse>
    {
        private readonly ISwapAdvertRepository _swapAdvertRepository;
        private readonly IMapper _mapper;

        public GetByIdSwapAdvertQueryHandler(ISwapAdvertRepository swapAdvertRepository, IMapper mapper)
        {
            _swapAdvertRepository = swapAdvertRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdSwapAdvertResponse> Handle(GetByIdSwapAdvertQuery request, CancellationToken cancellationToken)
        {
            SwapAdvert swapAdvert = await _swapAdvertRepository.GetAsync(
                predicate: s => s.Id == request.SwapAdvertId,
                 include: i => i.Include(i => i.Advert)
                .Include(i => i.Advert.Address.Country)
                .Include(i => i.Advert.Address.City)
                .Include(i => i.Advert.Address.District)
                .Include(i => i.Advert.Address.Neighbourhood)
                .Include(i => i.Advert.Product.Brand)
                .Include(i => i.Advert.Product.Category)
                .Include(i => i.IndividualUser),
                 cancellationToken: cancellationToken
                );
            GetByIdSwapAdvertResponse getByIdSwapAdvertResponse = _mapper.Map<GetByIdSwapAdvertResponse>(swapAdvert);
            return getByIdSwapAdvertResponse;
        }
    }
}
