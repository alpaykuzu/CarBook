using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Commands.UpdatePricing
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommandRequest>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommandRequest request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.PricingID);
            if (pricing == null)
                throw new Exception("Pricing not found");
            
            pricing.Name = request.Name;
            await _repository.UpdateAsync(pricing);
        }
    }
}
