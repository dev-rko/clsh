using CleanShop.Domain.Entities;
using CleanShop.Application.Validators;
using CleanShop.Common.Data;
using CleanShop.Common.Business;
using FluentValidation;

namespace CleanShop.Application.Facades;

public class ProductWriteFacade : IProductWriteFacade
{
    private readonly IProductRepository _productRepository;
    private readonly ProductValidator _validator = new();

    public ProductWriteFacade(IProductRepository productRepository) =>
        _productRepository = productRepository;

    public async Task AddAsync(Product product)
    {
        FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(product).ConfigureAwait(false);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _productRepository.AddAsync(product).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Product product)
    {
        FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(product).ConfigureAwait(false);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        await _productRepository.UpdateAsync(product).ConfigureAwait(false);
    }

    public async Task RemoveAsync(int id)
    {
        await _productRepository.RemoveAsync(id).ConfigureAwait(false);
    }
}
