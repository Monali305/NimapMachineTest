using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Nimap_Machine_Test.Models;

namespace Nimap_Machine_Test.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string? ProductName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
        public Category? Category { get; set; }
    }
}
