using Ambev.DeveloperEvaluation.Application.Products.GetListProducts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Products.GetListProductByCategory
{
    public class GetListProductsByCategoryHandler : GetListProductHandler
    {
        public GetListProductsByCategoryHandler(IProductsRepository _ProductsRepository, IMapper mapper) : base(_ProductsRepository, mapper) 
        {
        }

        /// <summary>
        /// Handles the GetProductsCommand request
        /// </summary>
        /// <param name="request">The GetProducts command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Products details if found</returns>
        public override async Task<GetListProductResult> Handle(GetListProductByCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetListProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var listProduct = await _ProductsRepository.GetByCategoryAsync(request.Category, request.Page, request.Size,
                 request.Order, request.Direction,
                          cancellationToken);

            return _mapper.Map<GetListProductResult>(listProduct);
        }
    }
}
