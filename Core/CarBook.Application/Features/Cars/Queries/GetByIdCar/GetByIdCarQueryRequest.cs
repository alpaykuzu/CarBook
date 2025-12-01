using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetByIdCar
{
    public class GetByIdCarQueryRequest
    {
        public int Id { get; set; }

        public GetByIdCarQueryRequest(int id)
        {
            Id = id;
        }
    }
}
