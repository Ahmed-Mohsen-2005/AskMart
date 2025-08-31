using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.Dtos.CategoryDTO.Request;

namespace Application.Validators.Validations
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryRequest>
    {
        /*RuleFor(x => x.CategoryName)
    .NotEmpty().WithMessage("Category name is required.")
    .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");
*/
        public AddCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");

        }
    }
}