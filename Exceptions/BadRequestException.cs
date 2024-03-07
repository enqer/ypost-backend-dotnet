namespace ypost_backend_dotnet.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string messege) : base(messege) 
        {
        
        }

    }
}
