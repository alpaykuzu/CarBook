using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddresses.Commands.RemoveFooterAddress
{
    public class RemoveFooterAddressCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveFooterAddressCommandRequest(int id)
        {
            Id = id;
        }
    }
}
