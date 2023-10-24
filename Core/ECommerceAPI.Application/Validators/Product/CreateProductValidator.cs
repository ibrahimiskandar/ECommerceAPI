using ECommerceAPI.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerceAPI.Application.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<ProductCreateVM>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Name field cannot be empty.")
                .MinimumLength(2)
                    .WithMessage("Product name must contain at least 2 characters.")
                .MaximumLength(150)
                    .WithMessage("Product name can contain maximum 150 characters");

            RuleFor(p => p.Stock)
                .NotNull()
                    .WithMessage("Stock field cannot be empty.")
                .Must(s => s >= 0)
                    .WithMessage("Product stock cannot be less than 0.");

            RuleFor(p => p.Price)
                .NotNull()
                    .WithMessage("Price field cannot be empty.")
                .Must(s => s >= 0)
                    .WithMessage("Product price cannot be less than 0.");

        }
    }
}
