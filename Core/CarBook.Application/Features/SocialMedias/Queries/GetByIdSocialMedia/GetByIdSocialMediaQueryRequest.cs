using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.SocialMedias.Queries.GetByIdSocialMedia
{
    public class GetByIdSocialMediaQueryRequest : IRequest<GetByIdSocialMediaQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdSocialMediaQueryRequest(int id)
        {
            Id = id;
        }
    }
}
