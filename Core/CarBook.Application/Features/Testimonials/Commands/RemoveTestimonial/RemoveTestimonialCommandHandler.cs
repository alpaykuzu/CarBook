using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Testimonials.Commands.RemoveTestimonial
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommandRequest>
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.Id);
            if (testimonial != null)
            {
                await _repository.RemoveAsync(testimonial);
            }
        }
    }
}
