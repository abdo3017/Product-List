using System.ComponentModel.DataAnnotations;

namespace Luftborn.Presentation.ViewModels
{
    public class ProductModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public int AvailableAmount { get; set; }

        public decimal Cost { get; set; }
    }
}
