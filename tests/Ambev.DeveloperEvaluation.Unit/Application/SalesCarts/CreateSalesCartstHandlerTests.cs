using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.SalesCarts
{

    public class CreateSalesCartstHandlerTests
    {
        private readonly ISalesCartsRepository _SalesCartsRepository;
        private readonly IMapper _mapper;
        private readonly CreateSalesCartsHandler _handler;

        public CreateSalesCartstHandlerTests()
        {
            _SalesCartsRepository = Substitute.For<ISalesCartsRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateSalesCartsHandler(_SalesCartsRepository, _mapper);
            Setup();
        }
       
        private void Setup()
        {
            _SalesCartsRepository.ClearReceivedCalls();
            _mapper.ClearReceivedCalls();
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
                Carts  = new DeveloperEvaluation.Domain.Entities.Carts
                {
                    Id = CreateSalesCartsHandlerTestData.GetId(),
                    CreatedAt = DateTime.Now,
                    UserId = command.UserId,
                    CartsProductsItems = command.Products.Select(p =>
                        new CartsProductsItems
                        { CartId = p.CartId, ProductId = p.ProductId, Quantity = p.Quantity }).ToList()
                }
            };

            var result = new CreateSalesCartsResult
            {
                SalesNumber = SalesCarts.SalesNumber ?? 0, // Handle nullable int
                CreatedAt = SalesCarts.CreatedAt,
                UserId = SalesCarts.UserId,
                TotalSalesAmount = SalesCarts.TotalSalesAmount,
                BranchId = SalesCarts.BranchId,
                Products = SalesCarts.Carts.CartsProductsItems.Select(p =>
                    new CartItemResult(p.CartId, p.ProductId,p.Quantity,p.TotalAmountItem,
                    p.UnitPrice,p.Discounts,p.Canceled)).ToList()
            };

            _mapper.Map<DeveloperEvaluation.Domain.Entities.SalesCarts>(command).Returns(SalesCarts);

            _mapper.Map<CreateSalesCartsResult>(SalesCarts).Returns(result);

            _SalesCartsRepository.CreateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.SalesCarts>(), Arg.Any<CancellationToken>())
                .Returns(SalesCarts);

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
