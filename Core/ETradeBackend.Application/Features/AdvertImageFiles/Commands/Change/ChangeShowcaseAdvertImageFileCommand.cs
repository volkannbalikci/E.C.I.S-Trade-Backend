using ETradeBackend.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertImageFiles.Commands.Change;

public class ChangeShowcaseAdvertImageFileCommand : IRequest<ChangeShowcaseAdvertImageFileCommand>
{
    public string ImageId { get; set; }
    public string AdvertId { get; set; }

    public class ChangeShowcaseAdvertImageFileCommandHandler : IRequestHandler<ChangeShowcaseAdvertImageFileCommand, ChangeShowcaseAdvertImageFileCommand>
    {
        readonly IAdvertImageFileRepository _advertImageFileRepository;

        public ChangeShowcaseAdvertImageFileCommandHandler(IAdvertImageFileRepository advertImageFileRepository)
        {
            _advertImageFileRepository = advertImageFileRepository;
        }

        public async Task<ChangeShowcaseAdvertImageFileCommand> Handle(ChangeShowcaseAdvertImageFileCommand request, CancellationToken cancellationToken)
        {
            var query = _advertImageFileRepository.GetListByQueryable(
                include: a => a.Include(a => a.Advert));
            var data = await query.FirstOrDefaultAsync( a => a.Advert.Id == Guid.Parse(request.AdvertId) && a.Showcase);
            if (data != null)
                data.Showcase = false;

            var image = await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.ImageId));
            if (image != null)
                image.Showcase = true;

            return new();
        }
    }
}
