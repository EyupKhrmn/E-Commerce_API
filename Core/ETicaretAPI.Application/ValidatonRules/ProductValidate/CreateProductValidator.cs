using ETicaretAPI.Application.Features.Commads.Product.CreateProduct;
using FluentValidation;

namespace ETicaretAPI.Application.ValidatonRules;

public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductValidator()
    {
        RuleFor(_ => _.Name).NotEmpty()
            .MaximumLength(150)
            .NotNull().WithMessage("Lütfen Ürün Adını Giriniz !");
        RuleFor(_ => _.Stock).NotNull()
            .WithMessage("Stock bilgisi giriniz !")
            .Must(s => s >= 0).WithMessage("Stock sayısı sıfırdan küçük olamaz !!");
        RuleFor(_ => _.Price).NotNull()
            .WithMessage("Price bilgisi giriniz !")
            .Must(s => s >= 0).WithMessage("Price sayısı sıfırdan küçük olamaz !!");
    }
}