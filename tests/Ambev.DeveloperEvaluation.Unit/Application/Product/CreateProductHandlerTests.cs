using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Product
{

    public class CreateCartstHandlerTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductsHandler _handler;

        public CreateCartstHandlerTests()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateProductsHandler(_productRepository, _mapper);
            Setup();
        }
        private void Setup()
        {
            _productRepository.ClearReceivedCalls();
            _mapper.ClearReceivedCalls();
        }

        [Fact(DisplayName = "Given valid product data When creating product Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateProductHandlerTestData.GenerateValidCommand();

            var product = new DeveloperEvaluation.Domain.Entities.Product
            {
                Id = command.Id,
                CreatedAt = DateTime.Now,
                Price = command.Price,
                Category = command.Category,
                Description = command.Description,
                Image = command.Image,
                Title = command.Title,
                Rating = command.Rating
            };

            var result = new CreateProductsResult {
                Id = product.Id,
                Price = product.Price,
                Category = product.Category,
                Description = product.Description,
                Image = product.Image,
                Title = product.Title,
                Rating = product.Rating
            };

            _mapper.Map<DeveloperEvaluation.Domain.Entities.Product>(command).Returns(product);

            _mapper.Map<CreateProductsResult>(product).Returns(result);

            _productRepository.CreateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.Product>(), Arg.Any<CancellationToken>())
                .Returns(product);

            // When
            var response = await _handler.Handle(command, CancellationToken.None);
            
            // Then
            var createProductResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createProductResult.Should().NotBeNull();
            createProductResult.Id.Should().Be(product.Id);
            await _productRepository.Received(2).CreateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.Product>(), Arg.Any<CancellationToken>());
        }
    }
}
