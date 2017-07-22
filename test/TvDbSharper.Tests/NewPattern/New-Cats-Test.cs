namespace TvDbSharper.Tests.NewPattern
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Xunit;
    using Xunit.Sdk;

    public class ApiClientMock : IApiClient
    {
        public string BaseAddress { get; set; }

        public CancellationToken CancellationToken { get; private set; }

        public WebHeaderCollection DefaultRequestHeaders { get; set; }

        public ApiRequest Request { get; private set; }

        public ApiResponse Response { get; set; }

        public Task<ApiResponse> SendRequestAsync(ApiRequest request, CancellationToken cancellationToken)
        {
            this.Request = request;
            this.CancellationToken = cancellationToken;

            return Task.FromResult(this.Response);
        }
    }

    public class ParserMock : IParser
    {
        public IReadOnlyDictionary<HttpStatusCode, string> ErrorMap { get; private set; }

        public ApiResponse Response { get; private set; }

        public object ResultObject { get; set; }

        public T Parse<T>(ApiResponse response, IReadOnlyDictionary<HttpStatusCode, string> errorMap)
        {
            this.Response = response;
            this.ErrorMap = errorMap;

            return (T)this.ResultObject;
        }
    }

    public class ApiTest<T>
    {
        public ApiTest()
        {
            this.RequestAssertions = new List<Action<ApiRequest>>();
        }

        /// <summary>
        /// Holds the response that should be returned from the ApiClient mock.
        /// </summary>
        private ApiResponse ApiResponse { get; set; }

        /// <summary>
        /// Creates the class under test.
        /// Passes ApiClient and a Parser 
        /// </summary>
        private Func<IApiClient, IParser, T> CreateTarget { get; set; }

        /// <summary>
        /// The error map object that should be passed in the parser mock.
        /// </summary>
        private IReadOnlyDictionary<HttpStatusCode, string> ErrorMap { get; set; }

        /// <summary>
        /// The type of exception that is expected to be thrown by the method under test.
        /// </summary>
        private Type ExpectedExceptionType { get; set; }

        /// <summary>
        /// Indicates that the return value should not be checked.
        /// </summary>
        private bool IgnoreReturnValue { get; set; }

        /// <summary>
        /// Signals that the method under test is expected to pass CancellationToken.None to the ApiClient.
        /// </summary>
        private bool NoCancellationToken { get; set; }

        /// <summary>
        /// Holds the result object that should be returned from the Parser mock.
        /// </summary>
        private object ParserResultObject { get; set; }

        /// <summary>
        /// List with assersions on the request object.
        /// </summary>
        private List<Action<ApiRequest>> RequestAssertions { get; }

        /// <summary>
        /// The value that the method under test should return.
        /// </summary>
        private object ReturnValue { get; set; }

        /// <summary>
        /// Runs the method under test.
        /// Passes a CancellationToken.
        /// </summary>
        private Func<T, CancellationToken, Task<object>> TargetMethod { get; set; }

        public ApiTest<T> HasNoReturnValue()
        {
            this.IgnoreReturnValue = true;

            return this;
        }

        public async Task RunAsync()
        {
            // Arrange
            var apiClient = new ApiClientMock
            {
                Response = this.ApiResponse
            };

            var parser = new ParserMock
            {
                ResultObject = this.ParserResultObject
            };

            var token = this.NoCancellationToken ? CancellationToken.None : new CancellationTokenSource().Token;

            // Act
            var impl = this.CreateTarget(apiClient, parser);

            if (this.ExpectedExceptionType != null)
            {
                try
                {
                    await this.TargetMethod(impl, token).ConfigureAwait(false);

                    Assert.True(false, $"An exception was expected to be thrown. typeof({this.ExpectedExceptionType.Name})");
                }
                catch (Exception exception)
                {
                    if (exception is TrueException)
                    {
                        throw;
                    }

                    string message = "The exception does not match the expected type."
                                     + $"\r\nExpected: typeof({this.ExpectedExceptionType.Name})"
                                     + $"\r\nActual: typeof({exception.GetType().Name})";

                    Assert.True(this.ExpectedExceptionType == exception.GetType(), message);
                }

                return;
            }

            var result = await this.TargetMethod(impl, token).ConfigureAwait(false);

            // Assert
            Assert.True(token == apiClient.CancellationToken,
                "The method under test does not pass the cancellation token to the ApiClient");

            foreach (var requestAssertion in this.RequestAssertions)
            {
                requestAssertion(apiClient.Request);
            }

            // When parser.Response or parser.ErrorMap are null, it means that the parser was not called
            Assert.True(apiClient.Response == parser.Response,
                "The method under test does not pass the reaponse from the ApiClient to the Parser.");

            Assert.True(this.ErrorMap == parser.ErrorMap, "The error maps do not match.");

            if (!this.IgnoreReturnValue)
            {
                if (this.ReturnValue != null)
                {
                    Assert.True(this.ReturnValue == result, "The method under test does not return the expected value.");
                }
                else
                {
                    Assert.True(parser.ResultObject == result, "The method under test does not return the result of the Parser.");
                }
            }
        }

        public ApiTest<T> SetApiResponse(ApiResponse response)
        {
            this.ApiResponse = response;

            return this;
        }

        public ApiTest<T> SetResultObject(object result)
        {
            this.ParserResultObject = result;

            return this;
        }

        public ApiTest<T> ShouldRequest(string method, string url)
        {
            this.RequestAssertions.Add(request =>
            {
                Assert.True(method == request.Method, "The request method does not match the expected value.");
                Assert.True(url == request.Url, "The URL does not match the expected value.");
            });

            return this;
        }

        public ApiTest<T> ShouldRequest(Action<ApiRequest> action)
        {
            this.RequestAssertions.Add(action);

            return this;
        }

        public ApiTest<T> ShouldReturn(object returnValue)
        {
            this.ReturnValue = returnValue;
            return this;
        }

        public ApiTest<T> ShouldThrow<TException>()
        {
            this.ExpectedExceptionType = typeof(TException);
            return this;
        }

        public ApiTest<T> WhenCallingAMethod<TResult>(Func<T, CancellationToken, Task<TResult>> action)
        {
            this.TargetMethod = async (arg, token) => await action(arg, token).ConfigureAwait(false) as object;

            return this;
        }

        public ApiTest<T> WhenCallingAMethod(Func<T, CancellationToken, Task> action)
        {
            this.TargetMethod = async (arg, token) =>
            {
                await action(arg, token).ConfigureAwait(false);

                return Task.FromResult((object)null);
            };

            return this;
        }

        public ApiTest<T> WithConstructor(Func<IApiClient, IParser, T> creator)
        {
            this.CreateTarget = creator;

            return this;
        }

        public ApiTest<T> WithErrorMap(IReadOnlyDictionary<HttpStatusCode, string> errorMap)
        {
            this.ErrorMap = errorMap;

            return this;
        }

        public ApiTest<T> WithNoCancellationToken()
        {
            this.NoCancellationToken = true;

            return this;
        }
    }
}