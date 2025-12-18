using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Commands.DeleteCarFeature
{
    public class DeleteCarFeatureCommandHandler : IRequestHandler<DeleteCarFeatureCommandRequest>
    {
        private readonly IRepository<CarFeature> repository;

        public DeleteCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(DeleteCarFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var carFeature = await repository.GetByIdAsync(request.Id);
            if (carFeature != null)
            {
                await repository.RemoveAsync(carFeature);
            }
        }
    }
}
