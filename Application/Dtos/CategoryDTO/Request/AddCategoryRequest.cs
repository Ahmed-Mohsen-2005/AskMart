using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.CategoryDTO.Request
{
    public class AddCategoryRequest


    {
        //    [Required(ErrorMessage = "Category name is required")]
        //    [StringLength(50, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 50 characters")]
        //    [RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Only letters, numbers, spaces and hyphens are allowed")]
        public string? CategoryName { get; set; }

    }
}
