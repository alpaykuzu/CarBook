using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<Blog> GetByIdBlogWithAuthorAsync(int id)
        {
            var result = await _context.Blogs.Include(a => a.Author)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.BlogID == id);
            return result;
        }

        public async Task<List<Blog>> GetLastBlogsWithAuthorsAsync(int? number = null)
        {
            if (number == 0)
                return await _context.Blogs.Include(a => a.Author)
                    .Include(c => c.Category)
                    .Include(d => d.Comments)
                    .OrderByDescending(b => b.BlogID)
                    .ToListAsync();

            return await _context.Blogs.Include(a => a.Author)
                .Include(c => c.Category)
                .Include(d => d.Comments)
                .OrderByDescending(b => b.BlogID)
                .Take(number.Value)
                .ToListAsync();
        }
    }
}
