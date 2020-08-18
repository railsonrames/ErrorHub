namespace ErrorHub.Domain.Models
{
    public class Result<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
