using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommandRequest>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.SocialMediaID);
            if (socialMedia != null)
            {
                socialMedia.Name = request.Name;
                socialMedia.Url = request.Url;
                socialMedia.Icon = request.Icon;
                await _repository.UpdateAsync(socialMedia);
            }
        }
    }
}
