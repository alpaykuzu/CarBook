using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddresses.Queries.GetByIdFooterAddress
{
    public class GetByIdFooterAddressQueryHandler : IRequestHandler<GetByIdFooterAddressQueryRequest, GetByIdFooterAddressQueryResponse>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetByIdFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdFooterAddressQueryResponse> Handle(GetByIdFooterAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.Id);
            if (footerAddress == null)
                return null;
            
            return new GetByIdFooterAddressQueryResponse
            {
                FooterAddressID = footerAddress.FooterAddressID,
                Description = footerAddress.Description,
                Address = footerAddress.Address,
                Phone = footerAddress.Phone,
                Email = footerAddress.Email
            };
        }
    }
}
