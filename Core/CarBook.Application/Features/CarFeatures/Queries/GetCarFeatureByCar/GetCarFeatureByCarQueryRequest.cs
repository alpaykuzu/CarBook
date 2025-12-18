using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Queries.GetCarFeatureByCar
{
    public class GetCarFeatureByCarQueryRequest : IRequest<List<GetCarFeatureByCarQueryResponse>>
    {
        public int CarID { get; set; }

        public GetCarFeatureByCarQueryRequest(int carID)
        {
            CarID = carID;
        }
    }
}
