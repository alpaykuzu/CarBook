using CarBook.Application.Features.Rentals.Queries.GetAllRental;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Rentals.Queries.GetRentalByAppUser
{
    public class GetRentalByAppUserQueryHandler : IRequestHandler<GetRentalByAppUserQueryRequest, List<GetRentalByAppUserQueryResponse>>
    {
        private readonly IRepository<Rental> rentalRepository;
        private readonly IRepository<Location> locationRepository;

        public GetRentalByAppUserQueryHandler(IRepository<Rental> rentalRepository, IRepository<Location> locationRepository)
        {
            this.rentalRepository = rentalRepository;
            this.locationRepository = locationRepository;
        }
        public async Task<List<GetRentalByAppUserQueryResponse>> Handle(GetRentalByAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var rentals = await rentalRepository.GetQueryable()
                .Include(r => r.Reservation)
                .Include(c => c.Car).ThenInclude(b => b.Brand)
                .Where(x => x.Reservation.AppUserID == request.AppUserID)
                .ToListAsync();

            var locations = await locationRepository.GetAllAsync();

            var response = rentals.Select(rental => new GetRentalByAppUserQueryResponse
            {
                RentalID = rental.RentalID,
                CarID = rental.CarID,
                Model = rental.Car.Model,
                Brand = rental.Car.Brand.Name,
                ReservationID = rental.ReservationID,
                PickUpLocationID = rental.PickUpLocationID,
                PickUpLocationName = locations.FirstOrDefault(x => x.LocationID == rental.PickUpLocationID)?.Name ?? "",
                DropOffLocationID = rental.DropUpLocationID,
                DropOffLocationName = locations.FirstOrDefault(x => x.LocationID == rental.DropUpLocationID)?.Name ?? "",
                PickUpDate = rental.PickUpDate,
                DropOffDate = rental.DropOffDate,
                PickUpTime = rental.PickUpTime,
                DropOffTime = rental.DropOffTime,
                Description = rental.Description,
                TotalPrice = rental.TotalPrice
            }).ToList();

            return response;
        }
    }
}
