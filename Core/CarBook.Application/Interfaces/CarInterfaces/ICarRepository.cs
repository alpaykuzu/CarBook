using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<IList<Car>> GetCarsListWithBrandAsync();
        Task<IList<Car>> GetLastCarsListWithBrandAsync(int number);
        Task<IList<Car>> GetCarsListWithPricingAsync(string pricingType);
    }
}
