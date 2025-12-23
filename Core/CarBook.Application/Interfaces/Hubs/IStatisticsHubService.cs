using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.Hubs
{
    public interface IStatisticsHubService
    {
        Task SendCarCountAsync(int count);
        Task SendLocationCountAsync(int count);
        Task SendAuthorCountAsync(int count);
        Task SendBlogCountAsync(int count);
        Task SendBrandCountAsync(int count);
        Task SendCarPricingUpdateNotification();
        Task SendAutomaticCarCountUpdateNotification();
        Task SendMostBrandUpdateNotification();
        Task SendMostBlogWithCommentUpdateNotification();
        Task SendCarCountByKmUpdateNotification();
        Task SendCarCountByFuelUpdateNotification();
        Task SendCarModelAndBrandMaxOrMinDailyPriceUpdateNotification();
    }
}
