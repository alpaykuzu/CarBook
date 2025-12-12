using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<IList<Car>> GetCarsListWithBrandAsync()
        {
            return await _context.Cars
                .Include(car => car.Brand)
                .ToListAsync();
        }

        public async Task<IList<Car>> GetCarsListWithPricingAsync(string pricingType)
        {
            return await _context.Cars
                .Include(car => car.Brand)
                .Include(car => car.CarPricings).ThenInclude(pricing => pricing.Pricing)
                .Where(car => car.CarPricings.Any(pricing => pricing.Pricing.Name == pricingType))
                .ToListAsync();
        }

        public async Task<IList<Car>> GetLastCarsListWithBrandAsync(int number)
        {
            return await _context.Cars
                .Include(car => car.Brand)
                .OrderByDescending(car => car.CarID)
                .Take(number)
                .ToListAsync();
        }
    }
}
