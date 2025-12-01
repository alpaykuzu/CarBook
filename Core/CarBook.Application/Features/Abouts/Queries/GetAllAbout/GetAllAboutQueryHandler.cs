using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Abouts.Queries.GetAllAbout
{
    public class GetAllAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAllAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetAllAboutQueryResponse>> Handle()
        {
            var abouts = await _repository.GetAllAsync();
            return abouts.Select(a => new GetAllAboutQueryResponse
            {
                AboutID = a.AboutID,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl
            }).ToList();
        }
    }
}
