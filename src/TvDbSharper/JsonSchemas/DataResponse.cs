namespace TvDbSharper.JsonSchemas
{
    public class DataResponse<TResponse>
    {
        public DataResponse()
        {
        }

        public DataResponse(TResponse data)
        {
            this.Data = data;
        }

        public TResponse Data { get; set; }
    }
}