using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreWebApi.DataContext
{
    public class UsersTB
    {
        [Key]
        public int UserId { get; set; }
        public int UserNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
