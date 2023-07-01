namespace MassaratMVC.Models
{
    public class LoginResponse
    {
        public String? message { get; set; }
        public Boolean isSuccess { get; set; }
        public IEnumerable<String>? errors { get; set; }
        public DateTime? expireDate { get; set; }

    }
}
