using AutoMapper;
using ETradeBackend.Application.Features.Admins.Commands.Create;
using ETradeBackend.Application.Features.Admins.Commands.Delete;
using ETradeBackend.Application.Features.Admins.Commands.Update;
using ETradeBackend.Application.Features.Admins.Queries.GetById;
using ETradeBackend.Application.Features.Admins.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Profiles;

public class AdminMappingProfiles : Profile
{
    public AdminMappingProfiles()
    {
        CreateMap<Admin, CreateAdminCommand>().ReverseMap();
        CreateMap<User, CreateAdminCommand>().ReverseMap();
        CreateMap<Admin, CreatedAdminResponse>().ReverseMap();
        CreateMap<Admin, DeleteAdminCommand>().ReverseMap();
        CreateMap<DeleteAdminCommand, DeletedAdminResponse>()
            .ForMember(destinationMember: a => a.AdminId, memberOptions: opt => opt.MapFrom(a => a.AdminId)).ReverseMap();
        CreateMap<Admin, UpdateAdminCommand>()
            .ForMember(destinationMember: a => a.AdminFirstName, memberOptions: opt => opt.MapFrom(a => a.FirstName))
            .ForMember(destinationMember: a => a.AdminLastName, memberOptions: opt => opt.MapFrom(a => a.LastName))
            .ForMember(destinationMember: a => a.AdminContactNumber, memberOptions: opt => opt.MapFrom(a => a.ContactNumber)).ReverseMap();
        CreateMap<User, UpdateAdminCommand>()
                        .ForMember(destinationMember: a => a.UserEmail, memberOptions: opt => opt.MapFrom(a => a.Email))
            .ReverseMap();
        CreateMap<Admin, UpdatedAdminResponse>()
            .ForMember(destinationMember: a => a.AdminFirstName, memberOptions: opt => opt.MapFrom(a => a.FirstName))
            .ForMember(destinationMember: a => a.AdminLastName, memberOptions: opt => opt.MapFrom(a => a.LastName))
            .ForMember(destinationMember: a => a.AdminContactNumber, memberOptions: opt => opt.MapFrom(a => a.ContactNumber))
            .ForMember(destinationMember: a => a.UserEmail, memberOptions: opt => opt.MapFrom(a => a.User.Email))
            .ReverseMap();

        //CreateMap<Paginate<Admin>, GetListResponse<GetListAdminListItemDto>>().ReverseMap();
        //CreateMap<Admin, GetListAdminListItemDto>()
        //    .ForMember(destinationMember: a => a.FirstName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.FirstName))
        //    .ForMember(destinationMember: a => a.LastName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.LastName))
        //    .ForMember(destinationMember: a => a.UserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
        //    //.ForMember(destinationMember: a => a.Email, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.Email))
        //    .ReverseMap();

        //CreateMap<Admin, GetByIdAdminResponse>()
        //    .ForMember(destinationMember: a => a.FirstName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.FirstName))
        //    .ForMember(destinationMember: a => a.LastName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.LastName))
        //    .ForMember(destinationMember: a => a.UserName, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.UserName))
        //    //.ForMember(destinationMember: a => a.Email, memberOptions: opt => opt.MapFrom(a => a.IndividualUser.Email))
        //    .ReverseMap();
    }
}
