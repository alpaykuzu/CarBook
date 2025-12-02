using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Testimonials.Commands.UpdateTestimonial
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommandRequest>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.TestimonialID);
            if (testimonial != null)
            {
                testimonial.Name = request.Name;
                testimonial.Title = request.Title;
                testimonial.Comment = request.Comment;
                testimonial.ImageUrl = request.ImageUrl;
                await _repository.UpdateAsync(testimonial);
            }
        }
    }
}
