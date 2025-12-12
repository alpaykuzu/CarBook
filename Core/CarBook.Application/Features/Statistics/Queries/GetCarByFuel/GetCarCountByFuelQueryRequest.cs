using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarByFuel
{
    public class GetCarCountByFuelQueryRequest : IRequest<GetCarCountByFuelQueryResponse>
    {
        public string FuelType { get; set; }

        public GetCarCountByFuelQueryRequest(string fuelType)
        {
            FuelType = fuelType;
        }
    }
}
