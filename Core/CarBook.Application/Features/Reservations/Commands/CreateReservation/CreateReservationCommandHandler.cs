using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandQuery>
    {
        private readonly IRepository<Reservation> repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateReservationCommandQuery request, CancellationToken cancellationToken)
        {
            Reservation reservation = new Reservation()
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Phone = request.Phone,
                CarID = request.CarID,
                PickUpLocationID = request.PickUpLocationID,
                DropOffLocationID = request.DropOffLocationID,
                Age = request.Age,
                DriverLicenseYear = request.DriverLicenseYear,
                Description = request.Description,
                Status = "Rezervasyon Alındı"
            };
            await repository.CreateAsync(reservation);
        }
    }
}
