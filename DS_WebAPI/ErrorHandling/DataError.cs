namespace DS_WebAPI.ErrorHandling
{
    public class DataError
    {
        public string Message { get; set; }

        public DataError(string msg)
        {
            this.Message = msg;
        }
    }
}
