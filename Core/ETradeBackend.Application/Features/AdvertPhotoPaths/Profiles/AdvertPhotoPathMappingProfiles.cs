using AutoMapper;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Create;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Delete;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Update;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Queries.GetById;
using ETradeBackend.Application.Features.AdvertPhotoPaths.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertPhotoPaths.Profiles;

public class AdvertPhotoPathMappingProfiles : Profile
{
    public AdvertPhotoPathMappingProfiles()
    {
        CreateMap<AdvertPhotoPath, CreateAdvertPhotoPathCommand>().ReverseMap();
        CreateMap<AdvertPhotoPath, CreatedAdvertPhotoPathResponse>().ReverseMap();
        CreateMap<AdvertPhotoPath, DeleteAdvertPhotoPathCommand>().ReverseMap();
        CreateMap<AdvertPhotoPath, DeletedAdvertPhotoPathResponse>().ReverseMap();
        CreateMap<AdvertPhotoPath, UpdateAdvertPhotoPathCommand>().ReverseMap();
        CreateMap<AdvertPhotoPath, UpdatedAdvertPhotoPathResponse>().ReverseMap();

        CreateMap<Paginate<AdvertPhotoPath>, GetListResponse<GetListAdvertPhotoPathListItemDto>>().ReverseMap();
        CreateMap<AdvertPhotoPath, GetListAdvertPhotoPathListItemDto>().ReverseMap();
        CreateMap<AdvertPhotoPath, GetByIdAdvertPhotoPathResponse>().ReverseMap();
    }
}
