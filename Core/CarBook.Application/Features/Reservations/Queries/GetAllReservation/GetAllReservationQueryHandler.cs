using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reservations.Queries.GetAllReservation
{
    public class GetAllReservationQueryHandler : IRequestHandler<GetAllReservationQueryRequest, List<GetAllReservationQueryResponse>>
    {
        private readonly IRepository<Reservation> repository;

        public GetAllReservationQueryHandler(IRepository<Reservation> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetAllReservationQueryResponse>> Handle(GetAllReservationQueryRequest request, CancellationToken cancellationToken)
        {
            var reservations = await repository.GetAllAsync();
            return reservations.Select(r => new GetAllReservationQueryResponse
            {
                ReservationID = r.ReservationID,
                Name = r.Name,
                Surname = r.Surname,
                Email = r.Email,
                Phone = r.Phone,
                CarID = r.CarID,
                PickUpLocationID = r.PickUpLocationID,
                DropOffLocationID = r.DropOffLocationID,
                Age = r.Age,
                DriverLicenseYear = r.DriverLicenseYear,
                Description = r.Description,
                Status = r.Status
            }).ToList();
        }
    }
}
