using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CarBook.Application.Features.AppUsers.Queries.GetCheckAppUser
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQueryRequest, GetCheckAppUserQueryResponse>
    {
        private readonly IRepository<AppUser> _repository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<GetCheckAppUserQueryResponse> Handle(GetCheckAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetQueryable()
                .Include(x => x.AppRole)
                .FirstOrDefaultAsync(x => x.Username == request.Username);

            if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return new GetCheckAppUserQueryResponse
                {
                    AppUserID = user.AppUserID,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Username = user.Username,
                    AppRoleID = user.AppRoleID,
                    AppRoleName = user.AppRole.AppRoleName,
                    IsExist = true
                };
            }

            return new GetCheckAppUserQueryResponse
            {
                IsExist = false
            };
        }
    }
}