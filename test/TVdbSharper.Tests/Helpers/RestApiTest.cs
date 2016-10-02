namespace TvDbSharper.Tests.Helpers
{
    using System;
    using System.Threading.Tasks;

    using NSubstitute;

    public class RestApiTest<T>
    {
        public RestApiTest(IHttpJsonClient jsonClient, IRestClient restClient)
        {
            this.JsonClient = jsonClient;
            this.RestClient = restClient;
        }

        public RestApiTest()
            : this(Substitute.For<IHttpJsonClient>(), Substitute.For<IRestClient>())
        {
        }

        public RestApiTest(RestApiTestDependencies dependencies)
            : this(dependencies.JsonClient, dependencies.RestClient)
        {
        }

        public Func<IHttpJsonClient, Task<T>> ExpectedCallAsync { get; set; }

        public T ReturnsValueForAnyArgs { get; set; }

        public T ReturnValue { get; set; }

        public Func<IRestClient, Task> TriggerAsync { get; set; }

        private IHttpJsonClient JsonClient { get; }

        private IRestClient RestClient { get; }

        public async Task RunAsync()
        {
            this.ExpectedCallAsync(this.JsonClient).Returns(this.ReturnValue);

            await this.TriggerAsync(this.RestClient);

            if (!Equals(this.ReturnsValueForAnyArgs, default(T)))
            {
                this.ExpectedCallAsync(this.JsonClient).ReturnsForAnyArgs(this.ReturnsValueForAnyArgs);
            }

            await this.ExpectedCallAsync(this.JsonClient.Received());
        }
    }
}