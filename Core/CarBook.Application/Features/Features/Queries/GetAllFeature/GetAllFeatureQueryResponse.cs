using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Queries.GetAllFeature
{
    public class GetAllFeatureQueryResponse
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
    }
}
