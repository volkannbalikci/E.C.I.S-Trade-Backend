using AutoMapper;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Update;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetById;
using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetList;
using ETradeBackend.Application.Features.CorporateAdverts.Commands.Create;
using ETradeBackend.Application.Features.CorporateAdverts.Commands.Delete;
using ETradeBackend.Application.Features.CorporateAdverts.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Profiles;

public class CorporateAdvertOrderItemMappingProfiles : Profile
{
    public CorporateAdvertOrderItemMappingProfiles()
    {
        CreateMap<CorporateAdvertOrderItem, CreateCorporateAdvertOrderItemCommand>().ReverseMap();
        CreateMap<CorporateAdvertOrderItem, CreatedCorporateAdvertOrderItemResponse>().ReverseMap();
        CreateMap<CorporateAdvertOrderItem, DeleteCorporateAdvertOrderItemCommand>().ReverseMap();
        CreateMap<CorporateAdvertOrderItem, DeletedCorporateAdvertOrderItemResponse>().ReverseMap();
        CreateMap<CorporateAdvertOrderItem, UpdateCorporateAdvertOrderItemCommand>().ReverseMap();
        CreateMap<CorporateAdvertOrderItem, UpdatedCorporateAdvertOrderItemResponse>().ReverseMap();

        CreateMap<Paginate<CorporateAdvertOrderItem>, GetListResponse<GetListCorporateAdvertOrderItemListItemDto>>().ReverseMap();
        CreateMap<CorporateAdvertOrderItem, GetListCorporateAdvertOrderItemListItemDto>()
                       .ForMember(destinationMember: i => i.CorporateAdvertOrderId, memberOptions: opt => opt.MapFrom(i => i.CorporateAdvertOrderId))
                       .ForMember(destinationMember: i => i.CorporateAdvertOrderItemId, memberOptions: opt => opt.MapFrom(i => i.Id))
                       .ForMember(destinationMember: i => i.AdvertTitle, memberOptions: opt => opt.MapFrom(i => i.CorporateAdvert.Advert.Title))
                       .ForMember(destinationMember: i => i.Amount, memberOptions: opt => opt.MapFrom(i => i.Amount))
                       .ForMember(destinationMember: i => i.TotalPrice, memberOptions: opt => opt.MapFrom(i => i.TotalPrice)).ReverseMap();

        CreateMap<CorporateAdvertOrderItem, GetByIdCorporateAdvertOrderItemResponse>()
               .ForMember(destinationMember: i => i.CorporateAdvertOrderId, memberOptions: opt => opt.MapFrom(i => i.CorporateAdvertOrderId))
               .ForMember(destinationMember: i => i.CorporateAdvertOrderItemId, memberOptions: opt => opt.MapFrom(i => i.Id))
               .ForMember(destinationMember: i => i.AdvertTitle, memberOptions: opt => opt.MapFrom(i => i.CorporateAdvert.Advert.Title))
               .ForMember(destinationMember: i => i.Amount, memberOptions: opt => opt.MapFrom(i => i.Amount))
               .ForMember(destinationMember: i => i.TotalPrice, memberOptions: opt => opt.MapFrom(i => i.TotalPrice)).ReverseMap();
    }
}
