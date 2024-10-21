namespace KPMG.CRM.Integration.API.Models
{
    public class BaseResponse<T>
    {
        public string message { get; set; } 
        public bool result { get; set; }
        public T data { get; set; }
    }
}
