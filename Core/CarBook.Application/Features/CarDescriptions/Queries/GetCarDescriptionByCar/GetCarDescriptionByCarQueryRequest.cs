using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarDescriptions.Queries.GetCarDescriptionByCar
{
    public class GetCarDescriptionByCarQueryRequest : IRequest<GetCarDescriptionByCarQueryResponse>
    {
        public int CarID { get; set; }

        public GetCarDescriptionByCarQueryRequest(int carID)
        {
            CarID = carID;
        }
    }
}
