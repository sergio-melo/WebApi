using Microsoft.AspNetCore.Components.Web;

namespace WebApi_Video.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Sucess { get; set; } = true;
    }
}
