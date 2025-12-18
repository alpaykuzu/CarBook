using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Comments.Queries.GetAllComment
{
    public class GetAllCommentQueryResponse
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogID { get; set; }
    }
}
