using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reviews.Queries.GetReviewsByCar
{
    public class GetReviewsByCarQueryRequest : IRequest<List<GetReviewsByCarQueryResponse>>
    {
        public int CarID { get; set; }

        public GetReviewsByCarQueryRequest(int carID)
        {
            CarID = carID;
        }
    }
}
