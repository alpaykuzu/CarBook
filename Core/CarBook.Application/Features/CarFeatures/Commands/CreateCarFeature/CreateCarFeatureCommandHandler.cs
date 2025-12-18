using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Commands.CreateCarFeature
{
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommandRequest>
    {
        private readonly IRepository<CarFeature> repository;

        public CreateCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateCarFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            CarFeature carFeature = new CarFeature
            {
                CarID = request.CarID,
                FeatureID = request.FeatureID,
                Available = request.Available
            };
            await repository.CreateAsync(carFeature);
        }
    }
}
