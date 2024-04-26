using System.ComponentModel.DataAnnotations;

namespace Knilla.Models
{
    public class UserMasterModel
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string? User_Name { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; }
        public string? Token { get; set; }
    }
    public class LoginModel
    {
        public string User_Name { get; set; }
        
        public string Password { get; set; }
    }
}
