using AutoMapper;
using ETradeBackend.Application.Features.Brands.Commands.Create;
using ETradeBackend.Application.Features.Brands.Commands.Delete;
using ETradeBackend.Application.Features.Brands.Commands.Update;
using ETradeBackend.Application.Features.Brands.Queries.GetById;
using ETradeBackend.Application.Features.Brands.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Brands.Profiles;

public class BrandMappingProfiles : Profile
{
    public BrandMappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        CreateMap<Brand, DeletedBrandResponse>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();

        CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
        CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
        CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
    }
}
