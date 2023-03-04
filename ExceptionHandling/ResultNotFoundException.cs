namespace Product_API_DI.ExceptionHandling
{
    public class ResultNotFoundException : Exception
    {
        public ResultNotFoundException(string message) : base(message) { }
        public ResultNotFoundException(string message, Exception exc) : base(message, exc) { }
        
        
    }
}
