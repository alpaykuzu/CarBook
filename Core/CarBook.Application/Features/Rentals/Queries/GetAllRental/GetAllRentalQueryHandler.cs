using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Rentals.Queries.GetAllRental
{
    public class GetAllRentalQueryHandler : IRequestHandler<GetAllRentalQueryRequest, List<GetAllRentalQueryResponse>>
    {
        private readonly IRepository<Rental> rentalRepository;
        private readonly IRepository<Location> locationRepository;

        public GetAllRentalQueryHandler(IRepository<Rental> rentalRepository, IRepository<Location> locationRepository)
        {
            this.rentalRepository = rentalRepository;
            this.locationRepository = locationRepository;
        }

        public async Task<List<GetAllRentalQueryResponse>> Handle(GetAllRentalQueryRequest request, CancellationToken cancellationToken)
        {
            var rentals = await rentalRepository.GetQueryable()
                .Include(c => c.Car).ThenInclude(b => b.Brand).ToListAsync();
            var locations = await locationRepository.GetAllAsync();

            var response = rentals.Select(rental => new GetAllRentalQueryResponse
            {
                RentalID = rental.RentalID,
                CarID = rental.CarID,
                Brand = rental.Car.Brand.Name,
                Model = rental.Car.Model,
                ReservationID = rental.ReservationID,
                PickUpLocationID = rental.PickUpLocationID,
                PickUpLocationName = locations.FirstOrDefault(x => x.LocationID == rental.PickUpLocationID)?.Name ?? "",
                DropUpLocationID = rental.DropUpLocationID,
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
