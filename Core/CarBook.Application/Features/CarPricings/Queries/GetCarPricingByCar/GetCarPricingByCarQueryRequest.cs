using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Queries.GetCarPricingByCar
{
    public class GetCarPricingByCarQueryRequest : IRequest<GetCarPricingByCarQueryResponse>
    {
        public int CarID { get; set; }

        public GetCarPricingByCarQueryRequest(int carID)
        {
            CarID = carID;
        }
    }
}
