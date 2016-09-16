using System.Threading.Tasks;
using Google.Apis.Analytics.v3.Data;

namespace GoogleAnalyticsApi.Application
{
    public interface IGoogleAnalyticsDataServiceV1
    {
        Task<RealtimeData> GetCurrentActiveUsers();
    }
}
