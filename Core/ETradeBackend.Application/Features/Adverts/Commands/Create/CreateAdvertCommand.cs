using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Adverts.Commands.Create;

public class CreateAdvertCommand : IRequest<CreatedAdvertResponse>
{
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public class CreateAdvertCommandHandler : IRequestHandler<CreateAdvertCommand, CreatedAdvertResponse>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public CreateAdvertCommandHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<CreatedAdvertResponse> Handle(CreateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert advert = _mapper.Map<Advert>(request);
            advert.Id = Guid.NewGuid();
            await _advertRepository.AddAsync(advert);
            CreatedAdvertResponse createdAdvertResponse = _mapper.Map<CreatedAdvertResponse>(advert);
            return createdAdvertResponse;
        }
    }
}
