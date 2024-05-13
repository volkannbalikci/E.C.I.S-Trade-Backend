using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Adverts.Commands.Update;

public class UpdateAdvertCommand : IRequest<UpdatedAdvertResponse>
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public class UpdateAdvertCommandHandler : IRequestHandler<UpdateAdvertCommand, UpdatedAdvertResponse>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public UpdateAdvertCommandHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedAdvertResponse> Handle(UpdateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(p => p.Id == request.Id);
            advert = _mapper.Map(request, advert);
            await _advertRepository.UpdateAsync(advert);
            UpdatedAdvertResponse updatedAdvertResponse = _mapper.Map<UpdatedAdvertResponse>(advert);
            return updatedAdvertResponse;
        }
    }
}
