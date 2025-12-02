using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Testimonials.Queries.GetByIdTestimonial
{
    public class GetByIdTestimonialQueryRequest : IRequest<GetByIdTestimonialQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdTestimonialQueryRequest(int id)
        {
            Id = id;
        }
    }
}
