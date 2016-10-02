namespace TvDbSharper.RestClient.JsonSchemas
{
    public class TvDbResponse<TData>
    {
        public TvDbResponse()
        {
        }

        public TvDbResponse(TData data)
        {
            this.Data = data;
        }

        public TData Data { get; set; }

        public Errors Errors { get; set; }

        public Links Links { get; set; }
    }
}