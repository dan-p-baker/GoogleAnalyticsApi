using System;
using System.Threading.Tasks;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Services;

namespace GoogleAnalyticsApi.Application
{
    internal class GoogleAnalyticsDataServiceV1 : IGoogleAnalyticsDataServiceV1
    {
        private static string ApiKey => "AIzaSyCkah50U8qlEIL3B_QGFdWxwFt1WVeE8_0";
        private readonly AnalyticsService _analyticsService;

        public GoogleAnalyticsDataServiceV1()
        {
            var initializer = new BaseClientService.Initializer { ApplicationName =  "Google Analytics", ApiKey = ApiKey };
            _analyticsService = new AnalyticsService(initializer);
        }

        private DataResource.RealtimeResource.GetRequest GetCurrentActiveUsersRequest()
        {
            return _analyticsService.Data.Realtime.Get("ga:17550507", "rt:activeUsers");
        }

        async Task<RealtimeData> IGoogleAnalyticsDataServiceV1.GetCurrentActiveUsers()
        {
            try
            {
                var request = GetCurrentActiveUsersRequest();
                var realTimeData = await request.ExecuteAsync();
                return realTimeData;
            }
            catch (Exception exception)
            {

                throw new ApplicationException(exception.ToString());
            }
        }
    }
}

