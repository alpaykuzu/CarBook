using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandRequest
    {
        public string Name { get; set; }
    }
}
