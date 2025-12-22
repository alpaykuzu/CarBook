using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.Hubs
{
    public interface ICarHubService
    {
        Task SendCarCountAsync(int count);
    }
}
