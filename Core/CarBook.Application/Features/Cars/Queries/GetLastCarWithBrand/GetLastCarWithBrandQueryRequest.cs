using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetLastCarWithBrand
{
    public class GetLastCarWithBrandQueryRequest
    {
        public int Number { get; set; }

        public GetLastCarWithBrandQueryRequest(int number)
        {
            Number = number;
        }
    }
}
