using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nimap_Machine_Test.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public Category? Category { get; set; }
    }
}
