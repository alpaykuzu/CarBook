using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.SocialMedias.Commands.RemoveSocialMedia
{
    public class RemoveSocialMediaCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveSocialMediaCommandRequest(int id)
        {
            Id = id;
        }
    }
}
