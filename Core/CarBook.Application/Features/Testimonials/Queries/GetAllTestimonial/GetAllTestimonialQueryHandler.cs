using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Testimonials.Queries.GetAllTestimonial
{
    public class GetAllTestimonialQueryHandler : IRequestHandler<GetAllTestimonialQueryRequest, List<GetAllTestimonialQueryResponse>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetAllTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllTestimonialQueryResponse>> Handle(GetAllTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
            var testimonials = await _repository.GetAllAsync();
            return testimonials.Select(t => new GetAllTestimonialQueryResponse
            {
                TestimonialID = t.TestimonialID,
                Name = t.Name,
                Title = t.Title,
                Comment = t.Comment,
                ImageUrl = t.ImageUrl
            }).ToList();
        }
    }
}
