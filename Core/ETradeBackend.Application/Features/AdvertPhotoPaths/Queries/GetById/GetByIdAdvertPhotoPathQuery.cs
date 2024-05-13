using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertPhotoPaths.Queries.GetById;

public class GetByIdAdvertPhotoPathQuery : IRequest<GetByIdAdvertPhotoPathResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAdvertPhotoPathQueryHandler : IRequestHandler<GetByIdAdvertPhotoPathQuery, GetByIdAdvertPhotoPathResponse>
    {
        private readonly IAdvertPhotoPathRepository _advertPhotoPathRepository;
        private readonly IMapper _mapper;

        public GetByIdAdvertPhotoPathQueryHandler(IAdvertPhotoPathRepository advertPhotoPathRepository, IMapper mapper)
        {
            _advertPhotoPathRepository = advertPhotoPathRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAdvertPhotoPathResponse> Handle(GetByIdAdvertPhotoPathQuery request, CancellationToken cancellationToken)
        {
            AdvertPhotoPath advertPhotoPath = await _advertPhotoPathRepository.GetAsync(
                predicate: a => a.Id == request.Id
                );
            GetByIdAdvertPhotoPathResponse getByIdAdvertPhotoPathResponse = _mapper.Map<GetByIdAdvertPhotoPathResponse>(advertPhotoPath);
            return getByIdAdvertPhotoPathResponse;
        }
    }
}
