using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Commands.CreateTagCloud
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommandRequest>
    {
        private readonly IRepository<TagCloud> _repository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCloudCommandRequest request, CancellationToken cancellationToken)
        {
            TagCloud tagCloud = new TagCloud
            {
                Title = request.Title,
                BlogID = request.BlogID
            };
            await _repository.CreateAsync(tagCloud);
        }
    }
}
