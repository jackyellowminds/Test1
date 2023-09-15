using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreWebApi.Models
{
    public class LoginMD
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
      
    }
}
