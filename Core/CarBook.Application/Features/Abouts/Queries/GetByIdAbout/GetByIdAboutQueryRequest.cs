using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Abouts.Queries.GetByIdAbout
{
    public class GetByIdAboutQueryRequest
    {
        public int Id { get; set; }
        public GetByIdAboutQueryRequest(int id)
        {
            Id = id;
        }
    }
}
