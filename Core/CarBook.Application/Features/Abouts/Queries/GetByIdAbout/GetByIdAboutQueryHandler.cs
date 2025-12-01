using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Abouts.Queries.GetByIdAbout
{
    public class GetByIdAboutQueryHandler
    {
        private readonly IRepository<About> _repository;
        public GetByIdAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdAboutQueryResponse> Handle(GetByIdAboutQueryRequest query)
        {
            var about = await _repository.GetByIdAsync(query.Id);
            if (about == null)
            {
                return null;
            }
            return new GetByIdAboutQueryResponse
            {
                AboutID = about.AboutID,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };
        }
    }
}
