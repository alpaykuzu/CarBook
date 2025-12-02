using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Commands.CreatePricing
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommandRequest>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePricingCommandRequest request, CancellationToken cancellationToken)
        {
            var pricing = new Pricing
            {
                Name = request.Name,                
            };
            await _repository.CreateAsync(pricing);
        }
    }
}
