using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddresses.Commands.UpdateFooterAddress
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommandRequest>
    {
        private readonly IRepository<FooterAddress> __repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            __repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var footerAddress = await __repository.GetByIdAsync(request.FooterAddressID);
            if (footerAddress != null)
            {
                footerAddress.Description = request.Description;
                footerAddress.Address = request.Address;
                footerAddress.Phone = request.Phone;
                footerAddress.Email = request.Email;
                await __repository.UpdateAsync(footerAddress);
            }
        }
    }
}
