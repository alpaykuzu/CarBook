using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Commands.RemovePricing
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommandRequest>
    {
        private readonly IRepository<Pricing> _repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePricingCommandRequest request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.Id);
            if (pricing != null)
                await _repository.RemoveAsync(pricing);       
        }
    }
}
