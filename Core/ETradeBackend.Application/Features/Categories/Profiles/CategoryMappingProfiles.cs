using AutoMapper;
using ETradeBackend.Application.Features.Categories.Commands.Create;
using ETradeBackend.Application.Features.Categories.Commands.Delete;
using ETradeBackend.Application.Features.Categories.Commands.Update;
using ETradeBackend.Application.Features.Categories.Queries.GetById;
using ETradeBackend.Application.Features.Categories.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Categories.Profiles;

public class CategoryMappingProfiles : Profile
{
    public CategoryMappingProfiles()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
        CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();

        CreateMap<Paginate<Category>, GetListResponse<GetListCategoryListItemDto>>().ReverseMap();
        CreateMap<Category, GetListCategoryListItemDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();
    }
}
