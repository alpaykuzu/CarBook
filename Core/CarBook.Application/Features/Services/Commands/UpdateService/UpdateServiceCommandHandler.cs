using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Services.Commands.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommandRequest>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.ServiceID);
            if (service == null)
                throw new Exception("Service not found");

            service.Title = request.Title;
            service.Description = request.Description;
            service.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(service);
        }
    }
}
