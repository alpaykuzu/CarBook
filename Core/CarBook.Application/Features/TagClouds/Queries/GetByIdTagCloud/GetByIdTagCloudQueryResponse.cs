using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Queries.GetByIdTagCloud
{
    public class GetByIdTagCloudQueryResponse
    {
        public int TagCloudID { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }
    }
}
