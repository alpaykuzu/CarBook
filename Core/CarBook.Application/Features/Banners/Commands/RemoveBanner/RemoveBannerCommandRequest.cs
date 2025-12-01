using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Banners.Commands.RemoveBanner
{
    public class RemoveBannerCommandRequest
    {
        public int Id { get; set; }
        public RemoveBannerCommandRequest(int id)
        {
            Id = id;
        }
    }
}
