using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reviews.Queries.GetReviewsByCar
{
    public class GetReviewsByCarQueryHandler : IRequestHandler<GetReviewsByCarQueryRequest, List<GetReviewsByCarQueryResponse>>
    {
        private readonly IRepository<Review> repository;

        public GetReviewsByCarQueryHandler(IRepository<Review> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetReviewsByCarQueryResponse>> Handle(GetReviewsByCarQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = repository.GetQueryable().Where(r => r.CarID == request.CarID).ToList();
            var response = reviews.Select(r => new GetReviewsByCarQueryResponse
            {
                CarID = r.CarID,
                CustomerName = r.CustomerName,
                Comment = r.Comment,
                CustomerImage = r.CustomerImage,
                Rating = r.Rating,
                ReviewDate = r.ReviewDate,
                ReviewID = r.ReviewID
            }).ToList();
            return response;
        }
    }
}
