using System.Net;

namespace ShopFlickerAPI.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessage = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessage { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
    }
}
