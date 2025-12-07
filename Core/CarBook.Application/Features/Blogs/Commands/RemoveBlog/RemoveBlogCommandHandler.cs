using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Blogs.Commands.RemoveBlog
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommandRequest>
    {
        private readonly IRepository<Blog> _repository;

        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
                throw new Exception("Blog not found");
            
            await _repository.RemoveAsync(blog);
        }
    }
}
