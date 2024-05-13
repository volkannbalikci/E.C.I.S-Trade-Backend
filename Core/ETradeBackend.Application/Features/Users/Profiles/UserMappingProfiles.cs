using AutoMapper;
using ETradeBackend.Application.Features.Users.Commands.Create;
using ETradeBackend.Application.Features.Users.Commands.Delete;
using ETradeBackend.Application.Features.Users.Commands.Update;
using ETradeBackend.Application.Features.Users.Queries.GetById;
using ETradeBackend.Application.Features.Users.Queries.GetList;
using ETradeBackend.Domain.Entities;
using Framework.Application.Responses;
using Framework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Users.Profiles;

public class UserMappingProfiles : Profile
{
    public UserMappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();
        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();

        CreateMap<Paginate<User>, GetListResponse<GetListUserListItemDto>>().ReverseMap();
        CreateMap<User, GetListUserListItemDto>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
    }
}
