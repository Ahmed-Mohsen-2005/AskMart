using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ProductDTO.Request
{
    public class CreateProductRequest
    {

        //[Required(ErrorMessage = "Product name is required")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 50 characters")]
        //[RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Only letters, numbers, spaces and hyphens are allowed")]
        public int CategoryId { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductName { get; set; }
        public float? ProductPrice { get; set; }
        public int? StockQuantity { get; set; }
       
    }
}
