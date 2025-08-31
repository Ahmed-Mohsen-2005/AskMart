using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductDTO.Request
{
    public class ChangeProductNameRequest
    {
        //[Required(ErrorMessage = "Product name is required")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 50 characters")]
        //[RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Only letters, numbers, spaces and hyphens are allowed")]
        public int ProductId { get; set; }
        public string? NewName { get; set; }

    }
}
