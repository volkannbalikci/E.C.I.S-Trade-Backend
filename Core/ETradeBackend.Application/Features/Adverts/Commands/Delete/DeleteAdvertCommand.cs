using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Adverts.Commands.Delete;

public class DeleteAdvertCommand : IRequest<DeletedAdvertResponse>
{
    public Guid Id { get; set; }

    public class DeleteAdvertCommandHandler : IRequestHandler<DeleteAdvertCommand, DeletedAdvertResponse>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public DeleteAdvertCommandHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            this._mapper = mapper;
        }

        public async Task<DeletedAdvertResponse> Handle(DeleteAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(p => p.Id == request.Id);
            await _advertRepository.DeleteAsync(advert);
            DeletedAdvertResponse deletedAdvertResponse = _mapper.Map<DeletedAdvertResponse>(advert);
            return deletedAdvertResponse;
        }
    }
}
