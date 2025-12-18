using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Commands.UpdateCarFeature
{
    public class UpdateCarFeatureCommandHandler : IRequestHandler<UpdateCarFeatureCommandRequest>
    {
        private readonly IRepository<CarFeature> repository;

        public UpdateCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateCarFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var carFeature = await repository.GetByIdAsync(request.CarFeatureID);
            if (carFeature != null)
            {
                if(carFeature.Available)
                    carFeature.Available = false;
                else
                    carFeature.Available = true;
                await repository.UpdateAsync(carFeature);
            }
        }
    }
}
