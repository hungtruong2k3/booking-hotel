using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Booking_Hotel.Models
{
    public class Product
    {
        [Key] public int? ProductId { get; set; }
        [StringLength(50)]
        [Required] public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        [Required] public string? ProductDescription { get; set; }
        [StringLength(50)]
        public string? ProductImage { get; set; }
        [ForeignKey("LeverID")]
        public int LeverID { get; set; }
        public LevelHotel? levelHotel { get; set; }
    }
}
