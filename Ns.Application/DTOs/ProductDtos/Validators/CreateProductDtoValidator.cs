using FluentValidation;
using Ns.Application.Contracts.Persistence;

namespace Ns.Application.DTOs.ProductDtos.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {

        private readonly IProductRepository _productRepository;
        public CreateProductDtoValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;


            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull()
                .MaximumLength(80).WithMessage("{PropertyName} must not be more than 80 characters!");

            RuleFor(p => p.ProduceDate).NotEmpty().WithMessage("{PropertyName} is required!")
               .NotNull()
            .MustAsync(async (pDate, token) =>
            {
                var ProduceDateExist = await _productRepository.IsProduceDateExist(pDate);
                return ProduceDateExist;
            }).WithMessage("ProduceDate must be Unique");


            RuleFor(p => p.ManufactureEmail).NotEmpty().WithMessage("{PropertyName} is required!")
             .NotNull()
             .MaximumLength(260).WithMessage("{PropertyName} must not be more than 260 characters!")
             .MustAsync(async (mEmail, token) =>
             {
                 var MaEmailExist = await _productRepository.IsEmailExist(mEmail);
                 return MaEmailExist;
             })
             .WithMessage("Email must be Unique");


            RuleFor(p => p.ManufacturePhone).NotEmpty().WithMessage("{PropertyName} is required!")
               .NotNull()
               .MaximumLength(12).WithMessage("{PropertyName} must not be more than 12 characters!");



        }
    }
}

