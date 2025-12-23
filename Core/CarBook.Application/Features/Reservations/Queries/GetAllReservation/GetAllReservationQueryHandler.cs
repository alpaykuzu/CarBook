using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Location> locationRepository;

        public GetAllReservationQueryHandler(IRepository<Reservation> repository, IRepository<Location> locationRepository)
        {
            this.repository = repository;
            this.locationRepository = locationRepository;
        }

        public async Task<List<GetAllReservationQueryResponse>> Handle(GetAllReservationQueryRequest request, CancellationToken cancellationToken)
        {
            var reservations = await repository.GetQueryable()
                .Include(u=> u.AppUser)
                .Include(c => c.Car).ThenInclude(b => b.Brand)
                .ToListAsync();
            var locations = await locationRepository.GetAllAsync();

            return reservations.Select(r => new GetAllReservationQueryResponse
            {   
                ReservationID = r.ReservationID,
                AppUserID = r.AppUserID,
                Name = r.AppUser.Name,
                Email = r.AppUser.Email,
                Surname = r.AppUser.Surname,
                CarID = r.CarID,
                Brand = r.Car.Brand.Name,
                Model = r.Car.Model,
                PickUpLocationID = r.PickUpLocationID,
                PickUpLocationName = locations.FirstOrDefault(x => x.LocationID == r.PickUpLocationID)?.Name ?? "",
                DropOffLocationID = r.DropOffLocationID,
                DropOffLocationName = locations.FirstOrDefault(x => x.LocationID == r.DropOffLocationID)?.Name ?? "",
                Age = r.Age,
                DriverLicenseYear = r.DriverLicenseYear,
                Description = r.Description,
                Status = r.Status
            }).ToList();
        }
    }
}
