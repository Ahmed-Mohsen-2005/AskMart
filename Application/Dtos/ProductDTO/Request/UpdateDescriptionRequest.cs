using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductDTO.Request
{
    public class UpdateDescriptionRequest
    {
        //[Required(ErrorMessage = "Product description name is required")]
        //[StringLength(200, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 200 characters")]
        //[RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Only letters, numbers, spaces and hyphens are allowed")]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? NewDescription { get; set; }
    }
}
