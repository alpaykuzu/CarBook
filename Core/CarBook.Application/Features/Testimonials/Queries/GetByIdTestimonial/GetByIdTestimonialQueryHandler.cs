using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Testimonials.Queries.GetByIdTestimonial
{
    internal class GetByIdTestimonialQueryHandler : IRequestHandler<GetByIdTestimonialQueryRequest, GetByIdTestimonialQueryResponse>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetByIdTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdTestimonialQueryResponse> Handle(GetByIdTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.Id);
            return new GetByIdTestimonialQueryResponse
            {
                TestimonialID = testimonial.TestimonialID,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl
            };
        }
    }
}
