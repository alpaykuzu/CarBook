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
    public class StatisticsHubService : IStatisticsHubService
    {
        private readonly IHubContext<StatisticsHub> _hubContext;

        public StatisticsHubService(IHubContext<StatisticsHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendAuthorCountAsync(int count)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveAuthorCount", count);
        }

        public async Task SendAutomaticCarCountUpdateNotification()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveAutomaticCarCountUpdateNotification");
        }

        public async Task SendBlogCountAsync(int count)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveBlogCount", count);
        }

        public async Task SendBrandCountAsync(int count)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveBrandCount", count);
        }

        public async Task SendCarCountAsync(int count)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveCarCount", count);
        }

        public async Task SendCarCountByFuelUpdateNotification()
        {
            await _hubContext.Clients.All.SendAsync("CarCountByFuelUpdateNotification");
        }

        public async Task SendCarCountByKmUpdateNotification()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveCarCountByKmUpdateNotification");
        }

        public async Task SendCarModelAndBrandMaxOrMinDailyPriceUpdateNotification()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveCarModelAndBrandMaxDailyPriceUpdateNotification");
        }

        public async Task SendCarPricingUpdateNotification()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveCarPricingUpdateNotification");
        }

        public async Task SendLocationCountAsync(int count)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveLocationCount", count);
        }

        public async Task SendMostBlogWithCommentUpdateNotification()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMostBlogWithCommentUpdateNotification");
        }

        public async Task SendMostBrandUpdateNotification()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMostBrandUpdateNotification");
        }
    }
}
