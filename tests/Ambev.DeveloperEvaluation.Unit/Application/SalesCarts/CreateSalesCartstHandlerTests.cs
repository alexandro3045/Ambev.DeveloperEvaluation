using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Unit.Extensions;
using AutoMapper;
using Bogus;
using FluentAssertions;
using MediatR;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SalesCarts
{

    public class CreateSalesCartstHandlerTests
    {
        private readonly ISalesCartsRepository _SalesCartsRepository;
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        private readonly CreateSalesCartsHandler _handler;
        private readonly IMediator _mediator;

        public CreateSalesCartstHandlerTests()
        {
            _SalesCartsRepository = Substitute.For<ISalesCartsRepository>();
            _ProductRepository = Substitute.For<IProductRepository>(); // Fixing the conversion issue
            _mapper = Substitute.For<IMapper>();
            _mediator = Substitute.For<IMediator>();
            _handler = new CreateSalesCartsHandler(_SalesCartsRepository, _ProductRepository, _mapper, _mediator);
        }


        [Fact(DisplayName = "Given valid SalesCarts data When creating SalesCarts Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateSalesCartsHandlerTestData.GenerateValidCommand();

            var SalesCarts = new DeveloperEvaluation.Domain.Entities.SalesCarts
            {
                Id = CreateSalesCartsHandlerTestData.GetId(),
                SalesNumber = command.SalesNumber,
                CreatedAt = DateTime.Now,
                UserId = Guid.Parse(command.UserId),
                BranchId = command.BranchId,
                Carts = new DeveloperEvaluation.Domain.Entities.Carts
                {
                    Id = CreateSalesCartsHandlerTestData.GetId(),
                    CreatedAt = DateTime.Now,
                    UserId = command.UserId,
                    CartsProductsItems = command.Products.Select(p =>
                        new CartsProductsItems
                        {
                            CartId = p.CartId,
                            ProductId = p.ProductId,
                            Quantity = p.Quantity,
                            Product = new DeveloperEvaluation.Domain.Entities.Product { Price = new Faker().Random.Decimal(0.00m, 99.00m, 2) }
                        }).ToList()
                }
            };

            var result = new CreateSalesCartsResult
            (
                 SalesCarts.SalesNumber ?? 0,
                SalesCarts.CreatedAt,
                SalesCarts.UserId,
                 SalesCarts.TotalSalesAmount,
                SalesCarts.BranchId,
                 SalesCarts.Carts.CartsProductsItems.Select(p =>
                    new CartItemResult(p.CartId, p.ProductId, p.Quantity, p.TotalAmountItem,
                    p.UnitPrice, p.Discounts, p.Canceled)).ToList()
            );

            _mapper.Map<DeveloperEvaluation.Domain.Entities.SalesCarts>(command).Returns(SalesCarts);

            _mapper.Map<CreateSalesCartsResult>(SalesCarts).Returns(result);

            DeveloperEvaluation.Domain.Entities.Product p = new DeveloperEvaluation.Domain.Entities.Product();
            SalesCarts.Carts.CartsProductsItems.ForEach(async cp =>
            {
                var Product = ProductTestData.GenerateValidProduct();
                Product.Id = cp.ProductId;
                cp.Product = Product;
            });

            _SalesCartsRepository.CreateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.SalesCarts>(), Arg.Any<CancellationToken>())
                .Returns(SalesCarts);

            SalesCarts.CalculateCart();

            // When
            var response = await _handler.Handle(command, CancellationToken.None);

            // Then
            var createSalesCartsResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createSalesCartsResult.Should().NotBeNull();
            createSalesCartsResult.SalesNumber.Should().Be(SalesCarts.SalesNumber);
            await _SalesCartsRepository.Received(2).CreateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.SalesCarts>(), Arg.Any<CancellationToken>());
        }
    }
}
