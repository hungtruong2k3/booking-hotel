using System.ComponentModel.DataAnnotations;

namespace Booking_Hotel.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPassword { get; set; }
        public string? UserConfirmPassword { get; set; }

        public string? UserRole { get; set; }
    }
}