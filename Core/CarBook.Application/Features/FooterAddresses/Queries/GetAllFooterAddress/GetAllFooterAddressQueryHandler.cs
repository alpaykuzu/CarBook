using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddresses.Queries.GetAllFooterAddress
{
    public class GetAllFooterAddressQueryHandler : IRequestHandler<GetAllFooterAddressQueryRequest, List<GetAllFooterAddressQueryResponse>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetAllFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllFooterAddressQueryResponse>> Handle(GetAllFooterAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var footerAddresses = await _repository.GetAllAsync();
            var response = footerAddresses.Select(fa => new GetAllFooterAddressQueryResponse
            {
                FooterAddressID = fa.FooterAddressID,
                Description = fa.Description,
                Address = fa.Address,
                Phone = fa.Phone,
                Email = fa.Email
            }).ToList();
            return response;
        }
    }
}
