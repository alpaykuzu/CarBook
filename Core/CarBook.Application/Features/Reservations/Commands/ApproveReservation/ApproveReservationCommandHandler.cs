using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Reservations.Commands.ApproveReservation
{
    public class ApproveReservationCommandHandler : IRequestHandler<ApproveReservationCommandRequest>
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IRepository<CarPricing> _carPricingRepository;

        public ApproveReservationCommandHandler(IRepository<Reservation> reservationRepository, IRepository<Rental> rentalRepository, IRepository<CarPricing> carPricingRepository)
        {
            _reservationRepository = reservationRepository;
            _rentalRepository = rentalRepository;
            _carPricingRepository = carPricingRepository;
        }

        public async Task Handle(ApproveReservationCommandRequest request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationID);
            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }
            reservation.Status = "Onaylandı";
            await _reservationRepository.UpdateAsync(reservation);

            var totalHours = (reservation.DropOffDate.ToDateTime(reservation.DropOffTime) - reservation.PickUpDate.ToDateTime(reservation.PickUpTime)).TotalHours;
            var carPricing = await _carPricingRepository.GetQueryable().Include(p => p.Pricing).Where(cp => cp.CarID == reservation.CarID).ToListAsync();

            var hourlyRate = carPricing.FirstOrDefault(x => x.Pricing.Name == "Saatlik").Amount;
            var dailyRate = carPricing.FirstOrDefault(x => x.Pricing.Name == "Günlük").Amount;
            var weeklyRate = carPricing.FirstOrDefault(x => x.Pricing.Name == "Haftalık").Amount;

            var hours = totalHours % 24;
            var hoursPrice = (decimal)hours * hourlyRate;

            var days = Math.Floor(totalHours / 24);
            var weeks = Math.Floor(days / 7);
            var weeksPrice = (decimal)weeks * weeklyRate;

            var daysRemainder = days % 7;
            var daysPrice = (decimal)daysRemainder * dailyRate;

            var totalPrice = hoursPrice + daysPrice + weeksPrice;   

            Rental rental = new Rental
            {
                CarID = reservation.CarID,
                PickUpDate = reservation.PickUpDate,
                DropOffDate = reservation.DropOffDate,
                Description = reservation.Description,
                DropOffTime = reservation.DropOffTime,
                DropUpLocationID = reservation.DropOffLocationID ?? 0,
                PickUpLocationID = reservation.PickUpLocationID ?? 0,
                PickUpTime = reservation.PickUpTime,
                ReservationID = reservation.ReservationID,
                TotalPrice = totalPrice
            };
            await _rentalRepository.CreateAsync(rental);
        }
    }
}
