namespace GoogleAnalyticsApi.Models
{
    public class GoogleAnalyticsDataModel
    {
        public string AnalyticType { get; set; }
        public string Value { get; set; }

        public GoogleAnalyticsDataModel(string analyticType, string value)
        {
            AnalyticType = analyticType;
            Value = value;
        }
    }
}
