using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarDescriptions.Queries.GetCarDescriptionByCar
{
    public class GetCarDescriptionByCarQueryHandler : IRequestHandler<GetCarDescriptionByCarQueryRequest, GetCarDescriptionByCarQueryResponse>
    {
        private readonly IRepository<CarDescription> repository;

        public GetCarDescriptionByCarQueryHandler(IRepository<CarDescription> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCarDescriptionByCarQueryResponse> Handle(GetCarDescriptionByCarQueryRequest request, CancellationToken cancellationToken)
        {
            var carDescriptions = await repository.GetQueryable().Where(cd => cd.CarID == request.CarID).FirstOrDefaultAsync();
            return new GetCarDescriptionByCarQueryResponse
            {
                CarDescriptionID = carDescriptions.CarDescriptionID,
                Details = carDescriptions.Details
            };
        }
    }
}
