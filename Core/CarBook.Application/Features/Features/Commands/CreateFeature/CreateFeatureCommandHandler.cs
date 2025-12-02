using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Commands.CreateFeature
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommandRequest>
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            Feature feature = new Feature
            {
                Name = request.Name
            };
            await _repository.CreateAsync(feature);
        }
    }
}
