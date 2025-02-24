using Ambev.DeveloperEvaluation.Application.Products.GetListProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetListProductsByCategory;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Products.GetListProductByCategory
{
    public class GetListProductsByCategoryHandler : IRequestHandler<GetListProductByCategoryCommand, GetListProductResult>
    {
        protected readonly IProductRepository _ProductsRepository;
        protected readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetListProductsHandler
        /// </summary>
        /// <param name="ProductsRepository">The ProductsItems repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetProductsCommand</param>
        public GetListProductsByCategoryHandler(
            IProductRepository ProductsRepository,
            IMapper mapper)
        {
            _ProductsRepository = ProductsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductsCommand request
        /// </summary>
        /// <param name="request">The GetProducts command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The ProductsItems details if found</returns>
        public async Task<GetListProductResult> Handle(GetListProductByCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetListProducByCategorytValidator();
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
