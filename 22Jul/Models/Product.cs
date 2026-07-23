using System.ComponentModel.DataAnnotations;

namespace _22JUL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Mandatory")]

        public string Stationaryitem { get; set; }
        [Required(ErrorMessage = "Price is Mandatory")]

        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }

    }
}
