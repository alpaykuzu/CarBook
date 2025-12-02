using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddresses.Queries.GetByIdFooterAddress
{
    public class GetByIdFooterAddressQueryRequest : IRequest<GetByIdFooterAddressQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdFooterAddressQueryRequest(int id)
        {
            Id = id;
        }
    }
}
