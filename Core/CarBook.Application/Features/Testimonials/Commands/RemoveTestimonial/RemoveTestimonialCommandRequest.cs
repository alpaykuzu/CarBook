using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Testimonials.Commands.RemoveTestimonial
{
    public class RemoveTestimonialCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveTestimonialCommandRequest(int id)
        {
            Id = id;
        }
    }
}
