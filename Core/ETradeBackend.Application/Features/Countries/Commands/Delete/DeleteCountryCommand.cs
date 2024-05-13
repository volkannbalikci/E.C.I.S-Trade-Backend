using AutoMapper;
using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Countries.Commands.Delete;

public class DeleteCountryCommand : IRequest<DeletedCountryResponse>
{
    public Guid Id { get; set; }

    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeletedCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public DeleteCountryCommandHandler(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<DeletedCountryResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            Country? country = await _countryRepository.GetAsync(c => c.Id == request.Id);
            await _countryRepository.DeleteAsync(country);
            DeletedCountryResponse deletedCountryResponse = _mapper.Map<DeletedCountryResponse>(country);
            return deletedCountryResponse;
        }
    }
}
