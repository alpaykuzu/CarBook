using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddresses.Commands.RemoveFooterAddress
{
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommandRequest>
    {
        private readonly IRepository<FooterAddress> _repository;

        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.Id);
            if (footerAddress != null)
                await _repository.RemoveAsync(footerAddress);
        }
    }
}
