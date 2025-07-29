using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün Adını Boş Geçmeyin!");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı için en az 2 karakter veri girişi yapın!");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın!");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Ürün fiyatı boş geçilemez!")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan küçük olamaz!")
                .LessThan(1000).WithMessage("Ürün fiyatı bu kadar yüksek olamaz, girdiğiniz değeri kontrol edin!");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!");
        }
    }
}
