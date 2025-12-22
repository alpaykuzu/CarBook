using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest>
    {
        private readonly IRepository<Review> repository;

        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            Review review = new Review
            {
                CustomerName = request.CustomerName,
                CustomerImage = request.CustomerImage,
                Comment = request.Comment,
                Rating = request.Rating,
                ReviewDate = request.ReviewDate
            };
            await repository.CreateAsync(review);
        }
    }
}
