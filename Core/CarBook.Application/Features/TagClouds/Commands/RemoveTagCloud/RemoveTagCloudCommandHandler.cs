using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Commands.RemoveTagCloud
{
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommandRequest>
    {
        private readonly IRepository<TagCloud> _repository;

        public RemoveTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTagCloudCommandRequest request, CancellationToken cancellationToken)
        {
            var tagCloud = await _repository.GetByIdAsync(request.Id);
            if (tagCloud != null)
                await _repository.RemoveAsync(tagCloud);
        }
    }
}
