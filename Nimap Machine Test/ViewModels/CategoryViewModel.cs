using System.ComponentModel.DataAnnotations;

namespace Nimap_Machine_Test.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? CategoryName { get; set; }
    }
}
