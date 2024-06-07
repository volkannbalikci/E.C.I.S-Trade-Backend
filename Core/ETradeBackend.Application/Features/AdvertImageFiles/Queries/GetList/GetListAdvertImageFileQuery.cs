using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertImageFiles.Queries.GetList;

public class GetListAdvertImageFileQuery : IRequest<List<GetListAdvertImageFileListItemDto>>
{
    public Guid AdvertId { get; set; }

    public class GetListAdvertImageFileQueryHandler : IRequestHandler<GetListAdvertImageFileQuery, List<GetListAdvertImageFileListItemDto>>
    {
        readonly IAdvertRepository _advertRepository;
        readonly IConfiguration configuration;

        public GetListAdvertImageFileQueryHandler(IAdvertRepository advertRepository, IConfiguration configuration)
        {
            _advertRepository = advertRepository;
            this.configuration = configuration;
        }

        public async Task<List<GetListAdvertImageFileListItemDto>> Handle(GetListAdvertImageFileQuery request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(
                predicate: a => a.Id == request.AdvertId,
                include: a => a.Include(a => a.AdvertImageFiles)
                );
           return advert?.AdvertImageFiles.Select(a => new GetListAdvertImageFileListItemDto
            {
                Path = $"{configuration["BaseStorageUrl"]}/{a.Path}",
                FileName = a.FileName,
                Id = a.Id
            }).ToList();         
        }
    }
}
