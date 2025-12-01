using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Banners.Queries.GetByIdBanner
{
    public class GetByIdBannerQueryRequest
    {
        public int Id { get; set; }

        public GetByIdBannerQueryRequest(int id)
        {
            Id = id;
        }
    }
}
