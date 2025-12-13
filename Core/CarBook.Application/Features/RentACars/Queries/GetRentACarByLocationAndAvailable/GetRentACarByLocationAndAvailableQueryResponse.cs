using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RentACars.Queries.GetRentACarByLocationAndAvailable
{
    public class GetRentACarByLocationAndAvailableQueryResponse
    {
        public int RentACarID { get; set; }
        public int CarID { get; set; }
        public int LocationID { get; set; }
        public bool IsAvailable { get; set; }
    }
}
