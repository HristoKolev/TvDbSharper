namespace TvDbSharper.Tests.Helpers
{
    using NSubstitute;

    public class RestApiTestDependencies
    {
        public RestApiTestDependencies(IHttpJsonClient jsonClient, IRestClient restClient)
        {
            this.JsonClient = jsonClient;
            this.RestClient = restClient;
        }

        public static RestApiTestDependencies DefaultDependencies
        {
            get
            {
                var jsonClient = Substitute.For<IHttpJsonClient>();

                var restClient = new RestClient(jsonClient);

                return new RestApiTestDependencies(jsonClient, restClient);
            }
        }

        public IHttpJsonClient JsonClient { get; }

        public IRestClient RestClient { get; }
    }
}