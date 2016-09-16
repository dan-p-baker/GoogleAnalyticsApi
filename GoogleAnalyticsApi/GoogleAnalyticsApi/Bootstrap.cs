using GoogleAnalyticsApi.Application;
using SimpleInjector;

namespace GoogleAnalyticsApi
{
    internal class Bootstrap
    {
        public static Container Container;

        public static void Start()
        {
            Container = new Container();
            Container.Register<IGoogleAnalyticsDataServiceV1, GoogleAnalyticsDataServiceV1>(Lifestyle.Singleton);
        }
    }
}


