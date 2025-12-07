using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TagClouds.Commands.RemoveTagCloud
{
    public class RemoveTagCloudCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveTagCloudCommandRequest(int id)
        {
            Id = id;
        }
    }
}
