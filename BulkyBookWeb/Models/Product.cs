using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        
        public double Quantiy { get; set; }
        public double Price { get; set; }
        public DateTime CreateDataTime { get; set; } = DateTime.Now;
    }
}
