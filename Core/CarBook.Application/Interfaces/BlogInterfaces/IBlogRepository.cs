using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLastBlogsWithAuthorsAsync(int? number = null);
        Task<Blog> GetByIdBlogWithAuthorAsync(int id);
    }
}
