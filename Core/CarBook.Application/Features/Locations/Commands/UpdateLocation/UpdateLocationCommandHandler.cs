using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.LocationID);
            if (location == null)
                throw new Exception("Location not found");
            
            location.Name = request.Name;
            await _repository.UpdateAsync(location);
        }
    }
}
