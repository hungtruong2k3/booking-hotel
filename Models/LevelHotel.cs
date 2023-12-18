using System.ComponentModel.DataAnnotations;

namespace Booking_Hotel.Models
{
    public class LevelHotel
    {
        [Key] public int LeverID { get; set; }
        [StringLength(50)]
        [Required] public string LocalName { get; set; }
        [StringLength(150)]
       
        public ICollection<Product>? Products { get; set; }
   
    }
}
