namespace NjordinSight.Web.Services
{
    public class ApiOptions
    {
        public const string ApiService = nameof(ApiService);

        public string Name { get; init; }

        public string Url { get; set; }
    }
}
