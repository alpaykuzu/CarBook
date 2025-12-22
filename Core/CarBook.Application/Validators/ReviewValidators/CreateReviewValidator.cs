using CarBook.Application.Features.Reviews.Commands.CreateReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommandRequest>
    {
        public CreateReviewValidator()
        {
            RuleFor(r => r.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");
            RuleFor(r => r.CustomerImage)
                .MaximumLength(200).WithMessage("Customer image URL cannot exceed 200 characters.");
            RuleFor(r => r.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(1000).WithMessage("Comment cannot exceed 1000 characters.");
            RuleFor(r => r.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
            RuleFor(r => r.ReviewDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Review date cannot be in the future.");
        }
    }
}
