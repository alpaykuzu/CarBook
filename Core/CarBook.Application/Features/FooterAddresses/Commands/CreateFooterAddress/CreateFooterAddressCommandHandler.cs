using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddresses.Commands.CreateFooterAddress
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommandRequest>
    {
        private readonly IRepository<FooterAddress> _repository;
        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            FooterAddress footerAddress = new FooterAddress()
            {
                Description = request.Description,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email
            };
            await _repository.CreateAsync(footerAddress);
        }
    }
}
