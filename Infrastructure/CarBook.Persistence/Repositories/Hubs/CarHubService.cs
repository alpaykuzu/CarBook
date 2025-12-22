using CarBook.Application.Interfaces.Hubs;
using CarBook.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.Hubs
{
    public class CarHubService : ICarHubService
    {
        private readonly IHubContext<CarHub> _hubContext;

        public CarHubService(IHubContext<CarHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendCarCountAsync(int count)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveCarCount", count);
        }
    }
}
