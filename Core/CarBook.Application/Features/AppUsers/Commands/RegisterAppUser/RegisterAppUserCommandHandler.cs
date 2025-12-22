using CarBook.Application.Enums;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AppUsers.Commands.RegisterAppUser
{
    public class RegisterAppUserCommandHandler : IRequestHandler<RegisterAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> repository;

        public RegisterAppUserCommandHandler(IRepository<AppUser> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RegisterAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var newUser = new AppUser
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                AppRoleID = (int)RolesType.Member
            };
            await repository.CreateAsync(newUser);
        }
    }
}
