namespace TvDbSharper.Tests.Helpers
{
    using NSubstitute;

    public class RestTestDependencies
    {
        public RestTestDependencies(IHttpJsonClient jsonClient, IRestClient restClient)
        {
            this.JsonClient = jsonClient;
            this.RestClient = restClient;
        }

        public static RestTestDependencies DefaultDependencies
        {
            get
            {
                var jsonClient = Substitute.For<IHttpJsonClient>();

                var restClient = new RestClient(jsonClient);

                return new RestTestDependencies(jsonClient, restClient);
            }
        }

        public IHttpJsonClient JsonClient { get; set; }

        public IRestClient RestClient { get; set; }
    }
}