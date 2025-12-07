using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Commands.UpdateTagCloud
{
    internal class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommandRequest>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommandRequest request, CancellationToken cancellationToken)
        {
            var tagCloud = await _repository.GetByIdAsync(request.TagCloudID);
            if (tagCloud == null)
                throw new Exception("TagCloud not found");

            tagCloud.Title = request.Title;
            tagCloud.BlogID = request.BlogID;
            await _repository.UpdateAsync(tagCloud);
        }
    }
}
